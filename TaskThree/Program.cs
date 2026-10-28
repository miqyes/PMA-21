using System;
using System.IO;
namespace TaskThree;
    class Program {
        static void Main() {
            try {
                double[,] matrixA = MatrixOperations.ReadMatrix("MatrixOne.txt");
                double[,] matrixB = MatrixOperations.ReadMatrix("MatrixTwo.txt");

                int rowsA = matrixA.GetLength(0);
                int colsA = matrixA.GetLength(1);

                int rowsB = matrixB.GetLength(0);
                int colsB = matrixB.GetLength(1);
                
                double[,] addResult = MatrixCalculate.AddMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] subResult = MatrixCalculate.SubMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] multResult = MatrixCalculate.MultMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] divResult = MatrixCalculate.DivMatrix(matrixA, matrixB, rowsA, colsA);

                using (StreamWriter sw = new StreamWriter("Result.txt")) {
                    sw.WriteLine("Addition:");
                    MatrixOperations.WriteOperations(sw, matrixA, "+", matrixB, addResult, rowsA, colsA);
                    
                    sw.WriteLine("\nSubtraction:");
                    MatrixOperations.WriteOperations(sw, matrixA, "-", matrixB, subResult, rowsA, colsA);
                    
                    sw.WriteLine("\nMultiplication:");
                    MatrixOperations.WriteOperations(sw, matrixA, "*", matrixB, multResult, rowsA, colsA);
                    
                    sw.WriteLine("\nDivision:");
                    MatrixOperations.WriteOperations(sw, matrixA, "/", matrixB, divResult, rowsA, colsA);
                }
            }
            catch (FileNotFoundException) {
                Console.WriteLine("Error: cannot open file");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Calculation is completed. Results saved to 'Result.txt'."); 
        }
    }
