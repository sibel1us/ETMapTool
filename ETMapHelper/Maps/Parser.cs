using ETMapHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertex = System.Tuple<ETMapHelper.Maps.Point, ETMapHelper.Maps.Point, ETMapHelper.Maps.Point>;

namespace ETMapHelper.Maps
{
    public static class Parser
    {
        public static double ParseDouble(string input)
        {
            return double.Parse(input, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses a point from input.
        /// </summary>
        /// <param name="input">"X Y Z"</param>
        /// <returns></returns>
        public static Point ParsePoint(string input)
        {
            var split = input.Split(Tokens.Space, StringSplitOptions.RemoveEmptyEntries);

            return new Point
            (
                double.Parse(split[0]),
                double.Parse(split[1]),
                double.Parse(split[2])
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">"( 0 0 0 ) ( 1 1 1 ) ( 2 2 2 ) common/caulk 0 0 0 0.5 0.5 0 4 0"</param>
        /// <returns></returns>
        public static Face ParseFace(string input)
        {
            Face face = new Face
            {
                Vertex = new Vertex(new Point(), new Point(), new Point())
            };

            var split = input.Split(Tokens.Space, StringSplitOptions.RemoveEmptyEntries);

            face.Vertex.Item1.X = ParseDouble(split[1]);
            face.Vertex.Item1.Y = ParseDouble(split[2]);
            face.Vertex.Item1.Z = ParseDouble(split[3]);
            face.Vertex.Item2.X = ParseDouble(split[6]);
            face.Vertex.Item2.Y = ParseDouble(split[7]);
            face.Vertex.Item2.Z = ParseDouble(split[8]);
            face.Vertex.Item3.X = ParseDouble(split[11]);
            face.Vertex.Item3.Y = ParseDouble(split[12]);
            face.Vertex.Item3.Z = ParseDouble(split[13]);
            face.Texture = split[15];
            face.TextureX = ParseDouble(split[16]);
            face.TextureY = ParseDouble(split[17]);
            face.Rotation = ParseDouble(split[18]);
            face.ScaleX = ParseDouble(split[19]);
            face.ScaleY = ParseDouble(split[20]);
            face.Detail = (ParseDouble(split[21]) == 134217728);

            return face;
        }

        /// <summary>
        /// Parses Entity or Brush id from a line.
        /// </summary>
        /// <param name="line">Example: "// entity 3"</param>
        /// <returns>Parsed id</returns>
        public static int ParseId(string line)
        {
            if (line.StartsWith(Tokens.Entity))
            {
                try
                {
                    return int.Parse(line.Substring(Tokens.Entity.Length).Trim());
                }
                catch
                {
                    throw new ParseException($"Couldn't parse entity id from line \"{line}\"");
                }
            }

            try
            {
                return int.Parse(line.Substring(Tokens.Brush.Length).Trim());
            }
            catch
            {
                throw new ParseException($"Couldn't parse brush id from line \"{line}\"");
            }
        }

        // TODO: rework this
        public static KeyValuePair<string, string> ParseKeyValuePair(string input)
        {
            string key = null;
            string value = null;

            var stringArray = input.ToLower().Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries);

            bool findingKey = true;

            foreach (var child in stringArray)
            {
                if (child.Trim().Length == 0) continue;

                if (findingKey)
                {
                    key = child;
                    findingKey = false;
                    continue;
                }

                value = child;
                break;
            }

            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));

            return new KeyValuePair<string, string>(key, value);
        }

        public static PatchComponent ParsePatchComponent(string input)
        {
            // TODO: figure out what happens here (obviously it works)
            var whole = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var split = new string[whole.Length - 2];
            Array.Copy(whole, 1, split, 0, split.Length);

            var primitiveCount = split.Length / 7;

            // Fill the component with new primitives
            PatchComponent component = new PatchComponent
            {
                Primitives = new List<PatchPrimitive>(Enumerable.Repeat(new PatchPrimitive(), primitiveCount))
            };


            for (int i = 0; i < split.Length; i++)
            {
                int n = i / 7;

                // first and last are ignored
                switch (i % 7)
                {
                    case 1:
                        component.Primitives[n].X = ParseDouble(split[i]); break;
                    case 2:
                        component.Primitives[n].Y = ParseDouble(split[i]); break;
                    case 3:
                        component.Primitives[n].Z = ParseDouble(split[i]); break;
                    case 4:
                        component.Primitives[n].Value1 = ParseDouble(split[i]); break;
                    case 5:
                        component.Primitives[n].Value2 = ParseDouble(split[i]); break;
                }
            }

            return component;
        }
    }
}
