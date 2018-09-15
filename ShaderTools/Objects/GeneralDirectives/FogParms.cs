using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    [Format(Token.fogparms, "fog color", "distance to opaque")]
    public class FogParms : IGeneralDirective
    {
        /// <summary>
        /// Fog opaque color.
        /// </summary>
        public RGBColor Color { get; set; }

        /// <summary>
        /// Distance to opaque.
        /// </summary>
        [Display(Name = "Opacity", Description = "Distance (in units) to opaque.")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive.")]
        public int Opacity { get; set; }
    }
}
