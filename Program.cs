namespace matrixLab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Задаємо імена файлів напряму (або можна брати з args[0], якщо запускаєш через консоль)
                string inputFilePath = "input.txt";
                string outputFilePath = "result.txt";

                // Перевірка наявності файлу та викидання помилки, якщо його немає
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Input file not found at: {inputFilePath}");
                }

                // Зчитування з файлу
                string fileContent = File.ReadAllText(inputFilePath);
                List<double[,]> matrices = Matrix.parseMatricesFromFile(fileContent);

                if (matrices.Count < 2)
                {
                    throw new InvalidOperationException("The file must contain at least two matrices.");
                }

                double[,] matrixA = matrices[0];
                double[,] matrixB = matrices[1];

                // Запис результатів у новий файл
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("INITIAL MATRICES:");
                    writer.WriteLine("Matrix A:");
                    Matrix.writeMatrixToStream(writer, matrixA);

                    writer.WriteLine("Matrix B:");
                    Matrix.writeMatrixToStream(writer, matrixB);
                    writer.WriteLine();

                    // 1. Додавання
                    writer.WriteLine("ADDITION");
                    try
                    {
                        double[,] addResult = Matrix.addMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, addResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform addition: {ex.Message}");
                    }
                    writer.WriteLine();

                    // 2. Віднімання
                    writer.WriteLine("SUBTRACTION");
                    try
                    {
                        double[,] subResult = Matrix.subtractMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, subResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform subtraction: {ex.Message}");
                    }
                    writer.WriteLine();

                    // 3. Множення
                    writer.WriteLine("MULTIPLICATION");
                    try
                    {
                        double[,] mulResult = Matrix.multiplyMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, mulResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform multiplication: {ex.Message}");
                    }
                    writer.WriteLine();

                    // 4. Ділення (множення на обернену)
                    writer.WriteLine("DIVISION");
                    try
                    {
                        double[,] divResult = Matrix.divideMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, divResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform division: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Перехоплення помилки (наприклад, якщо файлу немає) та виведення в консоль англійською
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
