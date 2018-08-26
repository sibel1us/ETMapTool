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
        public int Id { get; set; }
        public string Texture { get; set; }
        public int[] Values = new int[5];
        public List<PatchComponent> Components;

        private string DebuggerDisplay => $"Patch: {Id}, Cmp: {Components.Count}, Tex: {Texture}";

        public Patch(int id)
        {
            Id = id;
            Components = new List<PatchComponent>();
        }

        public override string ToString()
        {
            return $"( {Values[0]} {Values[1]} {Values[2]} {Values[3]} {Values[4]} )";
        }
    }
}
