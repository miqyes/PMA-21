namespace Task9;
struct Characteristics
{
    public int Memory { get; set; }
    public string Color{ get; set; }
    public double Battery{ get; set; }
    public int Price{ get; set; }

    public Characteristics(int memory, string color, double battery, int price)
    {
        Memory = memory;
        Color = color;
        Battery = battery;
        Price = price;
    }

    public override string ToString()
    {
        return $"Memory: {Memory} GB , Color:{Color}, Battery:{Battery} mAh, Price :{Price} grn \n";
    }
    
    }
