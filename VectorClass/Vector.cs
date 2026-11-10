using System;

public class Vector
{
    public double[] data;

    public Vector(params double[] coordinates)
    {
        data = coordinates;
    }

    public static Vector operator +(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("different sizes");

        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first.data[i] + second.data[i];
        }

        return new Vector(result);
    }

    public static Vector operator -(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("different sizes");

        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first.data[i] - second.data[i];
        }

        return new Vector(result);
    }

    public static Vector operator *(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("different sizes");

        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first.data[i] * second.data[i];
        }

        return new Vector(result);
    }

    public static Vector operator /(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("different sizes");

        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            if (second.data[i] == 0)
                throw new DivideByZeroException("division by zero.");

            result[i] = first.data[i] / second.data[i];
        }

        return new Vector(result);
    }

    public override string ToString()
    {
        return $"({string.Join("; ", data)})";
    }
}