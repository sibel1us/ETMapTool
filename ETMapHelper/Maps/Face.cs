using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Vertex = System.Tuple<ETMapHelper.Maps.Point, ETMapHelper.Maps.Point, ETMapHelper.Maps.Point>;

namespace ETMapHelper.Maps
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Face
    {
        private string DebuggerDisplay => $"Face: {Texture}";

        public Vertex Vertex { get; set; }
        public string Texture { get; set; }
        public double TextureX { get; set; }
        public double TextureY { get; set; }
        public double Rotation { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public bool Detail { get; set; }

        public override string ToString()
        {
            return $"{GetPoints()} {GetTex()} {GetTail()}";
        }

        public string GetPoints()
        {
            return $"{GetPoint(Vertex.Item1)} {GetPoint(Vertex.Item2)} {GetPoint(Vertex.Item3)}";
        }

        public string GetPoint(Point point)
        {
            return $"( {Get(point.X)} {Get(point.Y)} {Get(point.Z)} )";
        }

        public string GetTex()
        {
            return $"{Texture} {Get(TextureX)} {Get(TextureY)} {Get(Rotation)} {Get(ScaleX, true)} {Get(ScaleY, true)}";
        }

        /// <summary>
        /// Gets the last 3 numbers in the line.
        /// </summary>
        /// <returns></returns>
        public string GetTail()
        {
            return (this.Detail)
                    ? "134217728 0 0"
                    : "0 4 0";
        }

        private string Get(double value, bool decimals = false)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            if (decimals || value % 1 != 0) return $"{value.ToString("0.000000", nfi)}";
            return $"{value.ToString(nfi)}";
        }
    }
}
