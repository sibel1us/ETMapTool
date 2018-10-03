using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    [Deprecated]
    [ClassDisplay(Name = "Texture Size", Description = "")]
    [Format(Token.q3map_texturesize, "x", "y")]
    public class TextureSize
    {
        public double X { get; set; }
        public double Y { get; set; }

        public TextureSize(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
