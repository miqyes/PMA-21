namespace figureClass;

class Program
{
    private const string tab = "___________________";
    static void Main()
    {
        IColour red = new RedColour();
        IColour orange = new OrangeColour();
        IColour purple = new PurpleColour();
        try
        {
            Figure redCircle = new Circle(1, red);
            redCircle.Draw();
            Console.WriteLine(tab);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Помилка {exception.Message}");
        }
        try
        {
            Figure orangeRectangle = new Rectangle(5, 6, orange);
            orangeRectangle.Draw();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Помилка {exception.Message}");
        }

        try
        {
            Figure purpleSquare = new Square(4, purple);
            Console.WriteLine(tab);
            purpleSquare.Draw();
            Console.WriteLine(tab);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Помилка {exception.Message}");
        }

        try
        {
            Figure nonExistentCircle = new Circle();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        try
        {
            Figure nonExsistent = new Fictional();
            nonExsistent.Draw();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
