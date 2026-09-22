namespace VectorClass;

public class Vector
{
    private double[] values;

    public Vector(double[] values)
    {
        this.values = values;
    }

    public double this[int index]
    {
        get => values[index];
        set => values[index] = value;
    }

    public int Size => values.Length;

    public Vector Add(Vector other)
    {
        if (Size != other.Size)
        {
            throw new Exception("вектори повині мати одинаковий розмір");
        }
        Vector result = new Vector(new double[this.Size]);
        for (int i = 0; i < Size; i++)
        {
            result[i] = this[i] + other[i];
        }

        return result;
    }

    public Vector Sub(Vector other)
    {
        if (Size != other.Size)
        {
            throw new Exception("вектори повині мати одинаковий розмір");
        }
        Vector result = new Vector(new double[this.Size]);
        for (int i = 0; i < Size; i++)
        {
            result[i] = this[i] - other[i];
        }

        return result;
    }

    public Vector Mult(Vector other)
    {
        if (Size != other.Size)
        {
            throw new Exception("вектори повині мати одинаковий розмір");
        }
        Vector result = new Vector(new double[this.Size]);
        for (int i = 0; i < Size; i++)
        {
            result[i] = this[i] * other[i];
        }

        return result;
    }

    public Vector Div(Vector other)
    {
        if (Size != other.Size)
        {
            throw new Exception("вектори повині мати одинаковий розмір");
        }
        Vector result = new Vector(new double[this.Size]);
        for (int i = 0; i < Size; i++)
        {
            if (other[i] == 0)
            {
                throw new Exception("вектор-дільник не може містити нульових елементів при діленні");
            }

            result[i] = this[i] / other[i];
        }

        return result;
    }
    public override string ToString()
    {
        return "(" + string.Join(", ", values) + ")";
    }
}