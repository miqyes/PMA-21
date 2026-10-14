using System;

class Circle(double radius, Color color) : Shape(color)
{
    private readonly double radius = radius;

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override string GetDescription()
    {
        return "Коло з радіусом " + radius;
    }
}