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
    public class Brush
    {
        public int Id { get; set; }
        public List<Face> Faces { get; set; }

        public Point Center
        {
            get
            {
                if (Faces.Count == 0)
                    throw new ArgumentException("Brush with no faces", nameof(this.Faces));

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

        public bool HasOnlyTexture(string texture)
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

        /// <summary>
        /// GtkRadiant considers brushes as Detail if even a single face is Detail.
        /// </summary>
        public bool Detail
        {
            get
            {
                return Faces.Any(f => f.Detail);
            }
        }
    }
}
