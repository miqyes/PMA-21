namespace VectorClass{
class Program
    {
        private const string InputFileName = "vector.txt";
        private const string OutputFileName = "result.txt";

        static double[] ParseLine(string line)
        {
            return line.Split([", ", ",", " ", "\n", "\t", "\r"], StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }

        static Vector[] ReadVectors()
        {
            if (!File.Exists(InputFileName))
            {
                File.WriteAllText(OutputFileName, $"Couldn't find file {InputFileName}");
                Environment.Exit(1);
            }

            string[] input = File.ReadAllLines(InputFileName);
            
            if (input.Length < 2)
            {
                File.WriteAllText(OutputFileName, $"{InputFileName} must contain at least 2 vectors");
                Environment.Exit(1);
            }

            
            double[] firstTemp = ParseLine(input[0]);
            
            Vector baseVector = new Vector(firstTemp);
            
            Vector[] vectors = new Vector[input.Length];
            vectors[0] = baseVector;

            for (int i = 1; i < input.Length; i++)
            {
                double[] temp = ParseLine(input[i]);

                if (temp.Length != baseVector.Length)
                {
                    File.WriteAllText(OutputFileName, $"Vectors must be of equal length");
                    Environment.Exit(1);
                }
                
                Vector currentVector = new Vector(temp);
                vectors[i] = currentVector;
            }

            return vectors;
        }

        
        static void SaveToFile(string resAdding, string resSubtraction, string resMultiplying, string resDividing)
        {
            string result = $"Adding: {resAdding}\r\n\r\n" +
                            $"Subtraction: {resSubtraction}\r\n\r\n" +
                            $"Multiplying: {resMultiplying}\r\n\r\n" +
                            $"Dividing: {resDividing}";

            File.WriteAllText(OutputFileName, result);
        }

        static void Main()
        {
            Vector[] vectors = ReadVectors();
            Vector vectorFirst = vectors[0];
            Vector vectorSecond = vectors[1];

            string resAdding;
            string resSubtraction;
            string resMultiplying;
            string resDividing;

            File.WriteAllText(OutputFileName, "");

            try
            {
                Vector ab = vectorFirst + vectorSecond;
                resAdding = $"({vectorFirst}) + ({vectorSecond}) = ({ab})";
            }
            catch (Exception ex)
            {
                resAdding = ex.Message;
            }

            try
            {
                Vector cd = vectorFirst - vectorSecond;
                resSubtraction = $"({vectorFirst}) - ({vectorSecond}) = ({cd})";
            }
            catch (Exception ex)
            {
                resSubtraction = ex.Message;
            }

            try
            {
                Vector ef = vectorFirst * vectorSecond;
                resMultiplying = $"({vectorFirst}) * ({vectorSecond}) = ({ef})";
            }
            catch (Exception ex)
            {
                resMultiplying = ex.Message;
            }

            try
            {
                Vector gh = vectorFirst / vectorSecond;
                resDividing = $"({vectorFirst}) / ({vectorSecond}) = ({gh})";
            }
            catch (Exception ex)
            {
                resDividing = ex.Message;
            }

            SaveToFile(resAdding, resSubtraction, resMultiplying, resDividing);
        }
    }
}
