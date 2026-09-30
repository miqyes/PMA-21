using System;

namespace Vector_C_
{
    public class Vector
    {
        public double[] elements;

        public Vector(double[] elements)
        {
            this.elements = elements;
        }

        public static Vector Add(Vector FirstVector, Vector SecondVector)
        {
            if (FirstVector.elements.Length != SecondVector.elements.Length)
            {
                Console.WriteLine("Vector of different sizes!");
                return null;
            }

            double[] res = new double[FirstVector.elements.Length];
            for (int i = 0; i < FirstVector.elements.Length; i++)
            {
                res[i] = FirstVector.elements[i] + SecondVector.elements[i];
            }
            return new Vector(res);
        }

        public static Vector Subtract(Vector FirstVector, Vector SecondVector)
        {
            if (FirstVector.elements.Length != SecondVector.elements.Length)
            {
                Console.WriteLine("Vector of different sizes!");
                return null;
            }

            double[] res = new double[FirstVector.elements.Length];
            for (int i = 0; i < FirstVector.elements.Length; i++)
            {
                res[i] = FirstVector.elements[i] - SecondVector.elements[i];
            }
            return new Vector(res);
        }

        public static Vector Multiply(Vector FirstVector, Vector SecondVector)
        {
            int MinLength = Math.Min(FirstVector.elements.Length, SecondVector.elements.Length);
            double[] res = new double[MinLength];

            for (int i = 0; i < MinLength; i++)
            {
                res[i] = FirstVector.elements[i] * SecondVector.elements[i];
            }
            return new Vector(res);
        }

        public static Vector Divide(Vector FirstVector, Vector SecondVector)
        {
            int MinLength = Math.Min(FirstVector.elements.Length, SecondVector.elements.Length);
            double[] res = new double[MinLength];

            for (int i = 0; i < MinLength; i++)
            {
                if (SecondVector.elements[i] == 0)
                {
                    Console.WriteLine("You cannot divide by 0!");
                    return null;
                }
                res[i] = FirstVector.elements[i] / SecondVector.elements[i];
            }
            return new Vector(res);
        }

        public string ToVector()
        {
            return $"({string.Join(",", elements)})";
        }
    }
}