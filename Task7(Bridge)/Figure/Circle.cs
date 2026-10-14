namespace Task7;

class Circle : Shape,ISquare,IPerimeter
{
    int radius;

    public Circle() 
    {
        radius = 0;
    }

    public Circle(int radius, IColor color) : base(color,radius)
    {
    }

    public double Square()
    {
        return (Math.PI * radius * radius);
    }

    public double Perimeter()
    {
        return (2 * (Math.PI * radius));
    }

    public override string ToString()
    {
        return $"Shape is Circle with radius = {radius}" + base.ToString();
    }
}