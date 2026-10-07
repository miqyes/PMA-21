class Read
{
    public static Matrix[] ReadMatrixes(string path)
    {
        string[] lines = File.ReadAllLines(path).Where(line => line != "").ToArray();
        int count = lines.Length / 2;
        Matrix[] result = new Matrix[count];

        for (int i = 0; i < count; i++)
        {
            float[][] values = new float[2][];
            for (int r = 0; r < 2; r++)
            {
                values[r] = lines[i * 2 + r].Split(' ').Select(float.Parse).ToArray();
            }
            result[i] = new Matrix(values);
        }

        return result;
    }
}
