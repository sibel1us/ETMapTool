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
        private string DebuggerDisplay => $"Brush: {Id}, Faces: {Faces.Count}";

        public int Id { get; set; }
        public List<Face> Faces { get; set; }

        public Brush()
        {
            Faces = new List<Face>();
        }

        public bool HasOnlyTexture(string texture)
        {
            foreach (var face in Faces)
            {
                if (face.Texture != texture) return false;
            }
            return true;
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
