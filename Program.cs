using System;
using System.IO;

namespace Фібоначчі
{
    public class Fibonacci
    {
        public static int Limit;
        public static string generate(int a, int b)
        {
            return a + "," + b + Steps(a, b, 2);
        }
        public static string Steps(int a, int b, int count)
        {
            if (count >= Limit)
            {
                return "";
            }
            int next = a + b;
            return "," + next + Steps(b, next, count + 1);
        }
    }

    public class FileWorker
    {
        public static int ReadLimit(string filename)
        {
            string text = File.ReadAllText(filename);
            return int.Parse(text);
        }
        public static int[] ReadNumbers(string filename)
        {
            string text = File.ReadAllText(filename);
            string[] parts = text.Split(',');

            int[] numbers = new int[2];
            numbers[0] = int.Parse(parts[0]);
            numbers[1] = int.Parse(parts[1]);
            return numbers;
        }
        public static void WriteResult(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci.Limit = FileWorker.ReadLimit("limit.txt");

            int[] numbers = FileWorker.ReadNumbers("input.txt");
            int a = numbers[0];
            int b = numbers[1];

            string result = Fibonacci.generate(a, b);
            Console.WriteLine("Result: " + result);
            FileWorker.WriteResult("result.txt", result);
        }
    }
}