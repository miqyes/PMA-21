class Program
{
    static double[,] ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split().Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] row = lines[i].Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(row[j]);
            }
        }

        return matrix;
    }

    static double[,] Add(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return result;
    }

    static double[,] Sub(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }

        return result;
    }

    static double[,] Mult(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = matrixB.GetLength(0);
        int colsB = matrixB.GetLength(1);
        if (colsA != rowsB)
        {
            throw new Exception("Дві матриці можна перемножити між собою тоді і тільки тоді," +
                                " коли кількість стовпців першої матриці дорівнює кількості рядків другої матриці.");
        }

        double[,] result = new double[rowsA, colsB];
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }

    static double[,] Div(double[,] matrixA, double[,] matrixB)
    {
        double[,] inverse = Invert(matrixB);
        return Mult(matrixA, inverse);
    }

    static double[,] Invert(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        if (rows != cols)
        {
            throw new Exception("матриця повинна бути квадратна");
        }

        double[,] expanded = new double[rows, rows * 2];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                expanded[i, j] = matrix[i, j];
            }

            expanded[i, i + rows] = 1;
        }

        for (int i = 0; i < rows; i++)
        {
            int pivot = i;
            for (int j = i + 1; j < rows; j++)
            {
                if (Math.Abs(expanded[j, i]) > Math.Abs(expanded[pivot, i]))
                {
                    pivot = j;
                }
            }

            if (pivot != i)
            {
                for (int k = 0; k < rows * 2; k++)
                {
                    (expanded[i, k], expanded[pivot, k]) = (expanded[pivot, k], expanded[i, k]);
                }
            }

            if (Math.Abs(expanded[i, i]) < 1e-10)
            {
                throw new Exception("матриця вироджена");
            }

            double factor = expanded[i, i];
            for (int k = 0; k < rows * 2; k++)
            {
                expanded[i, k] /= factor;
            }

            for (int j = 0; j < rows; j++)
            {
                if (i != j)
                {
                    double f = expanded[j, i];
                    for (int k = 0; k < rows * 2; k++)
                    {
                        expanded[j, k] -= f * expanded[i, k];
                    }
                }
            }
        }

        double[,] result = new double[rows, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                result[i, j] = expanded[i, j + rows];
            }
        }

        return result;
    }

    static void WriteMatrix(double[,] matrix, StreamWriter file)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                file.Write(matrix[i, j] + " ");
            }

            file.WriteLine();
        }
    }

    static void PrintResult(double[,] matrixA, double[,] matrixB, StreamWriter file, char operation)
    {
        WriteMatrix(matrixA, file);
        file.Write($"{operation}\n");
        WriteMatrix(matrixB, file);
        file.Write($"=\n");
        switch (operation)
        {
            case '+':
                WriteMatrix(Add(matrixA, matrixB), file);
                break;
            case '-':
                WriteMatrix(Sub(matrixA, matrixB), file);
                break;
            case '*':
                WriteMatrix(Mult(matrixA, matrixB), file);
                break;
            case '/':
                WriteMatrix(Div(matrixA, matrixB), file);
                break;
            default:
                throw new Exception($"операція {operation} не розпізнано");
        }

        file.WriteLine();
    }

    static void Main()
    {
        double[,] matrixA = ReadMatrix("MatrixA.txt");
        double[,] matrixB = ReadMatrix("MatrixB.txt");
        StreamWriter file = new StreamWriter("result.txt");

        PrintResult(matrixA, matrixB, file, '+');
        PrintResult(matrixA, matrixB, file, '-');
        PrintResult(matrixA, matrixB, file, '*');
        PrintResult(matrixA, matrixB, file, '/');

        file.Close();

        Console.WriteLine("Готово");
    }
}