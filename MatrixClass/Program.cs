using matrixclass;

namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string input = "inputmatrix.txt";
            if (File.Exists(input))
            {
                Console.WriteLine("File exists");
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
            
            string[] lines = File.ReadAllLines(input);
            int ra = 2;
            int ca = 2;
            double[,] a = new double[ra, ca];
            for (int i = 0; i < ra; i++)
            {
                string[] row = lines[i].Split(' ');
                for (int j = 0; j < ca; j++)
                {
                    a[i, j] = double.Parse(row[j]);
                }
            }
            
            int rb = 2;
            int cb = 2;
            double[,] b = new double[rb, cb];
            for (int i = 0; i < rb; i++)
            { 
                string[] row = lines[ra + 1 + i].Split(' ');
                for (int j = 0; j < cb; j++)
                {
                    b[i, j] = double.Parse(row[j]);
                }
            }

            Matrix matrixres = new Matrix(a, b, ra, ca, rb, cb);
            File.WriteAllText("outputmatrix.txt", string.Empty);
            matrixres.result("A + B", matrixres.add());
            matrixres.result("A - B", matrixres.sub());
            matrixres.result("A * B", matrixres.mul());
            matrixres.result("A / B", matrixres.div());
        }
    }
}
