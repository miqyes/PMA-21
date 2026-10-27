namespace classVector
{
    public class Vector
    {
        public double[] coordinates;
        public Vector(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
        public Vector add(Vector other)
        {
            double[]result=new double[coordinates.Length];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = coordinates[i] + other.coordinates[i];
            }
            return new Vector(result);
        }
        public Vector subtract(Vector other)
        {
            double[] result = new double[coordinates.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = coordinates[i] - other.coordinates[i];
            }
            return new Vector(result);
        }
        public Vector multiply(Vector other)
        {
            double[] result = new double[coordinates.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = coordinates[i] * other.coordinates[i];
            }
            return new Vector(result);
        }
        public Vector divide(Vector other)
        {
            double[] result = new double[coordinates.Length];
            for (int i = 0; i < result.Length; i++)
                if (other.coordinates[i] == 0)
                {
                    throw new DivideByZeroException("Division by zero in coordinate  " + i);
                }
                else
                {
                    result[i] = coordinates[i] / other.coordinates[i];
                }
            return new Vector(result);
        }
        public override string ToString()
        {
            return "(" + string.Join("; ", coordinates) + ")";
        }
    }
}
