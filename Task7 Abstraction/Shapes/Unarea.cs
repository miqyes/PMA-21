public class Unarea : Shape, IPerimeter
{
    private double side;

    public Unarea(double side, IColor color) : base(color)
    {
        this.side = side;
    }

    public override string GetName()
    {
        return "Unarea";
    }

    public double GetPerimeter()
    {
        return 2 * side;
    }
}
