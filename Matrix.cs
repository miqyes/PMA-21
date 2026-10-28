using System.ComponentModel;

namespace ClassMatrixCalculator
{
    class Matrix
    {
        private List<List<float>> matrix;
        
        public Matrix(List<List<float>> numberMatrix)
        {
            matrix = numberMatrix;
        }
        
        public List<List<float>> getMatrix()
        {
            return matrix;
        }

        public float this[int row, int col]
        {
            get { return matrix[row][col]; }
            
        }
        public int Row
        {
            get { return matrix.Count; }
            
        }

        public int Col
        {
            get { return matrix[0].Count; }
        }
       

        public static Matrix SumMatrix(Matrix first, Matrix second)
        {
            if (first.Row!= second.Row||first.Col!= second.Col)
            {
                throw new Exception("Matrix lengths do not match");
            }
            List<List<float>> sumMatrix = new List<List<float>>();
            for (int i = 0; i < first.Row; i++)
            {
                sumMatrix.Add(new List<float>());
                
                for (int j=0; j<first.Col; j++)
                {
                    sumMatrix[i].Add(first[i,j] + second[i,j]);
                }
            }
            
            return new Matrix( sumMatrix);
        }

        public static Matrix DifferenceMatrix(Matrix first, Matrix second)
        {
            if (first.Row != second.Row||first.Col != second.Col)
            {
                throw new Exception("Matrix lengths do not match");
            }
            List<List<float>> differenceMatrix = new List<List<float>>();
            for (int i = 0; i < first.Row; i++)
            {
                differenceMatrix.Add(new List<float>());
                
                for (int j=0; j<first.Col; j++)
                {
                    differenceMatrix[i].Add(first[i,j] - second[i,j]);
                }
            }
            
            return new Matrix( differenceMatrix);
            
        }

        public static Matrix ProductMatrix(Matrix first, Matrix second)
        {
            if (first.Row != second.Row|| first.Col!= second.Col|| first.Row!=second.Col)
            {
                throw new Exception("Matrix lengths do not match");
            }
            List<List<float>> productMatrix = new List<List<float>>();
            for (int i = 0; i < first.Row; i++)
            {
                
                productMatrix.Add(new List<float>());
                for (int j = 0; j < first.Col; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < first.Col; k++)
                    {
                        sum += first[i,k] * second[k,j];
                    }
                    productMatrix[i].Add(sum);
                    
                }
            }

            return new Matrix(productMatrix);
        }

        public static float DetMatrix(Matrix matrix)
        {
            List<float> detMatrix = new List<float>();
            float numbersFirst=1;
            float numbersSecond=1;
            float det=0;
            if (matrix.Row != matrix.Col)
            {
                throw new Exception("Matrix length not match");
            }
            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    
                    if (i == j)
                    {
                        numbersFirst *= matrix[i, j];

                    }
                    else
                    {
                        numbersSecond *= matrix[i, j];
                    }
                }
                
            }

            det=numbersFirst-numbersSecond;
            detMatrix.Add(det);
            
            return det;
        }
    
        

        public static Matrix InverseMatrix(Matrix matrix)
        {
            List<List<float>> inverseMatrix = new List<List<float>>();
            
            float det=DetMatrix(matrix);

            if (det == 0)
            {
                throw new Exception("det=0");
            }

            for (int i = 0; i < matrix.Row; i++)
            {
                
                inverseMatrix.Add(new List<float>());
                for (int j = 0; j < matrix.Col; j++)
                {
                    
                    
                    float value;   
                    if (i == j)
                    {
                        
                        value = matrix[1 - i, 1 - j] / det;

                    }
                    else
                    {
                        value = -matrix[i, j] / det;
                    }
                    inverseMatrix[i].Add(value);
                }
                
            }
            return new Matrix(inverseMatrix);
        }

        public static Matrix DivisionMatrix(Matrix first, Matrix second)
        {
            if (first.Row != second.Row||first.Col != second.Col)
            {
                throw new Exception("Matrixs have different sizes");
            }
            

            Matrix inverseMatrix = InverseMatrix(second);
            
            Matrix divisionMatrix = ProductMatrix(first, inverseMatrix);

            return divisionMatrix;
        }
        
    }
}