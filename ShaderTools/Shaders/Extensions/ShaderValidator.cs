using ShaderTools.Shaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Extensions
{
    public enum ValidationLevel
    {
        None = 0,
        Superficial,
        Warning,
        Critical
    }

    public class ValidationResult
    {
        public ValidationLevel Level { get; set; }
        public string Message { get; set; }
    }

    public static class ShaderValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shader"></param>
        /// <returns></returns>
        public static List<ValidationResult> ValidateSurfaceparms(this Shader shader)
        {
            // Init validation result list
            var list = new List<ValidationResult>();

            // Init dictionary of shader's surfaceparms, and the flags for each surfaceparm
            Dictionary<Surfaceparms, SurfparmFlags> parms = shader.Surfparms
                                                                  .ToDictionary(sp => sp, sp => SurfaceparmHelper.GetFlags(sp));

            // Don't bother with calculations if there are no surfaceparms
            if (!shader.Surfparms.Any())
            {
                return list;
            }

            // Get unused surfaceparms
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Unused)))
            {
                list.Add(new ValidationResult
                {
                    Level = ValidationLevel.Superficial,
                    Message = $"Surfaceparm {kvp.Key} is unused."
                });
            }

            // Get dangerous surfaceparms such as structural, detail and areaportal
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Avoid)))
            {
                list.Add(new ValidationResult
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Surfaceparm {kvp.Key} should be avoided unless you know exactly what you are doing."
                });
            }

            // Get surfaceparms that should never be used (origin)
            foreach (var kvp in parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.DoNotUse)))
            {
                list.Add(new ValidationResult
                {
                    Level = ValidationLevel.Critical,
                    Message = $"Surfaceparm {kvp.Key} should never be used. Use the common.shader-implementation."
                });
            }

            // Check for multiple footstep surfaceparms
            if (parms.Count(kvp => kvp.Value.HasFlag(SurfparmFlags.Footsteps)) > 1)
            {
                string joined = string.Join(", ", parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Footsteps)));

                list.Add(new ValidationResult
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Shader has multiple footstep-surfaceparms ({joined})."
                });
            }

            // Check for multiple liquid surfaceparms
            if (parms.Count(kvp => kvp.Value.HasFlag(SurfparmFlags.Liquid)) > 1)
            {
                string joined = string.Join(", ", parms.Where(kvp => kvp.Value.HasFlag(SurfparmFlags.Liquid)));

                list.Add(new ValidationResult
                {
                    Level = ValidationLevel.Warning,
                    Message = $"Shader has multiple liquid-surfaceparms ({joined})."
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

                        list.Add(new ValidationResult
                        {
                            Level = ValidationLevel.Warning,
                            Message = $"Surfaceparm {kvp.Key} should be used with the following surfaceparms: {joined}."
                        });
                    }
                }
            }

            // Check for list of surfaceparms that are useless on volume-marked surfaces
            if (parms.Any(kvp => kvp.Value.HasFlag(SurfparmFlags.Volume)))
            {
                foreach (var useless in SurfaceparmHelper.UselessWithVolume())
                {
                    list.Add(new ValidationResult
                    {
                        Level = ValidationLevel.Superficial,
                        Message = $"Surfaceparm {useless} is useless on shaders that represent volumes."
                    });
                }
            }

            // Return the validation results ordered from most to least critical
            return list.OrderByDescending(x => x.Level).ToList();
        }
    }
}
