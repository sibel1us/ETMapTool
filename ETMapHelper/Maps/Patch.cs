using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ETMapHelper.Maps
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Patch
    {
        private string DebuggerDisplay => $"Patch: {Id}, Parts: {Components.Count}, Tex: {Texture}";

        public int Id { get; set; }
        public string Texture { get; set; }
        public int[] Values { get; set; }
        public List<PatchComponent> Components { get; set; }

        public Patch(int id)
        {
            Id = id;
            Values = new int[5];
            Components = new List<PatchComponent>();
        }

        public string ValuesToString()
        {
            return $"( {Values[0]} {Values[1]} {Values[2]} {Values[3]} {Values[4]} )";
        }
    }
}
