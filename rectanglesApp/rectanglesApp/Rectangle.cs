namespace rectanglesApp
{
    public class Rectangle
    {

        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
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

    }
}