using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.StageDirectives
{
    public enum TcModFunc
    {
        swap,
        turb,
        scale,
        scroll,
        stretch,
        transform,
        rotate,
        entityTranslate,
    }

    public class TcMod : IStageDirective
    {
    }
}
