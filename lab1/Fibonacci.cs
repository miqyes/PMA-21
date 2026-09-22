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
            int nextNum = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
            if (nextNum > lim)
            {
                return numbers;
            }
            numbers.Add(nextNum);
            return Limit(numbers, lim);
        }
    }
}