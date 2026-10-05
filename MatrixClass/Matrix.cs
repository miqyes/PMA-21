namespace matrixclass
{
    public class Matrix
    {
        private double[,] matrix ;
        public int rows => matrix.GetLength(0);
        public int cols => matrix.GetLength(1);

        public Matrix(double[,] values)
        {
            matrix=values;
        }
        
        public double[,] add(Matrix other)
        {
            if (matrix.GetLength(0) != other.matrix.GetLength(0) || matrix.GetLength(1) != other.matrix.GetLength(1))
            {
                throw new ArgumentException("Sizes are dif!Error!");
            }

            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res[i, j] = matrix[i, j] + other.matrix[i, j];
                }
            }
            return res;
        }

        public double[,] sub(Matrix other)
        {
            if (matrix.GetLength(0) != other.matrix.GetLength(0) || matrix.GetLength(1) != other.matrix.GetLength(1))
            {
                throw new ArgumentException("Sizes are dif!Error!");
            }

            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res[i, j] = matrix[i, j] - other.matrix[i, j];
                }
            }

            return res;
        }

        public double[,] mul(Matrix other)
        {
            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        res[i, j] += matrix[i, k] * other.matrix[k, j];
                    }
                }
            }

            return res;
        }

        public double[,] div(Matrix other)
        {
            double[,] newother = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double det = (other.matrix[0, 0] * other.matrix[1, 1]) - (other.matrix[1, 0] * other.matrix[0, 1]);
                    if (det == 0)
                    {
                        throw new ArgumentException("Determinant is 0!");
                    }
                    else
                    {
                        newother[0, 0] = other.matrix[1, 1] / det;
                        newother[1, 1] = other.matrix[0, 0] / det;
                        newother[0, 1] = -other.matrix[0, 1] / det;
                        newother[1, 0] = -other.matrix[1, 0] / det;
                    }
                }
            }

            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        res[i, j] += matrix[i, k] * newother[k, j];
                    }
                }
            }

            return res;
        }

        public static void result(string act, double[,] m)
        {
            string text = act + " =\n";
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    text += m[i, j] + " ";
                text += "\n";
            }

            File.AppendAllText("outputmatrix.txt",text);
        }
    }
}