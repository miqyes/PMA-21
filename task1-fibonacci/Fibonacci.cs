using System.Numerics;

namespace Task1Fibonacci;

class Fibonacci
{
    public static List<BigInteger> Generate(int count, List<BigInteger> numbers)
    {
        if (numbers.Count < 2) throw new ArgumentException("Need at least two starting numbers", nameof(numbers));
        if (numbers.Count >= count) return numbers;

        numbers.Add(numbers[numbers.Count - 1] + numbers[numbers.Count - 2]);
        return Generate(count, numbers);
    }

    public static List<BigInteger> GenerateLimit(int limit, List<BigInteger> numbers)
    {
        if (numbers.Count < 2) throw new ArgumentException("Need at least two starting numbers", nameof(numbers));

        BigInteger next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
        if (next > limit) return numbers;

        numbers.Add(next);
        return GenerateLimit(limit, numbers);
    }
}