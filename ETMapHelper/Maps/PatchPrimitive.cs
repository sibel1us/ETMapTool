using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public class PatchPrimitive
    {
        private readonly NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }

        public PatchPrimitive()
        {

        }

        public PatchPrimitive(double x, double y, double z, double val1, double val2)
        {
            X = x;
            Y = y;
            Z = z;
            Value1 = val1;
            Value2 = val2;
        }

        public override string ToString()
        {
            return $"( {Get(X)} {Get(Y)} {Get(Z)} {Get(Value1)} {Get(Value2)} )";
        }

        private string Get(double value, bool decimals = false)
        {
            if (decimals || value % 1 != 0) return $"{value.ToString("0.000000", nfi)}";
            return $"{value.ToString(nfi)}";
        }
    }
}
