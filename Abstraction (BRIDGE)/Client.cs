namespace Abstraction
{

    public class Client
    {
        public void Run()
        {
            IColour red = new Red();
            IColour yellow = new Yellow();
            IColour purple = new Purple();


            Shape[] shapes = new Shape[]
            {
                new Circle(5.0, red),
                new Rectangle(4.0, 6.0, yellow),
                new Square(4.0, purple),
                new Circle(3.5, purple),
                new Circle (),
                new Square(),
                new Rectangle()
               
            };
            
            
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i]);
                
            }
        }

    }
}