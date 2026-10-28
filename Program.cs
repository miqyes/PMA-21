namespace matrixClas
{
    public class Program
    {
        public static void Main(string[] args)
        {
     
                string lines = File.ReadAllText("matrixCl.txt");
                string[] parts = lines.Replace("\r", "").Split('\n');
                Matrix<double> matrixA = new Matrix<double>(parts[0] + "\n" + parts[1]);
                Matrix<double> matrixB = new Matrix<double>(parts[3] + "\n" + parts[4]);
                string result = $"Add+:\n{Matrix<double>.Print<double>(matrixA.Add(matrixB).Values)}\n" + $"Sub-:\n{Matrix<double>.Print<double>(matrixA.Sub(matrixB).Values)}\n" + $"Multiply*:\n{Matrix<double>.Print<double>(matrixA.Multiply(matrixB).Values)}\n" + $"Divide/:\n{Matrix<double>.Print<double>(matrixA.Divide(matrixB))}\n";
                File.WriteAllText("resultM.txt", result);
            
            
        }
    }
}