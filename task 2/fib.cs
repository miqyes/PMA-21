namespace task_2
{
    public static class Fibonacci
    {
        public static List<int> GetLimit(List<int> val, int limit)
        {
            int next = val[^1] + val[^2];

            if (next > limit)
            {
                return val;
            }

            val.Add(next);

            return GetLimit(val, limit);
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