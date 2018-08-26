using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public class PatchComponent
    {
        public PatchPrimitive[] Primitives;

        public PatchComponent(string data)
        {
            var whole = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var split = new string[whole.Length - 2];
            Array.Copy(whole, 1, split, 0, split.Length);

            var primitiveCount = split.Length / 7;

            Primitives = new PatchPrimitive[primitiveCount];

            for (int i = 0; i < primitiveCount; i++)
            {
                Primitives[i] = new PatchPrimitive();
            }

            for (int i = 0; i < split.Length; i++)
            {
                int n = i / 7;
                    
                switch (i % 7)
                {
                    default:
                        break;
                    case 1:
                        Primitives[n].X = ParseDecimal(split[i]); break;
                    case 2:
                        Primitives[n].Y = ParseDecimal(split[i]); break;
                    case 3:
                        Primitives[n].Z = ParseDecimal(split[i]); break;
                    case 4:
                        Primitives[n].Value1 = ParseDecimal(split[i]); break;
                    case 5:
                        Primitives[n].Value2 = ParseDecimal(split[i]); break;
                }
            }
        }

        public double ParseDecimal(string input)
        {
            return double.Parse(input, CultureInfo.InvariantCulture);
        }

        public string GetData()
        {
            var sb = new StringBuilder();

            sb.Append("( ");
            foreach (var primitive in Primitives) sb.Append($"{primitive.GetData()} ");
            sb.Append(")");

            return sb.ToString();
        }
    }
}
