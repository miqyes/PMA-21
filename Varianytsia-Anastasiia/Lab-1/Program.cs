class FibonacciCalculator
{
    static int Fibonacci(int n, int first, int second)
    {
        if (n == 0)
        {
            return first;
        }

        if (n == 1)
        {
            return second;
        }

        return Fibonacci(n - 1, first, second) + Fibonacci(n - 2, first, second);
    }

    static void Main(string[] args)
    {
        string filePath = "input.txt";
        string[] lines = File.ReadAllLines(filePath);

        int first = int.Parse(lines[0]);
        int second = int.Parse(lines[1]);
        int count = int.Parse(lines[2]);

        int total = 2 + count;

        for (int i = 0; i < total; i++)
        {
            Console.Write(Fibonacci(i, first, second));

            if (i < total - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }
}
