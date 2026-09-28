using System;

public abstract class Shape
{
    protected Color _color;

    protected Shape(Color color)
    {
        if(color == null)
            throw new ArgumentNullException("color");
        _color = color;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();

    public virtual void DisplayInfo()
    {
        string colorInfo = _color.ApplyColor();

        Console.WriteLine($"Shape: {GetType().Name}");
        Console.WriteLine($"  Color: {colorInfo}");
        Console.WriteLine($"  Area: {GetArea():F2}");
        Console.WriteLine($"  Perimeter: {GetPerimeter():F2}\n");

        _color.RestColor();
    }
}

public class Rectangle : Shape 
{ 
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height, Color color) : base(color)
    { 
        Width = width;
        Height = height;
    }

    public override double GetArea() => Width * Height;
    public override double GetPerimeter() => (Height + Width) * 2;
}

public class Square : Shape
{
    public double Side { get; }

    public Square(double side, Color color) : base(color)
    {
        Side = side;
    }

    public override double GetArea() => Side * Side;

    public override double GetPerimeter() => 4 * Side;
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius, Color color) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea() => Radius * Radius * Math.PI;

    public override double GetPerimeter() => Radius * Math.PI * 2;
}
