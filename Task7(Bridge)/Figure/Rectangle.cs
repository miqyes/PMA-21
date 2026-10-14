namespace Task7;

class Rectangle : Shape,ISquare,IPerimeter
{
    protected int a, b;

    public Rectangle() 
    {
        a = 0;
        b = 0;
    }

    public Rectangle(int a, int b, IColor color) : base(color,b)
    {
        this.a = a;
    }

    public double Square()
    {
        return a * b;
    }

    public double Perimeter()
    {
        return 2 * (a + b);
    }

    protected virtual string text()
    {
        return $"Shape is Rectangle with first side = {a},second = {b}";
    }
    public override string ToString()
    {
        return text() + base.ToString();
    }
}
