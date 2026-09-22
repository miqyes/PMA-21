using ConsoleApp1;

class Program
{
    static void PrintResult(Matrix matrixA, Matrix matrixB, StreamWriter file, char operation)
    {
        matrixA.WriteMatrix(file);
        file.Write($"{operation}\n");
        matrixB.WriteMatrix(file);
        file.Write($"=\n");
        switch (operation)
        {
            case '+':
                matrixA.Add(matrixB).WriteMatrix(file);
                break;
            case '-':
                matrixA.Sub(matrixB).WriteMatrix(file);
                break;
            case '*':
                matrixA.Mult(matrixB).WriteMatrix(file);
                break;
            case '/':
                matrixA.Div(matrixB).WriteMatrix(file);
                break;
            default:
                throw new Exception($"операція {operation} не розпізнано");
        }

        file.WriteLine();
    }

    static void Main()
    {
        Matrix matrixA = Matrix.ReadMatrix("MatrixA.txt");
        Matrix matrixB = Matrix.ReadMatrix("MatrixB.txt");
        StreamWriter file = new StreamWriter("result.txt");

        PrintResult(matrixA, matrixB, file, '+');
        PrintResult(matrixA, matrixB, file, '-');
        PrintResult(matrixA, matrixB, file, '*');
        PrintResult(matrixA, matrixB, file, '/');

        file.Close();

        Console.WriteLine("Готово");
    }
}