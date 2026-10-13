namespace ClassVector
{
    static class FileWorker
    {
        public static Vector[] input(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new Exception("File not found: " + inputFile);
            }

            string[] lines = File.ReadAllLines(inputFile);

            if (lines.Length >= 2)
            {
                double[] vecFirst = lines[0].Split(',').Select(double.Parse).ToArray();
                double[] vecSecond = lines[1].Split(',').Select(double.Parse).ToArray();

                return new Vector[] {new Vector(vecFirst), new Vector(vecSecond)};

            }

            throw new Exception("Not enough lines in the input file");

        }
    }
}
