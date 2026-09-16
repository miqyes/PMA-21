using System.IO;
using System.Collections.Generic;

class FileManager
{
    const string INPUT_FILE = "input.txt";
    const string LIMIT_FILE = "limit.txt";
    const string COUNT_FILE = "count.txt";  
    const string OUTPUT_FILE = "output.txt";

    public static int[] GetInitialNumbersFromFile()
    {
        string[] lines = File.ReadAllLines(INPUT_FILE);

        int first = int.Parse(lines[0]);
        int second = int.Parse(lines[1]);

        return [first, second];
    }

    public static int GetLimitNumberFromFile()
    {
        string text = File.ReadAllText(LIMIT_FILE).Trim();

        return int.Parse(text);
    }

    public static int GetCountFromFile()
    {
        string text = File.ReadAllText(COUNT_FILE).Trim();
        return int.Parse(text);
    }

    public static void SaveResultToFile(List<string> lines)
    {
        File.WriteAllLines(OUTPUT_FILE, lines);

        Console.WriteLine("Результат збережено у " + OUTPUT_FILE);
    }
}