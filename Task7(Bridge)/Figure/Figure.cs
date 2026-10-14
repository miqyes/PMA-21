namespace Task7;

abstract  class Shape
{
   public int C { get; set; }
    IColor color;

    public Shape(IColor color,int c)
    {
        this.color = color;
        this.C= c;
    }

    public Shape()
    {
        color = new WithoutColor();
        this.C= 0;
    }
    

    public override string ToString()
    {
        string res= $"\nFigure has a {color.Color} color.";
        if (this is ISquare square)
            res += $"\nSquare={square.Square()} ";
        if(this is IPerimeter perimeter)
            res += $"\nPerimeter={perimeter.Perimeter()} \n ";
        return res;
    }
}




