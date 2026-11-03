namespace ArrVer
{

    public class VectorCalculator
    {
        public static double[] Adding(double[] vOne, double[] vTwo)
        {
            if (vOne.Length != vTwo.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            return vOne.Select((val, i) => val + vTwo[i]).ToArray();






            /*double[] outcome = new double[vOne.Length];


            for (int i = 0; i < vOne.Length; i++)
            {
                outcome[i] = vOne[i] + vTwo[i];
            }

            return outcome;*/
        }


        public static double[] Subtracting(double[] vOne, double[] vTwo)
        {
            if (vOne.Length != vTwo.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            return vOne.Select((val, i) => val - vTwo[i]).ToArray();






            /*double[] outcome = new double[vOne.Length];
            for (int i = 0; i < vOne.Length; i++)
            {
                outcome[i] = vOne[i] - vTwo[i];
            }

            return outcome;*/
        }

        public static double[] Multiplying(double[] vOne, double[] vTwo)
        {
            if (vOne.Length != vTwo.Length)
            {
                throw new Exception("Different lengths of vectors");
            }

            return vOne.Select((val, i) => val * vTwo[i]).ToArray();





            /* double[] outcome = new double[vOne.Length];


             for (int i = 0; i < vOne.Length; i++)

             {
                 outcome[i] = vOne[i] * vTwo[i];
             }

             return outcome;*/

        }

        public static double[] Dividing(double[] vOne, double[] vTwo)
        {
            if (vOne.Length != vTwo.Length)
            {
                throw new Exception("Different lengths of vectors");
            }


            return vOne.Select((val, i) =>
            {
                if (vTwo[i] == 0)
                {
                    throw new Exception("Cant divide by zero ;3");
                }

                return val / vTwo[i];
            }).ToArray();
        }
    }
}


/*double[] outcome = new double[vOne.Length];
for (int i = 0; i < vOne.Length; i++)
{
    if (vTwo[i] == 0)
    {
        throw new Exception ("Cant divide by zero ;3");
    }

    outcome[i] = vOne[i] / vTwo[i];
     return outcome;
}*/


  