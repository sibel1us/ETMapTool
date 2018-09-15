using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Attributes
{
    /// <summary>
    /// Extra attributes for surfaceparms.
    /// </summary>
    public class FormatAttribute : Attribute
    {
        public string Argument { get; set; }
        public List<string> Parameters { get; set; }

        public FormatAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Argument"></param>
        /// <param name="Parameters"></param>
        public FormatAttribute(string Argument, params string[] Parameters)
        {
            this.Argument = Argument;
            this.Parameters = Parameters.ToList();
        }
    }
}
