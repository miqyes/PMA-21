using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        double[,] matrixOne = FileManager.GetFirstMatrixFromFile();
        double[,] matrixTwo = FileManager.GetSecondMatrixFromFile();

        List<string> results = [];

        if (MatrixCalculator.HaveSameDimensions(matrixOne, matrixTwo))
        {
            double[,] sumMatrix = MatrixCalculator.Add(matrixOne, matrixTwo);
            results.Add("--- Додавання (A + B) ---");
            results.Add(MatrixCalculator.ToString(sumMatrix));
            results.Add(string.Empty);

            double[,] subtractionMatrix = MatrixCalculator.Subtract(matrixOne, matrixTwo);
            results.Add("--- Віднімання (A - B) ---");
            results.Add(MatrixCalculator.ToString(subtractionMatrix));
            results.Add(string.Empty);
        }
        else
        {
            results.Add("Додавання та віднімання неможливі: матриці мають різні розміри.");
            results.Add(string.Empty);
        }

        if (MatrixCalculator.CanMultiply(matrixOne, matrixTwo))
        {
            double[,] multiplicationMatrix = MatrixCalculator.Multiply(matrixOne, matrixTwo);
            results.Add("--- Множення (A * B) ---");
            results.Add(MatrixCalculator.ToString(multiplicationMatrix));
            results.Add(string.Empty);
        }
        else
        {
            results.Add("Множення неможливе: кількість стовпців матриці A не дорівнює кількості рядків матриці B.");
            results.Add(string.Empty);
        }
        
        //  A / B = A * B^(-1)
        if (!MatrixCalculator.IsSquare(matrixTwo))
        {
            results.Add("Ділення неможливе: матриця B не є квадратною.");
        }
        else if (!MatrixCalculator.CanMultiply(matrixOne, matrixTwo))
        {
            results.Add("Ділення неможливе: розміри матриць несумісні.");
        }
        else
        {
            double[,] divisionMatrix = MatrixCalculator.Divide(matrixOne, matrixTwo);
            if (divisionMatrix == null)
            {
                results.Add("Ділення неможливе: детермінант матриці B дорівнює нулю (оберненої матриці не існує).");
            }
            else
            {
                results.Add("--- Ділення (A / B = A * B^(-1)) ---");
                results.Add(MatrixCalculator.ToString(divisionMatrix));
            }
        }

        FileManager.SaveResultToFile(results);
    }
}