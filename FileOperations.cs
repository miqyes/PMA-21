namespace VectorClass;

public class FileOperations
{
    public static double[] ReadFromFile(string fileName)
    {
        string[] coordinates = File.ReadAllText(fileName).Split(',');
        if (coordinates.Length < 1)
        {
            throw new InvalidDataException("Error: you must have at least 1 coordinate!");
        }
        int n = coordinates.Length;
        double[] vector = new double[n];
        for (int i = 0; i < n; i++)
        {
            vector[i] = double.Parse(coordinates[i]);
        }
        return vector;
    }
}