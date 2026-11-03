namespace abstraction2;

public class Unperimetable : Shape, IPerim, IArea
{
    public Unperimetable(IColour colour) : base(colour)
    {
    }

    double IPerim.GetPerimeter()
    {
        throw new NotSupportedException("This figure does not have a perimeter!");
    }

    double IArea.GetArea()
    {
        throw new NotSupportedException("This figure does not have an area!");
    }
}