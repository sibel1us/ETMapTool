using ShaderTools.Shaders.Exceptions;
using ShaderTools.Shaders.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders
{
    public class Shader
    {
        public string ETFolder { get; set; } = null;

        public string Name { get; set; }

        public List<IGeneralDirective> GeneralDirectives { get; set; }
        public HashSet<Surfaceparms> Surfparms { get; set; }
        // STAGE

        /// <summary>
        /// Initialize a new shader with unknown shader-file and game-locations.
        /// </summary>
        public Shader() : this("", null) { }

        /// <summary>
        /// Initialize a new shader with unknown game folder.
        /// </summary>
        /// <param name="fullPath"></param>
        public Shader(string name) : this(name, null) { }

        /// <summary>
        /// Initialize a new shader with a known game folder.
        /// </summary>
        public Shader(string name, string gamePath)
        {
            Logger.Debug($"Initialized new shader '{name}'");

            ETFolder = gamePath;

            // Initialize variables
            Name = name;
            Surfparms = new HashSet<Surfaceparms>();
            GeneralDirectives = new List<IGeneralDirective>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string AddGeneralDirective(IGeneralDirective value)
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

            Logger.Debug($"Added general directive {value.GetType()} to shader.");
            this.GeneralDirectives.Add(value);
            return errorMessage;
        }
    }
}
