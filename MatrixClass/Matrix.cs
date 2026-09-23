namespace Task4;
public class Matrix
{
    double[,] data = new double[2, 2];

    public Matrix() { }
    public Matrix(double[,] data)
    {
        this.data = data;
    }
    public double this[int i, int j] {
        get { return data[i, j]; }
        set { data[i, j] = value; } }
    
    public static Matrix operator +(Matrix matrixFirst, Matrix matrixSecond) {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrixFirst[i, j] + matrixSecond[i, j]; }
        return res; }
    
    public static Matrix operator -(Matrix matrixFirst, Matrix matrixSecond)
    {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrixFirst[i, j] - matrixSecond[i, j]; }
        return res; }
    
    public static Matrix operator *(Matrix matrixFirst, Matrix matrixSecond)
    {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                for (int k = 0; k < 2; k++)
                    res[i, j] += matrixFirst[i, k] * matrixSecond[k, j]; } }
        return res;
    }
    public static int determinant(Matrix matrix) {
        int determinant = (int)(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
        if (determinant == 0)
            throw new Exception("Визначник дорівнює 0");
        return determinant;
 }
    public static Matrix reverseMatrix(Matrix matrix)
    {
        int det = determinant(matrix);
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (i + j % 2 == 1)
                    res[i, j] = -matrix[i, j] / det;
                res[i, i] = matrix[j-i, j-i]/det;
            }
        }
        return res;
    }
    public static Matrix operator /(Matrix matrixFirst, Matrix matrixSecond)
    {
        return matrixFirst * reverseMatrix(matrixSecond);
    }
    
    public override string ToString()
    {
        return $"{data[0, 0]} {data[0, 1]}\n {data[1, 0]} {data[1, 1]}";
    }
}




