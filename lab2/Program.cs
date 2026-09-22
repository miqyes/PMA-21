namespace Vector
{
    class Program
    {
        static void Main()
        {
            string[] firstVector;
            string[] secondVector;

            try
            {
                firstVector = File.ReadAllText("firstvector.txt").Split(',');
                secondVector = File.ReadAllText("secondvector.txt").Split(',');
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: cannot find file!");
                return;
            }

            if (firstVector.Length < 1)
            {
                Console.WriteLine("Error: you must have at least 1 coordinate!");
                return;
            }

            if (secondVector.Length != firstVector.Length)
            {
                Console.WriteLine("Error: the number of coordinates in your vector must be the same");
                return;
            }
            
            int n = firstVector.Length;
            double[] first = new double[n];
            double[] second = new double[n];

            for (int i = 0; i < n; i++)
            {
                first[i] = double.Parse(firstVector[i]);
                second[i] = double.Parse(secondVector[i]);
            }
            
            var add = Calculator.Add(first, second);
            var sub = Calculator.Sub(first, second);
            var mult = Calculator.Mult(first, second);

            string divResult;
            try
            {
                var div = Calculator.Div(first, second);
                divResult = "(" + string.Join(",", firstVector) + ")" + "/" + "(" + string.Join(",", secondVector) +
                            ")" + "=" + "(" + string.Join(",", div) + ")";
            }
            catch (DivideByZeroException)
            {
                divResult = "Error: you cannot divide by zero!";
            }

            string addResult = "(" + string.Join(",", firstVector) + ")" + "+" + "(" + string.Join(",", secondVector) +
                               ")" + "=" + "(" + string.Join(",", add) + ")";
            string subResult = "(" + string.Join(",", firstVector) + ")" + "-" + "(" + string.Join(",", secondVector) +
                               ")" + "=" + "(" + string.Join(",", sub) + ")";
            string multResult = "(" + string.Join(",", firstVector) + ")" + "*" + "(" + string.Join(",", secondVector) +
                                ")" + "=" + "(" + string.Join(",", mult) + ")";
            string[] result = { addResult, subResult, multResult, divResult };
            File.WriteAllLines("output.txt", result);
        }            
    }
}