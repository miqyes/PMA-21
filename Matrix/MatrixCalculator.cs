
namespace Matrix
{
    public class MatrixCalculator
    {
        public static double[,] Adding(double[,] mOne, double[,] mTwo)
        {
            double[,] outcome = new double[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    outcome[i, j] = mOne[i, j] + mTwo[i, j];
                }
            }
            
            return outcome;
        }

        public static double[,] Subtracting(double[,] mOne, double[,] mTwo)
        {
            double[,] outcome = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    outcome[i, j] = mOne[i, j] - mTwo[i, j];
                }
            }
           
            return outcome;
        }

        public static double[,] Multiplying(double[,] mOne, double[,] mTwo)
        {
            double[,] outcome = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    outcome[i, j] = mOne[i, 0] * mTwo[0, j] + mOne[i, 1] * mTwo[1, j];
                }
            }
            
            return outcome;
        }

        public static double[,] Dividing(double[,] mOne, double[,] mTwo)
        {
            double det = mTwo[0, 0] * mTwo[1, 1] - mTwo[0, 1] * mTwo[1, 0];
            if (det == 0)
            {
                File.WriteAllText("result.txt", "Cant divide by zero ;3");
                Environment.Exit(1);
            }

        
            double[,] inv = new double[2, 2];
            inv[0, 0] = mTwo[1, 1] / det;
            inv[0, 1] = -mTwo[0, 1] / det;
            inv[1, 0] = -mTwo[1, 0] / det;
            inv[1, 1] = mTwo[0, 0] / det;

          
            double[,] outcome = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    outcome[i, j] = mOne[i, 0] * inv[0, j] + mOne[i, 1] * inv[1, j];
                }
            }
            
            return outcome;
        }
    }
}