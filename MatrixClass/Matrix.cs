namespace MatrixClass
{
    public class Matrix
    {
        private double[,] values;
        
        
        public int RowCount
        {
            get
            {
                return values.GetLength(0);
            }
        }

       
        public int ColumnCount
        {
            get
            {
                return values.GetLength(1);
            }
        }

       
        public double this[int row, int cols]
        {
            get
            {
                return values[row, cols];
            }
            set
            {
                values[row, cols] = value;
            }
        }

        public Matrix(int rows, int cols)
        {
            values = new double[rows, cols];
        }

        public Matrix(double[,] sourceArray)
        {
            int rows = sourceArray.GetLength(0);
            int cols = sourceArray.GetLength(1);

            values = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    values[i, j] = sourceArray[i, j];
                }
            }
        }

      
        public static Matrix operator +(Matrix matrixFirst, Matrix matrixSecond)
        {
            int rOne = matrixFirst.RowCount;
            int cOne = matrixFirst.ColumnCount;

            int rTwo = matrixSecond.RowCount;
            int cTwo = matrixSecond.ColumnCount;

            if (rOne != rTwo || cOne != cTwo)
            {
                throw new Exception("Cant add because of different sizes");
            }

            Matrix outcome = new Matrix(rOne, cOne);
            for (int i = 0; i < rOne; i++)
            {
                for (int j = 0; j < cOne; j++)
                {
                    outcome[i, j] = matrixFirst[i, j] + matrixSecond[i, j];
                }
            }

            return outcome;
        }

    
        public static Matrix operator -(Matrix matrixFirst, Matrix matrixSecond)
        {
            int rOne = matrixFirst.RowCount;
            int cOne = matrixFirst.ColumnCount;

            int rTwo = matrixSecond.RowCount;
            int cTwo = matrixSecond.ColumnCount;

            if (rOne != rTwo || cOne != cTwo)
            {
                throw new Exception("Cant subtract because of different sizes");
            }

            Matrix outcome = new Matrix(rOne, cOne);
            for (int i = 0; i < rOne; i++)
            {
                for (int j = 0; j < cOne; j++)
                {
                    outcome[i, j] = matrixFirst[i, j] - matrixSecond[i, j];
                }
            }

            return outcome;
        }

     
        public static Matrix operator *(Matrix matrixFirst, Matrix matrixSecond)
        {
            int rOne = matrixFirst.RowCount;
            int cOne = matrixFirst.ColumnCount;

            int rTwo = matrixSecond.RowCount;
            int cTwo = matrixSecond.ColumnCount;

            if (cOne != rTwo)
            {
                throw new Exception(
                    "Cant multiply because amount of columns in first matrix doesnt equal amount of rows in second");
            }

            Matrix outcome = new Matrix(rOne, cTwo);
            for (int i = 0; i < rOne; i++)
            {
                for (int j = 0; j < cTwo; j++)
                {
                    for (int k = 0; k < cOne; k++)
                    {
                        outcome[i, j] += matrixFirst[i, k] * matrixSecond[k, j];
                    }
                }
            }

            return outcome;
        }

      
        private static Matrix GetInverse(Matrix matrix)
        {
            int rTwo = matrix.RowCount;
            int cTwo = matrix.ColumnCount;

            if (rTwo != cTwo)
            {
                throw new Exception("Matrix-divisor isnt square-like, impossible to find inverse matrix");
            }

            int n = rTwo;
            Matrix megaMatrix = new Matrix(n, 2 * n);   

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    megaMatrix[i, j] = matrix[i, j];
                }

                megaMatrix[i, i + n] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                double mainDiagEl = megaMatrix[i, i];

                if (mainDiagEl == 0)
                {
                    int swapRow = -1;
                    for (int r = i + 1; r < n; r++)
                    {
                        if (megaMatrix[r, i] != 0)
                        {
                            swapRow = r;
                            break;
                        }
                    }

                    if (swapRow == -1)
                    {
                        throw new Exception("Determinant = 0, impossible to find inverse matrix");
                    }

                    for (int j = 0; j < 2 * n; j++)
                    { 
                        double temp = megaMatrix[i, j]; 
                        megaMatrix[i, j] = megaMatrix[swapRow, j]; 
                        megaMatrix[swapRow, j] = temp;
                    }

                    mainDiagEl = megaMatrix[i, i];
                }

                for (int j = 0; j < 2 * n; j++)
                {
                    megaMatrix[i, j] /= mainDiagEl;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double multiplier = megaMatrix[k, i];
                        for (int j = 0; j < 2 * n; j++)
                        {
                            megaMatrix[k, j] -= multiplier * megaMatrix[i, j];
                        }
                    }
                }
            }

            Matrix inverse = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = megaMatrix[i, j + n];
                }
            }

            return inverse;
        }

   
        public static Matrix operator /(Matrix matrixFirst, Matrix matrixSecond)
        {
            Matrix invTwo = GetInverse(matrixSecond);
            return matrixFirst * invTwo;
        }
    }
}