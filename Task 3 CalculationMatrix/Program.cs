class Program
{
    static void Main()
    {
        string input = "Input.txt";
        string output = "Output.txt";
        float[][][] matrixes = Read.ReadMatrixes(input);

        MatrixWriter.Write(output, matrixes[0], "*", matrixes[1], Matrix.Multiply(matrixes[0], matrixes[1]));
        MatrixWriter.Write(output, matrixes[0], "*", matrixes[6], Matrix.Multiply(matrixes[0], matrixes[6]));
        MatrixWriter.Write(output, matrixes[0], "+", matrixes[1], Matrix.Add(matrixes[0], matrixes[1]));
        MatrixWriter.Write(output, matrixes[1], "-", matrixes[0], Matrix.Subtract(matrixes[1], matrixes[0]));


        try
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[3], Matrix.Divide(matrixes[2], matrixes[3]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[3], "You can't divide by a singular matrix");
        }

        try
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[6], Matrix.Divide(matrixes[2], matrixes[6]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[2], "/", matrixes[6], "You can't divide by a singular matrix");
        }

        try
        {
            MatrixWriter.Write(output, matrixes[1], "/", matrixes[5], Matrix.Divide(matrixes[1], matrixes[5]));
        }
        catch (InvalidOperationException)
        {
            MatrixWriter.Write(output, matrixes[1], "/", matrixes[5], "You can't divide by a singular matrix");
        }
       
    }
}
