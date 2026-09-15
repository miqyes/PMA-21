namespace ConsoleApp4
{
    public class Fibonacci
    {
        public static List<int> Recursion(List<int> numbers, int steps)
        {
            if (steps == 0)
            {
                return numbers;
            }
            int nextNum = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
            numbers.Add(nextNum);
            return Recursion(numbers, steps - 1);

        }
        public static List<int> Limit(List<int> numbers, int lim)
        {
            while (numbers[numbers.Count - 1] > lim)
            {
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers;
        }

    }
}