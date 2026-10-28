
namespace Vector
{

    class MathOperation
    {
        public static List<float> productVector(List<float> vectorFirst, List<float> vectorSecond)
        {
            if (vectorFirst.Count != vectorSecond.Count)
            {
                throw new Exception("Vectors need to have the same length");
                
            }
            
            List<float> vectorProduct = new List<float>();

            for (int i = 0; i < vectorFirst.Count; i++)
            {
                vectorProduct.Add(vectorFirst[i]*vectorSecond[i]);

            }

            return vectorProduct;

        }

       public static List<float> sumVector(List<float> vectorFirst, List<float> vectorSecond)
        {
            if (vectorFirst.Count != vectorSecond.Count)
            {
                throw new Exception("Vectors need to have the same length");
            }
            

            List<float> SumVector = new List<float>();

            for (int i = 0; i < vectorFirst.Count; i++)
            {
                SumVector.Add(vectorFirst[i] + vectorSecond[i]);
            }

            return SumVector;
        }

        public static List<float> differenceVector(List<float> vectorFirst, List<float> vectorSecond)
        {
            if (vectorFirst.Count != vectorSecond.Count)
            {
                throw new Exception("Vectors need to have the same length");
            }
            

            List<float> DifferenceVector = new List<float>();

            for (int i = 0; i < vectorFirst.Count; i++)
            {
                DifferenceVector.Add(vectorFirst[i] - vectorSecond[i]);
            }

            return DifferenceVector;
        }

        public static List<float> divisionVector(List<float> vectorFirst, List<float> vectorSecond)
        {
            if (vectorFirst.Count != vectorSecond.Count)
            {
                throw new Exception("Vectors need to have the same length");
            }
           
            

            List<float> DivisionVector = new List<float>();

            for (int i = 0; i < vectorFirst.Count; i++)
            {
                if (vectorSecond[i] == 0)
                {
                    throw new Exception("Divivsion by zero is not allowed");
                }
                DivisionVector.Add(vectorFirst[i] / vectorSecond[i]);
            }

            return DivisionVector;
        }

    }
}