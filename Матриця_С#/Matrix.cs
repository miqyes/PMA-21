using System;

namespace Матриця_С_
{
    public class Matrix
    {
        public int Size;
        public double[,] Data;

        public Matrix(int MatrixSize)
        {
            Size = MatrixSize;
            Data = new double[Size, Size];
        }
        public static Matrix Add(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix Resultmatrix = new Matrix(FirstMatrix.Size);
            for (int RowIndex = 0; RowIndex < FirstMatrix.Size; RowIndex++) 
            {
                for (int ColumnIndex = 0; ColumnIndex < FirstMatrix.Size; ColumnIndex++)
                {
                    Resultmatrix.Data[RowIndex, ColumnIndex] = FirstMatrix.Data[RowIndex, ColumnIndex] + SecondMatrix.Data[RowIndex, ColumnIndex];
                }
            }
            return Resultmatrix;
        }
        public static Matrix Subtract(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix ResultMatrix = new Matrix(FirstMatrix.Size);
            for(int RowIndex = 0; RowIndex < FirstMatrix.Size; RowIndex++)
            {
                for(int ColumnIndex=0; ColumnIndex<FirstMatrix.Size; ColumnIndex++)
                {
                    ResultMatrix.Data[RowIndex, ColumnIndex] = FirstMatrix.Data[RowIndex, ColumnIndex] - SecondMatrix.Data[RowIndex, ColumnIndex];
                }
            }
            return ResultMatrix;
        }
        public static Matrix Multiply(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix ResultMatrix = new Matrix(FirstMatrix.Size);
            for(int RowIndex = 0; RowIndex < FirstMatrix.Size; RowIndex++)
            {
                for(int ColumnIndex = 0; ColumnIndex < FirstMatrix.Size; ColumnIndex++)
                {
                    double ElementSum = 0;
                    for(int InnerIndex = 0; InnerIndex < FirstMatrix.Size; InnerIndex++)
                    {
                        ElementSum += FirstMatrix.Data[RowIndex, InnerIndex] * SecondMatrix.Data[InnerIndex, ColumnIndex];
                    }
                    ResultMatrix.Data[RowIndex, ColumnIndex] = ElementSum;
                }
            }
            return ResultMatrix;
        }
        public static Matrix Invert(Matrix TargetMatrix)
        {
            int MatrixSize = TargetMatrix.Size;
            Matrix WorkingMatrix = new Matrix(MatrixSize);
            Matrix InvertedMatrix = new Matrix(MatrixSize);

            for(int RowIndex = 0; RowIndex < MatrixSize; RowIndex++)
            {
                for(int ColumnIndex = 0; ColumnIndex < MatrixSize; ColumnIndex++)
                {
                    WorkingMatrix.Data[RowIndex, ColumnIndex] = TargetMatrix.Data[RowIndex, ColumnIndex];
                    if (RowIndex == ColumnIndex)
                    {
                        InvertedMatrix.Data[RowIndex, ColumnIndex] = 1.0;
                    }
                    else
                    {
                        InvertedMatrix.Data[RowIndex, ColumnIndex] = 0.0;
                    }
                }
            }

            for(int StepIndex = 0; StepIndex < MatrixSize; StepIndex++)
            {
                double PivotElement = WorkingMatrix.Data[StepIndex, StepIndex];
                if (PivotElement == 0)
                {
                    Console.WriteLine("We cannot divide by zero!");
                    return null;
                }
                for(int ColumnIndex = 0; ColumnIndex < MatrixSize; ColumnIndex++)
                {
                    WorkingMatrix.Data[StepIndex, ColumnIndex] /= PivotElement;
                    InvertedMatrix.Data[StepIndex, ColumnIndex] /= PivotElement;
                }
                for(int RowIndex = 0; RowIndex < MatrixSize; RowIndex++)
                {
                    if (RowIndex != StepIndex)
                    {
                        double Multiplier = WorkingMatrix.Data[RowIndex, StepIndex];
                        for(int ColumnIndex = 0; ColumnIndex < MatrixSize; ColumnIndex++)
                        {
                            WorkingMatrix.Data[RowIndex, ColumnIndex] -= Multiplier * WorkingMatrix.Data[StepIndex, ColumnIndex];
                            InvertedMatrix.Data[RowIndex, ColumnIndex] -= Multiplier * InvertedMatrix.Data[StepIndex, ColumnIndex];
                        }
                    }
                }
            }
            return InvertedMatrix;
        } 

        public static Matrix Divide(Matrix FirstMatrix, Matrix SecondMatrix)
        {
            Matrix InvertedSecondMatrix = Invert(SecondMatrix);
            if (InvertedSecondMatrix == null)
            {
                return null;
            }
            return Multiply(FirstMatrix, InvertedSecondMatrix);
        }
        public string ToText()
        {
            string ResultText = "";
            for(int RowIndex = 0; RowIndex < Size; RowIndex++)
            {
                for(int ColumnIndex = 0; ColumnIndex < Size; ColumnIndex++)
                {
                    ResultText += Math.Round(Data[RowIndex, ColumnIndex], 2);
                    if (ColumnIndex < Size - 1)
                    {
                        ResultText += "\t";
                    }
                }
                ResultText += "\n";
            }
            return ResultText;
        }
    }
}
