using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Maps
{
    public class Point
    {
        /// <summary>
        /// Point at 0,0,0
        /// </summary>
        public static readonly Point Origin = new Point(0, 0, 0);

        /// <summary>
        /// 
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Z { get; set; }

        public static Point FromTuple(Tuple<double, double, double> tuple)
        {
            return new Point(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public Tuple<double, double, double> ToTuple() => Tuple.Create(X, Y, Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initialize 
        /// </summary>
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

        public bool IsOrigin => this.Equals(Point.Origin);

        /// <summary>
        /// Returns <see cref="DistanceTo(double, double, double)"/> on the entity's origin.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public double DistanceTo(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Origin == null)
                throw new ArgumentNullException(nameof(entity.Origin));

            return DistanceTo(entity.Origin);
        }

        /// <summary>
        /// Returns <see cref="DistanceTo(double, double, double)"/> on point.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double DistanceTo(Point p) => DistanceTo(p.X, p.Y, p.Z);

        /// <summary>
        /// Returns the distance between this point and the parameter coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public double DistanceTo(double x, double y, double z)
        {
            return Math.Sqrt(
                Math.Pow((X - x), 2) +
                Math.Pow((Y - y), 2) +
                Math.Pow((Z - z), 2));
        }

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return
                    this.X == other.X &&
                    this.Y == other.Y &&
                    this.Z == other.Z;
            }

            return base.Equals(obj);
        }

        public bool Equals(Point other, double errorMargin)
        {
            return
                Math.Abs(this.X - other.X) <= errorMargin &&
                Math.Abs(this.Y - other.Y) <= errorMargin &&
                Math.Abs(this.Z - other.Z) <= errorMargin;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
