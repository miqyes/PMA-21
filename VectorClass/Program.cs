namespace UNI
{
    class Program
    {
        static void Main()
        {
            const string inpath="input.txt";
            if (File.Exists(inpath))
            {
                Console.WriteLine("Input file exists");
            }
            else
            {
                Console.WriteLine("Input file does not exist");
            }
            string[] lines=File.ReadAllLines(inpath);
            
            double[] vf=lines[0].Split(',').Select(double.Parse).ToArray();
            double[] vs=lines[1].Split(',').Select(double.Parse).ToArray();
            
            Vector vectorres=new Vector(vf,vs);

            if (!vectorres.checksize())
            {
                return;
            }

            string[] results = vectorres.calculate();
            File.WriteAllLines("output.txt",results);
        }
    }
}
