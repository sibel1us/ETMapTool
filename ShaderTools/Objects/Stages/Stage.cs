using ShaderTools.Shaders.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
    /// <summary>
    /// 
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// 
        /// </summary>
        public ITexture Texture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IStageDirective> Directives { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        public Stage(ITexture texture)
        {
            this.Texture = texture;
            this.Directives = new List<IStageDirective>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="directives"></param>
        public Stage(ITexture texture, IEnumerable<IStageDirective> directives)
        {
            this.Texture = texture;
            this.Directives = directives.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="directives"></param>
        public Stage(ITexture texture, params IStageDirective[] directives)
        {
            this.Texture = texture;
            this.Directives = directives.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Stage LightmapStage()
        {   // TODO: rgbGen identity
            return new Stage(new LightMap(), null);
        }
    }
}
