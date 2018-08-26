using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ETMapHelper.Maps
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Face
    {
        public Point[] Vertex = new Point[3];

        public string Texture { get; set; }
        double TextureX { get; set; }
        double TextureY { get; set; }
        double Rotation { get; set; }
        double ScaleX { get; set; }
        double ScaleY { get; set; }
        public bool Detail { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                return $"Face: {Texture}";
            }
        }


        public Face()
        {
            
        }

        public Face(string line)
        {
            var split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Vertex[0] = new Point();
            Vertex[1] = new Point();
            Vertex[2] = new Point();

            for (int i = 0; i < split.Length; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 1:
                        Vertex[0].X = ParseDecimal(split[i]); break;
                    case 2:
                        Vertex[0].Y = ParseDecimal(split[i]); break;
                    case 3:
                        Vertex[0].Z = ParseDecimal(split[i]); break;
                    case 6:
                        Vertex[1].X = ParseDecimal(split[i]); break;
                    case 7:
                        Vertex[1].Y = ParseDecimal(split[i]); break;
                    case 8:
                        Vertex[1].Z = ParseDecimal(split[i]); break;
                    case 11:
                        Vertex[2].X = ParseDecimal(split[i]); break;
                    case 12:
                        Vertex[2].Y = ParseDecimal(split[i]); break;
                    case 13:
                        Vertex[2].Z = ParseDecimal(split[i]); break;
                    case 15:
                        Texture = split[i].Trim(); break;
                    case 16:
                        TextureX = ParseDecimal(split[i]); break;
                    case 17:
                        TextureY = ParseDecimal(split[i]); break;
                    case 18:
                        Rotation = ParseDecimal(split[i]); break;
                    case 19:
                        ScaleX = ParseDecimal(split[i]); break;
                    case 20:
                        ScaleY = ParseDecimal(split[i]); break;
                    case 21:
                        Detail = (ParseDecimal(split[i]) == 134217728); break;
                }
            }
        }

        public double ParseDecimal(string input)
        {
            return double.Parse(input, CultureInfo.InvariantCulture);
        }

        public string GetData()
        {
            return $"{GetPoints()} {GetTex()} {GetTail()}";
        }

        public string GetPoints()
        {
            return $"{GetPoint(0)} {GetPoint(1)} {GetPoint(2)}";
        }

        public string GetPoint(int i)
        {
            return $"( {Get(Vertex[i].X)} {Get(Vertex[i].Y)} {Get(Vertex[i].Z)} )";
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
