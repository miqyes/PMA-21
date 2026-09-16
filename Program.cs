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
        
        
        double x1 = double.Parse(vector1[0]);
        double y1 = double.Parse(vector1[1]);
        double z1 = double.Parse(vector1[2]);
        double x2 = double.Parse(vector2[0]);
        double y2 = double.Parse(vector2[1]);
        double z2 = double.Parse(vector2[2]);
        
        Console.WriteLine($"x1 = {x1}; y1 = {y1}; z1 = {z1}");
        Console.WriteLine($"x2 = {x2}; y2 = {y2}; z2 = {z2}");
       
        Console.WriteLine("Vector Calculate:");
        Console.WriteLine("Add + :");
        Console.WriteLine("Subtract - :");
        Console.WriteLine("Multiply * :");
        Console.WriteLine("Divide / :");
        Console.WriteLine("Choose operation:");
        
        switch (Console.ReadLine())
        {
            
            case "+":
            { 
              Console.WriteLine("result:");
              double Newx= (Vector.Add(x1, x2));
              double Newy= (Vector.Add(y1, y2));
              double Newz= (Vector.Add(z1, z2));
             Console.WriteLine($"({Newx}; {Newy}; {Newz})");
              break;
            }
            
            case "-":
            {
                Console.WriteLine("result:");
                double Newx= (Vector.Subtract(x1, x2));
                double Newy= (Vector.Subtract(y1, y2));
                double Newz= (Vector.Subtract(z1, z2));
                Console.WriteLine($"({Newx}; {Newy}; {Newz})");
                break;
            }
            
            case "*":
            {
                Console.WriteLine("result:");
                double Newx= (Vector.Multiply(x1, x2));
                double Newy= (Vector.Multiply(y1, y2));
                double Newz= (Vector.Multiply(z1, z2));
                Console.WriteLine($"({Newx}; {Newy}; {Newz})");
                break;
            }
            
            case "/":
            {
                Console.WriteLine("result:");
                double Newx= (Vector.Divide(x1, x2));
                double Newy= (Vector.Divide(y1, y2));
                double Newz=  (Vector.Divide(z1, z2));
                Console.WriteLine($"({Newx}; {Newy}; {Newz})");
                break;
            }
            
            
        }
        

    }
}