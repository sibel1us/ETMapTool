﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public class PatchComponent
    {
        public List<PatchPrimitive> Primitives { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("( ");
            foreach (var primitive in Primitives) sb.Append($"{primitive.ToString()} ");
            sb.Append(")");

            return sb.ToString();
        }
    }
}
