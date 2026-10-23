using System;
using System.Linq;

class Vector(double[] elements)
{
    private readonly double[] elements = elements;

    public int Length
    {
        get { return elements.Length; }
    }

    public Vector AddWithSteps(Vector other)
{
    int n = this.elements.Length;
    double[] result = new double[n];

    for (int i = 0; i < n; i++)
    {
        result[i] = this.elements[i] + other.elements[(i + 1) % n];
    }

    return new Vector(result);
}

    public Vector Add(Vector other)
    {
        double[] result = [.. this.elements.Zip(other.elements, (a, b) => a + b)];

        return new Vector(result);
    }

    public Vector SubtractWithSteps(Vector other)
    {
    int n = this.elements.Length;
    double[] result = new double[n];

    for (int i = 0; i < n; i++)
    {
            // if (i + 1 >= n)
            // {
            //     result[i] = this.elements[i] - other.elements[0];
            // }
            // else
            // {
            //     result[i] = this.elements[i] - other.elements[i + 1];
            // }
            if (i == 0)
            {
                result[i] = this.elements[i]-other.elements[n-1];
            }
            else
            {
                result[i] = this.elements[i]-other.elements[i-1];
            }
    }
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