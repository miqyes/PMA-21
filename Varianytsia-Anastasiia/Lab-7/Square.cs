using System;
class Square(double side, Color color) : Shape(color)
{
    private readonly double side = side;

    public override double CalculatePerimeter()
    {
        return 4 * side;
    }

    public override double CalculateArea()
    {
        return side * side;
    }

    public override string GetDescription()
    {
        return "Квадрат зі стороною " + side;
    }
}