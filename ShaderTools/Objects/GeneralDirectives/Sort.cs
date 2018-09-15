using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    /// <summary>
    /// tc_shader.c line 1265
    /// </summary>
    public enum SortValue
    {
        [Display(Name = "Portal", Description = "")]
        portal,

        [Display(Name = "Sky", Description = "")]
        sky,

        [Display(Name = "Opaque", Description = "")]
        opaque,

        [Display(Name = "Decal", Description = "")]
        decal,

        [Display(Name = "See-through", Description = "")]
        seeThrough,

        [Display(Name = "Banner", Description = "")]
        banner,

        [Display(Name = "Additive", Description = "")]
        additive,

        [Display(Name = "Nearest", Description = "")]
        nearest,

        [Display(Name = "Underwater", Description = "")]
        underwater
    }

    /// <summary>
    /// Applied 
    /// </summary>
    [ClassDisplay(Name = "Sort", Description = "Applied automatically by stages. Only use if you know what you are doing.")]
    public class Sort : IGeneralDirective
    {
        public SortValue Value { get; set; }

        public Sort(SortValue value)
        {
            Value = value;
        }

        // from source code, just for reference
        private enum SortVal
        {
            SS_BAD,
            SS_PORTAL,          // mirrors, portals, viewscreens
            SS_ENVIRONMENT,     // sky box
            SS_OPAQUE,          // opaque
            SS_DECAL,           // scorch marks, etc.
            SS_SEE_THROUGH,     // ladders, grates, grills that may have small blended edges in addition to alpha test
            SS_BANNER,
            SS_FOG,
            SS_UNDERWATER,      // for items that should be drawn in front of the water plane
            SS_BLEND0,          // regular transparency and filters
            SS_BLEND1,          // generally only used for additive type effects
            SS_BLEND2,
            SS_BLEND3,
            SS_BLEND6,
            SS_STENCIL_SHADOW,
            SS_ALMOST_NEAREST,  // gun smoke puffs
            SS_NEAREST          // blood blobs
        }
    }
}
