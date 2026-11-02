using System.Globalization;

namespace VectorClass;

public class Vector
{
    private readonly double[] _components;

    public int Dimension => _components.Length;

    public Vector(params double[] components)
    {
        if (components == null || components.Length == 0)
            throw new ArgumentException("Вектор не може бути порожнім.");

        _components = (double[])components.Clone();
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= _components.Length)
                throw new IndexOutOfRangeException("Індекс виходить за межі вимірності вектора.");
            return _components[index];
        }
    }

    private static void EnsureSameDimension(Vector a, Vector b)
    {
        if (a.Dimension != b.Dimension)
            throw new InvalidOperationException($"Неможливо виконати операцію: різна розмірність ({a.Dimension} != {b.Dimension}).");
    }

    public static Vector operator +(Vector a, Vector b)
    {
        EnsureSameDimension(a, b);
        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] + b[i];

        return new Vector(result);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        EnsureSameDimension(a, b);
        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] - b[i];

        return new Vector(result);
    }

    public static Vector operator *(Vector a, Vector b)
    {
        EnsureSameDimension(a, b);
        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] * b[i];

        return new Vector(result);
    }

    public static Vector operator *(Vector a, double scalar)
    {
        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] * scalar;

        return new Vector(result);
    }

    public static Vector operator *(double scalar, Vector a) => a * scalar;

    public static Vector operator /(Vector a, Vector b)
    {
        EnsureSameDimension(a, b);
        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
        {
            if (Math.Abs(b[i]) < double.Epsilon)
                throw new DivideByZeroException($"Ділення на нуль у координаті з індексом {i}.");

            result[i] = a[i] / b[i];
        }

        return new Vector(result);
    }

    public static Vector operator /(Vector a, double scalar)
    {
        if (Math.Abs(scalar) < double.Epsilon)
            throw new DivideByZeroException("Ділення на нуль неможливе.");

        double[] result = new double[a.Dimension];
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] / scalar;

        return new Vector(result);
    }

    public override string ToString()
    {
        var elements = _components.Select(x => x.ToString("G", CultureInfo.InvariantCulture));
        return $"({string.Join(", ", elements)})";
    }
}