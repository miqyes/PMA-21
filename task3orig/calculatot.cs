using System.Globalization;
using System.Text;

namespace task3orig
{
    public class Matrix
    {
        public readonly int Size;
        public readonly double[,] Data;

        public Matrix(int matrixSize)
        {
            Size = matrixSize;
            Data = new double[Size, Size];
        }
    }

    public static class MatrixOperations
    {
        private const double Epsilon = 1e-12;

        public static Matrix Add(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix(firstMatrix.Size);
            for (int rowIndex = 0; rowIndex < firstMatrix.Size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < firstMatrix.Size; columnIndex++)
                {
                    resultMatrix.Data[rowIndex, columnIndex] = firstMatrix.Data[rowIndex, columnIndex] + secondMatrix.Data[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static Matrix Subtract(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix(firstMatrix.Size);
            for (int rowIndex = 0; rowIndex < firstMatrix.Size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < firstMatrix.Size; columnIndex++)
                {
                    resultMatrix.Data[rowIndex, columnIndex] = firstMatrix.Data[rowIndex, columnIndex] - secondMatrix.Data[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static Matrix Multiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix(firstMatrix.Size);
            for (int rowIndex = 0; rowIndex < firstMatrix.Size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < firstMatrix.Size; columnIndex++)
                {
                    double elementSum = 0;
                    for (int innerIndex = 0; innerIndex < firstMatrix.Size; innerIndex++)
                    {
                        elementSum += firstMatrix.Data[rowIndex, innerIndex] * secondMatrix.Data[innerIndex, columnIndex];
                    }
                    resultMatrix.Data[rowIndex, columnIndex] = elementSum;
                }
            }
            return resultMatrix;
        }

        public static Matrix? Divide(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix? invertedSecondMatrix = Invert(secondMatrix);
            if (invertedSecondMatrix == null)
            {
                return null;
            }
            return Multiply(firstMatrix, invertedSecondMatrix);
        }

        private static Matrix? Invert(Matrix targetMatrix)
        {
            int matrixSize = targetMatrix.Size;
            Matrix workingMatrix = new Matrix(matrixSize);
            Matrix invertedMatrix = new Matrix(matrixSize);

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    workingMatrix.Data[rowIndex, columnIndex] = targetMatrix.Data[rowIndex, columnIndex];
                    invertedMatrix.Data[rowIndex, columnIndex] = (rowIndex == columnIndex) ? 1.0 : 0.0;
                }
            }

            for (int stepIndex = 0; stepIndex < matrixSize; stepIndex++)
            {
                int pivotRow = FindPivotRow(workingMatrix, stepIndex);
                if (Math.Abs(workingMatrix.Data[pivotRow, stepIndex]) < Epsilon)
                {
                    return null;
                }

                SwapRows(workingMatrix, stepIndex, pivotRow);
                SwapRows(invertedMatrix, stepIndex, pivotRow);

                double pivotElement = workingMatrix.Data[stepIndex, stepIndex];
                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    workingMatrix.Data[stepIndex, columnIndex] /= pivotElement;
                    invertedMatrix.Data[stepIndex, columnIndex] /= pivotElement;
                }

                for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
                {
                    if (rowIndex != stepIndex)
                    {
                        double multiplier = workingMatrix.Data[rowIndex, stepIndex];
                        for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                        {
                            workingMatrix.Data[rowIndex, columnIndex] -= multiplier * workingMatrix.Data[stepIndex, columnIndex];
                            invertedMatrix.Data[rowIndex, columnIndex] -= multiplier * invertedMatrix.Data[stepIndex, columnIndex];
                        }
                    }
                }
            }
            return invertedMatrix;
        }

        private static int FindPivotRow(Matrix targetMatrix, int stepIndex)
        {
            int bestRow = stepIndex;
            for (int rowIndex = stepIndex + 1; rowIndex < targetMatrix.Size; rowIndex++)
            {
                if (Math.Abs(targetMatrix.Data[rowIndex, stepIndex]) > Math.Abs(targetMatrix.Data[bestRow, stepIndex]))
                {
                    bestRow = rowIndex;
                }
            }
            return bestRow;
        }

        private static void SwapRows(Matrix targetMatrix, int firstRow, int secondRow)
        {
            if (firstRow == secondRow)
            {
                return;
            }
            for (int columnIndex = 0; columnIndex < targetMatrix.Size; columnIndex++)
            {
                (targetMatrix.Data[firstRow, columnIndex], targetMatrix.Data[secondRow, columnIndex]) =
                    (targetMatrix.Data[secondRow, columnIndex], targetMatrix.Data[firstRow, columnIndex]);
            }
        }
    }

    public static class MatrixFormatter
    {
        public static string ToText(Matrix targetMatrix, int decimalPlaces = 2)
        {
            StringBuilder resultText = new StringBuilder();
            for (int rowIndex = 0; rowIndex < targetMatrix.Size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < targetMatrix.Size; columnIndex++)
                {
                    double roundedValue = Math.Round(targetMatrix.Data[rowIndex, columnIndex], decimalPlaces);
                    resultText.Append(roundedValue.ToString(CultureInfo.InvariantCulture));
                    if (columnIndex < targetMatrix.Size - 1)
                    {
                        resultText.Append('\t');
                    }
                }
                resultText.Append('\n');
            }
            return resultText.ToString();
        }
    }

    public static class FileWorker
    {
        private static readonly char[] Separators = ['\t', ' '];

        public static Matrix ReadMatrix(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File '" + filePath + "' not found.", filePath);
            }

            string[] lines = File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            if (lines.Length == 0)
            {
                throw new FormatException("File '" + filePath + "' is empty.");
            }

            int matrixSize = lines.Length;
            Matrix resultMatrix = new Matrix(matrixSize);

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                string[] parts = lines[rowIndex].Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != matrixSize)
                {
                    throw new FormatException("Row " + (rowIndex + 1) + " in '" + filePath + "' must contain exactly "
                                              + matrixSize + " numbers (the matrix must be square).");
                }

                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    if (!double.TryParse(parts[columnIndex], NumberStyles.Float, CultureInfo.InvariantCulture,
                            out resultMatrix.Data[rowIndex, columnIndex]))
                    {
                        throw new FormatException("Cannot read number '" + parts[columnIndex] + "' in '" + filePath + "'.");
                    }
                }
            }
            return resultMatrix;
        }

        public static void WriteResult(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }

    public static class ReportBuilder
    {
        public static string Build(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix additionResult = MatrixOperations.Add(firstMatrix, secondMatrix);
            Matrix subtractionResult = MatrixOperations.Subtract(firstMatrix, secondMatrix);
            Matrix multiplicationResult = MatrixOperations.Multiply(firstMatrix, secondMatrix);
            Matrix? divisionResult = MatrixOperations.Divide(firstMatrix, secondMatrix);

            string output = "Addition (A + B):\n" + MatrixFormatter.ToText(additionResult) + "\n"
                          + "Subtraction (A - B):\n" + MatrixFormatter.ToText(subtractionResult) + "\n"
                          + "Multiplication (A * B):\n" + MatrixFormatter.ToText(multiplicationResult) + "\n";

            if (divisionResult != null)
            {
                output += "Division (A * B^-1):\n" + MatrixFormatter.ToText(divisionResult) + "\n";
            }
            else
            {
                output += "Division (A * B^-1):\nCannot divide by zero!\n";
            }
            return output;
        }
    }
}