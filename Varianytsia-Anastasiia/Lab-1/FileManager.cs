using System.IO;
using System.Collections.Generic;

class FileManager
{
    public static int[] GetInitialNumbersFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        int first = int.Parse(lines[0]);
        int second = int.Parse(lines[1]);

        return [first, second];
    }

    public static int GetLimitNumberFromFile(string filePath)
    {
        string text = File.ReadAllText(filePath).Trim();

        return int.Parse(text);
    }

    public static void SaveResultToFile(string filePath, List<int> numbers)
    {
        string textToWrite = string.Join(", ", numbers);

        File.WriteAllText(filePath, textToWrite);

        Console.WriteLine("Результат збережено у " + filePath);
    }
}