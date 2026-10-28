 public static class Matrix
 {
        private static void checkSameDimension(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                throw new Exception("Different dimensions of matrices");
            }
        }

         public static double[,] add(double[,] a, double[,] b)
         {
            checkSameDimension(a, b);
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
         }

        public static double[,] subtract(double[,] a, double[,] b)
        {
            checkSameDimension(a, b);
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static double[,] multiply(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0))
            {
                throw new Exception("Number of columns in A must equal number of rows in B");
            }

            int rows = a.GetLength(0);
            int cols = b.GetLength(1);
            int n = a.GetLength(1);
            double[,] result = new double[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    result[i, j] = 0;
                    for(int k = 0; k < n; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static double determinant(double[,] m)
        {
            double mainDiagonal = m[0, 0] * m[1, 1];
            double secondaryDiagonal = m[0, 1] * m[1, 0];
            return mainDiagonal - secondaryDiagonal;
        }

        public static double[,] inverse(double[,] m)
        {
            int n = m.GetLength(0);
            if (n != m.GetLength(1))
            {
                throw new Exception("Matrix B must be square for division");
            }

            double det = determinant(m);

            if(Math.Abs(det) < 1e-9)
            {
                throw new DivideByZeroException("Determinant is 0, inverse matrix doesn`t exist");
            }

            int rowsCount = m.GetLength(0);
            int colCount = m.GetLength(1);
            double[,] res = new double[rowsCount, colCount];

            res[0, 0] = m[1, 1] / det;
            res[0, 1] = -m[0, 1] / det;
            res[1, 0] = -m[1, 0] / det;
            res[1, 1] = m[0, 0] / det;

            return res;

        }

        public static double[,] divide(double[,] a, double[,] b)
        {
            return multiply(a, inverse(b));
        }

    public static string ToStr(double[,] m)
        {
            string[] rows = new string[m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                double[] row = new double[m.GetLength(1)];
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    row[j] = m[i, j];
                }
                rows[i] = string.Join(" ", row);
            }
            return string.Join("; ", rows);
        }

    }