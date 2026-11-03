namespace MatrixClass
{
    class Program
    {
        private const string InputFilename = "matrix.txt";
        private const string OutputFilename = "result.txt";

        static Matrix[] ReadTwoMatrices()
        {
            if (!File.Exists(InputFilename))
            {
                File.WriteAllText(OutputFilename, $"Couldn't find file {InputFilename}");
                Environment.Exit(1);
            }

            string input = File.ReadAllText(InputFilename);
            string[] parts = input.Split(["\r\n\r\n"], StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                File.WriteAllText(OutputFilename, "Two matrices are needed in order to run the program");
                Environment.Exit(1);
            }

            Matrix matrixA = ParseMatrix(parts[0]);
            Matrix matrixB = ParseMatrix(parts[1]);

            return new Matrix[]
            {
                matrixA, matrixB
            };
        }

        static Matrix ParseMatrix(string part)
        {
            string[] lines = part.Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;

            string[] firstRowEl = lines[0].Split([" ", "\t"], StringSplitOptions.RemoveEmptyEntries);
            int cols = firstRowEl.Length;

            double[,] tempArray = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] elements = lines[i].Split([" ", "\t"], StringSplitOptions.RemoveEmptyEntries);
                   
                for (int j = 0; j < cols; j++)
                {
                    tempArray[i, j] = double.Parse(elements[j]);
                }
            }

            return new Matrix(tempArray);
        }

        static void SaveMatrixToFile(Matrix matrix)
        {
            string result = "";
            int rows = matrix.RowCount;
            int cols = matrix.ColumnCount;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j] + " ";
                    
                }

                if (i < rows - 1)
                {
                    result += "\r\n";
                }
            }

            result += "\r\n\r\n";
            File.AppendAllText(OutputFilename, result);
        }

        static void Main()
        {
            Matrix[] matrices = ReadTwoMatrices();
            Matrix matrixA = matrices[0];
            Matrix matrixB = matrices[1];

            File.WriteAllText(OutputFilename, "");

            File.AppendAllText(OutputFilename, "Adding\r\n");
            try
            {
                Matrix addingRes = matrixA + matrixB;
                SaveMatrixToFile(addingRes);
            }
            
            catch (Exception ex)
            {
                File.AppendAllText(OutputFilename, ex.Message + "\r\n\r\n");
            }

            File.AppendAllText(OutputFilename, "Subtraction\r\n");
            try
            {
                Matrix subRes = matrixA - matrixB;
                SaveMatrixToFile(subRes);
            }
            catch (Exception ex)
            {
                File.AppendAllText(OutputFilename, ex.Message + "\r\n\r\n");
            }

            File.AppendAllText(OutputFilename, "Multiplying\r\n");
            try
            {
                Matrix mulRes = matrixA * matrixB;
                SaveMatrixToFile(mulRes);
            }
            catch (Exception ex)
            {
                File.AppendAllText(OutputFilename, ex.Message + "\r\n\r\n");
            }

            File.AppendAllText(OutputFilename, "Dividing\r\n");
            try
            {
                Matrix divRes = matrixA / matrixB;
                SaveMatrixToFile(divRes);
            }
            catch (Exception ex)
            {
                File.AppendAllText(OutputFilename, ex.Message);
            }
        }
    }
}
