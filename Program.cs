using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ClassMatrixCalculator
{
    class Program
    {
        static string MatrixToString(Matrix m)
        {
            string result = "";

            foreach (List<float> row in m.getMatrix())
            {
                foreach (float value in row)
                {
                    result += value + " ";
                }

                result += "\n";
            }

            return result;
        }

        static List<List<float>> ReadMatrixFromFile(string fileName)
        {



            string[] matrixRows = File.ReadAllLines(fileName);

            List<List<float>> matrix = new List<List<float>>();

            foreach (string row in matrixRows)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }

                List<float> rowElements = row
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(float.Parse)
                    .ToList();

                matrix.Add(rowElements);
            }

            return matrix;
        }






        static void Main()
            {
                const string RESULT_FILE = "resultMatrix.txt";
                List<List<float>> firstMatrix = new List<List<float>>();
                List<List<float>> secondMatrix = new List<List<float>>();
                List<List<float>> thirdMatrix = new List<List<float>>();

                firstMatrix = ReadMatrixFromFile("firstMatrix.txt");

                secondMatrix = ReadMatrixFromFile("secondMatrix.txt");



                Matrix first = new Matrix(firstMatrix);
                Matrix second = new Matrix(secondMatrix);
                Matrix matrix = first;
                Matrix resultMatrix;

               

                try
                {
                    resultMatrix = Matrix.SumMatrix(first, second);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                File.WriteAllText(RESULT_FILE, "Sum matrix: \n" + MatrixToString(resultMatrix) + "\n");

                try
                {
                    resultMatrix = Matrix.ProductMatrix(first, second);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                File.AppendAllText(RESULT_FILE, "Product matrix: \n" + MatrixToString(resultMatrix) + "\n");

                try
                {
                    resultMatrix = Matrix.DifferenceMatrix(first, second);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                File.AppendAllText(RESULT_FILE, "Difference matrix: \n" + MatrixToString(resultMatrix) + "\n");

                try
                {
                    resultMatrix = Matrix.InverseMatrix(matrix);


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                File.AppendAllText(RESULT_FILE, "Inverse matrix:\n" + MatrixToString(resultMatrix) + "\n");

                try
                {
                    resultMatrix = Matrix.DivisionMatrix(first, second);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                File.AppendAllText(RESULT_FILE, "Division matrix: \n" + MatrixToString(resultMatrix) + "\n");






            }
        }
    }
