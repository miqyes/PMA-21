
class Program
{
    static void Main()
    {
        string start = "start.txt";
        string end = "result.txt";
        float[][] vectors = Vector.read(start);

        File.AppendAllText(end, Vector.change(vectors[2]) + " * 4 = " + Vector.change(Vector.multiply(vectors[2], 4)) + "\n");
        try
        {
            File.AppendAllText(end, Vector.change(vectors[3]) + " / 3 = " + Vector.change(Vector.division(vectors[3], 3)) + "\n");
            Vector.division(vectors[3], 0);
        }
        catch (DivideByZeroException)
        {
            File.AppendAllText(end, Vector.change(vectors[3]) + " / 0 = You can't divide by 0\n");
        }

        try
        {
            File.AppendAllText(end, Vector.change(vectors[0]) + " + " + Vector.change(vectors[1]) + " = " + Vector.change(Vector.add(vectors[0], vectors[1])) + "\n");
            Vector.add(vectors[0], vectors[4]);
            File.AppendAllText(end, Vector.change(vectors[1]) + " - " + Vector.change(vectors[0]) + " = " + Vector.change(Vector.subtract(vectors[1], vectors[0])) + "\n");
            Vector.subtract(vectors[0], vectors[4]);
        }
        catch (ArgumentException)
        {
            File.AppendAllText(end, Vector.change(vectors[0]) + " + " + Vector.change(vectors[4]) + " = You can't add vectors different length\n");
            File.AppendAllText(end, Vector.change(vectors[0]) + " - " + Vector.change(vectors[4]) + " = You can't subtract vectors different length\n");
        }
      

    }
}
