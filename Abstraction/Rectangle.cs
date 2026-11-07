namespace UNI;

public abstract class Rectangle : Figure
{
    protected double width;
    protected double height;

    public Rectangle(double width, double height, Color color) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override string Name => "Rectangle";
    double GetArea() => width * height; 
    double GetPerimetr() => 2 * (width + height);
}