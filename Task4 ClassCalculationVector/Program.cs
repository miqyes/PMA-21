class Program
{
    static void Main()
    {
        string start = "Start.txt";
        string end = "Result.txt";
        Vector[] vectors = Read.ReadFromFile(start);

        File.AppendAllText(end, vectors[2].ToString() + " * 4 = " + Vector.Multiply(vectors[2], 4).ToString() + "\n");
        try
        {
            File.AppendAllText(end, vectors[3].ToString() + " / 3 = " + Vector.Division(vectors[3], 3).ToString() + "\n");
            Vector.Division(vectors[3], 0);
        }
        catch (DivideByZeroException)
        {
            File.AppendAllText(end, vectors[3].ToString() + " / 0 = You can't divide by 0\n");
        }

        try
        {
            File.AppendAllText(end, vectors[0].ToString() + " + " + vectors[1].ToString() + " = " + Vector.Add(vectors[0], vectors[1]).ToString() + "\n");
            Vector.Add(vectors[0], vectors[4]);
            File.AppendAllText(end, vectors[1].ToString() + " - " + vectors[0].ToString() + " = " + Vector.Subtract(vectors[1], vectors[0]).ToString() + "\n");
            Vector.Subtract(vectors[0], vectors[4]);
        }
        catch (ArgumentException)
        {
            File.AppendAllText(end, vectors[0].ToString() + " + " + vectors[4].ToString() + " = You can't Add vectors different length\n");
            File.AppendAllText(end, vectors[0].ToString() + " - " + vectors[4].ToString() + " = You can't subtract vectors different length\n");
        }


    }
}