public static class FileWorker
{
    public static double[,] ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);

        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        double[,] m = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            double[] row = lines[i].Split(' ').Select(double.Parse).ToArray();

            for (int j = 0; j < cols; j++)
            {
                m[i, j] = row[j];
            }
        }
        return m;
    }

    public static void WriteResults(string fileName, string[] lines)
    {
        File.WriteAllLines(fileName, lines);
    }
}
