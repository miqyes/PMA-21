namespace fibonachi;

class FibonachiTask
{
    public static List<int> fibonachi(int steps, List<int> numbers)
    {
        if (steps <= 2)
            return numbers;

        numbers.Add(numbers[^1] + numbers[^2]);
        return fibonachi(steps - 1, numbers);
    }

    public static List<int> limit(int lim, List<int> numbers)
    {
        int nextValue = numbers[^1] + numbers[^2];

        if (nextValue > lim)
            return numbers;

        numbers.Add(nextValue);
        return limit(lim, numbers);
    }
}