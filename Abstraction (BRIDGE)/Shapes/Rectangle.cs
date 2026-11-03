namespace Abstraction
{

    public class Rectangle : Shape
    {
        public double Width
        {
            get; 
            set;
        }

        public double Height
        {
            get;
            set;
        }

        public Rectangle(double width, double height, IColour colour) : base(colour)
        {
            Width = width;
            Height = height;
        }
        
        public Rectangle() : base(new NoColour())
        {
            Width = 0.0;
            Height = 0.0;
        }

        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => 2 * (Width + Height);
    }
}