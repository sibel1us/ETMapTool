using ShaderTools.Shaders.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    [Format(Token.entityMergable)]
    [ClassDisplay(Name = "Entity Mergable", Description = "Allows sprite surfaces from multiple entities to be merged.")]
    public class EntityMergable : IGeneralDirective
    {
    }
}
