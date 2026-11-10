public abstract class Shape
{
    protected Color color { get; set; }

    public abstract string name { get; }
    public abstract double Area();
    public abstract double Perimeter();

    public virtual void Display()
    {
        Console.WriteLine($"Name: {name}, Area: {Area()}, Perimeter: {Perimeter()}, Color: {color.Name}");
    }
    public Shape(Color color)
    {
        this.color = color;
    }
}

public class Rectangle:Shape
{
    public double width;
    public double height;
    public override string name => "Rectangle";
    public Rectangle(double width, double height, Color color) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }

    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}

public class  Square:Shape
{
    public double side;
    public override string name => "Square";

    public Square(double side, Color color) : base(color)
    {
        this.side = side;
    }

    public override double Area()
    {
        return side * side;
    }

    public override double Perimeter()
    {
        return 4 * side;
    }
}

public class Circle : Shape
{
    public double radius;
    public override string name => "Circle";
    public Circle(double radius, Color color) : base(color)
    {
        this.radius = radius;
    }
    public override double Area()
    {
        return Math.PI * radius * radius;
    }
    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}