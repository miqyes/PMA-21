using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        double[][] vectors = FileManager.LoadVectorFromFile(inputPath);
        double[] vectorOne = vectors[0];
        double[] vectorTwo = vectors[1];

        if (vectorOne.Length != vectorTwo.Length)
        {
            Console.WriteLine("Помилка: вектори мають різну довжину.");

            return;
        }

        double[] vectorSum = VectorCalculator.Add(vectorOne, vectorTwo);
        double[] subtractionResult = VectorCalculator.Subtract(vectorOne, vectorTwo);
        double[] multipliedVector = VectorCalculator.Multiply(vectorOne, vectorTwo);

        string strV1 = VectorCalculator.ToString(vectorOne);
        string strV2 = VectorCalculator.ToString(vectorTwo);

        List<string> results =
        [
            strV1 + "+" + strV2 + "= " + VectorCalculator.ToString(vectorSum),
            strV1 + "-" + strV2 + "= " + VectorCalculator.ToString(subtractionResult),
            strV1 + "*" + strV2 + "= " + VectorCalculator.ToString(multipliedVector),
        ];

        if (VectorCalculator.HasZero(vectorTwo))
        {
            results.Add("Ділення неможливе: у другому векторі є нуль.");
        }
        else
        {
            double[] divisionResult = VectorCalculator.Divide(vectorOne, vectorTwo);
            results.Add(strV1 + " / " + strV2 + " = " + VectorCalculator.ToString(divisionResult));
        }

        FileManager.SaveResultToFile(outputPath, results);
    }
}