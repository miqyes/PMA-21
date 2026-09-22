using Fibonacci;

class Program
{
    static void Main()
    {
        string[] numbers = File.ReadAllText("input.txt").Split();

        long a = long.Parse(numbers[0]);
        long b = long.Parse(numbers[1]);

        int steps = int.Parse(File.ReadAllText("steps.txt"));

        //try with resources
        using (StreamWriter output = new StreamWriter("output.txt"))
        {
            output.Write(a + "," + b);

            FibonacciHelper.FibonacciSteps(a, b, steps, output);
        }
    }
}