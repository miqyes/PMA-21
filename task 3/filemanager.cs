namespace task_3;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class filemanager
{
    const string Separator = " ";

    public static double[][]? LoadVectorFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"error, file '{filePath}' not found.");
            return null;
        }

        string[] lines = File.ReadAllLines(filePath);
        List<double[]> vectors = new List<double[]>();

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            double[] vector = new double[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                vector[i] = double.Parse(parts[i].Replace(',', '.'), CultureInfo.InvariantCulture);
            }

            vectors.Add(vector);
        }

        if (vectors.Count < 2)
        {
            Console.WriteLine("error, in file must beat least 2 vectors for operation.");
            return null;
        }

        return vectors.ToArray();
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);
        Console.WriteLine($"result saved in: {Path.GetFullPath(filePath)}");
    }
}