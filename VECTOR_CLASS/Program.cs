namespace vectorClasss
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string[] lines=File.ReadAllLines("vectors.txt");
            File.WriteAllText("resultV.txt", " ");
            Vector vectrFirst = new Vector(lines[0]);
            Vector vectrSecond = new Vector(lines[1]);
            Vector copy= new Vector(vectrFirst);
            string result = $"Add+: {vectrFirst.Add(vectrSecond).Print()}\n"+$"Sub-: {vectrFirst.Sub(vectrSecond).Print()}\n"+$"Multiply*: {vectrFirst.Multiply(vectrSecond).Print()}\n"+$"Divide/: {vectrFirst.Divide(vectrSecond).Print()}\n";
            File.WriteAllText("resultV.txt", result);
            
        }
    }    
}