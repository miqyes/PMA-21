namespace vectorClass;

class Vector
{
    private double[] coordinates;
    private int GetLength()
    {
        return coordinates.Length;
    }
    public Vector(double [] c)
    {
        coordinates = c;
    }

    public override string ToString()
    {
        return string.Join(" ", coordinates);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        double[] result = new double[a.GetLength()];
        for (int i = 0; i < result.Length; i++) {
            result[i] = a.coordinates[i] + b.coordinates[i];
        }

        return new Vector(result);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        double[] result=new double[a.GetLength()];
        for (int i = 0; i < result.Length; i++) {
            result[i] = a.coordinates[i] - b.coordinates[i];
        }
        return new Vector(result);
    }
    public static Vector operator *(Vector a, Vector b)
    {
        double[] result=new double[a.GetLength()];
        for (int i = 0; i < result.Length; i++) {
            result[i] = a.coordinates[i] * b.coordinates[i];
        }
        return new Vector(result);
    }
    public static Vector operator /(Vector a, Vector b)
    {
        double[] result = new double[a.GetLength()];
        for (int i = 0; i < result.Length; i++) {
            result[i] = a.coordinates[i] / b.coordinates[i];
        }

        return new Vector(result);
    }

    public static bool divisionByZero(Vector b)
    {
        for(int i=0; i<b.GetLength();i++) {
            if (b.coordinates[i] == 0) {
                return true;
            }
        }
        return false;
    }
}

