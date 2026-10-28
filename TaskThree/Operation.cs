using System;
using System.IO;
namespace TaskThree;

public static class MatrixOperations {
    public static double[,] ReadMatrix(string fileName) {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++) {
            string[] nums = lines[i].Split(' ');
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = double.Parse(nums[j]);
            }
        }
        return matrix;
    }

    public static void WriteOperations(StreamWriter sw, double[,] matrixA, string op, double[,] matrixB, double[,] result, int rows, int cols) {
        int middleRow = rows / 2; 
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
            sw.Write($"{matrixA[i, j],3:0.##} "); 
            }
            sw.Write(i == middleRow ? $"  {op}  " : "     ");
            for (int j = 0; j < cols; j++) {
                sw.Write($"{matrixB[i, j],3:0.##} ");
            }
            sw.Write(i == middleRow ? "  =  " : "     ");
            for (int j = 0; j < cols; j++) {
                sw.Write($"{result[i, j],3:0.##} ");
            }
            sw.WriteLine();
        }
    }
}
