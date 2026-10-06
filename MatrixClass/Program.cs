namespace MatrixClass
{
    class Program
    {
        static void Main()
        {
            double[,] matrixA;
            double[,] matrixB;

            try
            {
                matrixA = Matrix.ReadMatrix("matrixOne.txt");
                matrixB = Matrix.ReadMatrix("matrixTwo.txt");

                Matrix matrix = new Matrix(matrixA);

                Matrix second = new Matrix(matrixB);

                Matrix addResult = matrix.AddMatrix(second);
                Matrix subResult = matrix.SubMatrix(second);
                Matrix multResult = matrix.MultMatrix(second);
                Matrix divResult = matrix.DivMatrix(second);
                
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine("\nAddition:");
                    Matrix.WriteMatrix(sw, matrixA);
                    sw.WriteLine("+");
                    Matrix.WriteMatrix(sw, matrixB);
                    sw.WriteLine("=");
                    Matrix.WriteMatrix(sw, addResult.matr);
                    
                    sw.WriteLine("\nSubtraction:");
                    Matrix.WriteMatrix(sw, matrixA);
                    sw.WriteLine("-");
                    Matrix.WriteMatrix(sw, matrixB);
                    sw.WriteLine("=");
                    Matrix.WriteMatrix(sw, subResult.matr);
                    
                    sw.WriteLine("\nMultiplication:");
                    Matrix.WriteMatrix(sw, matrixA);
                    sw.WriteLine("*");
                    Matrix.WriteMatrix(sw, matrixB);
                    sw.WriteLine("=");
                    Matrix.WriteMatrix(sw, multResult.matr);
                    
                    sw.WriteLine("\nDivision:");
                    Matrix.WriteMatrix(sw, matrixA);
                    sw.WriteLine("/");
                    Matrix.WriteMatrix(sw, matrixB);
                    sw.WriteLine("=");
                    Matrix.WriteMatrix(sw, divResult.matr);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: cannot find file!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
