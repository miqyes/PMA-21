using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class FileManager
{
    const string SEPARATOR = " ";

    public static ArrayList LoadListFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        int[] numbers = [.. lines[0]
            .Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)];

        ArrayList list = new ArrayList();

        foreach (int number in numbers)
        {
            list.Add(number);
        }

        return list;
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}