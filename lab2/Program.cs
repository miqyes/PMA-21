using System;
namespace labTwo
{
    class Program
    {
        static double add(double x, double y)
        {
            return x + y;
        }
        static double sub(double x, double y)
        {
            return x - y;
        }
        static double mult(double x, double y)
        {
            return x * y;
        }
        static double div(double x, double y)
        {
            return x / y;
        }
        static void Main()
        {
            if (!File.Exists("firstvector.txt"))
            {
                Console.WriteLine("Error: cannot find file firstvector.txt");
                return;
            }
            string[] firstVector = File.ReadAllText("firstvector.txt").Split(';');
            int x1 = int.Parse(firstVector[0]);
            int y1 = int.Parse(firstVector[1]);
            int z1 = int.Parse(firstVector[2]);

            if (!File.Exists("secondvector.txt"))
            {
                Console.WriteLine("Error: cannot find file secondvector.txt");
                return;
            }
            string[] secondVector = File.ReadAllText("secondvector.txt").Split(';');
            int x2 = int.Parse(secondVector[0]);
            int y2 = int.Parse(secondVector[1]);
            int z2 = int.Parse(secondVector[2]);

            double[] first = { x1, y1, z1 };
            double[] second = { x2, y2, z2 };

            double[] addResult = new double[3];
            double[] subResult = new double[3];
            double[] multResult = new double[3];
            double[] divResult = new double[3];

            for (int i = 0; i < 3; i++)
            {
                addResult[i] = add(first[i], second[i]);
                subResult[i] = sub(first[i], second[i]);
                multResult[i] = mult(first[i], second[i]);
                divResult[i] = div(first[i], second[i]);

                if (second[i] == 0)
                {
                    Console.WriteLine("Error: you cannot divide by zero");
                    return;
                }
            }


            string result = ("(" + x1 + ";" + y1 + ";" + z1 + ")" + "+" + "(" + x2 + ";" + y2 + ";" + z2 + ")" + "=" + "(" + addResult[0] + ";" + addResult[1] + ";" + addResult[2] + ")\n" + "(" + x1 + ";" + y1 + ";" + z1 + ")" + "-" + "(" + x2 + ";" + y2 + ";" + z2 + ")" + "=" + "(" + subResult[0] + ";" + subResult[1] + ";" + subResult[2] + ")\n" + "(" + x1 + ";" + y1 + ";" + z1 + ")" + "*" + "(" + x2 + ";" + y2 + ";" + z2 + ")" + "=" + "(" + multResult[0] + ";" + multResult[1] + ";" + multResult[2] + ")\n" + "(" + x1 + ";" + y1 + ";" + z1 + ")" + ":" + "(" + x2 + ";" + y2 + ";" + z2 + ")" + "=" + "(" + divResult[0] + ";" + divResult[1] + ";" + divResult[2] + ")");
            File.WriteAllText("output.txt", result);
            Console.WriteLine(result);
        }
    }
}
