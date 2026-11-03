namespace figureClass;

public class Rectangle: Figure, IAreaCalculate, IPerimeterCalculate
{
    private double weight;
    private double height;

    public Rectangle(): base(new NoColour())
    {
        throw new Exception($"Неможливо створити фігури з кольором:  {colour.GetColourName()}: сторони не задані, тому периметр і площу не обчислюємо  ");
    }
    public Rectangle(double height, double weight, IColour colour):base(colour) 
    {
        if (height <= 0 || weight <= 0)
        {
            throw new Exception("Не існує прямокутника з від'ємними сторонами");
        }
        this.height = height;
        this.weight = weight;
    }

    public double Perimeter()
    {
        return 2 * (height + weight);
    }

    public  double Area()
    {
        return height * weight;
    }

    public override void Draw()
    {
        Console.WriteLine($" прямокутник з шириною: {weight} і висотою {height} \n Колір: {colour.GetColourName()} \n з периметром: {Perimeter()} \n з площею: {Area()} ");

    }
}