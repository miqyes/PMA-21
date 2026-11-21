using System;

namespace project;

public abstract class Shape
{
    protected Color Color { get; set; }

    public Shape(Color color)
    {
        this.Color = color;
    }
    public virtual string GetInfo()
    {
        return $"{Color.GetColor()}";
    }
}