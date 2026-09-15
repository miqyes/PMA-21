using System;
namespace vector
{
    class Program
    {
        public static void Main()
        {
            static double add(double x, double y)
            {
                return x + y;
            }
            static double difference(double x, double y)
            {
                return x - y;
            }
            static double multiplied(double x, double y)
            {
                return x * y;
            }
            static double divided(double x, double y)
            {
                return x / y;
            }

            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Error: file are not found!");
                return;
            }
            string[] lines = File.ReadAllLines("input.txt");
            if (lines.Length < 2)
            {
                Console.WriteLine("Error: file must contain at least 2 lines!");
                return;
            }
            string[] firstNumbers = lines[0].Split(' ');
            string[] secondNumbers = lines[1].Split(' ');
            if (firstNumbers.Length != 3 || secondNumbers.Length != 3)
            {
                Console.WriteLine("Error: each line must contain exactly 3 numbers!");
            }
            double x1 = double.Parse(firstNumbers[0]);
            double y1 = double.Parse(firstNumbers[1]);
            double z1 = double.Parse(firstNumbers[2]);
            double x2 = double.Parse(secondNumbers[0]);
            double y2 = double.Parse(secondNumbers[1]);
            double z2 = double.Parse(secondNumbers[2]);
            double addX = add(x1, x2);
            double addY = add(y1, y2);
            double addZ = add(z1, z2);
            double diffX = difference(x1, x2);
            double diffY = difference(y1, y2);
            double diffZ = difference(z1, z2);
            double multX = multiplied(x1, x2);
            double multY = multiplied(y1, y2);
            double multZ = multiplied(z1, z2);
            double divX = divided(x1, x2);
            double divY = divided(y1, y2);
            double divZ = divided(z1, z2);

            string result = "First vector: " + "(" + x1 + "," + y1 + "," + z1 + ")" + Environment.NewLine +
                "Second vector: " + "(" + x2 + "," + y2 + "," + z2 + ")" + Environment.NewLine +
            "Sum: " + "(" + x1 + "," + y1 + "," + z1 + ")" + "+" + "(" + x2 + "," + y2 + "," + z2 + ")" + "=" + "(" + addX + ", " + addY + ", " + addZ + ")" + Environment.NewLine +
            "Difference: "+ "(" + x1 + "," + y1 + "," + z1 + ")" + "+" + "(" + x2 + "," + y2 + "," + z2 + ")" + "=" + "(" + diffX +", "+diffY+", "+diffZ+")"+Environment.NewLine+
            "Product: "+ "(" + x1 + "," + y1 + "," + z1 + ")" + "+" + "(" + x2 + "," + y2 + "," + z2 + ")" + "=" + "(" + multX + ", " + multY + ", " + multZ+")"+Environment.NewLine+
            "Qoutient: "+ "(" + x1 + "," + y1 + "," + z1 + ")" + "+" + "(" + x2 + "," + y2 + "," + z2 + ")" + "=" + "(" + divX + ", " + divY + ", " + divZ+")";
            File.WriteAllText("result.txt", result);
            Console.WriteLine("Result is successfully saved in file 'result.txt'");
        }
    }
}
