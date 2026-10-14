using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace FibonacciApp
{
    class Program
    {
        static void Main()
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Error: input.txt is missing.");
                return;
            }

            BigInteger[] initialNumbers = File.ReadAllText("input.txt")
                .Split(new char[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            if (initialNumbers.Length < 2)
            {
                Console.WriteLine("Error: input.txt must contain at least 2 numbers.");
                return;
            }

            if (!File.Exists("steps.txt") || !int.TryParse(File.ReadAllText("steps.txt").Trim(), out int count) || count < 2)
            {
                Console.WriteLine("Error steps are missed or lower than 2.");
                return;
            }

            BigInteger limit = File.Exists("limit.txt")
                ? BigInteger.Parse(File.ReadAllText("limit.txt").Trim())
                : BigInteger.Pow(10, 100);

            if (initialNumbers[0] > limit || initialNumbers[1] > limit)
            {
                Console.WriteLine("Error: initial numbers exceed the limit.");
                return;
            }

            // 1. Генерація за кількістю кроків
            List<BigInteger> numbersBySteps = new List<BigInteger> { initialNumbers[0], initialNumbers[1] };
            FibonacciGenerator.GenerateByCount(count, numbersBySteps);

            // 2. Генерація до максимального значення (ліміту)
            List<BigInteger> numbersByLimit = new List<BigInteger> { initialNumbers[0], initialNumbers[1] };
            FibonacciGenerator.GenerateByLimit(limit, numbersByLimit);

            // Перевірка чи вистачило кроків для досягнення ліміту
            if (numbersBySteps.Count < numbersByLimit.Count)
            {
                Console.WriteLine($"Error: steps count ({count}) is too small to reach the limit ({limit}).");
                return;
            }

            // Окреме збереження у два файли
            FibonacciGenerator.SaveToFile(numbersBySteps, "output_steps.txt");
            FibonacciGenerator.SaveToFile(numbersByLimit, "output_limit.txt");

            Console.WriteLine($"Saved {numbersBySteps.Count} numbers to output_steps.txt");
            Console.WriteLine($"Saved {numbersByLimit.Count} numbers to output_limit.txt");
        }
    }
}