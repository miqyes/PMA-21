namespace Task7;

class Square : Rectangle
{

    public Square()  { }

    public Square(int a, IColor color) : base(a, a, color) { }

    protected override string text()
    {
        return  $"Shape is Square with side = {a}";
    }
}
