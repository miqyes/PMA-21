using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class FileManager
{
    const string SEPARATOR = " ";

    public static Vector[] LoadVectorFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        double[] elementsOne = [.. lines[0]
            .Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)];

        double[] elementsTwo = [.. lines[1]
            .Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)];

        return [new Vector(elementsOne), new Vector(elementsTwo)];
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}