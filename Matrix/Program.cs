
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
            double[,] a = new double[ra,ca];
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
            double[,] addres = Matrix.add(a, b, ra, ca);
            double[,] subres = Matrix.sub(a, b, ra, ca);
            double[,] mulres = Matrix.mul(a, b, ra, ca, cb);
            double[,] divres = Matrix.div(a, b, ra, ca);

        static void res(string act, double[,] matrix)
            {
                string text = act + " =\n";
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        text += matrix[i, j] + " ";
                    text += "\n";
                }

                File.AppendAllText("outputmatrix.txt",text);
            }

            File.WriteAllText("outputmatrix.txt", string.Empty);
            res("A + B", addres);
            res("A - B", subres);
            res("A * B", mulres);
            res("A / B", divres);
        }
    }
}
