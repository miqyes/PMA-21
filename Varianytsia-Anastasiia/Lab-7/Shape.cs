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
