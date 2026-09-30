namespace  vectorClass;

static class FileWorker
{
    public static Vector[] readFromFile(string filePath, string separator)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found: " + filePath);
        }

        string[] lines = File.ReadAllLines(filePath);
        string[] firstParts = lines[0].Split(separator);
        string[] secondParts = lines[1].Split(separator);
        double[] vectorFirst = new double[firstParts.Length];
        double[] vectorSecond = new double[secondParts.Length];

        if (vectorFirst.Length != vectorSecond.Length)
        {
            throw new ArgumentException("Vectors are not equal");
        }

        for (int i = 0; i < vectorFirst.Length; i++)
        {
            vectorFirst[i] = double.Parse(firstParts[i]);
        }

        for (int i = 0; i < vectorSecond.Length; i++)
        {
            vectorSecond[i] = double.Parse(secondParts[i]);
        }

        return [new Vector(vectorFirst), new Vector(vectorSecond)];


    }

    public static void writeToFile(string resultFilePath, Vector vectorFirst, Vector vectorSecond, Vector add,
        Vector subtract, Vector multiply, Vector? division)
    {
        string messageDivision;
        if (division==null)
        {
            messageDivision = "Division by 0";
        }
        else
        {
            messageDivision = string.Join(" ", division);
        }
        File.WriteAllText(resultFilePath, "Vectors:\na=(" + vectorFirst + ")\nb=(" + vectorSecond + ")\nOperation\n(" +
                                          vectorFirst + ") + (" + vectorSecond + ") = (" + add + ")\n(" +
                                          vectorFirst + ") - (" + vectorSecond + ") = ("+ subtract + ")\n(" +
                                          vectorFirst + ") * (" + vectorSecond + ") = (" + multiply + ")\n(" +
                                          vectorFirst + ") / (" + vectorSecond + ") = (" + messageDivision + ")\n");

    }
}
    
