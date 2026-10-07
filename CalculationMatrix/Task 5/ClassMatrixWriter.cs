class MatrixWriter
{
    public static void Write(string path, Matrix firstMatrix, string sign, Matrix secondMatrix, Matrix result)
    {
        string[] firstLines = firstMatrix.ToString().Split('\n');
        string[] secondLines = secondMatrix.ToString().Split('\n');
        string[] resultLines = result.ToString().Split('\n');
        string text = "";
        for (int r = 0; r < 2; r++)
        {
            string mark = r == 0 ? "  " + sign + "  " : "     ";
            string equal = r == 0 ? "  =  " : "     ";
            text += firstLines[r] + mark + secondLines[r] + equal + resultLines[r] + "\n";
        }
        File.AppendAllText(path, text + "\n");
    }

    public static void Write(string path, Matrix firstMatrix, string sign, Matrix secondMatrix, string error)
    {
        string[] firstLines = firstMatrix.ToString().Split('\n');
        string[] secondLines = secondMatrix.ToString().Split('\n');

        string text = "";
        for (int r = 0; r < 2; r++)
        {
            string mark = r == 0 ? "  " + sign + "  " : "     ";
            string equal = r == 0 ? "  =  " + error : "";
            text += firstLines[r] + mark + secondLines[r] + equal + "\n";
        }
        File.AppendAllText(path, text + "\n");
    }
}
