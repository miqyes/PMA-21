using System;

namespace project;

public class Square : Rectangle
{
    public Square(double side, Color color) : base(side, side, color)
    {
    }

    public override string GetInfo()
    {
        return $"Square ({Color.GetColor()}: area = {GetArea():F2}, perimeter = {GetPerimeter():F2})";
    }
}