using System;
using System.IO;

namespace Vector_C_
{
    public class FileWorker
    {
        public static Vector ReadVector(string line)
        {
            string[] parts = line.Split(',');
            double[] numbers = new double[parts.Length];
            for(int i = 0; i < parts.Length; i++)
            {
                numbers[i] = double.Parse(parts[i]);
            }
            return new Vector(numbers);
        }

        public static void Result(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
        }
    }
}