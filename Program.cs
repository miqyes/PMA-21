namespace  matrix;

class Program
{
    public static void saveMatrixToFile(StreamWriter sw, string fileName, double[,] matrix)
    {
        sw.WriteLine(fileName);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sw.Write($"{matrix[i, j]} ");
            }
            sw.WriteLine();
        }
        sw.WriteLine();
    }
    public static double[,] readMatrixFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new Exception("Не знайдено файлу.");
        }
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        string[] firstRowElements = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int cols = firstRowElements.Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] rowsElement = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Convert.ToDouble(rowsElement[j]);
            }
        }
        return matrix;
    }
    const string firstMatrixFile = "firstMatrix.txt";
    const string secondMatrixFile = "secondMatrix.txt";

    static void Main()
    {
        try
        {
            double[,] firstMatrix = readMatrixFromFile(firstMatrixFile);
            double[,] secondMatrix = readMatrixFromFile(secondMatrixFile);
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                saveMatrixToFile(sw, "Перша матриця: ", firstMatrix);
                saveMatrixToFile(sw, "Друга матриця: ", secondMatrix);
                try
                {
                    double[,] add = Operation.add(firstMatrix, secondMatrix);
                    saveMatrixToFile(sw, "Додавання: ", add);
                    double[,] difference = Operation.difference(firstMatrix, secondMatrix);
                    saveMatrixToFile(sw, "Віднімання: ", difference);
                }
                catch (ArgumentException ex)
                {
                    sw.WriteLine($"Помилка: {ex.Message}");
                }

                try
                {
                    double[,] multiply = Operation.multiply(firstMatrix, secondMatrix);
                    saveMatrixToFile(sw, "Множення ", multiply);
                }
                catch (ArgumentException ex)
                {
                    sw.WriteLine($"Помилка: {ex.Message}");
                }

                try
                {
                    double[,] division = Operation.division(firstMatrix, secondMatrix);
                    saveMatrixToFile(sw, "Ділення (множення на обернену матрицю)", division);
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"Помилка: {ex.Message}");
                }
            }

            Console.WriteLine("Записано у файл");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Помилка : {ex.Message}"); 
        }
    }
}