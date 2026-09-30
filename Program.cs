using System;

namespace Фібоначчі
{
    class Program
    {
        private const string limitFilename = "limit.txt";
        private const string inputFilename = "input.txt";
        private const string resultFilename = "result.txt";
        private const string stepsFilename = "steps.txt";
        static void Main(string[] args)
        {
            int stepsValue = FileWorker.ReadNumber(stepsFilename);
            int LimitValue= FileWorker.ReadNumber(limitFilename);

            int[] InitialNumber = FileWorker.ReadNumbers(inputFilename);

            List<int> countSeq = Fibonacci.Count(stepsValue, new List<int>(InitialNumber));
            string countResult = string.Join(",", countSeq);

            List<int> limitSeq = Fibonacci.Limit(LimitValue, new List<int>(InitialNumber));
            string limitResult = string.Join(",", limitSeq);

            Console.WriteLine("Result of steps: " + countResult);
            Console.WriteLine("Result of limit: " + limitResult);

            string finalResult = "Count: " + countResult + "\nLimit: " + limitResult;
            FileWorker.WriteResult(resultFilename, finalResult);
        }
    }
}