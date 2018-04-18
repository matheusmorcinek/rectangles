using System;
using System.Collections.Generic;

namespace rectanglesApp
{
    public class Rectangle
    {

        public Point vertexTopLeft { get; set; }

        public Point vertexTopRight { get; set; }

        public Point vertexBottomLeft { get; set; }

        public Point vertexBottomRight { get; set; }

        //middle point x,y
        public decimal x { get; set; }

        public decimal y { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public int zIndex { get; set; }

        public Rectangle(decimal x, decimal y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rectangle(Point vertexBottomLeft, Point vertexTopRight)
        {
            this.vertexBottomLeft = vertexBottomLeft;
            this.vertexTopRight = vertexTopRight;
            SetRemainingVertexes(vertexBottomLeft, vertexTopRight);
            SetMiddlePoint();
            SetWidht();
            SetHeight();

            SetHashCodeToVertexes();
        }


        private void SetHashCodeToVertexes()
        {

            vertexTopLeft.hashCode = GetHashCode();

            vertexTopRight.hashCode = GetHashCode();

            vertexBottomLeft.hashCode = GetHashCode();

            vertexBottomRight.hashCode = GetHashCode();

        }

        private void SetWidht()
        {
            width = vertexTopRight.x - vertexTopLeft.x;
        }

        private void SetHeight()
        {
            height = vertexTopLeft.y - vertexBottomLeft.y;
        }

        private void SetMiddlePoint()
        {
            x = Decimal.Divide((vertexTopLeft.x + vertexBottomRight.x), 2);
            y = Decimal.Divide((vertexTopLeft.y + vertexBottomRight.y), 2);
        }

        private void SetRemainingVertexes(Point vertexBottomLeft, Point vertexTopRight)
        {
            vertexTopLeft = new Point(vertexBottomLeft.x, vertexTopRight.y);
            vertexBottomRight = new Point(vertexTopRight.x, vertexBottomLeft.y);
        }

        public bool Contains(Point point)
        {
            return (point.x >= this.x - this.width &&
                    point.x <= this.x + this.width &&
                    point.y >= this.y - this.height &&
                    point.y <= this.y + this.height);
        }

        public bool Intersects(Rectangle range)
        {
            return !(range.x - range.width > this.x + this.width ||
                     range.x + range.width < this.x - this.width ||
                     range.y - range.height > this.y + this.height ||
                     range.y + range.height < this.y - this.height);
        }

        public double Area()
        {
            List<Point> vertices234 = new List<Point>() { vertexTopRight, vertexTopRight, vertexTopLeft };

            Point auxVertex = vertexBottomLeft.Nearest(vertices234);
            List<Point> otherVertices = null;
            if (auxVertex.Equals(vertexTopRight))
            {
                otherVertices = new List<Point> { vertexTopLeft, vertexBottomRight };
            }
            else if (auxVertex.Equals(vertexTopLeft))
            {
                otherVertices = new List<Point> { vertexTopRight, vertexBottomRight };
            }
            else if (auxVertex.Equals(vertexBottomRight))
            {
                otherVertices = new List<Point> { vertexTopRight, vertexTopLeft };
            }

            int result = (int)vertexBottomLeft.Distance(auxVertex);
            int height = (int)auxVertex.Distance(auxVertex.Nearest(otherVertices));
            return result * height;
        }

        public override int GetHashCode()
        {
            return int.Parse(Math.Truncate(x).ToString() + Math.Truncate(y).ToString());
        }
    }

}

////TODO this method should be moved to the Grid class, 
//public static int OverlappedArea(Rectangle rectangleOne, Rectangle rectangleTwo)
//{
//    //var rectangleOneArea = rectangleOne.Area();
//    //var rectangleTwoArea = rectangleTwo.Area();

//    int areaOverlapped = (Math.Min(rectangleOne.vertexTwo.x, rectangleTwo.vertexTwo.x) -
//                         Math.Max(rectangleOne.vertexOne.x, rectangleTwo.vertexOne.x)) *
//                         (Math.Min(rectangleOne.vertexTwo.y, rectangleTwo.vertexTwo.y) -
//                         Math.Max(rectangleOne.vertexOne.y, rectangleTwo.vertexOne.y));

//    //return (rectangleOneArea + rectangleTwoArea - areaOverlapped);
//    return areaOverlapped;
//}

