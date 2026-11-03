using System;

namespace abstraction2
{
    class Program
    {
        static void Main()
        {
            IColour red = new Red();
            IColour blue = new Blue();
            IColour green = new Green();
            IColour nocolour = new NoColour();

            try
            {
                Shape circle = new Circle(5, red);
                Console.WriteLine("Figure 1: circle");
                Console.Write("Colour: ");
                Console.WriteLine(circle.GetColourName());
                
                Console.Write("Perimeter: ");
                Console.WriteLine(((IPerim)circle).GetPerimeter());
                
                Console.Write("Area: ");
                Console.WriteLine(((IArea)circle).GetArea());
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                Shape rectangle = new Rectangle(5, 5, blue);
                Console.WriteLine("Figure 2: rectangle");
                Console.Write("Colour: ");
                Console.WriteLine(rectangle.GetColourName());
                
                Console.Write("Perimeter: ");
                Console.WriteLine(((IPerim)rectangle).GetPerimeter());
                
                Console.Write("Area: ");
                Console.WriteLine(((IArea)rectangle).GetArea());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            try
            {
                Shape square = new Square(5, green);
                Console.WriteLine("Figure 3: square");
                Console.Write("Colour: ");
                Console.WriteLine(square.GetColourName());
                
                Console.Write("Perimeter: ");
                Console.WriteLine(((IPerim)square).GetPerimeter());
                
                Console.Write("Area: ");
                Console.WriteLine(((IArea)square).GetArea());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Shape unknown = new Unperimetable(nocolour);
                Console.WriteLine("Figure 4: unknown");
                Console.Write("Colour: ");
                Console.WriteLine(unknown.GetColourName());
                
                Console.Write("Perim: ");
                Console.WriteLine(((IPerim)unknown).GetPerimeter());
                
                Console.Write("Area: ");
                Console.WriteLine(((IArea)unknown).GetArea());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}