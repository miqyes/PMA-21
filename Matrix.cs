namespace matrixclass
{
    public class Matrix
    {
        private double[,] a;
        private double[,] b;
        private int ra, ca;
        private int rb, cb;

        public Matrix(double[,] matra, double[,] matrb, int rowsa, int colsa, int rowsb, int colsb)
        {
            a = matra;
            b = matrb;
            ra=rowsa;
            ca = colsa;
            rb = rowsb;
            cb = colsb;
        }

        public double[,] add()
        {
            if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
            {
                throw new ArgumentException("Sizes are dif!Error!");
            }

            double[,] res = new double[ra, ca];
            for (int i = 0; i < ra; i++)
            {
                for (int j = 0; j < ca; j++)
                {
                    res[i, j] = a[i, j] + b[i, j];
                }
            }
            return res;
        }

        public double[,] sub()
        {
            if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
            {
                throw new ArgumentException("Sizes are dif!Error!");
            }

            double[,] res = new double[ra, ca];
            for (int i = 0; i < ra; i++)
            {
                for (int j = 0; j < ca; j++)
                {
                    res[i, j] = a[i, j] - b[i, j];
                }
            }

            return res;
        }

        public double[,] mul()
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

        public double[,] div()
        {
            double[,] newb = new double[rb, cb];
            for (int i = 0; i < rb; i++)
            {
                for (int j = 0; j < cb; j++)
                {
                    newb[cb - 1 - j, i] = b[i, j];
                }
            }

            double[,] res = new double[ra, ca];
            for (int i = 0; i < ra; i++)
            {
                for (int j = 0; j < ca; j++)
                {
                    for (int k = 0; k < ca; k++)
                    {
                        res[i, j] += a[i, k] * newb[k, j];
                    }
                }
            }

            return res;
        }

        public void result(string act, double[,] matr)
        {
            string text = act + " =\n";
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                    text += matr[i, j] + " ";
                text += "\n";
            }

            File.AppendAllText("outputmatrix.txt",text);
        }
    }
}