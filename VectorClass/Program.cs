namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string inpath="input.txt";
            string[] lines=File.ReadAllLines(inpath);

            Vector first = new Vector(lines[0]);
            Vector second = new Vector(lines[1]);

            if (!first.checksize(second))
            {
                return;
            }

            string[] results = first.calculate(second);
            File.WriteAllLines("output.txt",results);
        }
    }
}