
namespace UNI
{
    public class Vector
    {
        private double[] vector;
        public int size=>vector.Length;

        public Vector(double[] value,int s)
        {
            vector = value;
            s = size;
        }
       
        public Vector(string values)
        {
            vector=values.Split(',').Select(double.Parse).ToArray();
        }

        public bool checksize(Vector other)
        {
            if (size != other.size)
            { 
                Console.WriteLine("Sizes does not match");
                return false;
            }
            else
            {
                return true;
            }
        }

       public string[] calculate(Vector other)
        {
            double[] add = new double[size];
            double[] sub = new double[size];
            double[] mul = new double[size];
            double[] div = new double[size];

            for (int i = 0; i < size; i++)
            {
                add[i] = vector[i] + other.vector[i];
                sub[i] = vector[i] - other.vector[i];
                mul[i] = vector[i] * other.vector[i];
                div[i] = vector[i] / other.vector[i];
                if (other.vector[i] == 0)
                {
                    Console.WriteLine("Error!Div on 0!");
                }
            }
        
            string addi = $"({string.Join(",", vector)})+({string.Join(",", other.vector)})=({string.Join(",", add)})";
            string subi = $"({string.Join(",", vector)})-({string.Join(",", other.vector)})=({string.Join(",", sub)})";
            string muli = $"({string.Join(",", vector)})*({string.Join(",", other.vector)})=({string.Join(",", mul)})";
            string divi = $"({string.Join(",", vector)})/({string.Join(",", other.vector)})=({string.Join(",", div)})";

            string[] results = { addi, subi, muli, divi };
            return results;
        }
    }
}
