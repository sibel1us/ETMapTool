using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools
{
    public static class GeneralExtensions
    {
        // TODO: settings to change decimal number amount
        private static readonly NumberFormatInfo nfi = new NumberFormatInfo
        {
            NumberDecimalSeparator = "."
        };

        /// <summary>
        /// <see cref="double.ToString(IFormatProvider)"/> implementation that forces a dot decimal separator.
        /// </summary>
        /// <param name="dbl"></param>
        /// <returns></returns>
        public static string ToStr(this double dbl)
        {
            return dbl.ToString(nfi);
        }
    }
}
