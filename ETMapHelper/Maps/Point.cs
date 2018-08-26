using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point()
        {
            X = Y = Z = 0;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }

        public string ToStringInteger()
        {
            return $"{Math.Round(X)} {Math.Round(Y)} {Math.Round(Z)}";
        }

        public bool IsOrigin()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public double DistanceTo(Entity e)
        {
            if (e.Origin == null) return -1;
            return DistanceTo(e.Origin);
        }

        public double DistanceTo(Point p)
        {
            return DistanceTo(p.X, p.Y, p.Z);
        }

        public double DistanceTo(double x, double y, double z)
        {
            return Math.Sqrt(
                Math.Pow((X - x), 2) +
                Math.Pow((Y - y), 2) +
                Math.Pow((Z - z), 2));
        }

        public double DistanceToOrigin()
        {
            if (IsOrigin()) return 0;
            return DistanceTo(0, 0, 0);
        }
    }
}
