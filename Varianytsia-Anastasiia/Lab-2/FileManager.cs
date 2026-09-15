using System.IO;
using System.Collections.Generic;

class FileManager
{
    public static double[][] LoadVectorFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        string[] parts1 = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] v1 = new double[parts1.Length];

        for (int i = 0; i < parts1.Length; i++)
        {
            v1[i] = double.Parse(parts1[i]);
        }

        string[] parts2 = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] v2 = new double[parts2.Length];
        
        for (int i = 0; i < parts2.Length; i++)
        {
            v2[i] = double.Parse(parts2[i]);
        }

        return [v1, v2];
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}