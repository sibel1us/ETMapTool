using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    public class Sort : IGeneralDirective
    {

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
