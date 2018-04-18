using System;
using System.Collections.Generic;

namespace rectanglesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Dictionary<int, Rectangle> rectangleDictionary = new Dictionary<int, Rectangle>();

            int boundary = 10;
            Quadtree quadtree = new Quadtree(new Rectangle(boundary / 2, boundary / 2, boundary / 2, boundary / 2), 4);

            Rectangle azul = new Rectangle(new Point() { x = 2, y = 1 }, new Point() { x = 4, y = 6 });
            Rectangle vermelho = new Rectangle(new Point() { x = 3, y = 3 }, new Point() { x = 7, y = 8 });
            Rectangle amarelo = new Rectangle(new Point() { x = 4, y = 7 }, new Point() { x = 6, y = 10 });
            Rectangle verdeClaro = new Rectangle(new Point() { x = 6, y = 1 }, new Point() { x = 9, y = 7 });

            //var numberhash = azul.GetHashCode();
            // rectangleDictionary.Add(azul.GetHashCode(), azul);


            quadtree.InsertRectangle(azul);
            quadtree.InsertRectangle(vermelho);

            //Rectangle response;
            //var test = rectangleDictionary.TryGetValue(numberhash, out response);
            //var hgfhfg = rectangleDictionary.TryGetValue(1232, out response);

            //quadtree.Insert(new Point() { x = 3, y = 3 });
            //quadtree.Insert(new Point() { x = 7, y = 8 });  

            //quadtree.Insert(new Point() { x = 8, y = 9 });
            //quadtree.Insert(new Point() { x = 7, y = 8 });

            //quadtree.Insert(new Point() { x = 2, y = 1 });
            //quadtree.Insert(new Point() { x = 1, y = 1 });


            //testing
            var t1 = vermelho.Intersects(azul);
            var t2 = azul.Intersects(vermelho);


            //var range = new Rectangle(0, 0, 5, 4);
            var range = new Rectangle(2, 2, 2, 2);
            var pointList = quadtree.Query(range);


            //Random random = new Random();
            //for(int x = 0; x < 5; x++)
            //{
            //    var px = random.Next(boundary);
            //    var py = random.Next(boundary);
            //    Point point = new Point
            //    {
            //        x = px,
            //        y = py
            //    };
            //    quadtree.Insert(point);
            //}


        }
    }
}