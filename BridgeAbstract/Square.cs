namespace figureClass;

public class Square:Rectangle
{
    private double side;
    public Square():base()
    {
        throw new Exception($"Неможливо створити фігури з кольором:  {colour.GetColourName()}: сторони не задані, тому периметр і площу не обчислюємо  ");
    }
    public Square(double side, IColour colour) : base(side, side, colour)
    {
        this.side = side;
    }

    public override void Draw()
    {
        Console.WriteLine($" сторона квадрата : {side}  \n Колір: {colour.GetColourName()}\n периметр: {Perimeter()} \n площа: {Area()} ");
    }
}