class Program
{
    static float[][] readvectors(string path)
    {
        float[][] result = File.ReadAllLines(path).Select(l => l.Split(", ").Select(i => float.Parse(i)).ToArray()).ToArray();
        return result;
    }

    static string vectortostring(float[] vector)
    {
        return "(" + string.Join(", ", vector) + ")";
    }

    static float[] add(float[] element1, float[] element2)
    {
        float[] result = new float[element1.Length];
        if (element1.Length != element2.Length)
        {
            Console.WriteLine("Vectors must have the same length");
            return result;
        }
        else
        {
            for (int i = 0; i < element1.Length; i++)
            {
                result[i] = element1[i] + element2[i];
            }
            return result;
        }
    }

    static float[] multiply(float[] element1, float scalar)
    {
        float[] result = new float[element1.Length];
        for (int i = 0; i < element1.Length; i++)
        {
            result[i] = element1[i] * scalar;
        }
        return result;
    }

    static float[] devision(float[] element1, float scalar)
    {
        float[] result = new float[element1.Length];
        for (int i = 0; i < element1.Length; i++)
        {
            result[i] = element1[i] / scalar;
        }
        return result;
    }

    static float[] subtract(float[] element1, float[] element2)
    {
        float[] result = new float[element1.Length];
        if (element1.Length != element2.Length)
        {
            Console.WriteLine("Vectors must have the same length");
            return result;
        }
        else
        {
            for (int i = 0; i < element1.Length; i++)
            {
                result[i] = element1[i] - element2[i];
            }
            return result;
        }
    }

    static void Main()
    {
        string filestarts = "start.txt";
        string fileend = "result.txt";
        float[][] vectors = readvectors(filestarts);

        File.AppendAllText(fileend, vectortostring(vectors[0]) + " + " + vectortostring(vectors[1]) + " = " + vectortostring(add(vectors[0], vectors[1])) + "\n");
        File.AppendAllText(fileend, vectortostring(vectors[1]) + " - " + vectortostring(vectors[0]) + " = " + vectortostring(subtract(vectors[1], vectors[0])) + "\n");
        File.AppendAllText(fileend, vectortostring(vectors[2]) + " * 4 = " + vectortostring(multiply(vectors[2], 4)) + "\n");
        File.AppendAllText(fileend, vectortostring(vectors[3]) + " / 3 = " + vectortostring(devision(vectors[3], 3)) + "\n");
    }
}