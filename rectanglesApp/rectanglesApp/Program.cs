using System;

namespace rectanglesApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int boundary = 10;
            Quadtree quadtree = new Quadtree(new Rectangle(boundary / 2, boundary / 2, boundary / 2, boundary / 2 ), 4);

            Rectangle azul = new Rectangle(5, 5, 1, 1);
            Rectangle varmelho = new Rectangle(8, 8, 2, 2);
         
            quadtree.Insert(new Point() { x = 3, y = 3 });
            quadtree.Insert(new Point() { x = 7, y = 8 });  

            quadtree.Insert(new Point() { x = 8, y = 9 });
            quadtree.Insert(new Point() { x = 7, y = 8 });

            quadtree.Insert(new Point() { x = 2, y = 1 });
            quadtree.Insert(new Point() { x = 1, y = 1 });
            

            var t1 = varmelho.Intersects(azul);
            var t2 = azul.Intersects(varmelho);
           

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