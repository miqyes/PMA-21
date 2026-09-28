using System;
using System.Drawing;

public class Color
{
    public string Name { get; }
    public string HexCode { get; }

    protected Color(string name, string hexCode)
    {
        Name = name;
        HexCode = hexCode;
    }

    public virtual string ApplyColor()
    {
        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(HexCode);

        Console.Write($"\x1b[38;2;{c.R};{c.G};{c.B}m");

        return $"{Name} ({HexCode})";
    }

    public virtual void RestColor()
    {
        Console.Write("\x1b[0m");
    }
}

public class RedColor : Color
{
    public RedColor() : base("Red", "#FF0000") { }
}

public class BlueColor : Color
{
    public BlueColor() : base("Blue", "#0000FF") { }
}

public class GreenColor : Color
{
    public GreenColor() : base("Green", "#00FF00") { }
}

public class PurpleColor : Color
{
    public PurpleColor() : base("Purple", "#CB84FA") { }
}