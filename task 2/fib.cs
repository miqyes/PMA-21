namespace task_2
{
    public static class Fibonacci
    {
        private const int Limit = 100;

        public static int GetLimit(string stepPath)
        {
            string steps = File.ReadAllText(stepPath).Trim();
            int stepCount = int.Parse(steps);

            if (stepCount > Limit)
            {
                throw new ArgumentException($"Amount of steps ({stepCount}) is greater than {Limit}");
            }

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