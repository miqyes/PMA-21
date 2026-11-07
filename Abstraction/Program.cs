using System;

namespace UNI
{
    class Program
    {
        static void Main()
        {
            Figure[] figures = { new Circle(3, new Red()), new Rectangle(5, 4, new Green()), new Square(7, new Blue()) };
            foreach (Figure f in figures)
            {
                f.Draw();
            }
        } 
    }
}
