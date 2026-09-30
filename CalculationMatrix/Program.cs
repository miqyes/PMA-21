class Program
{
    static void Main()
    {
        string input = "Input.txt";
        string output = "output.txt";
        Matrix[] matrixes = Read.ReadMatrixes(input);

        MatrixWriter.Write(output, matrixes[0], "*", matrixes[1], matrixes[0].Multiply(matrixes[1]));
        MatrixWriter.Write(output, matrixes[0], "*", matrixes[6], matrixes[0].Multiply(matrixes[6]));
        MatrixWriter.Write(output, matrixes[0], "+", matrixes[1], matrixes[0].Add(matrixes[1]));
        MatrixWriter.Write(output, matrixes[1], "-", matrixes[0], matrixes[1].Subtract(matrixes[0]));

        try
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[3], matrixes[2].Divide(matrixes[3]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[3], "You can't divide by a singular matrix");
        }

        try
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[6], matrixes[2].Divide(matrixes[6]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[6], "You can't divide by a singular matrix");
        }

        try
        {
            MatrixWriter.Write(output, matrixes[1], "/", matrixes[5], matrixes[1].Divide(matrixes[5]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[1], "/", matrixes[5], "You can't divide by a singular matrix");
        }
    }
}
