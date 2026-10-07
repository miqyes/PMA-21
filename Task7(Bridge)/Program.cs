namespace Task7;

class Person
{
    static void Main()
    {
        List<Shape> shape = new List<Shape>();
        shape.Add(new Rectangle(3, 5, new RedColor()));
        shape.Add(new Square(5, new BlueColor()));
        shape.Add(new Triangle(3, 4, 90, new GreenColor()));
        shape.Add(new Circle(10, new RedColor()));
        shape.Add(new Rectangle());
        shape.Add(new Square());
        shape.Add(new Triangle());
        shape.Add(new Circle());
        foreach (var figure in shape) Console.WriteLine(figure);
    }
}