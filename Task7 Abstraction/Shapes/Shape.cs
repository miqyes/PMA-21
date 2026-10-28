public abstract class Shape
{
    protected IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public virtual string GetName()
    {
        return "Shape";
    }

    public override string ToString()
    {
        string text = GetName() + ", color: " + color.GetName();
        IArea areaShape = this as IArea;
        if (areaShape != null)
        {
            text += "\nArea: " + areaShape.GetArea();
        }
        IPerimeter perimeterShape = this as IPerimeter;
        if (perimeterShape != null)
        {
            text += "\nPerimeter: " + perimeterShape.GetPerimeter();
        }
        text += "\n\n";
        return text;
    }
}
