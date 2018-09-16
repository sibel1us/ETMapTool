using ShaderTools.Objects.CompilerDirectives;
using ShaderTools.Objects.GeneralDirectives;
using ShaderTools.Objects.StageDirectives;
using ShaderTools.Objects.Textures;
using ShaderTools.Utilities;
using ShaderTools.Utilities.Exceptions;
using ShaderTools.Utilities.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects
{
    public class Shader
    {
        public string Name { get; set; }

        public List<IGeneralDirective> GeneralDirectives { get; set; }
        public HashSet<Surfaceparms> Surfparms { get; set; }
        public List<Stage> Stages { get; set; }

        /// <summary>
        /// Is true if the shader has a <see cref="Lightmap"/>-stage with <see cref="RGBGen"/> with <see cref="RGBGenType.identity"/>.
        /// </summary>
        public bool HasLightmapStage
        {
            get
            {
                return Stages.Any(stage
                    => stage.Map is Lightmap
                    && stage.Directives.Any(d => (d as RGBGen)?.Type == RGBGenType.identity));
            }
        }

        /// <summary>
        /// Initialize a new shader with a known game folder.
        /// </summary>
        public Shader(string name)
        {
            Logger.Debug($"Initialized new shader '{name}'");

            // Initialize variables
            this.Name = name;
            this.Surfparms = new HashSet<Surfaceparms>();
            this.GeneralDirectives = new List<IGeneralDirective>();
            this.Stages = new List<Stage>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ShaderValidation AddGeneralDirective(IGeneralDirective value)
        {
            if (value == null)
            {
                throw new ShaderFileStructureException("Invalid general directive");
            }

            string errorMessage = null;

            if (this.GeneralDirectives.Any(g => g.GetType() == value.GetType() /*TODO: sun*/))
            {
                errorMessage = "Duplicate general directive";
            }
            else if (value is IDeformVertexes && GeneralDirectives.Any(g => g is IDeformVertexes))
            {
                errorMessage = "Duplicate deformVertexes-directive";
            }

            errorMessage = errorMessage + "";

            Logger.Debug($"Added general directive {value.GetType()} to shader.");
            this.GeneralDirectives.Add(value);
            return null; // TODO
        }
    }
}
