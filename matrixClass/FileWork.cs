namespace matrixClass;

public class FileWork
{
    public static void saveToFile(StreamWriter sw, string fileName, Matrix matrix)
    {
        sw.WriteLine(fileName);
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                sw.Write($"{matrix[i,j]} ");
            }
            sw.WriteLine();
        }
        sw.WriteLine();
    }

    public static Matrix readFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new Exception("Файл не знайдено");
        }

        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        string[] firstRowElement = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int cols = firstRowElement.Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] rowElement = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Convert.ToDouble(rowElement[j].Trim());
            }
            
        }

        return new Matrix(matrix);
    }
}
