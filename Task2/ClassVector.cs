
class Vector
{
    public static float[][] read(string path)
    {
        float[][] result = File.ReadAllLines(path).Select(l => l.Split(", ").Select(i => float.Parse(i)).ToArray()).ToArray();
        return result;
    }

    public static string change(float[] vector)
    {
        return "(" + string.Join(", ", vector) + ")";
    }

    public static float[] add(float[] firstVector, float[] secondVector)
    {
        float[] result = new float[firstVector.Length];
        if (firstVector.Length != secondVector.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }
        else
        {
            for (int i = 0; i < firstVector.Length; i++)
            {
                result[i] = firstVector[i] + secondVector[i];
            }
            return result;
        }
    }

    public static float[] multiply(float[] vector, float scalar)
    {
        float[] result = new float[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = vector[i] * scalar;
        }
        return result;
    }

    public static float[] division(float[] vector, float scalar)
    {
        float[] result = new float[vector.Length];
        if (scalar == 0)
        {
            throw new DivideByZeroException();
        }
        else
        {

            for (int i = 0; i < vector.Length; i++)
            {
                result[i] = vector[i] / scalar;
            }
            return result;
        }
    }


    public static float[] subtract(float[] firstVector, float[] secondVector)
    {
        float[] result = new float[firstVector.Length];
        if (firstVector.Length != secondVector.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }
        else
        {
            for (int i = 0; i < firstVector.Length; i++)
            {
                result[i] = firstVector[i] - secondVector[i];
            }


            return result;
        }

        return result;
    }
}

//float[] result = firstVector.Select((value, i) => value - secondVector[i]).ToArray();
