namespace Abstraction
{
    public class Square : Rectangle
    {
    
        public Square(double side, IColour colour) : base(side, side, colour)
        {
        }
        
        public Square() : base(0.0, 0.0, new NoColour())
        {
        }
        
    }
}
