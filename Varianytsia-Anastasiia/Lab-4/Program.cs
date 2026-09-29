using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Matrix matrixOne = FileManager.GetFirstMatrixFromFile();
        Matrix matrixTwo = FileManager.GetSecondMatrixFromFile();

        List<string> results = [];

        if (Matrix.HaveSameDimensions(matrixOne, matrixTwo))
        {
            Matrix sumMatrix = matrixOne + matrixTwo;
            results.Add("--- Додавання (A + B) ---");
            results.Add(sumMatrix.ToString());
            results.Add(" ");

            Matrix subtractionMatrix = matrixOne - matrixTwo;
            results.Add("--- Віднімання (A - B) ---");
            results.Add(subtractionMatrix.ToString());
            results.Add(" ");
        }
        else
        {
            results.Add("Додавання та віднімання неможливі: матриці мають різні розміри.");
            results.Add(" ");
        }

        if (Matrix.CanMultiply(matrixOne, matrixTwo))
        {
            Matrix multiplicationMatrix = matrixOne * matrixTwo;
            results.Add("--- Множення (A * B) ---");
            results.Add(multiplicationMatrix.ToString());
            results.Add(" ");
        }
        else
        {
            results.Add("Множення неможливе: кількість стовпців матриці A не дорівнює кількості рядків матриці B.");
            results.Add(" ");
        }

        // A / B = A * B^(-1)
        if (!matrixTwo.IsSquare() || matrixTwo.RowsCount != 2)
        {
            results.Add("Ділення неможливе: матриця B повинна бути квадратною порядку 2х2.");
        }
        else if (!Matrix.CanMultiply(matrixOne, matrixTwo))
        {
            results.Add("Ділення неможливе: розміри матриць несумісні.");
        }
        else
        {
            Matrix divisionMatrix = matrixOne / matrixTwo;
            if (divisionMatrix == null)
            {
                results.Add("Ділення неможливе: визначник матриці B дорівнює нулю (оберненої матриці не існує).");
            }
            else
            {
                results.Add("--- Ділення (A / B = A * B^(-1)) ---");
                results.Add(divisionMatrix.ToString());
            }
        }

        FileManager.SaveResultToFile(results);
    }
}