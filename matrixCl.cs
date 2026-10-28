using System.Numerics;

namespace matrixClas
{
    public class Matrix<T> where T: INumber <T>
    {
        public T[,] Values { get; set; }
        public Matrix(T[,] values)
        {
            Values = values;
        }
        
        public Matrix (string text)
        { 
            string[] lines = text.Split('\n');
            int rows = lines.Length; 
            int cols = lines[0].Split(' ').Length; 
            Values = new T[rows, cols]; 
            for (int i = 0; i < rows; i++) 
            { 
                string[] numbers = lines[i].Split(' ');
                
                for (int j = 0; j < cols; j++)
                {
                    Values[i, j] = T.Parse(numbers[j],null);
                }
            }
        }
        
        public Matrix<T> Add(Matrix <T> A)
        {
            int rows = Values.GetLength(0);
            int cols = Values.GetLength(1);
            T[,] result = new T[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = Values[i, j] + A.Values[i, j];
                }
            }

            return new Matrix<T>(result);
        }

        public Matrix<T> Sub(Matrix<T> S)
        {
            int rows = Values.GetLength(0);
            int cols = Values.GetLength(1);
            T[,] result = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = Values[i, j] - S.Values[i, j];
                }
            }
            
            return new Matrix<T>(result);
        }
        
        
        public Matrix<T> Multiply(Matrix<T> M)
        {
            int rows = Values.GetLength(0);
            int cols = M.Values.GetLength(1);
            int middle = Values.GetLength(1);
            T[,] result = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < middle; k++)
                    {
                        result[i, j] += Values[i, k] * M.Values[k, j];
                    }
                }
            }
            
            return new Matrix<T>(result);
        }
        
        public T Determinant()
        {
            return Values[0, 0] * Values[1, 1] - Values[0, 1] * Values[1, 0];
        }
        
        public T[,] Divide(Matrix<T> D)
        {
            T det = D.Determinant();
            T[,] inverse = new T[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (i == j)
                    {
                        inverse[i, j] = D.Values[1 - i, 1 - j] / det;
                    }
                    else
                    {
                        inverse[i, j] = D.Values[i, j] / det;
                    }
                }
            }
            
            
            T[,] result = new T[2, 2];
            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += Values[i, k] * inverse[k, j];
                    }
                }
            }

            return result;
        }

        public static string Print<T> (T[,] matrix)
        {
            string result = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += "\n";
            }
            
            return result;
        }
        
    }
}

