public class Circle : Shape, IPerimeter, IArea
{
    private double radius;

    public Circle(double radius, IColor color) : base(color)
    {
        this.radius = radius;
    }

    public override string GetName()
    {
        return "Circle";
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }
}
