using System;

namespace ConsoleApp2
{
    static class Program
    {
        static VectorCalculator.Vector[] GetCoordinates()
        {
            if (!File.Exists("coordinates.txt"))
            {
                Console.WriteLine("Couldn't find coordinates.txt");
                
                Environment.Exit(1);
               
            }
            

            string [] input = File.ReadAllLines("coordinates.txt");
            if (input.Length < 2)
            {
                Console.WriteLine("сoordinates.txt must contain at least 2 vectors");
                Environment.Exit(1);
            }
            
            VectorCalculator.Vector[] vectors = new VectorCalculator.Vector[input.Length];
            
            for (int i = 0; i < input.Length; i++)
            {
                string [] cleaned = input[i].Replace("(", "").Replace(")", "").Trim().Split(", ");
                vectors[i] = new VectorCalculator.Vector(
                    double.Parse(cleaned[0]),
                    double.Parse(cleaned[1]),
                    double.Parse(cleaned[2])
                );

            }
            return vectors;
            
        }

        
        static VectorCalculator.Vector Adding (VectorCalculator.Vector v1, VectorCalculator.Vector v2)
        {
            VectorCalculator.Vector outcome = v1 + v2;
            Console.WriteLine($"Adding: {v1} + {v2} = {outcome}");
            return outcome;
        }

        
        static VectorCalculator.Vector Subtraction (VectorCalculator.Vector v1, VectorCalculator.Vector v2)
        {
            VectorCalculator.Vector outcome = v1 - v2;
            Console.WriteLine($"Subtraction: {v1} - {v2} = {outcome}");
            return outcome;
        }

        static VectorCalculator.Vector Multiplying(VectorCalculator.Vector v1, VectorCalculator.Vector v2)
        {
            VectorCalculator.Vector outcome = v1 * v2;
            Console.WriteLine($"Multiplying: {v1} * {v2} = {outcome}");
            return outcome;
        }

        static VectorCalculator.Vector Dividing(VectorCalculator.Vector v1, VectorCalculator.Vector v2)
        {
            if (v2.X == 0 || v2.Y == 0 || v2.Z == 0)
            {
                Console.WriteLine("Cannot divide by zero ;3");
                Environment.Exit(1);
            }

            VectorCalculator.Vector outcome = v1 / v2;
            Console.WriteLine($"Dividing: {v1} / {v2} = {outcome}");
            return outcome;
        }
        
        

        static void SaveToFile(VectorCalculator.Vector v1, VectorCalculator.Vector v2, VectorCalculator.Vector v3,
            VectorCalculator.Vector v4, VectorCalculator.Vector[] vectors)
        {

            string result = $"Adding: {vectors[0]} + {vectors[1]} = {v1}\n" +
                            $"Subtraction: {vectors[0]} - {vectors[1]} = {v2}\n" +
                            $"Multiplying: {vectors[0]} * {vectors[1]} = {v3}\n" +
                            $"Dividing: {vectors[0]} / {vectors[1]} = {v4}\n";
            
            
            File.WriteAllText("result.txt", result);


        }
        
        static void Main()
        {
            VectorCalculator.Vector[] vectors = GetCoordinates();
            
            VectorCalculator.Vector aa1 = Adding(vectors[0], vectors[1]);
            VectorCalculator.Vector bb1 = Subtraction(vectors[0], vectors[1]);
            VectorCalculator.Vector cc1 = Multiplying(vectors[0], vectors[1]);
            VectorCalculator.Vector dd1 = Dividing(vectors[0], vectors[1]);
            
            SaveToFile(aa1, bb1, cc1, dd1, vectors);

            
        }
        
    }
}
        
        
        
    
