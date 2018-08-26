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
        public double X;
        public double Y;
        public double Z;
        public double Value1;
        public double Value2;

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

        // TODO: what is this function naming?
        public string GetData()
        {
            return $"( {Get(X)} {Get(Y)} {Get(Z)} {Get(Value1)} {Get(Value2)} )";
        }

        private string Get(double value, bool decimals = false)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            if (decimals || value % 1 != 0) return $"{value.ToString("0.000000", nfi)}";
            return $"{value.ToString(nfi)}";
        }
    }
}
