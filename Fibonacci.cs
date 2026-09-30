namespace Фібоначчі
{
    public class Fibonacci
    {
        public static List<int> Count(int count, List<int> seq)
        {
            if (count == 0)
            {
                return seq;
            }
            int next = seq[seq.Count - 1] + seq[seq.Count - 2];
            seq.Add(next);
            return Count(count - 1, seq);

        }
        public static List<int> Limit(int limit, List<int> seq)
        {
            int next = seq[seq.Count - 1] + seq[seq.Count - 2];
            if (next > limit)
            {
                return seq;
            }
            seq.Add(next);
            return Limit(limit, seq);
        }
    }
}
