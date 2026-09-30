using System;

namespace Вектор_клас
{
    class Program
    {
        private const string FirstVectorFile = "firstvector.txt";
        private const string SecondVectorFile = "secondvector.txt";
        private const string ResultFile = "result.txt";
        static void Main(string[] args)
        {
            Console.Write("Enter size of vector: ");
            int VectorSize = int.Parse(Console.ReadLine());
            Vector InputA = FileWorker.InputVector("A", VectorSize);
            Vector InputB = FileWorker.InputVector("B", VectorSize);

            FileWorker.WriteResult(FirstVectorFile, InputA.ToText());
            FileWorker.WriteResult(SecondVectorFile, InputB.ToText());

            Vector FirstVector = FileWorker.ReadVector(FirstVectorFile, VectorSize);
            Vector SecondVector = FileWorker.ReadVector(SecondVectorFile, VectorSize);

            Vector AdditionResult = Vector.Add(FirstVector, SecondVector);
            Vector SubtractionResult = Vector.Subtract(FirstVector, SecondVector);
            Vector MultiplicationResult = Vector.Multiply(FirstVector, SecondVector);
            Vector DivisionResult = Vector.Divide(FirstVector, SecondVector);

            string Output = "Addition (A + B): \n" + AdditionResult.ToText() + "\n" + "Subtraction (A - B): \n" + SubtractionResult.ToText() + "\n" + "Multiplication (A * B): \n" + MultiplicationResult.ToText() + "\n" + "Division (A/B): \n" + DivisionResult.ToText();

            FileWorker.WriteResult(ResultFile, Output);
            Console.WriteLine("Result in " + ResultFile);
            Console.WriteLine(Output);
        }
    }
}
