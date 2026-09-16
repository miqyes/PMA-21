namespace Task4;

public class Vector
{
    private double[] data;

    public Vector(double[] data1)
    {
        data = data1;
    }

    public double this[int i]
    {
        get { return data[i]; }
    }

    public static Vector operator +(Vector vec1, Vector vec2)
    {
        if (vec1.data.Length != vec2.data.Length)
            throw new Exception("Різні розміри");
        double[] result = new double[vec1.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = vec1[i] + vec2[i];
        }

        return new Vector(result);
    }

    public static Vector operator -(Vector vec1, Vector vec2)
    {
        if (vec1.data.Length != vec2.data.Length)
            throw new Exception("Різні розміри");
        double[] result = new double[vec1.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = vec1[i] - vec2[i];
        }

        return new Vector(result);
    }

    public static Vector operator *(Vector vec, double number)
    {
        double[] result = new double[vec.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = vec[i] * number;
        }

        return new Vector(result);
    }

    public static Vector operator /(Vector vec, double number)
    {
        if (number == 0)
            throw new Exception("Не можна ділити на 0(");

        double[] result = new double[vec.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = vec[i] / number;
        }

        return new Vector(result);
    }

    public override string ToString()
    {
        string result = "(";
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i];
            if (i < data.Length - 1)
                result += ";";
        }

        result += ")"; 
        return result;
    }
}