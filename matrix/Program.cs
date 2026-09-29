namespace Matrix
{
    class Program
    {
        static void Main()
        {
            try
            {
                double[,] matrixA = MatrixOperations.ReadMatrix("matrixOne.txt");
                double[,] matrixB = MatrixOperations.ReadMatrix("matrixTwo.txt");

                int rowsA = matrixA.GetLength(0);
                int colsA = matrixA.GetLength(1);

                int rowsB = matrixB.GetLength(0);
                int colsB = matrixB.GetLength(1);
                
                double[,] addResult = MatrixCalculate.AddMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] subResult = MatrixCalculate.SubMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] multResult = MatrixCalculate.MultMatrix(matrixA, matrixB, rowsA, colsA);
                double[,] divResult = MatrixCalculate.DivMatrix(matrixA, matrixB, rowsA, colsA);

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine("\nAddition:");
                    MatrixOperations.WriteMatrix(sw, matrixA, rowsA, colsA);
                    sw.WriteLine("+");
                    MatrixOperations.WriteMatrix(sw, matrixB, rowsB, colsB);
                    sw.WriteLine("=");
                    MatrixOperations.WriteMatrix(sw, addResult, rowsA, colsA);
                    
                    sw.WriteLine("\nSubtraction:");
                    MatrixOperations.WriteMatrix(sw, matrixA, rowsA, colsA);
                    sw.WriteLine("-");
                    MatrixOperations.WriteMatrix(sw, matrixB, rowsB, colsB);
                    sw.WriteLine("=");
                    MatrixOperations.WriteMatrix(sw, subResult, rowsA, colsA);
                    
                    sw.WriteLine("\nMultiplication:");
                    MatrixOperations.WriteMatrix(sw, matrixA, rowsA, colsA);
                    sw.WriteLine("*");
                    MatrixOperations.WriteMatrix(sw, matrixB, rowsB, colsB);
                    sw.WriteLine("=");
                    MatrixOperations.WriteMatrix(sw, multResult, rowsA, colsA);
                    
                    sw.WriteLine("\nDivision:");
                    MatrixOperations.WriteMatrix(sw, matrixA, rowsA, colsA);
                    sw.WriteLine("/");
                    MatrixOperations.WriteMatrix(sw, matrixB, rowsB, colsB);
                    sw.WriteLine("=");
                    MatrixOperations.WriteMatrix(sw, divResult, rowsA, colsA);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: cannot open file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
