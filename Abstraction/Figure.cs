namespace UNI;

public abstract class Figure: AArea, PPerimetr
{
    protected Color color;

    protected Figure(Color color)
    {
        this.color = color;
    }

    public abstract string Name
    {
        get;
    }

    public abstract double GetArea();
    public abstract double GetPerimetr();
    

    public void Draw()
    {
        Console.Write($"{color.Name}, {Name}: " + $"Area={GetArea()}, perimetr={GetPerimetr()}; ");
    }
}