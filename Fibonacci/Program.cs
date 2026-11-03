namespace FibonacciF
{
    class Program
    {
        private const string InputFilename = "input.txt";
        private const string InputRestrictions = "restrictions.txt";
        private const string Output = "output.txt";
        
        static int[] ReadAndParseFile(string path)
        {
            if (!File.Exists(path))
            {
                return new int[0];
            }
            
            string input = File.ReadAllText(path);
            string[] parts = input.Split([", ",","," ","\n","\t","\r"], StringSplitOptions.RemoveEmptyEntries);

            int[] result = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                result[i] = int.Parse(parts[i]);
            }

            return result;
        }


        static int[] HandleErrorAndGetDefault(string path, string customError, int[] defaultValues)
        {
            string error;
            if (!File.Exists(path))
            {
                error = $"Couldn't find file {path}";
            }
            else
            {
                error = customError;
            }
                
            File.AppendAllText(Output, error + $", working with default values\n");
            return defaultValues;
        }
        
        
        static List<int> GetInitialSeq()
        {
            int[] parts = ReadAndParseFile(InputFilename);

            if (parts.Length < 2)
            {
                int[] defaults = HandleErrorAndGetDefault(InputFilename, "Wrong amount of input lines", [0, 1]);
                return new List<int>(defaults);
            }

            return new List<int>(parts);
        }
        
        static int[] GetStepsAndLimit()
        {
            int[] parts = ReadAndParseFile(InputRestrictions);

            if (parts.Length != 2)
            {
                return HandleErrorAndGetDefault(InputRestrictions, "Wrong amount of elements", [7, 150]);
            }

            return parts;
        }

        static void SaveToFile(List<int> seqOne, List<int> seqSecond)
        {
           string result = "Sequence with certain amount of numbers: " + string.Join(", ", seqOne) + "\n" + 
                           "Sequence with limit: " + string.Join(", ", seqSecond);
           File.AppendAllText(Output, result);
        }
        
        static void Main()
        {
            File.WriteAllText(Output, "");
            
            List<int> initialSeq = GetInitialSeq();
            int[] result = GetStepsAndLimit();
            
            List<int> sSeq = new List<int>(initialSeq);
            Fibonacci.StepsSeq(sSeq, result[0]);
    
            List<int> lSeq = new List<int>(initialSeq);
            Fibonacci.LimitedSeq(lSeq, result[1]);
    
            SaveToFile(sSeq, lSeq);
        }
    }
}