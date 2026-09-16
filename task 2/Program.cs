namespace task_2
{
    class Program
    {
        static int Main()
        {
            string inputText = File.ReadAllText("input.txt").Trim();
            string[] parts = inputText.Split(',');
            List<int> numbers = new List<int>
            {
                int.Parse(parts[0].Trim()),
                int.Parse(parts[1].Trim())
            };
            int stepCount = Fibonacci.GetLimit("steps.txt");

            List<int> result = Fibonacci.FibValue(numbers, stepCount);

            string outputText = string.Join(",", result);
            File.WriteAllText("output.txt", outputText);

            Console.WriteLine(outputText);

            return 0;
        }
    }
}