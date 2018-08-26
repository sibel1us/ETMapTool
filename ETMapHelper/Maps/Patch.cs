using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ETMapHelper.Maps
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Patch : BrushBase
    {
        public string Texture = null;
        public int[] Values = new int[5];
        public List<PatchComponent> Components;

        private string DebuggerDisplay
        {
            get
            {
                return $"Patch: {Id}, Cmp: {Components.Count}, Tex: {Texture}";
            }
        }

        public Patch()
        {
            Components = new List<PatchComponent>();
        }

        public override bool IsDetail()
        {
            return false;
        }

        public override bool IsPatch()
        {
            return true;
        }

        public string GetValues()
        {
            return $"( {Values[0]} {Values[1]} {Values[2]} {Values[3]} {Values[4]} )";
        }

        public void ParseTexture(string data)
        {
            Texture = data.Trim();
        }
    }
}
