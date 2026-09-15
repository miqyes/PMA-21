namespace fibonachi
{
    class Program
    {
        public static void Main()
        {
            if (!File.Exists("input.txt") || !File.Exists("steps.txt"))
            {
                Console.WriteLine("Error: files are not found!");
                return;
            }

            string input = File.ReadAllText("input.txt");
            string steps = File.ReadAllText("steps.txt");

            string[] numbers = input.Split(',');
            if (numbers.Length != 2)
            {
                Console.WriteLine("Error: in file 'input.txt' must be 2 numbers!");
                return;
            }

            int firstNum = int.Parse(numbers[0]);
            int secondNum = int.Parse(numbers[1]);
            int numOfSteps = int.Parse(steps);

            if (firstNum < 0 || secondNum < 0 || numOfSteps < 0)
            {
                Console.WriteLine("Error: numbers can't be negative!");
                return;
            }
            List<int> stepsList = new List<int> { firstNum, secondNum };
            fibonachi.bySteps(stepsList, numOfSteps - 2);

            Console.Write("Enter limit: ");
            int limit = int.Parse(Console.ReadLine());

            List<int> limitList = new List<int> { firstNum, secondNum };
            fibonachi.byLimit(limitList, limit);

            string stepsResult = "By steps: " + string.Join(", ", stepsList);
            string limitResult = "By limit: " + string.Join(", ", limitList);

            string result = stepsResult + Environment.NewLine + limitResult;

            File.WriteAllText("result.txt", result);

            Console.WriteLine("Result is successfully saved in file 'result.txt'");
        }
    }
}