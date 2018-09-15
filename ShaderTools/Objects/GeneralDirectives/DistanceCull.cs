using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    public class DistanceCull : IGeneralDirective
    {
        public double OpaqueDistance { get; set; }
        public double TransparentDistance { get; set; }
        public double AlphaThreshold { get; set; }
    }
}
