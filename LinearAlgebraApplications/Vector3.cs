// Written by Turin Briggs 2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraApplications
{
    /// <summary>
    /// Representation of a 3-Dimensional vector, with built-in methods for transforming and scaling vectors
    /// </summary>
    internal class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        #region Constructors
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double a)
        {
            X = a;
            Y = a;
            Z = a;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion

        /// <summary>
        /// Normalize this vector
        /// </summary>
        public Vector3 Normalize()
        {
            double l = Length;
            if (l > 0)
            {
                double inv = 1 / l;
                X *= inv;
                Y *= inv;
                Z *= inv;
            }
            return this;
        }

        /// <summary>
        /// Normalizes the passed in vector and return it for chaining
        /// </summary>
        public static Vector3 Normalize(Vector3 v)
        {
            double l = v.Length;
            if (l > 0)
            {
                double inv = 1 / l;
                v.X *= inv;
                v.Y *= inv;
                v.Z *= inv;
            }
            return v;
        }

        /// <summary>
        /// Compute the cross product of 2 vectors
        /// </summary>
        public static Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
                );
        }

        /// <summary>
        /// Compute the dot product of 2 vectors
        /// </summary>
        public static double DotProduct(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// Vector addition operator
        /// </summary>
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Vector subtraction operator
        /// </summary>
        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Vector multiplication with a scaler operator
        /// </summary>
        public static Vector3 operator * (Vector3 a, double s)
        {
            return new Vector3(a.X * s, a.Y * s, a.Z * s);
        }
    }
}
