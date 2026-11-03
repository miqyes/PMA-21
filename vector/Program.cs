using System.Globalization;

class Program
{
    static int[] Add(int[] a, int[] b){
        int[] result = new int[a.Length];
        for(int i = 0; i < a.Length; i++){
            result[i] = a[i] + b[i];
        }
        return result;
    }

    static int[] Subtract(int[] a, int[] b){
        int[] result = new int[a.Length];
        for(int i = 0; i < a.Length; i++){
            result[i] = a[i] - b[i];
        }
        return result;
    }

    static int[] Multiply(int[] a, int number){
        int[] result = new int[a.Length];
        for(int i = 0; i < a.Length; i++){
            result[i] = a[i] * number;
        }
        return result;
    }

    static double[] Divide(int[] a, int number){
        double[] result = new double[a.Length];
        for(int i = 0; i < a.Length; i++){
            result[i] = (double)a[i] / number;
        }
        return result;
    }

    static string ToText(int[] vector){
        return "(" + string.Join(",", vector) + ")";
    }

    static string ToText(double[] vector){
        return "(" + string.Join(",", vector.Select(x => Math.Round(x, 2).ToString(CultureInfo.InvariantCulture))) + ")";
    }

    static void Main()
    {
        string input = Path.Combine("..", "..", "..", "info", "input.txt");
        string number = Path.Combine("..", "..", "..", "info", "number.txt");
        string output = Path.Combine("..", "..", "..", "info", "output.txt");

        if (!File.Exists(input) || !File.Exists(number)){
            Console.WriteLine("[ERROR] Input files don't exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(input);
            int numberContent = int.Parse(File.ReadAllText(number).Trim());

            List<int[]> vectors = new List<int[]>();
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                int[] vector = line
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                vectors.Add(vector);
            }

            if (vectors.Count < 2)
            {
                Console.WriteLine("[ERROR] File input.txt has <2 vectors");
                return;
            }

            int[] a = vectors[0];
            int[] b = vectors[1];

            if (a.Length != b.Length)
            {
                Console.WriteLine("[ERROR] Vectors must have the same length");
                return;
            }

            List<string> result = new List<string>();
            result.Add(ToText(a) + "+" + ToText(b) + "=" + ToText(Add(a, b)));
            result.Add(ToText(a) + "-" + ToText(b) + "=" + ToText(Subtract(a, b)));
            result.Add(ToText(a) + "*" + numberContent + "=" + ToText(Multiply(a, numberContent)));

            if (numberContent == 0)
            {
                result.Add(ToText(a) + "/" + numberContent + "=[ERROR] Division by zero");
            }
            else
            {
                result.Add(ToText(a) + "/" + numberContent + "=" + ToText(Divide(a, numberContent)));
            }

            File.WriteAllLines(output, result);

            foreach (string line in result)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
    }
}
