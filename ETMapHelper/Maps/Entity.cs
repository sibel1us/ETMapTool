using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETMapHelper.Exceptions;
using System.Diagnostics;

namespace ETMapHelper.Maps
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Entity
    {
        public int Id { get; set; }
        public Point Origin { get; set; }
        public List<Brush> Brushes { get; set; }
        public List<Patch> Patches { get; set; }
        public Dictionary<string, string> Props { get; set; }
        public string ClassName
        {
            get => Props[Tokens.classname];
            set => Props[Tokens.classname] = value;
        }

        private string DebuggerDisplay =>
            $"Entity {Id} \"{ClassName}\" " + ((Origin == null) ? $"({Brushes.Count} brushes)" : $"({Origin.ToString()})");

        public Entity(int id)
        {
            Id = id;
            Origin = null;
            Brushes = new List<Brush>();
            Patches = new List<Patch>();
            Props = new Dictionary<string, string>();
        }
    }
}
