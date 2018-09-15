using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    [ClassDisplay(Name = "Tess Size", Description = "")]
    public class TessSize : IStageDirective
    {
        [Display(Name = "Value")]
        public int Value { get; set; }

        public TessSize(int value)
        {

        }
    }
}
