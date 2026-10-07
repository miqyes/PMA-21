class Read
{
    public static float[][][] ReadMatrixes(string path)
    {
        string[] lines = File.ReadAllLines(path).Where(line => line != "").ToArray();
        int count = lines.Length / 2;
        float[][][] result = new float[count][][];

        for (int i = 0; i < count; i++)
        {
            result[i] = new float[2][];
            for (int r = 0; r < 2; r++)
            {
                result[i][r] = lines[i * 2 + r].Split(' ').Select(float.Parse).ToArray();
            }
        }

        return result;
    }
}