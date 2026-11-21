using System;

namespace project;

public class Circle : Shape, IArea, IPerimeter
{
    public double Radius { get; set; }

    public Circle(double radius, Color color) : base(color)
    {
        this.Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string GetInfo()
    {
        return $"Circle ({base.GetInfo()}, Radius = {Radius}, Area = {GetArea():F2}, Perimeter = {GetPerimeter():F2})";
    }
}