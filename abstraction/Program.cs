using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Color red = new RedColor();
        Color blue = new BlueColor();
        Color green = new GreenColor();
        Color purple = new PurpleColor();

        Shape[] shapes = new Shape[]
        {
            new Circle(radius: 5, color: purple),
            new Rectangle(width: 4, height: 6, color: blue),
            new Square(side: 3.5, color: green)
        };

        foreach (var shape in shapes)
            shape.DisplayInfo();
    }
}