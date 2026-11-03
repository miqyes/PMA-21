namespace Abstraction
{

    public abstract class Shape : IArea, IPerimeter
    {
        protected IColour colour;

        protected Shape(IColour colour)
        {
            this.colour = colour;
        }
       
        protected Shape()
        {
            this.colour = new NoColour();
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return
                $"Shape: {GetType().Name}, Colour: {colour.GetColourName}, Area: {GetArea()},  Perimeter: {GetPerimeter()}";
        }
    }
}