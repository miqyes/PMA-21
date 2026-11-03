namespace figureClass;

public class Fictional : Figure, IAreaCalculate, IPerimeterCalculate
{
    public Fictional() : base(new NoColour())
    {
    }

     double IAreaCalculate.Area()
    {
        throw new Exception("Площа не існує, оскільки фігура вигадана або не задана!");
    }

     double IPerimeterCalculate.Perimeter()
    {
        throw new Exception("Периметр не існує, оскільки фігура вигадана або не задана!");
    }

    public override void Draw()
    {
        Console.WriteLine($"Неіснуюча фігура \n Колір: {colour.GetColourName()}");
    }
}