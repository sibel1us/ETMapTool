using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class GeneralDirectives
    {
        [Display(Name = "No PicMip", Description = "Removes picmip's effect on textures (blurring). Use on signs and such that should always stay legible.")]
        public bool NoPicmip { get; set; }

        [Display(Name = "No MipMaps", Description = "Always renders a high quality texture, even at longer distances.")]
        public bool NoMipmap { get; set; }

        [Display(Name = "Portal", Description = "")]
        public bool Portal { get; set; } // TODO: identical to sort portal

        [Display(Name = "Polygon Offset", Description = "Renders this texture slightly off the surface it's placed. Use on decals in conjunction with correct sort-value.")]
        public bool PolygonOffset { get; set; }

        [Display(Name = "Texture Culling", Description = "Affects which side on the brush the texture is rendered (outside, inside, both)")]
        public Cull Cull { get; set; }

        [Display(Name = "Texture Sorting", Description = "Affects the order the textures are drawn.")]
        public SortValue Sort { get; set; }

        [Display(Name = "Sky Parameters", Description = "Marks this as a sky shader, and affects how the skybox is drawn.")]
        public SkyParms Skyparms { get; set; }

        [Display(Name = "Fog Parameters", Description = "Marks this as a fog shader, and affects how the fog is drawn.")]
        public FogParms Fogparms { get; set; }

        [Display(Name = "Deform Vertexes", Description = "")]
        public DeformVertexes Deformvertexes { get; set; }

        public GeneralDirectives()
        {
            // Init booleans
            NoPicmip = false;
            NoMipmap = false;
            Portal = false;
            PolygonOffset = false;

            Cull = default(Cull); // Cull.back
                                  // TODO: sort

            // Init objects
            Skyparms = null;
            Fogparms = null;
            Deformvertexes = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Cull
    {
        [Display(Name = "Back", Description = "Default value, texture is only rendered on the outside.")]
        back = 0,

        [Display(Name = "Front", Description = "Inverted, texture is rendered on the inside only.")]
        front,

        [Display(Name = "None/Disable", Description = "Texture is rendered on both sides, useful for grates, water, energy fields, etc.")]
        none,

        // TODO
        disable = none
    }

    public enum SortValue
    {
        portal,
        sky,
        opaque,
        banner,
        underwater,
        additive,
        nearest
    }

    // TODO: parser
    public enum SortVal
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
