namespace Task2;
public class Operations
{
    public static int[] add(int[] vec1, int[] vec2)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] + vec2[i];
        return res;
    }

    public static int[] difference(int[] vec1, int[] vec2)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] - vec2[i];
        return res;
    }

    public static int[] multiply(int[] vec1, int number)
    {
        int[] res = new int[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] * number;
        return res;
    }

    public static double[] divide(int[] vec1, double number)
    {
        if (number == 0)
            throw new Exception("Ділення на 0.НО-НО-НО(");
        double[] res = new double[3];
        for (int i = 0; i < 3; i++)
            res[i] = vec1[i] / number;
        return res;
    }
}