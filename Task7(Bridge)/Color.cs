namespace Task7;

interface IColor
{
    string Color { get; }
}

class RedColor : IColor
{
    public string Color
    {
        get { return "red"; }
    }
}

class WithoutColor : IColor
{
    public string Color
    {
        get { return "without"; }
    }
}

class BlueColor : IColor
{
    public string Color
    {
        get { return "blue"; }
    }
}

class GreenColor : IColor
{
    public string Color
    {
        get { return "green"; }
    }
}