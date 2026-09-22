using System.IO;
using System.Collections.Generic;

class FileManager
{
    const string SEPARATOR = " ";
    public static double[][] LoadVectorFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        string[] partsOne = lines[0].Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
        double[] vectorOne = new double[partsOne.Length];

        for (int i = 0; i < partsOne.Length; i++)
        {
            vectorOne[i] = double.Parse(partsOne[i]);
        }

        string[] partsTwo = lines[1].Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
        double[] vectorTwo = new double[partsTwo.Length];

        for (int i = 0; i < partsTwo.Length; i++)
        {
            vectorTwo[i] = double.Parse(partsTwo[i]);
        }

        return [vectorOne, vectorTwo];
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}