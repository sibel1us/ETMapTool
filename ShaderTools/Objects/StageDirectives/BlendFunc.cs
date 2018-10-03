using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.StageDirectives
{
    public enum BlendModeSrc
    {
        GL_ONE = 0,
        GL_ZERO,
        GL_DST_COLOR,
        GL_ONE_MINUS_DST_COLOR,
        US_DST_COLOR,
        GL_SRC_ALPH,
        GL_ONE_MINUS_SRC_ALPHA,
        US_SRC_ALPHA,
        GL_DST_ALPHA,
        GL_ONE_MINUS_DST_ALPHA,
        US_DST_ALPHA,
        GL_SRC_ALPHA_SATURATE
    }

    public enum BlendModeDst
    {
        GL_ONE = 0,
        GL_ZERO,
        GL_SRC_ALPHA,
        GL_ONE_MINUS_SRC_ALPHA,
        GL_DST_ALPHA,
        GL_ONE_MINUS_DST_ALPHA,
        GL_SRC_COLOR,
        GL_ONE_MINUS_SRC_COLOR

    }

    public class BlendFunc
    {
        public BlendModeSrc Source { get; set; }
        public BlendModeDst Destination { get; set; }
    }
}
