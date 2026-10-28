public static class FileWorker
{
    public static Matrix ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        double[,] data = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            double[] row = lines[i].Split(' ').Select(double.Parse).ToArray();
            for (int j = 0; j < cols; j++)
            {
                data[i, j] = row[j];
            }
        }
        return new Matrix(data);
    }

    public static void WriteResults(string fileName, string[] results)
    {
        File.WriteAllLines(fileName, results);
    }
}
