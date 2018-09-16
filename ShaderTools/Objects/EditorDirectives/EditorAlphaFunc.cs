using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.EditorDirectives
{
    public class EditorAlphaFunc : IEditorDirective
    {
        public enum EditorAlphaFunction
        {
            [Display(Name ="Greater than")]
            greater,

            [Display(Name = "Less than")]
            less,

            [Display(Name = "Greater or equal to")]
            gequal,
        }

        public EditorAlphaFunction Function { get; set; }
        public double Value { get; set; }
    }
}
