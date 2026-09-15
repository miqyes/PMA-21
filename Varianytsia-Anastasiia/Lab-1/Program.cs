using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string limitPath = "limit.txt";
        string outputPath = "output.txt";

        int[] initialNumbers = FileManager.GetInitialNumbersFromFile(inputPath);
        int first = initialNumbers[0];
        int second = initialNumbers[1];

        int limit = FileManager.GetLimitNumberFromFile(limitPath);

        if (first > limit)
        {
            Console.WriteLine("Помилка: перше число більше за заданий ліміт.");

            FileManager.SaveResultToFile(outputPath, new List<int>());

            return;
        }

        List<int> numbers = [first];

        if (second <= limit)
        {
            numbers.Add(second);

            numbers = Calculator.Fibonacci(limit, numbers);
        }
        else
        {
            Console.WriteLine("Друге число більше за ліміт, тому воно не буде додане до списку.");
        }
    
        FileManager.SaveResultToFile(outputPath, numbers);
    }
}