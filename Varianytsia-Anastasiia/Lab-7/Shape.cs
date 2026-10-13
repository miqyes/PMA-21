using System;

abstract class Shape(Color color)
{
    protected readonly Color color = color; // міст

    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();

    public abstract string GetDescription();

    public override string ToString()
    {
        return GetDescription() + " (колір: " + color.GetName() + "): периметр = "
            + Math.Round(CalculatePerimeter(), 2) + ", площа = "
            + Math.Round(CalculateArea(), 2);
    }
}

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