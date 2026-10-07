
namespace ConsoleApp
{
    class Program
    {
        const string INPUT_FILE = "input.txt";
        const string STEPS_FILE = "steps.txt";
        const string LIMITS_FILENAME= "limits.txt";
        const string RESULT_FILENAME = "result.txt";
            
        static void Main()
        { 
            string input = File.ReadAllText(INPUT_FILE);
           string[] parts = input.Split(" ");
           int firstsum = int.Parse(parts[0]);
           int secondsum = int.Parse(parts[1]);
           
           string steps = File.ReadAllText(STEPS_FILE);
           int stepСount = int.Parse(steps);
           
           List<int> numbers = new List<int> {firstsum,secondsum};
           string limitText = File.ReadAllText(LIMITS_FILENAME);
           int limit = int.Parse(limitText);
           List<int> countResult = Fibonacci.FibonacciCount(numbers, stepСount);
           List<int> limitResult = Fibonacci.FibonacciLimit([firstsum, secondsum], limit);
           string result = "For steps: " + string.Join(" ", countResult) + "\n" + "For limit: " + string.Join(" ", limitResult);
           File.WriteAllText(RESULT_FILENAME, result);
           
        }
        
    }
}
