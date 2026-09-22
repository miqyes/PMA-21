using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int[] initialNumbers = FileManager.GetInitialNumbersFromFile();
        int first = initialNumbers[0];
        int second = initialNumbers[1];

        int limit = FileManager.GetLimitNumberFromFile();
        int count = FileManager.GetCountFromFile();

        if (first > limit)
        {
            Console.WriteLine("Помилка: перше число більше за заданий ліміт.");

            FileManager.SaveResultToFile(new List<string>());

            return;
        }

        List<int> numbersByLimit = [first];

        if (second <= limit) {
            numbersByLimit.Add(second);

            numbersByLimit = Calculator.FibonacciByLimit(limit, numbersByLimit);
        } else {
            Console.WriteLine("Друге число більше за ліміт, тому воно не буде додане до списку.");
        }

        List<int> numbersByCount = [first, second];
        numbersByCount = Calculator.FibonacciByCount(count, numbersByCount);

        List<string> outputLines =
        [
            string.Join(", ", numbersByLimit),
            string.Join(", ", numbersByCount)
        ];

        FileManager.SaveResultToFile(outputLines);
    }
}