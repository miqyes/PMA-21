class Read
{
    public static Vector[] ReadFromFile(string path)
    {
        Vector[] result = File.ReadAllLines(path).Select(l => new Vector(l.Split(", ").Select(i => float.Parse(i)).ToArray())).ToArray();
        return result;
    }
}