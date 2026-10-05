using matrixclass;

namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string input = "inputmatrix.txt";
            
            string[] lines = File.ReadAllLines(input);
            int ra = int.Parse(lines[0]);
            int ca = ra;
            double[,] a = new double[ra, ca];
            for (int i = 0; i < ra; i++)
            {
                string[] row = lines[i+1].Split(' ');
                for (int j = 0; j < ca; j++)
                {
                    a[i, j] = double.Parse(row[j]);
                }
            }

            int rb = int.Parse(lines[ra + 2]);
            int cb = rb;
            double[,] b = new double[rb, cb];
            for (int i = 0; i < rb; i++)
            { 
                string[] row = lines[ra + 3 + i].Split(' ');
                for (int j = 0; j < cb; j++)
                {
                    b[i, j] = double.Parse(row[j]);
                }
            }

            Matrix first = new Matrix(a);
            Matrix second = new Matrix(b);
            
            File.WriteAllText("outputmatrix.txt", string.Empty);
            Matrix.result("A + B", first.add(second));
            Matrix.result("A - B", first.sub(second));
            Matrix.result("A * B", first.mul(second));
            Matrix.result("A / B", first.div(second));
        }
    }
}