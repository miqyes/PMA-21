namespace abstraction2;

public class Circle : Shape, IPerim, IArea
{
    private double radius;

    public Circle(double radius, IColour colour) : base(colour)
    {
        this.radius = radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }
} 