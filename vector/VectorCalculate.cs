using System;

namespace vector
{
    class VectorCalculate
    {
        public static double[] addVector(double[] firstVector, double[] secondVector)
        {
            if (firstVector.Length != secondVector.Length)
            {
                throw new ArgumentException("Різна довжина векторів");
            }
            double[] result = new double[firstVector.Length];
            for (int i = 0; i < firstVector.Length; i++)
            {
                result[i] = firstVector[i] + secondVector[i];
            }

            return result;
        }

        public static double[] subtractVector(double[] firstVector, double[] secondVector)
        {
            double[] result = new double[firstVector.Length];
            for (int i = 0; i < firstVector.Length; i++)
            {
                result[i] = firstVector[i] - secondVector[i];
            }
            return result;
        }

        public static double[] multiplyVector(double[] firstVector, double[] secondVector)
        {
            double[] result = new double[firstVector.Length];
            for (int i = 0; i < firstVector.Length; i++)
            {
                result[i] = firstVector[i] * secondVector[i];
            }
            return result;
        }

        public static double[] divisionVector(double[] firstVector, double[] secondVector)
        {
            double[] result = new double[firstVector.Length];
            for (int i = 0; i < firstVector.Length; i++)
            {
                if (secondVector[i] == 0)
                {
                    throw new DivideByZeroException(" Ділення на нуль не можливе");
                }
                result[i] = firstVector[i] / secondVector[i];
            }
            return result;
        }
    }
}
