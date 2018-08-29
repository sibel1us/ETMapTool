using ShaderTools.Shader.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader
{
    public class Writer
    {
        #region Static Stuff
        private static readonly NumberFormatInfo nfi;

        static Writer()
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
        #endregion

        #region Non-Static stuff
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





        public Writer()
        {
            IndentDepth = 0;
            sw = new StringWriter();

        }


        public void Write(GeneralDirectives general)
        {
            if (general.NoPicmip)
                Write("nopicmip");

            if (general.NoMipmap)
                Write("nomipmap");

            if (general.Cull != default(Cull))
                Write($"cull {general.Cull}");

            Write(general.Skyparms);
            Write(general.Fogparms);
            Write(general.Deformvertexes);
        }

        public void Write(SkyParms skyParms)
        {
            if (skyParms != null)
            {
                Write($"skyparms {skyParms.Farbox.ToString(false)} {skyParms.CloudHeight} {skyParms.Nearbox.ToString(false)}");
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

        public void Write(DeformVertexes deformVertexes)
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

        #endregion
    }
}
