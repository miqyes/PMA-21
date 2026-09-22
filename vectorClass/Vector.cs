namespace vectorClass;

public class Vector
{
    private double[] coordinates;

    public Vector(double[] c)
    {
        coordinates = c;
    }

    public double this[int i]
    {
        get
        {
            return coordinates[i];
        }
    }

    public int Length
    {
        get
        {
            return coordinates.Length;
        }
    }

    public static Vector operator +(Vector first, Vector second)
    {
        double[] result = new double[first.Length];
        if (first.Length != second.Length)
        {
            throw new Exception(" У векторів не може бути різна довжина ");
        }
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first[i] + second[i];
        }

        return new Vector(result);
    }

    public static Vector operator -(Vector first, Vector second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; (i) < first.Length; (i)++)
        {
            result[i] = first[i] - second[i];
        }

        return new Vector(result);
    }

    public static Vector operator *(Vector first, Vector second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; (i) < first.Length; (i)++)
        {
            result[i] = first[i] * second[i];
        }

        return new Vector(result);
    }
    public static Vector operator /(Vector first, Vector second)
    {
        double[] result = new double[first.Length];
        for (int i = 0; (i) < first.Length; (i)++)
        {
            if (second[i] == 0)
            {
                throw new Exception("Ділення на нуль неможливе");
            }
            result[i] = first[i] / second[i];
        }

        return new Vector(result);
    }
}
