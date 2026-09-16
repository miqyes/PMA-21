public class Vector
{
    public double[] Coordinates { get; }

    public Vector(double[] coordinates)
    {
        Coordinates = coordinates;
    }

    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Coordinates.Length != b.Coordinates.Length)
            throw new ArgumentException("vectors have different dimensions.");

        var result = new double[a.Coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.Coordinates[i] + b.Coordinates[i];
        }
        return new Vector(result);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        if (a.Coordinates.Length != b.Coordinates.Length)
            throw new ArgumentException("vectors have different dimensions.");

        var result = new double[a.Coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.Coordinates[i] - b.Coordinates[i];
        }
        return new Vector(result);
    }

    public static Vector operator *(Vector a, Vector b)
    {
        if (a.Coordinates.Length != b.Coordinates.Length)
            throw new ArgumentException("vectors have different dimensions.");

        var result = new double[a.Coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.Coordinates[i] * b.Coordinates[i];
        }
        return new Vector(result);
    }

    public static Vector operator /(Vector a, Vector b)
    {
        if (a.Coordinates.Length != b.Coordinates.Length)
            throw new ArgumentException("vectors have different dimensions.");

        var result = new double[a.Coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.Coordinates[i] / b.Coordinates[i];
        }
        return new Vector(result);
    }

    public override string ToString() => "(" + string.Join(", ", Coordinates) + ")";
}