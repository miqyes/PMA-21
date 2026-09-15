using System.Collections.Generic;

class Calculator
{
    public static List<int> Fibonacci(int limit, List<int> list)
    {
        int last = list[^1];
        int previous = list[^2];

        int nextNumber = last + previous;

        if (nextNumber > limit)
        {
            return list;
        }

        list.Add(nextNumber);

        return Fibonacci(limit, list);
    }
}