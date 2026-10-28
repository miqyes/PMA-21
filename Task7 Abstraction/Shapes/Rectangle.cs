public class Rectangle : Shape, IPerimeter, IArea
{
    protected double width;
    protected double height;

    public Rectangle(double width, double height, IColor color) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override string GetName()
    {
        return "Rectangle";
    }

    public double GetArea()
    {
        return width * height;
    }

    public double GetPerimeter()
    {
        return 2 * (width + height);
    }
}
