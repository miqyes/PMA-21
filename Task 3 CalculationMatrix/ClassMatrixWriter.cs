class MatrixWriter
{
    public static void Write(string path, float[][] firstMatrix, string sign, float[][] secondMatrix, float[][] resultMatrix)
    {
        string text = "";
        for (int r = 0; r < 2; r++)
        {
            string mark = r == 0 ? "  " + sign + "  " : "     ";
            string equal = r == 0 ? "  =  " : "     ";
            text += string.Join(" ", firstMatrix[r]) + mark + string.Join(" ", secondMatrix[r]) + equal + string.Join(" ", resultMatrix[r]) + "\n";
        }
        File.AppendAllText(path, text + "\n");
    }
    public static void Write(string path, float[][] firstMatrix, string sign, float[][] secondMatrix, string error)
    {
        string text = "";
        for (int r = 0; r < 2; r++)
        {
            string mark = r == 0 ? "  " + sign + "  " : "     ";
            string equal = r == 0 ? "  =  " + error : "";
            text += string.Join(" ", firstMatrix[r]) + mark + string.Join(" ", secondMatrix[r]) + equal + "\n";
        }
        File.AppendAllText(path, text + "\n");
    }
}
