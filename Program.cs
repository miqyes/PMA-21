using System;
using System.Collections.Generic;
using System.IO;
namespace Laboratorna1;
class Program
{
    public static int[] readFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("файла не iснує");
        }
        string text = File.ReadAllText(fileName);
        string[] parts = text.Split(',');
        int[] number = new int[parts.Length];
        for(int i = 0; i<parts.Length; i++)
        {
            number[i] = Convert.ToInt32(parts[i].Trim());
        }
        return number;

    }
     static void Main()
    {
        string input = "input.txt";
        string steps = "steps.txt";
        string limit = "limit.txt";
        string result = "result.txt";
        int[] inputNumbers = readFromFile(input);
        int[] stepsNumbers = readFromFile(steps);
        List<int> list = new List<int>(inputNumbers);
        int countStep = stepsNumbers[0];
        int[] limitNumbers = readFromFile(limit);
        int countLimit = limitNumbers[0];
        using (StreamWriter sw = new StreamWriter(result))

        {
            sw.WriteLine("Числа фiбоначчi для рекурсії: " + string.Join(", ", fibonacci.recursive(list, countStep)));
            sw.Write("Числа фiбоначчi з лімітом: " + string.Join(", ", fibonacci.limitFibonacci(list, countLimit)));
        }
        Console.WriteLine("Данi записано у файл");
     
    }
}