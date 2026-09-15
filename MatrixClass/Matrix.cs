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
    
    public static Matrix operator +(Matrix matrix1, Matrix matrix2) {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrix1[i, j] + matrix2[i, j]; }
        return res; }
    
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)
    {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrix1[i, j] - matrix2[i, j]; }
        return res; }
    
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)
    {
        Matrix res = new Matrix();
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < 2; j++) {
                for (int k = 0; k < 2; k++)
                    res[i, j] += matrix1[i, k] * matrix2[k, j]; } }
        return res;
    }
    public static int determinant(Matrix matrix) {
        int determinant = (int)(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
        if (determinant == 0)
            throw new DivideByZeroException();
        return determinant; }
    public static Matrix reverseMatrix(Matrix matrix)
    {
        int det = determinant(matrix);
        Matrix res = new Matrix();
        res[0, 0] = matrix[1, 1] / det;
        res[0, 1] = -matrix[0, 1] / det;
        res[1, 0] = -matrix[1, 0] / det;
        res[1, 1] = matrix[0, 0] / det;
        return res;
    }
    public static Matrix operator /(Matrix matrix1, Matrix matrix2)
    {
        return matrix1 * reverseMatrix(matrix2);
    }
    
    public override string ToString()
    {
        return $"{data[0, 0]} {data[0, 1]}\n {data[1, 0]} {data[1, 1]}";
    }
}