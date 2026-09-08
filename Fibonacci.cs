using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Fibonacci
    {
        public static int[] readNumbers(string path)
        {
            string[] numbers = File.ReadAllText(path).Split();
            int[] ints = new int[numbers.Length];
            for (int i=0; i<numbers.Length; i++)
            {
                ints[i] = int.Parse(numbers[i]);
            }
            return ints;
        }
        public static int readStep(string path)
        {
            string number = File.ReadAllText(path);
            int step = int.Parse(number);
            return step;
        }
        public static void writeFibonacci(string path, List<int> fib)
        {
            File.WriteAllText(path, string.Join(" ", fib));
        }

        // Source - https://stackoverflow.com/a/17634529
        // Posted by Gus
        // Retrieved 2026-09-06, License - CC BY-SA 3.0
        public static void CalculateFibonacci(int a, int b, int counter, int step, List<int> result)
        {
            if (counter > step) return;

            result.Add(a);
            CalculateFibonacci(b, a + b, counter + 1, step, result);
        }
    }
}