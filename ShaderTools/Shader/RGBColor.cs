﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShaderTools.Shader
{
    public class RGBColor
    {
        [Display(Name = "Blue")]
        [Range(0, 1, ErrorMessage = "Only values between 0 and 1 are valid")]
        public double Red { get; set; }

        [Display(Name = "Green")]
        [Range(0, 1, ErrorMessage = "Only values between 0 and 1 are valid")]
        public double Green { get; set; }

        [Display(Name = "Blue")]
        [Range(0, 1, ErrorMessage = "Only values between 0 and 1 are valid")]
        public double Blue { get; set; }

        public RGBColor()
        {
            Red = 1.0;
            Green = 1.0;
            Blue = 1.0;
        }

        public RGBColor(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static RGBColor NonNormalized(int red, int green, int blue)
        {
            if (red < 0 || red > 255) throw new ArgumentOutOfRangeException(nameof(red));
            if (green < 0 || green > 255) throw new ArgumentOutOfRangeException(nameof(green));
            if (blue < 0 || blue > 255) throw new ArgumentOutOfRangeException(nameof(blue));

            return new RGBColor
            (
                ((double)red) / 255d,
                ((double)green) / 255d,
                ((double)blue) / 255d
            );
        }
    }
}