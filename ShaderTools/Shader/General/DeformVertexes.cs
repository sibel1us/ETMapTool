using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class DeformVertexes
    {
        [Display(Name = "")]
        public IDeformVertexes Deform { get; set; }
    }

    public interface IDeformVertexes { }

    public class DeformAutosprite : IDeformVertexes { }

    public class DeformAutosprite2 : IDeformVertexes { }

    public class DeformWave : IDeformVertexes
    {
        public int Division { get; set; }
        // TODO: waveform function
        public double Base { get; set; }
        public double Amplitude { get; set; }
        public double Phase { get; set; }
        public double Frequency { get; set; }
    }

    public class DeformNormal : IDeformVertexes
    {
        public int Division { get; set; }
        public double Base { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
    }

    public class DeformBulge : IDeformVertexes
    {
        public double S { get; set; }
        public double T { get; set; }
        public double Speed { get; set; }
    }

    public class DeformMove : IDeformVertexes
    {
        public double Base { get; set; }
        public double Amplitude { get; set; }
        public double Phase { get; set; }
        public double Frequency { get; set; }
    }
}
