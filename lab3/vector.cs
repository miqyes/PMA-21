using System;

namespace vector
{
    public class vector
    {
        public double[] components;

        public int Size => components.Length;

        public vector(double[] components)
        {
            this.components = components;
        }

        public double this[int index]
        {
            get => components[index];
            set => components[index] = value;
        }

        private static void CheckSameSize(vector a, vector b)
        {
            if (a.Size != b.Size)
                throw new ArgumentException("Vectors must have the same dimension!");
        }

        public static vector operator +(vector a, vector b)
        {
            CheckSameSize(a, b);
            double[] result = new double[a.Size];
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] + b[i];
            return new vector(result);
        }

        public static vector operator -(vector a, vector b)
        {
            CheckSameSize(a, b);
            double[] result = new double[a.Size];
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] - b[i];
            return new vector(result);
        }

        public static vector operator *(vector a, vector b)
        {
            CheckSameSize(a, b);
            double[] result = new double[a.Size];
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] * b[i];
            return new vector(result);
        }

        public static vector operator /(vector a, vector b)
        {
            CheckSameSize(a, b);
            double[] result = new double[a.Size];
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] / b[i];
            return new vector(result);
        }

        public override string ToString()
        {
            return "(" + string.Join(",", components) + ")";
        }
    }
}
