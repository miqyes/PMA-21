using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    class Fibonacci
    {
        public static List<int> GenerateCount(List<int> numbers, int steps, int limit)
        {
            if (steps <= 0) {
                return numbers;
            }
            int next = numbers[numbers.Count -1] + numbers[numbers.Count -2];
            if (next > limit)
            {
                return numbers;
            }
            numbers.Add(next);
            return GenerateCount(numbers, steps - 1, limit);
        }
        public static List<int> GenerateLimit(List<int> numbers, int limit)
        {
            if (numbers[numbers.Count - 1] >= limit) {
                return numbers;
            }
            numbers.Add(numbers[numbers.Count - 1] + numbers[numbers.Count - 2]);
            return GenerateLimit(numbers, limit);


        }
    }

}
