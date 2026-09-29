namespace Matrix;

public static class MatrixOperations
{
    public static double[,] ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] nums = lines[i].Split(' ');
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(nums[j]);
            }
        }
        return matrix;
    }
    public static void WriteMatrix(StreamWriter sw, double[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sw.Write(matrix[i,j] + " ");
            }
            sw.WriteLine();
        }
    }
}