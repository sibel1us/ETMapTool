using ShaderTools.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Attributes
{
    /// <summary>
    /// Extra attributes for surfaceparms.
    /// </summary>
    public class SurfaceparmAttribute : Attribute
    {
        public SurfparmFlags Flags { get; set; }
        public Surfaceparms[] UseWith { get; set; }

        public SurfaceparmAttribute() { }

        public SurfaceparmAttribute(SurfparmFlags Flags)
        {
            this.Flags = Flags;
        }
    }

    [Flags]
    public enum SurfparmFlags
    {
        [Display(Name = "NULL", Description = "")]
        None = 0,

        [Display(Name = "Volume", Description = "Affects how the volume of the brush interacts.")]
        Volume = 1 << 0,

        [Display(Name = "Footsteps", Description = "Affects the footsteps on the surface.")]
        Footsteps = 1 << 1,

        [Display(Name = "ETJump", Description = "Only works on ETJump-mod.")]
        ETJump = 1 << 2,

        [Display(Name = "Affects Light Compile", Description = "Changes the way the surface affects light compile.")]
        AffectsLight = 1 << 3,

        [Display(Name = "Affects VIS Compile", Description = "Changes the way the surface affects VIS compile.")]
        AffectsVis = 1 << 4,

        [Display(Name = "Obsolete", Description = "This surfaceparm is defined in code, but doesn't do anything.")]
        Unused = 1 << 5,

        [Display(Name = "Avoid Using", Description = "Avoid using this surfaceparm unless you know what you are doing.")]
        Avoid = 1 << 6,

        [Display(Name = "Do Not Use", Description = "Do not use this surfaceparm.")]
        DoNotUse = 1 << 7,

        [Display(Name = "Liquid", Description = "This surfaceparm marks liquid brushes.")]
        Liquid = 1 << 8
    }
}
