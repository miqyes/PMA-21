public abstract class Color
{
    public string Name { get; }
    public string HexCode { get; }
    public virtual void applyColor() { }

    protected Color(string name, string hexCode)
    {
        Name = name;
        HexCode = hexCode;
    }
}

public class Red : Color
{
 public Red(): base("Red", "#FF0000") { }
}
public class Green : Color
{
    public Green() : base("Green", "#00FF00") { }
}
public class Blue : Color
{
    public Blue() : base("Blue", "#0000FF") { }
}

public class Yellow : Color
{
    public Yellow() : base("Yellow", "#FFFF00") { }
}