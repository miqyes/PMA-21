namespace LabVector;

public class Vectors
{
    public static double[,] masVector = new double[2, 3];
    
    public static double Add(double a, double b)
    {
        return a + b;
    }
    public static double Subtract(double a, double b)
    {
        return a-b;
    }
    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
            return a / b; 
    }

    public static double CheckDivide(double a, double b)
    {
        if (b == 0)
        {
            File.WriteAllText("rezult.txt", "ERROR");
            Environment.Exit(0);
        }
        return a / b;
    }
    
    public static bool Check(string []a, string []b)
    {
        if (a.Length == b.Length)
        {
            return true;  
        }
        else
        {
            File.WriteAllText("rezult.txt", "ERROR");
            return false;  
        }
           
    }

    
}
