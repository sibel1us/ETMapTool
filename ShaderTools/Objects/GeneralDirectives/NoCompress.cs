using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    [Format(Token.nocompress)]
    [ClassDisplay(Name = "No Compress", Description = "???")]
    public class NoCompress : IGeneralDirective
    {
    }

    [Format(Token.allowcompress)]
    [ClassDisplay(Name = "Allow Compress", Description = "???. Default value, specifying this is unnecessary. maybe?")]
    public class AllowCompress : IGeneralDirective
    {
    }
}
