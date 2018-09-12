using ShaderTools.Shaders;
using ShaderTools.Shaders.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.IO
{
    public class ShaderWriter
    {
        private static readonly NumberFormatInfo nfi;

        static ShaderWriter()
        {
            nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
            };
        }

        /// <summary>
        /// Formats a double to 0.0 or 0.NNNN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Format(double value)
        {
            if (value % 1 != 0)
                return value.ToString("0.0", nfi);

            return value.ToString(nfi);
        }

        private StringWriter sw;

        private string Indent { get; set; }

        private int _indentDepth;
        public int IndentDepth
        {
            get => _indentDepth;
            set
            {
                _indentDepth = value;

                // Indent with spaces or tabs depending on settings.
                if (Properties.Settings.Default.IndentTabs)
                {
                    Indent = new string('\t', _indentDepth);
                }
                else
                {
                    Indent = new string(' ', _indentDepth * Properties.Settings.Default.IndentSpaces);
                }
            }
        }

        public ShaderWriter()
        {
            IndentDepth = 0;
            sw = new StringWriter();

        }


        public void Write(IGeneralDirective general)
        {
        }

        public void Write(SkyParms skyParms)
        {
            if (skyParms != null)
            {
                Write($"skyparms {skyParms.Farbox} {skyParms.CloudHeight} {skyParms.Nearbox}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fogParms"></param>
        public void Write(FogParms fogParms)
        {
            if (fogParms != null)
            {
                Write($"fogparms {fogParms.Color.ToString(true)} {fogParms.Opacity}");
            }
        }

        public void Write(IDeformVertexes deformVertexes)
        {
            if (deformVertexes != null)
            {

            }
        }

        public void Write(string text)
        {
            // Writing separately avoids string concatenation, and is consistently 10%+ faster
            sw.Write(Indent);
            sw.WriteLine(text);
        }
    }
}
