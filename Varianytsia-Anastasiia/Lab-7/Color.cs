using System;

abstract class Color
{
    public abstract string GetName();
}

class Red : Color
{
    public override string GetName()
    {
        return "червоний";
    }
}

class Blue : Color
{
    public override string GetName()
    {
        return "синій";
    }
}

class Green : Color
{
    public override string GetName()
    {
        return "зелений";
    }
}