using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Exceptions;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ShaderTools.Objects;
using ShaderTools.Objects.GeneralDirectives;

namespace ShaderTools.Utilities
{
    public enum TextureStatus
    {
        [Display(Name = "Unknown", Description = "Game path has not been specified.")]
        Unknown,

        [Display(Name = "Missing", Description = "Texture not found.")]
        Missing,

        [Display(Name = "Found multiple", Description = "Multiple textures with different types exist with the same name.")]
        DuplicateExtension,

        [Display(Name = "Found (wrong extension)", Description = "Texture found, but with different extension.")]
        WrongExtension,

        [Display(Name = "Found", Description = "Texture found.")]
        Ok,
    }

    public enum ValidationLevel
    {
        None = 0,
        Superficial,
        Warning,
        Critical
    }

    public class ShaderValidation
    {
        public ValidationLevel Level { get; set; }
        public string Message { get; set; }
        public List<Type> Targets { get; set; }
        public List<Surfaceparms> Surfparms { get; set; }
    }

    public static class ShaderValidator
    {
        private static Regex _nameRegex = new Regex(Token.ShaderNameRegex);

        /// <summary>
        /// Validate shader name
        /// </summary>
        /// <param name="shader"></param>
        public static void ValidateName(this Shader shader)
        {
            ShaderValidator.ValidateName(shader.Name);
        }

        /// <summary>
        /// Validate shader name
        /// </summary>
        /// <param name="name"></param>
        public static bool ValidateName(string name) => _nameRegex.IsMatch(name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <returns></returns>
        public static List<ShaderValidation> ValidateGeneralDirectives(this Shader shader)
        {
            // Init validation result list
            var list = new List<ShaderValidation>();

            // Don't bother with calculations if there are no general directives
            if (!shader.GeneralDirectives.Any())
            {
                return list;
            }

            // Portal
            if (shader.GeneralDirectives.Any(d => (d as Sort)?.Value == SortValue.portal)
                && shader.GeneralDirectives.Any(d => d is Portal))
            {
                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Superficial,
                    Message = "Using both portal and sort portal is unnecessary..",
                    Targets = { typeof(Sort), typeof(Portal) }
                });
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <returns></returns>
        public static List<ShaderValidation> ValidateSurfaceparms(this Shader shader)
        {
            // Init validation result list
            var list = new List<ShaderValidation>();

            // Don't bother with calculations if there are no surfaceparms
            if (!shader.Surfparms.Any())
            {
                return list;
            }

            // Init dictionary of shader's surfaceparms, and the flags for each surfaceparm
            Dictionary<Surfaceparms, SurfparmFlags> parms =
                shader.Surfparms.ToDictionary(sp => sp, sp => SurfaceparmHelper.GetFlags(sp));

            // Get unused surfaceparms
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Unused)))
            {
                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Superficial,
                    Message = $"Surfaceparm {kvp.Key} is unused.",
                    Surfparms = { kvp.Key }
                });
            }

            // Get dangerous surfaceparms such as structural, detail and areaportal
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Avoid)))
            {
                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Surfaceparm {kvp.Key} should be avoided unless you know exactly what you are doing.",
                    Surfparms = { kvp.Key }
                });
            }

            // Get surfaceparms that should never be used (origin)
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.DoNotUse)))
            {
                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Critical,
                    Message = $"Surfaceparm {kvp.Key} should never be used. Use the common.shader-implementation.",
                    Surfparms = { kvp.Key }
                });
            }

            // Check for multiple footstep surfaceparms
            if (parms.Count(kvp => kvp.Value.HasFlag(SurfparmFlags.Footsteps)) > 1)
            {
                List<Surfaceparms> footsteps = parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Footsteps))
                                                    .Select(kvp => kvp.Key)
                                                    .ToList();

                string joined = string.Join(", ", parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Footsteps)));

                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Shader has multiple footstep-surfaceparms ({joined}).",
                    Surfparms = footsteps
                });
            }

            // Check for multiple liquid surfaceparms
            if (parms.Count(kvp => kvp.Value.HasFlag(SurfparmFlags.Liquid)) > 1)
            {
                List<Surfaceparms> liquids = parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Liquid))
                                                  .Select(kvp => kvp.Key)
                                                  .ToList();

                string joined = string.Join(", ", liquids);

                list.Add(new ShaderValidation
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Shader has multiple liquid surfaceparms ({joined}).",
                    Surfparms = liquids
                });
            }

            // Check for surfaceparms that should be used together (ie. sky and noimpact)
            foreach (var kvp in parms)
            {
                // TODO: verify that all UseWith-attributes are actually required
                Surfaceparms[] useWith = SurfaceparmHelper.GetSurfaceparmAttributes(kvp.Key).UseWith;

                if (useWith?.Any() == true)
                {
                    if (useWith.Any(sp => !parms.ContainsKey(sp)))
                    {
                        string joined = string.Join(", ", useWith);

                        list.Add(new ShaderValidation
                        {
                            Level = ValidationLevel.Warning,
                            Message = $"Surfaceparm {kvp.Key} should be used with the following surfaceparms: {joined}.",
                            Surfparms = { kvp.Key }, // Add only key, as the others might all be missing
                        });
                    }
                }
            }

            // Check for list of surfaceparms that are useless on volume-marked surfaces
            if (parms.Any(kvp => kvp.Value.HasFlag(SurfparmFlags.Volume)))
            {
                foreach (var useless in SurfaceparmHelper.UselessWithVolume())
                {
                    list.Add(new ShaderValidation
                    {
                        Level = ValidationLevel.Superficial,
                        Message = $"Surfaceparm {useless} is useless on shaders that represent volumes.",
                        Surfparms = { useless }
                    });
                }
            }

            // Return the validation results ordered from most to least critical
            return list.OrderByDescending(x => x.Level).ToList();
        }
    }
}
