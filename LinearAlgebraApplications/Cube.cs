// Written by Turin Briggs 2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraApplications
{
    internal class Cube
    {
        public List<Vector3> vertices;
        public Matrix4x4 projection_matrix;
        public double scale;

        public Cube()
        {
            scale = 100;
            // Initialize the cube around the origin
            vertices = new List<Vector3>();
            vertices.Add(new Vector3(-scale, -scale, scale));
            vertices.Add(new Vector3(scale, -scale, scale));
            vertices.Add(new Vector3(scale, scale, scale));
            vertices.Add(new Vector3(-scale, scale, scale));
            vertices.Add(new Vector3(-scale, -scale, -scale));
            vertices.Add(new Vector3(scale, -scale, -scale));
            vertices.Add(new Vector3(scale, scale, -scale));
            vertices.Add(new Vector3(-scale, scale, -scale));

            // Setup project matrix
            projection_matrix= new Matrix4x4();
            projection_matrix[2] = new double[] { 0, 0, 0, 0 };
            projection_matrix[3] = new double[] { 0, 0, 0, 0 };
        }

        public void TransformCube(Matrix4x4 t)
        {
            for(int i=0; i<vertices.Count; i++)
            {
                vertices[i] = t.TransformHomogenousPoint(vertices[i]);
            }
        }

        public List<Vector3> ProjectVertices()
        {
            List<Vector3> result = new List<Vector3>();

            for (int i = 0; i < vertices.Count; i++)
            {
                result.Add(projection_matrix.TransformHomogenousPoint(vertices[i]));
            }

            return result;
        }
    }
}
