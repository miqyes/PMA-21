using System;

namespace project;

public class Rectangle : Shape, IArea, IPerimeter
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height, Color color) : base(color)
    {
        this.Width = width;
        this.Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public override string GetInfo()
    {
        return $"Rectangle ({base.GetInfo()}, Width = {Width}, Height = {Height}, Area = {GetArea():F2}, Perimeter = {GetPerimeter():F2})";
    }
}