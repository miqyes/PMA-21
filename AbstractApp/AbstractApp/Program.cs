public class Program
{
    static void Main()
    {


        Color red = new Red();
        Color blue = new Blue();
        var green = new Green();
        var yellow = new Yellow();

        var rectangle = new Rectangle(5, 10, red);
        var rectangle2 = new Rectangle(1, 15, red);
        var square = new Square(4, blue);
        var square2 = new Square(10, yellow);
        var circle = new Circle(3, green);

        rectangle.Display();
        rectangle2.Display();
        square.Display();
        square2.Display();
        circle.Display();
    }
}