using System;
using System.IO;
namespace TaskThree;

static class Matrix {
    public static int[,] ReadMatrixFromFile(string filePath) {
        string[] lines = File.ReadAllLines(filePath);
        int[,] matrix = new int[2, 2];

        for (int i = 0; i < 2; i++) {
            string[] numbers = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 2; j++) {
                    matrix[i, j] = int.Parse(numbers[j]);
                }
            }
            return matrix;
        }

    public static string Print<T>(T[,] matrix) {
        string result = "";
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                    result += matrix[i, j].ToString() + " ";
                }
                result += "\n";
        }
        return result;
    }

    public static int[,] SumMatrix(int[,] a, int[,] b) {
        int[,] result = new int[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < a.GetLength(1); j++) {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    public static int[,] SubMatrix(int[,] a, int[,] b) {
        int[,] result = new int[a.GetLength(0), a.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < a.GetLength(1); j++) {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    public static int[,] MultMatrix(int[,] a, int[,] b) {
        int[,] result = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++) {
            for (int j = 0; j < b.GetLength(1); j++) {
                for (int k = 0; k < a.GetLength(1); k++) {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    public static double Determinant(int[,] m) {
        return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
    }
    public static double[,] Inverse(int[,] m)
    {
        double det = Determinant(m);
        if (det == 0) {
            throw new DivideByZeroException("Визначник дорівнює нулю. Оберненої матриці не існує (ділення на нуль).");
        }
        double[,] inv = new double[2, 2];
        inv[0, 0] = m[1, 1] / det;
        inv[0, 1] = -m[0, 1] / det;
        inv[1, 0] = -m[1, 0] / det;
        inv[1, 1] = m[0, 0] / det;

        return inv;
    }
    public static double[,] DivMatrix(int[,] a, int[,] b) {
        double[,] inv = Inverse(b);
        double[,] result = new double[2, 2];

        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                for (int k = 0; k < 2; k++) {
                    result[i, j] += a[i, k] * inv[k, j];
                }
            }
        }
    return result;
    }
}

class Calculation {
    static void Main(string[] args) {
        int[,] a = Matrix.ReadMatrixFromFile("MatOne.txt");
        int[,] b = Matrix.ReadMatrixFromFile("MatTwo.txt");

        string result = $"Sum (A + B):\n{Matrix.Print(Matrix.SumMatrix(a, b))}\n" +
                        $"Sub (A - B):\n{Matrix.Print(Matrix.SubMatrix(a, b))}\n" +
                        $"Mult (A * B):\n{Matrix.Print(Matrix.MultMatrix(a, b))}\n" +
                        $"Div (A / B):\n{Matrix.Print(Matrix.DivMatrix(a, b))}";
            
        File.WriteAllText("Results.txt", result);  
        Console.WriteLine("Calculations is completed. Results saved to Results.txt");
    }
}
