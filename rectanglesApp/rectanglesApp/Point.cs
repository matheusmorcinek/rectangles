using System;
using System.Collections.Generic;

namespace rectanglesApp
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public int hashCode { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
        }

        public override string ToString()
        {
            return ("(x" + x + " - y" + y + ")");
        }

        public double Distance(Point anotherPoint)
        {
            return Math.Sqrt(Math.Pow(x - anotherPoint.x, 2) +
                             Math.Pow(y - anotherPoint.y, 2));
        }

        /**
         * Returns the nearest point of the array in the parameter or null if array is empty.
         */
        public Point Nearest(List<Point> otherPoints)
        {
            Point nearestPoint = null;
            double minDistance = int.MaxValue;
            double currentDistance;

            for (int i = 0; i < otherPoints.Count; i++)
            {
                currentDistance = this.Distance(otherPoints[i]);
                if (currentDistance <= minDistance)
                {
                    minDistance = currentDistance;
                    nearestPoint = otherPoints[i];
                }
            }
            return nearestPoint;
        }

    }
}