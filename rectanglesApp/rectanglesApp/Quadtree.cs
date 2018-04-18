using System;
using System.Collections.Generic;
using System.Linq;

namespace rectanglesApp
{
    public class Quadtree
    {

        private Rectangle boundary;

        private int rectangleCapacity;

        private List<Point> points;

        private bool divided;

        private Quadtree northWest;

        private Quadtree northEast;

        private Quadtree southWest;

        private Quadtree southEast;

        //rectangles stored in the Dictionary 
        Dictionary<int, Rectangle> rectangleDictionary;

        Dictionary<string, int> areaColorResponse;


        public Quadtree(Rectangle boundary, int rectangleCapacity)
        {

            if (boundary == null)
            {
                throw new Exception("boundary is null");
            }
            //if (!(boundary.GetType().Equals("Rectangle")))
            //{
            //    throw new Exception("boundary should be a Rectangle");
            //}
            if (rectangleCapacity < 1)
            {
                throw new Exception("capacity must be greater than 0");
            }

            this.boundary = boundary;

            this.rectangleCapacity = rectangleCapacity;

            divided = false;

            points = new List<Point>();
        }

        public bool InsertRectangle(Rectangle rectangle)
        {

            if (!rectangle.Intersects(boundary))
            {
                return false;
            }

            if (rectangleDictionary == null)
            {
                rectangleDictionary = new Dictionary<int, Rectangle>();
            }

            rectangleDictionary.Add(rectangle.GetHashCode(), rectangle);

            //TODO not working well,
            List<Point> pointsFound = Query(rectangle);


            if (pointsFound.Count > 0)
            {
                //distinct
                pointsFound.GroupBy(x => x.hashCode).Select(x => x.First());
                var relatedRectangles = GetRelatedRectangles(pointsFound);

            }

            //last step
            Insert(rectangle.vertexTopLeft);
            Insert(rectangle.vertexTopRight);
            Insert(rectangle.vertexBottomLeft);
            Insert(rectangle.vertexBottomRight);


            //TODO return the rectangles that rectangle being sent overlap

            //than calculates the area being overlapped and add in the hash result


            //after get the points of the dictionary, order by rectangles by the zindex
            //only after that calculates the area and sent to the hash response


            return true;
        }

        private List<Rectangle> GetRelatedRectangles(List<Point> pointsFound)
        {

            List<Rectangle> rectangles = new List<Rectangle>();

            foreach (Point point in pointsFound)
            {

                Rectangle rectangle;
                rectangleDictionary.TryGetValue(point.hashCode, out rectangle);

                if (rectangle != null)
                {
                    rectangles.Add(rectangle);
                }

            }

            return rectangles;
        }


        public bool Insert(Point point)
        {

            if (!boundary.Contains(point))
            {
                return false;
            }

            if (points.Count < rectangleCapacity)
            {
                points.Add(point);
                return true;
            }

            if (!divided)
            {
                Subdivide();
            }

            return (this.northEast.Insert(point) || this.northWest.Insert(point) ||
                    this.southEast.Insert(point) || this.southWest.Insert(point));
        }

        private void Subdivide()
        {
            var x = boundary.x;
            var y = boundary.y;
            var w = boundary.width / 2;
            var h = boundary.height / 2;

            var ne = new Rectangle(x + w, y - h, w, h);
            northEast = new Quadtree(ne, rectangleCapacity);

            var nw = new Rectangle(x - w, y - h, w, h);
            northWest = new Quadtree(nw, rectangleCapacity);

            var se = new Rectangle(x + w, y + h, w, h);
            southEast = new Quadtree(se, rectangleCapacity);

            var sw = new Rectangle(x - w, y + h, w, h);
            southWest = new Quadtree(sw, rectangleCapacity);

            divided = true;
        }

        public List<Point> Query(Rectangle range)
        {
            List<Point> found = new List<Point>();

            if (!range.Intersects(boundary))
            {
                //empty array
                return found;
            }

            foreach (Point point in points)
            {
                if (range.Contains(point))
                {
                    found.Add(point);
                }
            }

            if (divided)
            {
                found.AddRange(northWest.Query(range));
                found.AddRange(northEast.Query(range));
                found.AddRange(southWest.Query(range));
                found.AddRange(southEast.Query(range));
            }

            return found;

        }

    }
}
