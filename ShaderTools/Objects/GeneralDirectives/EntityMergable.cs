using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    [Format(Token.entityMergable)]
    [ClassDisplay(Name = "Entity Mergable", Description = "Allows sprite surfaces from multiple entities to be merged.")]
    public class EntityMergable : IGeneralDirective
    {
    }
}
