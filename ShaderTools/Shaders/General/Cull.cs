using ShaderTools.Shaders.Attributes;
using ShaderTools.Shaders.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    [Format(Token.cull, "face")]
    [ClassDisplay(Name = "Cull", Description = "Determines which sides of the surface are rendered.")]
    public class Cull : IGeneralDirective
    {
        public CullValue Value { get; set; }

        public Cull(CullValue value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum CullValue
    {
        [Display(Name = "Back", Description = "Default value, texture is only rendered on the outside.")]
        back = 0,

        [Display(Name = "Front", Description = "Inverted, texture is rendered on the inside only.")]
        front,

        [Display(Name = "None", Description = "Texture is rendered on both sides, useful for grates, water, energy fields, etc.")]
        none,

        [Display(Name = "Disable", Description = "Texture is rendered on both sides, useful for grates, water, energy fields, etc.")]
        disable
    }
}
