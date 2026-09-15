namespace ConsoleApp2;

public class VectorCalculator
{
    public struct Vector
    {
        public double X { get; } 
        public double Y { get; }
        public double Z { get; }

        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }
        

        public static Vector operator -(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        
        public static Vector operator*(Vector vec1, Vector vec2)
        {
            return new Vector(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        }

        
        public static Vector operator /(Vector vec1, Vector vec2)
        {
            return new Vector (vec1.X / vec2.X,
                vec1.Y / vec2.Y,
                vec1.Z / vec2.Z);  
        }
        

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

    }
}
   

       