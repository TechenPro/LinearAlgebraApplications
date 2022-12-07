// Written by Turin Briggs 2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraApplications
{
    /// <summary>
    /// Representation of a 4x4 matrix, with built in methods for generating rotation and translation matrices
    /// Used for the transformation of 3-dimensional vectors and homogenous points
    /// Implementation for matrix multiplication to combine matrices
    /// </summary>
    internal class Matrix4x4
    {
        // The backing array of the matrix
        private double[][] m;

        // Construction defaults the matrix to a 4x4 Identity matrix
        public Matrix4x4()
        {
            m = new double[][] { new double [] { 1, 0, 0, 0 }, new double[] { 0, 1, 0, 0 }, new double[] { 0, 0, 1, 0 }, new double[] { 0, 0, 0, 1 } };
        }

        // Access operator override
        public double[] this[int key]
        {
            get => m[key];
            set => m[key] = value;
        }

        /// <summary>
        /// Multiply two 4x4 matrices
        /// </summary>
        public static Matrix4x4 operator * (Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 mult = new Matrix4x4();
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    mult[i][j] = a[i][0] * b[0][j] +
                                 a[i][1] * b[1][j] +
                                 a[i][2] * b[2][j] +
                                 a[i][3] * b[3][j];
                }
            }
            return mult;
        }

        /// <summary>
        /// Build a rotation transformation of the specified angle around the specified axis
        /// </summary>
        public static Matrix4x4 BuildRotationMatrix(double angle_deg, int axis)
        {
            Matrix4x4 r = new Matrix4x4();
            double angle = Math.PI * angle_deg / 180.0;
            // X axis
            if (axis == 1)
            {
                r.m[0] = new double[] { 1, 0, 0, 0 };
                r.m[1] = new double[] { 0, Math.Cos(angle), -Math.Sin(angle), 0};
                r.m[2] = new double[] { 0, Math.Sin(angle), Math.Cos(angle), 0};
            }
            // Y axis
            else if (axis == 2)
            {
                r.m[0] = new double[] { Math.Cos(angle), 0, Math.Sin(angle), 0};
                r.m[1] = new double[] { 0, 1, 0, 0 };
                r.m[2] = new double[] { -Math.Sin(angle), 0, Math.Cos(angle), 0 };
            }
            // Z axis
            else if (axis == 3)
            {
                r.m[0] = new double[] { Math.Cos(angle), -Math.Sin(angle), 0, 0 };
                r.m[1] = new double[] { Math.Sin(angle), Math.Cos(angle), 0, 0 };
                r.m[2] = new double[] { 0, 0, 1, 0};
            }
            
            return r;
        }

        /// <summary>
        /// Build a translation matrix with the provided values
        /// </summary>
        public static Matrix4x4 BuildTranslationMatrix(double x, double y, double z)
        {
            Matrix4x4 t = new Matrix4x4();
            t.m[3][0] = x;
            t.m[3][1] = y;
            t.m[3][2] = z;
            return t;
        }

        /// <summary>
        /// Handles both rotation and translation of a homogenous point
        /// </summary>
        public Vector3 TransformHomogenousPoint(Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = v.X * m[0][0] + v.Y * m[1][0] + v.Z * m[2][0] + m[3][0];
            result.Y = v.X * m[0][1] + v.Y * m[1][1] + v.Z * m[2][1] + m[3][1];
            result.Z = v.X * m[0][2] + v.Y * m[1][2] + v.Z * m[2][2] + m[3][2];
            double w = v.X * m[0][3] + v.Y * m[1][3] + v.Z * m[2][3] + m[3][3];

            if( w != 1 && w != 0)
            {
                result.X /= w;
                result.Y /= w;
                result.Z /= w;
            }

            return result;
        }

        /// <summary>
        /// Handles rotation of a vector
        /// </summary>
        public Vector3 TransformVector(Vector3 v)
        {
            Vector3 result = new Vector3();

            result.X = v.X * m[0][0] + v.Y * m[1][0] + v.Z * m[2][0];
            result.Y = v.X * m[0][1] + v.Y * m[1][1] + v.Z * m[2][1];
            result.Z = v.X * m[0][2] + v.Y * m[1][2] + v.Z * m[2][2];

            return result;
        }
        
    }
}
