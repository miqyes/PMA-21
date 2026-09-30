namespace task_3;

using System;
using System.Collections.Generic;

class Program
{
    private const string InputPath = "input.txt";
    private const string OutputPath = "output.txt";

    static void Main()
    {
        double[][]? vectors = filemanager.LoadVectorFromFile(InputPath);
        if (vectors == null)
        {
            return;
        }

        List<string> results = new List<string>();

        for (int i = 0; i < vectors.Length - 1; i++)
        {
            double[] vectorOne = vectors[i];
            double[] vectorTwo = vectors[i + 1];

            if (vectorOne.Length != vectorTwo.Length)
            {
                Console.WriteLine($"error: vectors in pair {i + 1} та {i + 2} have diff lenght.");
                continue;
            }

            results.Add($"Pair {i + 1} and {i + 2}");

            double[] sum = vc.Add(vectorOne, vectorTwo);
            double[] diff = vc.Subtract(vectorOne, vectorTwo);
            double[] mult = vc.Multiply(vectorOne, vectorTwo);
            string[] div = vc.Divide(vectorOne, vectorTwo);

            string strV1 = vc.ToString(vectorOne);
            string strV2 = vc.ToString(vectorTwo);

            results.Add($"{strV1} + {strV2} = {vc.ToString(sum)}");
            results.Add($"{strV1} - {strV2} = {vc.ToString(diff)}");
            results.Add($"{strV1} * {strV2} = {vc.ToString(mult)}");
            results.Add($"{strV1} / {strV2} = {vc.ToString(div)}");

            if (i < vectors.Length - 2)
            {
                results.Add("");
            }
        }

        filemanager.SaveResultToFile(OutputPath, results);
    }
}