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

    public static Vector operator +(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("Різні розміри");
        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first[i] + second[i];
        }

        return new Vector(result);
    }

    public static Vector operator -(Vector first, Vector second)
    {
        if (first.data.Length != second.data.Length)
            throw new Exception("Різні розміри");
        double[] result = new double[first.data.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = first[i] - second[i];
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