public class Unperim : Shape, IArea
{
    private double side;

    public Unperim(double side, IColor color) : base(color)
    {
        this.side = side;
    }

    public override string GetName()
    {
        return "Unperim";
    }

    public double GetArea()
    {
        return Math.PI * side;
    }

   
}
