namespace UNI;

public abstract class Square: Rectangle
{
    public Square(double side, Color color) : base(side, side, color) { }

    public override string Name => "Square";
}