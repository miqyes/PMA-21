using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string INPUT_PATH = "input.txt";
        string OUTPUT_PATH = "output.txt";

        Vector[] vectors = FileManager.LoadVectorFromFile(INPUT_PATH);
        Vector vectorOne = vectors[0];
        Vector vectorTwo = vectors[1];

        if (vectorOne.Length != vectorTwo.Length)
        {
            Console.WriteLine("Помилка: вектори мають різну довжину.");

            return;
        }

        Vector vectorSumWithSteps = vectorOne.AddWithSteps(vectorTwo);
        Vector vectorSubWithSteps = vectorOne.SubtractWithSteps(vectorTwo);
        Vector vectorSum = vectorOne.Add(vectorTwo);
        Vector subtractionResult = vectorOne.Subtract(vectorTwo);
        Vector multipliedVector = vectorOne.Multiply(vectorTwo);

        string strVFirst = vectorOne.ToString();
        string strVSecond = vectorTwo.ToString();

        List<string> results =
        [
            strVFirst + " + " + strVSecond + " (з кроками) = " + vectorSumWithSteps.ToString(),
            strVFirst + "-" + strVSecond + "(з кроками) = " + vectorSubWithSteps.ToString(), 
            strVFirst + "+" + strVSecond + "= " + vectorSum.ToString(),
            strVFirst + "-" + strVSecond + "= " + subtractionResult.ToString(),
            strVFirst + "*" + strVSecond + "= " + multipliedVector.ToString(),
        ];

        if (vectorTwo.HasZero())
        {
            results.Add("Ділення неможливе: у другому векторі є нуль.");
        }
        else
        {
            Vector divisionResult = vectorOne.Divide(vectorTwo);
            results.Add(strVFirst + " / " + strVSecond + " = " + divisionResult.ToString());
        }

        FileManager.SaveResultToFile(OUTPUT_PATH, results);
    }
}