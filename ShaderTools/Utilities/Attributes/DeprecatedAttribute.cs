using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Attributes
{
    /// <summary>
    /// This object is deprecated, and shouldn't be used.
    /// </summary>
    public class DeprecatedAttribute : Attribute
    {
        public string Message { get; set; }

        public DeprecatedAttribute()
        {

        }

        public DeprecatedAttribute(string message)
        {
            this.Message = message;
        }
    }
}
