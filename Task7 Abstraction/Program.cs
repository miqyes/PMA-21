class Program
{
    static void Main()
    {
        IColor red = new Red();
        IColor blue = new Blue();
        IColor green = new Green();

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle(1, red));
        shapes.Add(new Rectangle(4, 6, blue));
        shapes.Add(new Square(3, green));
        shapes.Add(new Circle(2, blue));
        shapes.Add(new Square(7, red));
        shapes.Add(new Unperim(2, red));
        shapes.Add(new Unarea(26, green));

        Console.WriteLine(string.Concat(shapes.Select(shape => shape.ToString())));
    }
}
