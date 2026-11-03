namespace ArrVer
{
    class Program
    {
        private const string InputFilename = "vector.txt";
        private const string Result = "result.txt";

        static double[] ParseLine(string line)
        {
            return line.Split([", ", ",", " ", "\n", "\t", "\r"], StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }

        static double[][] ReadVectors()
        {
            if (!File.Exists(InputFilename))
            {
                File.WriteAllText(Result, $"Couldn't find file {InputFilename}");
                Environment.Exit(1);
            }      

            string[] input = File.ReadAllLines(InputFilename);
            if (input.Length < 2)
            {
                File.WriteAllText(Result, $"{InputFilename} must contain at least 2 vectors");
                Environment.Exit(1);
            }


            double[][] vectors = new double[input.Length][];
            vectors[0] = ParseLine(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                double[] temp = ParseLine(input[i]);
                
                if (temp.Length != vectors[0].Length)
                {
                    File.WriteAllText(Result, $"{InputFilename} must contain vectors of EQUAL lengths");
                }

                vectors[i] = temp;
            }

            return vectors;
        }
        
        

        static void SaveToFile(string resAdding, string resSubtraction, string resMultiplying, string resDividing)
        {
            string result = $"Adding: {resAdding}\n" +
                            $"Subtraction: {resSubtraction}\n" +
                            $"Multiplying: {resMultiplying}\n" +
                            $"Dividing: {resDividing}";

            File.WriteAllText(Result, result);
        }

        
        static void Main()
        {

            double[][] vectors = ReadVectors();
            double[] vOne = vectors[0];
            double[] vTwo = vectors[1];
            
            string resAdding;
            string resSubtraction;
            string resMultiplying;
            string resDividing;
            
            File.WriteAllText(Result, "");
          
            try
            {
                double[] ab = VectorCalculator.Adding(vOne, vTwo);
                resAdding = $"({string.Join(",", vOne)}) + ({string.Join(",", vTwo)}) = ({string.Join(",", ab)})";
            }
            catch (Exception ex)
            {
                resAdding = ex.Message;
            }
            
            try
            {
                double[] cd = VectorCalculator.Subtracting(vOne, vTwo);
                resSubtraction = $"({string.Join(",", vOne)}) - ({string.Join(",", vTwo)}) = ({string.Join(",", cd)})";
            }
            catch (Exception ex)
            {
                resSubtraction = ex.Message;
            }
            
            try
            {
                double[] ef = VectorCalculator.Multiplying(vOne, vTwo);
                resMultiplying = $"({string.Join(",", vOne)}) * ({string.Join(",", vTwo)}) = ({string.Join(",", ef)})";
            }
            catch (Exception ex)
            {
                resMultiplying = ex.Message;
            }
            
            try
            {
                double[] gh = VectorCalculator.Dividing(vOne, vTwo);
                resDividing = $"({string.Join(",", vOne)}) / ({string.Join(",", vTwo)}) = ({string.Join(",", gh)})";
            }
            catch (Exception ex)
            {
                resDividing = ex.Message;
            }
            
            SaveToFile(resAdding, resSubtraction, resMultiplying, resDividing);
        }
    }
}
