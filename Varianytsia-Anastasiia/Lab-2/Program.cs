using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        double[][] vectors = FileManager.LoadVectorFromFile(inputPath);
        double[] v1 = vectors[0];
        double[] v2 = vectors[1];

        if (v1.Length != v2.Length)
        {
            Console.WriteLine("Помилка: вектори мають різну довжину.");

            return;
        }

        double[] vectorSum = VectorCalculator.Add(v1, v2);
        double[] subtractionResult = VectorCalculator.Subtract(v1, v2);
        double[] multipliedVector = VectorCalculator.Multiply(v1, v2);
        double[] divisionResult = VectorCalculator.Divide(v1, v2);

        
        string strV1 = VectorCalculator.ToString(v1);
        string strV2 = VectorCalculator.ToString(v2);

        List<string> results =
        [
            strV1 + "+" + strV2 + "= " + VectorCalculator.ToString(vectorSum),
            strV1 + "-" + strV2 + "= " + VectorCalculator.ToString(subtractionResult),
            strV1 + "*" + strV2 + "= " + VectorCalculator.ToString(multipliedVector),
            strV1 + "/" + strV2 + "= " + VectorCalculator.ToString(divisionResult),
        ];

        FileManager.SaveResultToFile(outputPath, results);
    }
}