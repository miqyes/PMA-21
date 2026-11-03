namespace VectorClass

{
    public class Vector
    {
        private double[] values;
        
        public int Length
        {
            get
            {
                return values.Length;
            }
        }
        
        public double this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }

        public Vector(int length)
        {
            values = new double[length];
        }

        public Vector(double[] elementsArray)
        {
            values = elementsArray.ToArray();
        }

       
        
        
        public static Vector operator +(Vector vectorFirst, Vector vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Different lengths of vectors");
            }
            

            double[] outcome = new double[vectorFirst.Length];
            for (int i = 0; i < vectorFirst.Length; i++)
            {
                outcome[i] = vectorFirst[i] + vectorSecond[i];
            }

            return new Vector(outcome);
        }

       
        public static Vector operator -(Vector vectorFirst, Vector vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            double[] outcome = new double[vectorFirst.Length];
            for (int i = 0; i < vectorFirst.Length; i++)
            {
                outcome[i] = vectorFirst[i] - vectorSecond[i];
            }

            return new Vector(outcome);
        }

       
        public static Vector operator *(Vector vectorFirst, Vector vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            double[] outcome = new double[vectorFirst.Length];
            for (int i = 0; i < vectorFirst.Length; i++)
            {
                outcome[i] = vectorFirst[i] * vectorSecond[i];
            }

            return new Vector(outcome);
        }

      
        public static Vector operator /(Vector vectorFirst, Vector vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            double[] outcome = new double[vectorFirst.Length];
            for (int i = 0; i < vectorFirst.Length; i++)
            {
                if (vectorSecond[i] == 0)
                {
                    throw new Exception("Cant divide by zero ;3");
                }

                outcome[i] = vectorFirst[i] / vectorSecond[i];
            }

            return new Vector(outcome);
        }

        
        public override string ToString()
        {
            return string.Join(",", values);
        }
    }
}