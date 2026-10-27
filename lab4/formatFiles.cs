namespace matrix
{
    class Format
    {
        public static double[,] ReadMatrix(string fileName)
        {
            string[] fileLines = File.ReadAllLines(fileName);
            int rows = fileLines.Length;
            int columns = fileLines[0].Split(' ').Length;
            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] numbers = fileLines[i].Split(' ');

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = double.Parse(numbers[j]);
                }
            }

            return matrix;
        }

        public static void WriteMatrix(StreamWriter writer, double[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    writer.Write(matrix[i, j] + " ");
                }

                writer.WriteLine();
            }
        }
    }
}
