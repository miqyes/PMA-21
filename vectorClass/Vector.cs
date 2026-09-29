namespace VectorClass;

public class Vector
{
    private double[] firstVector;
    private double[] secondVector;
    
    public Vector(double[] firstVector, double[] secondVector)
    {
        this.firstVector = firstVector;
        this.secondVector = secondVector;
    }

    public double[] FirstVector
    {
        get
        {
            return firstVector;
        }
    }
    
    public double[] SecondVector
    {
        get
        {
            return secondVector;
        }
    }
    
    public double[] Add()
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] + secondVector[i];
        }

        return result;
    }
    
    public double[] Sub()
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] - secondVector[i];
        }

        return result;
    }
    
    public double[] Mult()
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            result[i] = firstVector[i] * secondVector[i];
        }

        return result;
    }

    public double[] Div()
    {
        double[] result = new double[firstVector.Length];
        for (int i = 0; i < firstVector.Length; i++)
        {
            if (secondVector[i] == 0)
            {
                throw new DivideByZeroException();
            }
            result[i] = firstVector[i] / secondVector[i];
        }

        return result;
    }
    
}
