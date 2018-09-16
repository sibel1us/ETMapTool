using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects
{
    public enum ShaderReferenceStatus
    {
        [Display(Name = "Not Found", Description = "Shader not found in the same file.")]
        Unknown,

        [Display(Name = "Not Found", Description = "Shader not found.")]
        NotFound,

        [Display(
            Name = "Found in another file",
            Description = "Shader found, but in another .shader-file.")]
        FoundInAnotherFile,

        [Display(Name = "Found", Description = "Shader found in the same file.")]
        Found
    }

    [ClassDisplay(
        Name = "Shader Reference",
        Description = "")]
    public class ShaderReference
    {
        public string Name { get; set; }
        public Shader Reference { get; set; }

        public ShaderReferenceStatus Status
        {
            get
            {
                // TODO:
                return ShaderReferenceStatus.Unknown;
            }
        }
    }
}
