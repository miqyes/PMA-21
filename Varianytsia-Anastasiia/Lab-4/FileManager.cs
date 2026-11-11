using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class FileManager
{
    const string SEPARATOR = " ";
    const string FIRST_MATRIX_FILE = "matrixA.txt";
    const string SECOND_MATRIX_FILE = "matrixB.txt";
    const string OUTPUT_FILE = "output.txt";

    public static Matrix GetFirstMatrixFromFile()
    {
        return ReadMatrix(FIRST_MATRIX_FILE);
    }

    public static Matrix GetSecondMatrixFromFile()
    {
        return ReadMatrix(SECOND_MATRIX_FILE);
    }

    private static Matrix ReadMatrix(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        int rowsCount = lines.Length;
        int columnsCount = lines[0].Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries).Length;

        Matrix matrix = new(rowsCount, columnsCount);

        for (int row = 0; row < rowsCount; row++)
        {
            double[] rowValues = [.. lines[row]
                .Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
                .Select(value => double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture))];

            for (int column = 0; column < columnsCount; column++)
            {
                matrix[row, column] = rowValues[column];
            }
        }

        return matrix;
    }

    public static void SaveResultToFile(List<string> lines)
    {
        File.WriteAllLines(OUTPUT_FILE, lines);
        
        Console.WriteLine("Результат збережено у " + OUTPUT_FILE);
    }
}