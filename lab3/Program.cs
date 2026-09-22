namespace vector
{
    class program
    {
        public static void Main()
        {
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

            string[] firstNumbers = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondNumbers = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (firstNumbers.Length != secondNumbers.Length)
            {
                Console.WriteLine("Error: both vectors must have the same number of components!");
                return;
            }

            double[] arr1;
            double[] arr2;
            try
            {
                arr1 = firstNumbers.Select(double.Parse).ToArray();
                arr2 = secondNumbers.Select(double.Parse).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: file must contain only numbers!");
                return;
            }

            vector v1 = new vector(arr1);
            vector v2 = new vector(arr2);

            vector sum = v1 + v2;
            vector difference = v1 - v2;
            vector product = v1 * v2;

            // Перевірка на нуль тільки для ділення
            bool hasZero = arr2.Any(c => c == 0);
            string quotientLine;

            if (hasZero)
            {
                quotientLine = "Quotient= " + v1 + "/" + v2 + "=ПОМИЛКА: ДІЛЕННЯ НА НУЛЬ НЕ МОЖЛИВЕ";
            }
            else
            {
                vector quotient = v1 / v2;
                quotientLine = "Quotient=" + v1 + "/" + v2 + "=" + quotient;
            }

            string result = "First vector: " + v1 + Environment.NewLine +
                "Second vector: " + v2 + Environment.NewLine +
                "Sum=" + v1 + "+" + v2 + "=" + sum + Environment.NewLine +
                "Difference=" + v1 + "-" + v2 + "=" + difference + Environment.NewLine +
                "Product=" + v1 + "*" + v2 + "=" + product + Environment.NewLine +
                quotientLine;

            File.WriteAllText("result.txt", result);
            Console.WriteLine("Result is successfully saved in file 'result.txt'");
        }
    }
}
