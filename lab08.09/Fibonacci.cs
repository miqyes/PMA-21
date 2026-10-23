using System.Collections.Generic;
using System.Numerics;

class Fibonacci
{
    public static void Generate(int count, List<BigInteger> numbers)
    {
        if (numbers.Count >= count) return;
        
        BigInteger next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
        numbers.Add(next);

        Generate(count, numbers);
    }
}