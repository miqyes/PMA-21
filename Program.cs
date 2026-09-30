namespace matrix;

class Program
{
    const string FileMatrixA="matrixA.txt";
    const string FileMatrixB="matrixB.txt";
    const string ResultFile="result.txt";

    static void Main()
    {
        try
        {
            double[,] matrixA = ReadMatrix(FileMatrixA);
            double[,] matrixB = ReadMatrix(FileMatrixB);
            double[,] matrixSum = Matrix.add(matrixA, matrixB);
            double[,] matrixSubtraction = Matrix.subtraction(matrixA, matrixB);
            double[,] matrixMultiply = Matrix.multiply(matrixA, matrixB);
            double[,] matrixDivision = Matrix.division(matrixA, matrixB);
            WriteResultToFile(ResultFile, matrixA, matrixB, matrixSum, matrixSubtraction, matrixMultiply,
                matrixDivision);
        }

         catch (Exception ex)
        {
            Console.WriteLine(ex.Message); 
        }
    }


    static double[,] ReadMatrix(string file)
    {
        if (!File.Exists(file))
        {
            throw new FileNotFoundException("File is not found" + file);
        }
        string[] lines = File.ReadAllLines(file);
        int rows= lines.Length;
        string[] elementsInRow=lines[0].Split(' ');
        int cols = elementsInRow.Length;
        double[,]matrix=new double[rows,cols];
        for (int i = 0; i < rows; i++) {
            string[] elements=lines[i].Split(' ');
            for (int j = 0; j < cols; j++) {
                matrix[i,j]=Convert.ToDouble(elements[j]);
            }
        }
        return matrix;
    }
    static string MatrixToString(double[,] m) 
    { 
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                sb.Append(m[i, j] + "\t");
            sb.AppendLine();
        }
        return sb.ToString();
    }
   

    static void WriteResultToFile(string resultfile, double[,] matrixA, double[,] matrixB, double[,] matrixSum, double[,] matrixSubtraction, double[,] matrixMultiply, double[,] matrixDivision)
    {
        using (StreamWriter writer = new StreamWriter(resultfile, append: false))
        {
            writer.WriteLine("Matrix A : ");
            writer.WriteLine(MatrixToString(matrixA));
            writer.WriteLine("Matrix B : ");
            writer.WriteLine(MatrixToString(matrixB));
            if (matrixSum == null)
            {
                
                writer.WriteLine("A + B : Operation is failed\n");
            }
            else
            {
                writer.WriteLine("A + B : ");
                writer.WriteLine(MatrixToString(matrixSum));;
            }
            if (matrixSubtraction == null)
            {
                
                writer.WriteLine("A - B : Operation is failed\n");
            }
            else
            {
                writer.WriteLine("A - B : ");
                writer.WriteLine( MatrixToString(matrixSubtraction));;
            }
            if ( matrixMultiply == null)
            {
                
                writer.WriteLine("A * B : Operation is failed\n");
            }
            else
            {
                writer.WriteLine("A * B : ");
                writer.WriteLine(MatrixToString( matrixMultiply));;
            }
            
            if ( matrixDivision == null)
            {
                
                writer.WriteLine("A / B : Operation is failed\n");
            }
            else
            { 
                writer.WriteLine( "A / B : ");
                writer.WriteLine(MatrixToString( matrixDivision));;
            }
        }
    }
  

}