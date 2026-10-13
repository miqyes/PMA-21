namespace task_2
{
    class Program
    {
        private const string InputFile = "input.txt";
        private const string StepsFile = "steps.txt";
        private const string OutputFile = "output.txt";

        static void Main()
        {
            List<int> numbers = File.ReadAllText(InputFile)
                .Split(',')
                .Select(int.Parse)
                .ToList();

            int stepCount = File.ReadLines(StepsFile)
                .Select(int.Parse)
                .First();

            List<int> result = Fibonacci.FibValue(numbers, stepCount);

            string outputText = string.Join(",", result);
            File.WriteAllText(OutputFile, outputText);

            Console.WriteLine(outputText);
        }
    }
}