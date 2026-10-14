namespace Task7;

class Triangle : Shape,ISquare,IPerimeter
{
    int a;
    int angle;

    public Triangle()
    {
        a = 0;
        angle = 180;
    }

    public Triangle(int a, int b, int angle, IColor color) : base(color,b)
    {
        this.a = a;
        this.angle = angle;
    }

    public double Square()
    {
        return (0.5 * a * C * Math.Sin(angle * Math.PI / 180));
    }

    public double Perimeter()
    {
        return (Math.Sqrt(a * a + C * C - 2 * a * C * Math.Cos(angle * Math.PI / 180)) + a + C);
    }

    public override string ToString()
    {
        return $"Shape is Triangle with first side = {a},second = {C},and angle between them = {angle}" +
               base.ToString();
    }
}
