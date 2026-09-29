
namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string input = "inputmatrix.txt";

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

            static double[,] add(double[,] a, double[,] b, int r, int c)
            {
                if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
                {
                    throw new ArgumentException("Sizes are dif!Error!");
                }

                double[,] res = new double[r, c];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        res[i, j] = a[i, j] + b[i, j];
                    }
                }

                return res;
            }

            static double[,] sub(double[,] a, double[,] b, int r, int c)
            {
                if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
                {
                    throw new ArgumentException("Sizes are dif!Error!");
                }

                double[,] res = new double[r, c];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        res[i, j] = a[i, j] - b[i, j];
                    }
                }

                return res;
            }

            static double[,] mul(double[,] a, double[,] b, int ra, int ca, int cb)
            {
                double[,] res = new double[ra, cb];
                for (int i = 0; i < ra; i++)
                {
                    for (int j = 0; j < cb; j++)
                    {
                        for (int k = 0; k < ca; k++)
                        {
                            res[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }

                return res;
            }

            static double[,] div(double[,] a, double[,] b, int r, int c)
            {
                double[,] newb = new double[r, c];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        double det = (b[0, 0] * b[1, 1]) - (b[1, 0] * b[0, 1]);
                        if (det == 0)
                        {
                            throw new ArgumentException("Determinant is 0!");
                        }
                        else
                        {
                            newb[0, 0] = b[1, 1] / det;
                            newb[1, 1] = b[0, 0] / det;
                            newb[0, 1] = -b[0, 1] / det;
                            newb[1, 0] = -b[1, 0] / det;
                        }
                    }
                }

                double[,] res = new double[r, c];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        for (int k = 0; k < c; k++)
                        {
                         res[i, j] += a[i, k] * newb[k, j];
                        }
                    }
                }

                return res;
            }
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
            res("A + B", add(a, b, ra, ca));
            res("A - B", sub(a, b, ra, ca));
            res("A * B", mul(a, b, ra, ca, cb));
            res("A / B", div(a, b, ra, ca));
        }
    }
}
