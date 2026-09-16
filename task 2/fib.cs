namespace task_2
{
    public static class Fibonacci
    {
        private const int Limit = 100;

        private static void ValidateLimit(int stepCount)
        {
            if (stepCount > Limit)
            {
                throw new ArgumentException($"Amount of steps ({stepCount}) is greater than {Limit}");
            }
        }

        public static int GetLimit(string stepPath)
        {
            int stepCount = File.ReadLines(stepPath)
                .Select(int.Parse)
                .First();

            ValidateLimit(stepCount);
            return stepCount;
        }

        public static List<int> FibValue(List<int> val, int stepCount)
        {
            if (val.Count >= stepCount)
            {
                return val;
            }

            int next = val[^1] + val[^2];
            val.Add(next);

            return FibValue(val, stepCount);
        }
    }
}