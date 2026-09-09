using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Fibonacci
    {
        public static List <int> CalculateFibonacci(int step, List<int> result)
        {
            if (step == 0) return result;

            result.Add(result[^1] + result[^2]);
            return CalculateFibonacci(step - 1, result);
        }

        public static List<int> CalculateFibonacciLimitations(int limit, List<int> result)
        {
            if (result[^1] > limit) return result;

            result.Add(result[^1] + result[^2]);
            return CalculateFibonacciLimitations(limit, result);
        }

    }
}
