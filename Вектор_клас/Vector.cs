using System;

namespace Вектор_клас
{
    public class Vector
    {
        public int Size;
        public double[] Data;
        public Vector(int VectorSize)
        {
            Size = VectorSize;
            Data = new double[Size];
        }
        public static Vector Add(Vector FirstVector, Vector SecondVector)
        {
            Vector ResultVector = new Vector(FirstVector.Size);
            for (int Index = 0; Index < FirstVector.Size; Index++)
            {
                ResultVector.Data[Index] = FirstVector.Data[Index] + SecondVector.Data[Index];
            }
            return ResultVector;
        }
        public static Vector Subtract(Vector FirstVector, Vector SecondVector)
        {
            Vector ResultVector = new Vector(FirstVector.Size);
            for (int Index = 0; Index < FirstVector.Size; Index++)
            {
                    ResultVector.Data[Index] = FirstVector.Data[Index] - SecondVector.Data[Index];
            }
            return ResultVector;
        }
        public static Vector Multiply(Vector FirstVector, Vector SecondVector)
        {
            Vector ResultVector = new Vector(FirstVector.Size);
            for (int Index = 0; Index < FirstVector.Size; Index++)
            {
                ResultVector.Data[Index] = FirstVector.Data[Index] * SecondVector.Data[Index];
            }
            return ResultVector;
        }
        public static Vector Divide(Vector FirstVector, Vector SecondVector)
        {
            Vector ResultVector = new Vector(FirstVector.Size);
            for (int Index = 0; Index < FirstVector.Size; Index++)
            {
                ResultVector.Data[Index] = Math.Round(FirstVector.Data[Index] / SecondVector.Data[Index], 2);
            }
            return ResultVector;
        }
        public string ToText()
        {
            string ResultText = "(";
            for (int Index = 0; Index < Size; Index++)
            {
                ResultText += Math.Round(Data[Index], 2);
                if (Index < Size - 1)
                {
                    ResultText += ", ";
                }
            }
            ResultText += ")";
            return ResultText;
        }
        public string ToFile()
        {
            string ResultText = "";
            for (int Index = 0; Index < Size; Index++)
            {
                ResultText += Data[Index] + "\t";
            }
            return ResultText.Trim();
        }
    }
}
