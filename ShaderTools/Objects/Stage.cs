using ShaderTools.Objects.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class Stage
    {
        /// <summary>
        /// 
        /// </summary>
        public ITexture Map { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IStageDirective> Directives { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        public Stage(ITexture map)
        {
            this.Map = map;
            this.Directives = new List<IStageDirective>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="directives"></param>
        public Stage(ITexture map, IEnumerable<IStageDirective> directives)
        {
            this.Map = map;
            this.Directives = directives.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="directives"></param>
        public Stage(ITexture map, params IStageDirective[] directives)
        {
            this.Map = map;
            this.Directives = directives.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Stage LightmapStage()
        {   // TODO: rgbGen identity
            return new Stage(new Lightmap(), null);
        }
    }
}
