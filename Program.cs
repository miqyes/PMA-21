class Program
{
    static void Main()
    {
        Base[] eqs =
        {
            new Linear(2, 4),
            new Quadratic(1, -5, 6)
        };

        foreach (Base e in eqs)
        {
            e.Print();
        }
         
    }
}