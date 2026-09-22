namespace lab15._09;

public static class Files
{
    public static double[][] ReadVectors(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found: " + filePath);
        }

        string[] lines = File.ReadAllLines(filePath);
        double[][] vectors = new double[lines.Length][];
        char[] skip = { ' ', ',', ';', '(', ')' };

        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(skip, StringSplitOptions.RemoveEmptyEntries);
            vectors[i] = new double[parts.Length];

            for (int j = 0; j < parts.Length; j++)
            {
                vectors[i][j] = double.Parse(parts[j]);
            }
        }

        return vectors;
    }

    public static void WriteLines(string filePath, string[] lines)
    {
        File.WriteAllLines(filePath, lines);
    }
}