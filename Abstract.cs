public abstract class Base()
{ 
    public abstract double equation();

    public virtual void Print()
    {
        Console.WriteLine("Equation"+equation());
    }
}

class Linear : Base
{
    double k, b;

    public Linear(double k, double b)
    {
        this.k = k;
        this.b = b;
    }
    override public double equation()
    {
        double x = -b/k;
       // double y = 0;
       /* if (x == 0)
        {
            y = b;
        }

        if (y == 0)
        {
            x = -b / k;
        }
*/
        return x;
    }

    override public void Print()
    {
        Console.WriteLine(k + "x+" + b + "=0");
        Console.WriteLine("x=" + equation());
    }
    
}


class Quadratic : Base
{
    private double x1, x2, a, b, c;
    public Quadratic(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        
    }
        override public double equation()
        {
            double D = b * b - 4 * a * c;
         
            if (D < 0)
            {
                Console.WriteLine("Error");
            }

            if (D == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }

            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
            }

            return D;

        }

        public override void Print()
        {
            Console.WriteLine(a + "x^2+" + b + "x+" + c + "=0");
            
            double D = equation();
            if (D < 0)
            {
                Console.WriteLine("Error");
            }
            else if (D == 0)
            {
                Console.WriteLine("x=" + x1);
            }
            else
            {
                Console.WriteLine("x1=" + x1+";"+ "x2=" + x2);
            }
            
        }

    }
    