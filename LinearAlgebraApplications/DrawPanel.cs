// Written by Turin Briggs 2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Maui.Graphics;

namespace LinearAlgebraApplications
{
    public class DrawPanel : IDrawable
    {
        public static int worldsize = 600;
        internal Cube c;

        /// <summary>
        /// Draws a projection of the Cube c onto the xy-plane
        /// </summary>
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Draw main backdrop
            canvas.Translate(worldsize / 2, worldsize / 2);
            canvas.ResetState();
            canvas.FillColor = Colors.White;
            canvas.FillRectangle(-worldsize / 2, -worldsize / 2, 1000,1000);
            canvas.StrokeColor= Colors.Gray;
            canvas.DrawLine(-worldsize, 0, worldsize, 0);
            canvas.DrawLine(0, -worldsize, 0, worldsize);

            // Draw Cube
            List<Vector3> points = c.ProjectVertices();
            canvas.FillColor = Colors.Blue;
            foreach (Vector3 v in points)
            {
                canvas.FillCircle((float) v.X, (float) v.Y, 5);
            }
            for(int i=0; i<4; i++)
            {
                ConnectDrawnPoints(canvas, i, (i + 1) % 4, points);
                ConnectDrawnPoints(canvas, i + 4, ((i + 1) % 4) + 4, points);
                ConnectDrawnPoints(canvas, i, i + 4, points);
            }

        }

        /// <summary>
        /// Draws a line between the specified points in a list of points
        /// </summary>
        internal void ConnectDrawnPoints(ICanvas canvas, int i, int j, List<Vector3> points)
        {
            canvas.StrokeColor= Colors.Red;
            canvas.DrawLine((float) points[i].X, (float) points[i].Y, (float) points[j].X, (float) points[j].Y);
        }
    }
}
