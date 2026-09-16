using System;
using System.IO;

namespace VectorLab;

public class Program
{
    
    public static void Main(string[] args)
    {
        
        string input = File.ReadAllText("vector.txt");
        string[] lines = input.Split('\n');
        string[] vector1 = lines[0].Split(" ");   
        string[] vector2 = lines[1].Split(" ");   
        
        
        double x = double.Parse(vector1[0]);
        double y = double.Parse(vector1[1]);
        double z = double.Parse(vector1[2]);
        
        double X = double.Parse(vector2[0]);
        double Y = double.Parse(vector2[1]);
        double Z = double.Parse(vector2[2]);
        
        Console.WriteLine($"x1 = {x}; y1 = {y}; z1 = {z}");
        Console.WriteLine($"x2 = {X}; y2 = {Y}; z2 = {Z}");
       
        
        switch (Console.ReadLine())
        {
            
            case "+":
            { 
              double Newx= (Vector.Add(x, X));
              double Newy= (Vector.Add(y, Y));
              double Newz= (Vector.Add(z, Z));
              File.AppendAllText("result.txt", $"Add -: ({Newx}; {Newy}; {Newz})\n");
              break;
            }
            
            case "-":
            {
                double Newx = Vector.Subtract(x, X);
                double Newy = Vector.Subtract(y, Y);
                double Newz = Vector.Subtract(z, Z);
                File.AppendAllText("result.txt", $"Subtract -: ({Newx}; {Newy}; {Newz})\n");
                break;
            }
            
            case "*":
            {
                double Newx= (Vector.Multiply(x, X));
                double Newy= (Vector.Multiply(y, Y));
                double Newz= (Vector.Multiply(z, Z));
                File.AppendAllText("result.txt", $"Multiply * : ({Newx}; {Newy}; {Newz})\n");
                break;
            }
            
            case "/":
            {
                double Newx= (Vector.Divide(x, X));
                double Newy= (Vector.Divide(y, Y));
                double Newz=  (Vector.Divide(z, Z));
                File.AppendAllText("result.txt", $"Divide /: ({Newx}; {Newy}; {Newz})\n");
                break;
            }
            
            
        }
        

    }
}