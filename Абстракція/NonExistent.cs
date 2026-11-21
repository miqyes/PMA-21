using System;

namespace project;

public class NonExistent : Shape, IRun
{
    public NonExistent(Color color) : base(color)
    {
    }

    public string GetAreaMessage()
    {
        return "Area calculation is inaccessible for non-existent shape.";
    }

    public string GetPerimeterMessage()
    {
        return "Perimeter calculation is inaccessible for non-existent shape.";
    }

    public override string GetInfo()
    {
        return $"NonExistent ({base.GetInfo()})";
    }
}