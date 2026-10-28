public class Square : Rectangle
{
    public Square(double side, IColor color) : base(side, side, color)
    {
    }

    public override string GetName()
    {
        return "Square";
    }
}
