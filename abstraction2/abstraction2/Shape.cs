namespace abstraction2;

public class Shape
{
    private IColour colour;

    protected Shape(IColour colour)
    {
        this.colour = colour;
    }

    public string GetColourName()
    {
        return colour.GetColourName();
    }
}