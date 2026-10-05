namespace UNI;

public class Matrix
{

    public static double[,] add(double[,] a, double[,] b, int r, int c)
    {
        if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
        {
            throw new ArgumentException("Sizes are dif!Error!");
        }

        double[,] res = new double[r, c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                res[i, j] = a[i, j] + b[i, j];
            }
        }

        return res;
    }

   public static double[,] sub(double[,] a, double[,] b, int r, int c)
    {
        if (b.GetLength(0) != a.GetLength(0) || b.GetLength(1) != a.GetLength(1))
        {
            throw new ArgumentException("Sizes are dif!Error!");
        }

        double[,] res = new double[r, c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                res[i, j] = a[i, j] - b[i, j];
            }
        }

        return res;
    }

    public static double[,] mul(double[,] a, double[,] b, int ra, int ca, int cb)
    {
        double[,] res = new double[ra, cb];
        for (int i = 0; i < ra; i++)
        {
            for (int j = 0; j < cb; j++)
            {
                for (int k = 0; k < ca; k++)
                {
                    res[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return res;
    }
    public static double[,] div(double[,] a, double[,] b, int r, int c)
    {
        double[,] newb = new double[r, c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                double det = (b[0, 0] * b[1, 1]) - (b[1, 0] * b[0, 1]);
                if (det == 0)
                {
                    throw new ArgumentException("Determinant is 0!");
                }
                else
                {
                    newb[0, 0] = b[1, 1] / det;
                    newb[1, 1] = b[0, 0] / det;
                    newb[0, 1] = -b[0, 1] / det;
                    newb[1, 0] = -b[1, 0] / det;
                }
            }
        }

        double[,] res = new double[r, c];
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                for (int k = 0; k < c; k++)
                {
                    res[i, j] += a[i, k] * newb[k, j];
                }
            }
        }

        return res;
    }
}
