using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class FogParms
    {
        public RGBColor Color { get; set; }

        [Display(Name = "Blue")]
        [Range(0, 1, ErrorMessage = "Only values between 0 and 1 are valid")]
        public double Opacity { get; set; }
    }
}
