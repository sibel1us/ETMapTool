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
        public string Classname { get; set; }
        public Point Origin { get; set; }
        public List<Brush> Brushes { get; set; }
        public List<Patch> Patches { get; set; }
        public Dictionary<string, string> Props { get; set; }

        private string DebuggerDisplay
        {
            get
            {
                return $"Entity {Id} \"{Props["classname"]}\" " + ((Origin == null) ? $"({Brushes.Count} brushes)" : $"({Origin.ToString()})");
            }
        }

        public Entity()
        {
            Origin = null;
            Brushes = new List<Brush>();
            Patches = new List<Patch>();
            Props = new Dictionary<string, string>();
        }

        public Point ParseOrigin(string input)
        {
            var split = input.Split(Tokens.Space, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var x = double.Parse(split[0]);
                var y = double.Parse(split[1]);
                var z = double.Parse(split[2]);

                return new Point(x, y, z);
            }
            catch
            {
                throw new MissingPropertyException($"Trying to parse broken origin \"{input}\".");
            }
        }

        public void Write(StreamWriter writer)
        {
            if (!Props.ContainsKey(Tokens.classname))
                throw new Exception($"Entity {Id} with no classname.");

            if (Origin == null && Brushes.Count == 0)
                throw new Exception($"Entity {Id} with no content.");



        }
    }
}
