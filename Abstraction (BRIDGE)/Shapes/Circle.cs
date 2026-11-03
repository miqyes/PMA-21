namespace Abstraction
{

    public class Circle : Shape
    {
        public double Radius { 
            get;
            set;
            
        }

        public Circle(double radius, IColour colour) : base(colour)
        {
            Radius = radius;
        }

        public Circle() : base(new NoColour())
        {
            Radius = 0.0;
        }
        
        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}