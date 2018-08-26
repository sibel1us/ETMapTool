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
        public int Id;
        public Point Origin = null;
        public List<BrushBase> Brushes;
        public Dictionary<string, string> Props;

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
            Brushes = new List<BrushBase>();
            Props = new Dictionary<string, string>();
        }

        public void AddBrush(BrushBase brush)
        {
            Brushes.Add(brush);
        }

        public void ChangeSpawnFlags()
        {

        }

        public void AddProperty(string key, string value)
        {
            if (value == null)
            {
                if (!Props.ContainsKey(key))
                    throw new MissingPropertyException($"Trying to fetch missing key {key} from entity {Id}.");
            }

            // TODO: crash or just give warning?
            //if (Props.ContainsKey(key)) throw new ParseException($"Trying to add duplicate key {key} to entity {entity.Id}.");

            Props.Add(key, value);

            if (key == Tokens.Origin) Origin = ParseOrigin(value);
        }

        public Point ParseOrigin(string data)
        {
            var split = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var x = double.Parse(split[0]);
                var y = double.Parse(split[1]);
                var z = double.Parse(split[2]);

                return new Point(x, y, z);
            }
            catch
            {
                throw new MissingPropertyException($"Trying to parse broken origin \"{data}\".");
            }
        }


        public string Classname(string value = null)
        {
            if (value == null)
            {
                if (Props.ContainsKey(Tokens.classname))
                {
                    if (!string.IsNullOrEmpty(Props[Tokens.classname]))
                        return Props[Tokens.classname];
                }
                throw new MissingPropertyException($"Entity {Id} with no classname.");
            }

            if (!Props.ContainsKey(Tokens.classname)) Props.Add(Tokens.classname, value);
            else Props[Tokens.classname] = value;

            return value;
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
