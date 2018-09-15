using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Helpers
{
    public static class TokenHelper
    {
        /// <summary>
        /// Gets format attributes for the object.
        /// </summary>
        /// <exception cref="NullReferenceException"/>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static FormatAttribute GetFormatAttribute(object obj)
        {
            return GetFormatAttribute(obj.GetType());
        }

        /// <summary>
        /// Gets format attributes for the object.
        /// </summary>
        /// <exception cref="NullReferenceException"/>
        /// <param name="surfaceparm"></param>
        /// <returns></returns>
        public static FormatAttribute GetFormatAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(FormatAttribute), false);
            return (FormatAttribute)attributes[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetArgument(object obj)
        {
            return TokenHelper.GetFormatAttribute(obj.GetType()).Argument;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetArgument(Type type)
        {
            return TokenHelper.GetFormatAttribute(type).Argument;
        }

        /// <summary>
        /// Returns the full argument name and parameters. Example: "cull &lt;face&gt;"
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetFormat(object obj)
        {
            return TokenHelper.GetFormat(obj.GetType());
        }

        /// <summary>
        /// Returns the full argument name and parameters. Example: "cull &lt;face&gt;"
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFormat(Type type)
        {
            FormatAttribute attr = TokenHelper.GetFormatAttribute(type);

            if (attr.Parameters?.Any() == true)
            {
                string parameters = string.Join(" ", attr.Parameters.Select(s => $"<{s}>"));
                return $"{attr.Argument} {parameters}";
            }
            else
            {
                return attr.Argument;
            }
        }
    }
}
