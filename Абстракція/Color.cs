using System;

public abstract class Color
{
    public abstract string GetColor();
}

public class Red : Color
{
    public override string GetColor()
    {
        return "Red";
    }
}

public class Blue: Color
{
    public override string GetColor()
    {
        return "Blue";
    }
}

public class Green: Color
{
    public override string GetColor()
    {
        return "Green";
    }
}