namespace UNI;

public abstract class Circle : Figure
{
    private double radius;

    public Circle(double radius, Color color): base(color)
    {
        this.radius = radius;
    }
    public override string Name => "Circle";
    double GetArea() => Math.PI * radius * radius;
    double GetPerimetr() => 2 * Math.PI * radius;
}