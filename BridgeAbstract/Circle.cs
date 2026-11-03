namespace figureClass;

public class Circle:Figure,IPerimeterCalculate, IAreaCalculate
{
    private double radius;

    public Circle():base(new NoColour())
    {
        throw new Exception($"Неможливо створити фігури з кольором {colour.GetColourName()} \n сторони не задані, тому периметр і площу не обчислюємо  ");
    }
    public Circle(double radius, IColour colour) : base(colour)
    {
        if (radius <= 0)
        {
            throw new Exception("Такої фігури не існує (радіус має бути додатним)");
        }
        this.radius = radius;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    public double Perimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override void Draw()
    {
        Console.WriteLine($" коло з радіусом: {radius} \n Колір: {colour.GetColourName()} \n   з периметром: {Perimeter()} \n з площею: {Area()} ");
    }
}