namespace Fibonacci;

public class FibonacciHelper
{
    public static void FibonacciSteps(long a, long b, int steps, StreamWriter output)
    {
        if (steps == 0) return;
        long c = a + b;

        output.Write("," + c);

        FibonacciSteps(b, c, steps - 1, output);
    }

    public static void FibonacciLimit(long a, long b, long limit, StreamWriter output)
    {
        long c = a + b;

        if (c > limit)
            return;

        output.Write("," + c);

        FibonacciLimit(b, c, limit, output);
    }
}