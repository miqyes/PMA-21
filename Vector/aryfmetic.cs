namespace Task2;
public class Operations
{
    public static int[] add(int[] vecFirst, int[] vecSecond)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vecFirst[i] + vecSecond[i];
        return res;
    }

    public static int[] difference(int[] vecFirst, int[] vecSecond)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vecFirst[i] - vecSecond[i];
        return res;
    }

    public static int[] multiply(int[] vecFirst, int number)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vecFirst[i] * number;
        return res;
    }

    public static double[] divide(int[] vecFirst, double number)
    {
        if (number == 0)
            throw new Exception("Ділення на 0.НО-НО-НО(");
        double[] res = new double[3];
        for (int i = 0; i < 3; i++)
            res[i] = vecFirst[i] / number;
        return res;
    }
}