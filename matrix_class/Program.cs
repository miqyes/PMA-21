class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        var fileService = new MatrixFileService();
        var calc = new MatrixCalculator();

        List<Matrix> matrices = fileService.ReadMatricesFromFile("input.txt");

        Matrix a = matrices[0];
        Matrix b = matrices[1];

        Matrix sum = calc.Add(a, b);
        Matrix diff = calc.Subtract(a, b);
        Matrix prod = calc.Multiply(a, b);
        Matrix div = calc.Divide(a, b);

        using (var writer = new StreamWriter("result.txt"))
        {
            fileService.AppendOperationLog(writer, "Матриця A:", a);
            fileService.AppendOperationLog(writer, "Матриця B:", b);

            fileService.AppendOperationLog(writer, "1) Додавання (A + B):", sum);
            fileService.AppendOperationLog(writer, "2) Віднімання (A - B):", diff);
            fileService.AppendOperationLog(writer, "3) Множення (A * B):", prod);
            fileService.AppendOperationLog(writer, "4) Ділення (A / B):", div);
        }

        Console.WriteLine("Готово! Результати збережено у файл result.txt");
    }
}