namespace figureClass;

abstract public class Figure
{
    protected IColour colour;

    protected Figure(IColour colour)
    {
        this.colour = colour;
    }

    protected Figure()
    {
        this.colour = new NoColour();
    }

    abstract public void Draw();
}