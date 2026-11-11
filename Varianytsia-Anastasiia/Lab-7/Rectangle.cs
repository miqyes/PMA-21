using System;
class Rectangle(double width, double height, Color color) : Shape(color)
{
    private readonly double width = width;
    private readonly double height = height;

    public override double CalculatePerimeter()
    {
        return 2 * (width + height);
    }

    public override double CalculateArea()
    {
        return width * height;
    }

    public override string GetDescription()
    {
        return "Прямокутник " + width + "x" + height;
    }
}

