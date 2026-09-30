using System;

namespace Матриця_класС_
{
    class Program
    {
        private const string FirstMatrixFile = "first.txt";
        private const string SecondMatrixFile = "second.txt";
        private const string ResultFile = "result.txt";

        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix: ");
            int MatrixSize = int.Parse(Console.ReadLine());
            Matrix InputA = FileWorker.InputMatrix("A", MatrixSize);
            Matrix InputB = FileWorker.InputMatrix("B", MatrixSize);

            FileWorker.WriteResult(FirstMatrixFile, InputA.ToText());
            FileWorker.WriteResult(SecondMatrixFile, InputB.ToText());

            Matrix FirstMatrix = FileWorker.ReadMatrix(FirstMatrixFile, MatrixSize);
            Matrix SecondMatrix = FileWorker.ReadMatrix(SecondMatrixFile, MatrixSize);

            Matrix AdditionResult = Matrix.Add(FirstMatrix, SecondMatrix);
            Matrix SubtractionResult = Matrix.Subtract(FirstMatrix, SecondMatrix);
            Matrix MultiplicationResult = Matrix.Multiply(FirstMatrix, SecondMatrix);
            Matrix DivisionResult = Matrix.Divide(FirstMatrix, SecondMatrix);

            string DivisionText;
            if(DivisionResult != null)
            {
                DivisionText = DivisionResult.ToText();
            }
            else
            {
                DivisionText = "Cannot divide by zero!";
            }

                string Output = "Addition (A + B): \n" + AdditionResult.ToText() + "\n" + "Subtraction (A - B): \n" + SubtractionResult.ToText() + "\n" + "Multiplication (A * B): \n" + MultiplicationResult.ToText() + "\n" + "Division (A * B^-1): \n" + DivisionText;

            FileWorker.WriteResult(ResultFile, Output);
            Console.WriteLine("Result in " + ResultFile);
        }

    }
}
