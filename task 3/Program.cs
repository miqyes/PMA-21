namespace task_3;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class FileManager
{
    const string Separator = " ";

    public static double[][]? LoadVectorFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"[ПОМИЛКА] Файл '{filePath}' не знайдено.");
            return null;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length < 2)
        {
            Console.WriteLine("[ПОМИЛКА] У файлі має бути щонайменше 2 рядки з векторами.");
            return null;
        }

        string[] partsOne = lines[0].Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        double[] vectorOne = new double[partsOne.Length];
        for (int i = 0; i < partsOne.Length; i++)
        {
            vectorOne[i] = double.Parse(partsOne[i], CultureInfo.InvariantCulture);
        }

        string[] partsTwo = lines[1].Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        double[] vectorTwo = new double[partsTwo.Length];
        for (int i = 0; i < partsTwo.Length; i++)
        {
            vectorTwo[i] = double.Parse(partsTwo[i], CultureInfo.InvariantCulture);
        }

        return [vectorOne, vectorTwo];
    }

    public static void SaveResultToFile(string filePath, List<string> results)
    {
        File.WriteAllLines(filePath, results);
        Console.WriteLine($"Результат збережено у: {Path.GetFullPath(filePath)}");
    }
}

class Program
{
    private const string InputPath = "input.txt";
    private const string OutputPath = "output.txt";

    static void Main()
    {
        double[][]? vectors = FileManager.LoadVectorFromFile(InputPath);
        if (vectors == null)
        {
            return;
        }

        double[] vectorOne = vectors[0];
        double[] vectorTwo = vectors[1];

        if (vectorOne.Length != vectorTwo.Length)
        {
            Console.WriteLine("Помилка: вектори мають різну розмірність.");
            return;
        }

        double[] vectorSum = vc.Add(vectorOne, vectorTwo);
        double[] subtractionResult = vc.Subtract(vectorOne, vectorTwo);
        double[] multipliedVector = vc.Multiply(vectorOne, vectorTwo);

        string strV1 = vc.ToString(vectorOne);
        string strV2 = vc.ToString(vectorTwo);

        List<string> results =
        [
            strV1 + " + " + strV2 + " = " + vc.ToString(vectorSum),
            strV1 + " - " + strV2 + " = " + vc.ToString(subtractionResult),
            strV1 + " * " + strV2 + " = " + vc.ToString(multipliedVector)
        ];

        if (vc.HasZero(vectorTwo))
        {
            results.Add("Ділення неможливе: у другому векторі є нуль.");
        }
        else
        {
            double[] divisionResult = vc.Divide(vectorOne, vectorTwo);
            results.Add(strV1 + " / " + strV2 + " = " + vc.ToString(divisionResult));
        }

        FileManager.SaveResultToFile(OutputPath, results);
    }
}