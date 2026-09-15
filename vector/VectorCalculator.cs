using System;
using System.Collections.Generic;
using System.Text;

namespace program
{
    public static class VectorOperations
    {
        private static void CheckDimensions(double[] a, double[] b)
        {
            if (a.Length != b.Length)
            {
                throw new InvalidOperationException($"Різна розмірність: {a.Length} і {b.Length}");
            }
        }

        public static double[] Add(double[] a, double[] b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i] + b[i];
            }
            return res;
        }

        public static double[] Subtract(double[] a, double[] b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i] - b[i];
            }
            return res;
        }

        public static double[] Multiply(double[] a, double[] b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i] * b[i];
            }
            return res;
        }

        public static double[] Divide(double[] a, double[] b)
        {
            CheckDimensions(a, b);
            double[] res = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i] == 0)
                {
                    throw new DivideByZeroException($"Ділення на нуль у координаті {i}");
                }
                res[i] = a[i] / b[i];
            }
            return res;
        }

        public static string Format(double[] v)
        {
            string s = "(";
            for (int i = 0; i < v.Length; i++)
            {
                s += Math.Round(v[i], 2);
                if (i < v.Length - 1)
                {
                    s += ", ";
                }
            }
            s += ")";
            return s;
        }
    }
}
