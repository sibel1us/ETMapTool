using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public abstract class BrushBase
    {
        public int Id;
        
        public abstract bool IsPatch();
        public abstract bool IsDetail();
    }
}
