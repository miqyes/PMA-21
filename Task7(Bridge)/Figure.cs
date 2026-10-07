namespace Task7;

abstract  class Shape
{
    IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public Shape()
    {
        color = new WithoutColor();
    }
    

    public override string ToString()
    {
        string res= $"\nFigure has a {color.Color} color.";
        if (this is ISquare square)
            res += $"\nSquare={square.Square()} ";
        if(this is IPerimeter perimeter)
            res += $"\nPerimeter={perimeter.Perimeter()} \n ";
        return res;
    }
}

class Triangle : Shape,ISquare,IPerimeter
{
    int a, b;
    int angle;

    public Triangle() : base()
    {
        a = 0;
        b = 0;
        angle = 180;
    }

    public Triangle(int a, int b, int angle, IColor color) : base(color)
    {
        this.a = a;
        this.b = b;
        this.angle = angle;
    }

    public double Square()
    {
        return (0.5 * a * b * Math.Sin(angle * Math.PI / 180));
    }

    public double Perimeter()
    {
        return (Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle * Math.PI / 180)) + a + b);
    }

    public override string ToString()
    {
        return $"Shape is Triangle with first side = {a},second = {b},and angle between them = {angle}" +
               base.ToString();
    }
}

class Square : Rectangle
{

    public Square() : base() { }

    public Square(int a, IColor color) : base(a, a, color) { }

    protected override string text()
    {
       return  $"Shape is Square with side = {a}";
    }
}

class Rectangle : Shape,ISquare,IPerimeter
{
    protected int a, b;

    public Rectangle() : base()
    {
        a = 0;
        b = 0;
    }

    public Rectangle(int a, int b, IColor color) : base(color)
    {
        this.a = a;
        this.b = b;
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

class Circle : Shape,ISquare,IPerimeter
{
    int radius;

    public Circle() : base()
    {
        radius = 0;
    }

    public Circle(int radius, IColor color) : base(color)
    {
        this.radius = radius;
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