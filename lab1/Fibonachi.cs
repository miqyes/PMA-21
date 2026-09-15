namespace ConsoleApp1;

public class Fibonachii
{
    public static List<int> RecursiveFib(List<int> fib, int n)
    {
        if (n <= 2)
        {
            return fib;

        }
        else
        {
            fib.Add(fib[^1] + fib[^2]);
            return RecursiveFib(fib, n - 1);
        }
    }
    public static List<int> LimitsFib(List<int> fib1, int lim)
    {
        int t = fib1[^1] + fib1[^2];
        if ( t >= lim)
        {
            return fib1;
        }
        else
        {
            fib1.Add(t);
            return LimitsFib(fib1, lim);
        }
    } 
}
