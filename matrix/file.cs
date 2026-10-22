public static class MatrixFileService
{
    public static void ReadMtrx(string path, out double[,] matA, out string op, out double[,] matB)
    {
        string[] lines = File.ReadAllLines(path);

        List<string[]> rowsA = new List<string[]>();
        List<string[]> rowsB = new List<string[]>();
        op = "";
        bool foundOp = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (line == "")
                continue;

            if (line == "+" || line == "-" || line == "*" || line == "/")
            {
                op = line;
                foundOp = true;
                continue;
            }

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!foundOp)
                rowsA.Add(parts);
            else
                rowsB.Add(parts);
        }

        if (!foundOp || rowsA.Count == 0 || rowsB.Count == 0)
            throw new Exception("Некоректний формат файлу.");

        matA = new double[rowsA.Count, rowsA[0].Length];
        for (int i = 0; i < rowsA.Count; i++)
        {
            for (int j = 0; j < rowsA[0].Length; j++)
            {
                matA[i, j] = Convert.ToDouble(rowsA[i][j]);
            }
        }

        matB = new double[rowsB.Count, rowsB[0].Length];
        for (int i = 0; i < rowsB.Count; i++)
        {
            for (int j = 0; j < rowsB[0].Length; j++)
            {
                matB[i, j] = Convert.ToDouble(rowsB[i][j]);
            }
        }
    }

    public static void WriteResult(string path, double[,] result)
    {
        int rows = result.GetLength(0);
        int cols = result.GetLength(1);

        using var sw = new StreamWriter(path);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sw.Write($"{result[i, j]:F2}\t");
            }
            sw.WriteLine();
        }
    }
}