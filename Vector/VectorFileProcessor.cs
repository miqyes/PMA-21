public class VectorFileProcessor
{
    public void ProcessFile(string inputFilePath, string outputFilePath)
    {
        try
        {
            var lines = File.ReadAllLines(inputFilePath);

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string result = ProcessLine(line);
                        writer.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"{line} Error: {ex.Message}");
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"file I/O error: {ex.Message}");
        }
    }

    private string ProcessLine(string line)
    {
        string cleanLine = line.Replace(" ", "");

        int firstClose = cleanLine.IndexOf(')');
        int secondOpen = cleanLine.IndexOf('(', firstClose);
        int secondClose = cleanLine.IndexOf(')', secondOpen);

        string vec1Str = cleanLine.Substring(1, firstClose - 1);
        string op = cleanLine.Substring(firstClose + 1, secondOpen - firstClose - 1);
        string vec2Str = cleanLine.Substring(secondOpen + 1, secondClose - secondOpen - 1);

        var vec1 = ParseVector(vec1Str);
        var vec2 = ParseVector(vec2Str);

        Vector result = null;

        switch (op)
        {
            case "+":
                result = vec1 + vec2;
                break;
            case "-":
                result = vec1 - vec2;
                break;
            case "*":
                result = vec1 * vec2;
                break;
            case "/":
                result = vec1 / vec2;
                break;
            default:
                throw new InvalidOperationException("unknown operator.");
        }

        return result.ToString();
    }

    private Vector ParseVector(string str)
    {
        var parts = str.Split(',');
        var coords = new double[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            coords[i] = double.Parse(parts[i].Replace('.', ','));
        }

        return new Vector(coords);
    }
}