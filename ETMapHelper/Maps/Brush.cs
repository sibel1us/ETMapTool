using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ETMapHelper.Maps
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Brush : BrushBase
    {
        public List<Face> Faces;
        public Point Center
        {
            get
            {
                if (Faces.Count == 0) return null;

                int i = 0;
                double x = 0.0;
                double y = 0.0;
                double z = 0.0;

                foreach (var face in Faces)
                {
                    foreach (var vertex in face.Vertex)
                    {
                        i++;
                        x += vertex.X;
                        y += vertex.Y;
                        z += vertex.Z;
                    }
                }

                return new Point(x / i, y / i, z / i);
            }
        }

        private string DebuggerDisplay
        {
            get
            {
                return $"Brush: {Id}, Faces: {Faces.Count}, Location: {Center.ToStringInteger()}";
            }
        }

        public bool OnlySingleTexture(string texture)
        {
            foreach (var face in Faces)
            {
                if (face.Texture != texture) return false;
            }
            return true;
        }

        public Brush()
        {
            Faces = new List<Face>();
        }

        public void Add(Face face)
        {
            Faces.Add(face);
        }

        /// <summary>
        /// Even if only a single Face is detail, whole brush is considered detail by radiant.
        /// </summary>
        public bool Detail()
        {
            foreach (var face in Faces)
                if (face.Detail) return true;

            return false;
        }

        public void Write(StreamWriter writer)
        {
            if (Faces.Count < 4)
                throw new Exception($"Error: brush {Id} has only {Faces.Count} faces!");

            writer.WriteLine($"// brush {Id}");
            writer.WriteLine("{");
            foreach (var face in Faces) writer.WriteLine(face.GetData());
            writer.WriteLine("}");
        }

        public override bool IsPatch()
        {
            return false;
        }

        public override bool IsDetail()
        {
            return Detail();
        }
    }
}
