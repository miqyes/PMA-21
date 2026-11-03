namespace abstraction2;

public class Rectangle: Shape, IPerim, IArea
{
    private double height;
    private double width;

    public Rectangle(double height, double width, IColour colour) : base(colour)
    {
        this.height = height;
        this.width = width;
    }

    public double GetPerimeter()
    {
        return 2 * (height + width);
    }

    public double GetArea()
    {
        return height * width;
    }
}