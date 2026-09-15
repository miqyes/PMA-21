using System;

namespace fibonachi
{
    public static class fibonachi
    {
        public static List<int> bySteps(List<int> list, int count)
        {
            if (count <= 0)
            {
                return list;
            }

            list.Add(list[list.Count - 1] + list[list.Count - 2]);
            return bySteps(list, count - 1);
        }
        public static List<int> byLimit(List<int> list, int limit)
        {
            int nextValue = list[list.Count - 1] + list[list.Count - 2];

            if (nextValue > limit)
            {
                return list;
            }

            list.Add(nextValue);
            return byLimit(list, limit);
        }
    }
}
