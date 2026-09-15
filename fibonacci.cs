using System;
using System.IO; 
using System.Collections.Generic;

namespace UNI
{

    public class Fibonacci
    {
        private const int limit = 100;

        public static int GetLimit(string steppath)
        {
            string steps = File.ReadAllText(steppath).Trim();
            int stepCount = int.Parse(steps);

            if (stepCount > limit)
            {
                throw new ArgumentException($"Amount of steps ({stepCount}) is greater {limit}");
            }
            return stepCount;
        }

        public static List<int> FibValue(List<int> val, int stepCount)
        {
            if (val.Count >= stepCount)
            {
                return val;
            }

            int newel = val[^1] + val[^2];
            val.Add(newel);
            return FibValue(val, stepCount);
        }
    }
}