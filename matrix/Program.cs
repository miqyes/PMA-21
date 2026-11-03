using System.Globalization;

class Program
{
    static double[,] Add(double[,] a, double[,] b){
        double[,] result = new double[2, 2];
        for(int i = 0; i < 2; i++){
            for(int j = 0; j < 2; j++){
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    static double[,] Subtract(double[,] a, double[,] b){
        double[,] result = new double[2, 2];
        for(int i = 0; i < 2; i++){
            for(int j = 0; j < 2; j++){
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    static double[,] Multiply(double[,] a, double[,] b){
        double[,] result = new double[2, 2];
        for(int i = 0; i < 2; i++){
            for(int j = 0; j < 2; j++){
                for(int k = 0; k < 2; k++){
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    static double Determinant(double[,] m){
        return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
    }

    static double[,] Inverse(double[,] m){
        double det = Determinant(m);
        double[,] result = new double[2, 2];
        result[0, 0] = m[1, 1] / det;
        result[0, 1] = -m[0, 1] / det;
        result[1, 0] = -m[1, 0] / det;
        result[1, 1] = m[0, 0] / det;
        return result;
    }

    static double[,] Divide(double[,] a, double[,] b){
        return Multiply(a, Inverse(b));
    }

    static string Number(double x){
        return Math.Round(x, 2).ToString(CultureInfo.InvariantCulture);
    }

    static string[] ToRows(double[,] m){
        string row0 = Number(m[0, 0]) + " " + Number(m[0, 1]);
        string row1 = Number(m[1, 0]) + " " + Number(m[1, 1]);
        int width = Math.Max(row0.Length, row1.Length);
        return new[] { row0.PadRight(width), row1.PadRight(width) };
    }

    static void Save(List<string> result, double[,] a, char operation, double[,] b, double[,] c){
        string[] ra = ToRows(a);
        string[] rb = ToRows(b);
        string[] rc = ToRows(c);
        result.Add(ra[0] + "   " + rb[0] + "   " + rc[0]);
        result.Add(ra[1] + " " + operation + " " + rb[1] + " = " + rc[1]);
        result.Add("");
    }

    static void Main()
    {
        string input = Path.Combine("..", "..", "..", "info", "input.txt");
        string output = Path.Combine("..", "..", "..", "info", "output.txt");

        if (!File.Exists(input)){
            Console.WriteLine("[ERROR] Input file doesn't exist.");
            return;
        }

        try
        {
            double[] numbers = File.ReadAllText(input)
                .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                .ToArray();

            if (numbers.Length < 8)
            {
                Console.WriteLine("[ERROR] File input.txt must have 2 matrices 2x2");
                return;
            }

            double[,] a = { { numbers[0], numbers[1] }, { numbers[2], numbers[3] } };
            double[,] b = { { numbers[4], numbers[5] }, { numbers[6], numbers[7] } };

            List<string> result = new List<string>();
            Save(result, a, '+', b, Add(a, b));
            Save(result, a, '-', b, Subtract(a, b));
            Save(result, a, '*', b, Multiply(a, b));

            if (Determinant(b) == 0)
            {
                result.Add("A/B: [ERROR] det(B) = 0, matrix B has no inverse");
            }
            else
            {
                Save(result, a, '/', b, Divide(a, b));
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
