using System;
using System.Linq;

class Vector(double[] elements)
{
    private readonly double[] elements = elements;

    public int Length
    {
        get { return elements.Length; }
    }

    public Vector Add(Vector other)
    {
        double[] result = [.. this.elements.Zip(other.elements, (a, b) => a + b)];

        return new Vector(result);
    }

    public Vector Subtract(Vector other)
    {
        double[] result = [.. this.elements.Zip(other.elements, (a, b) => a - b)];

        return new Vector(result);
    }

    public Vector Multiply(Vector other)
    {
        double[] result = [.. this.elements.Zip(other.elements, (a, b) => a * b)];

        return new Vector(result);
    }

    public Vector Divide(Vector other)
    {
        double[] result = [.. this.elements.Zip(other.elements, (a, b) => a / b)];

        return new Vector(result);
    }

    public bool HasZero()
    {
        return elements.Contains(0);
    }

    public override string ToString()
    {
        return "(" + string.Join(", ", elements) + ")";
    }
}