using System.Collections.Generic;

class Calculator
{
    public static List<int> FibonacciByLimit(int limit, List<int> list)
    {
        int last = list[^1];
        int previous = list[^2];

        int nextNumber = last + previous;

        if (nextNumber > limit)
        {
            return list;
        }

        list.Add(nextNumber);

        return FibonacciByLimit(limit, list);
    }
    public static List<int> FibonacciByCount(int count, List<int> list)
    {
        if (count <= 0)
        {
            return list;
        }

        list.Add(list[^1] + list[^2]);
        return FibonacciByCount(count - 1, list);
    }
}