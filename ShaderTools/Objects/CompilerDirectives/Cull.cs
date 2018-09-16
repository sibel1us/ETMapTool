using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    [Format(Token.cull, "face")]
    [ClassDisplay(Name = "Cull", Description = "Determines which sides of the surface are rendered.")]
    public class Cull : ICompilerDirective
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
        backside = back,
        backsided = back,

        [Display(Name = "Front", Description = "Inverted, texture is rendered on the inside only.")]
        front,

        [Display(Name = "None", Description = "Texture is rendered on both sides, useful for grates, water, energy fields, etc.")]
        none,
        disable = none,
        twosided = none,
    }
}
