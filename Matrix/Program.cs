namespace Task3;
class Program
{
public static int[][,] read() {
string line = File.ReadAllText("matrix.txt");
int[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int n = parts.Length / 4;
int[][,] res = new int[n][,];
int index = 0;
for (int i = 0; i < n; i++) {
res[i] = new int[2, 2];
    for (int j = 0; j < 2; j++) {
        for (int k = 0; k < 2; k++)
            res[i][j, k] = parts[index++]; } }
return res; }
public static int[,] add(int[,] matrix1, int[,] matrix2) {
int[,] res = new int[2, 2];
for (int i = 0; i < 2; i++) {
    for (int j = 0; j < 2; j++)
        res[i, j] = matrix1[i, j] + matrix2[i, j]; }
return res; }
public static int[,] difference(int[,] matrix1, int[,] matrix2) {
int[,] res = new int[2, 2];
for (int i = 0; i < 2; i++) {
    for (int j = 0; j < 2; j++)
        res[i, j] = matrix1[i, j] - matrix2[i, j]; }
return res; }
public static int determinant(int[,] matrix) {
int determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
if (determinant == 0)
    throw new DivideByZeroException();
return determinant; }
public static double[,] reverseMatrix(int[,] matrix) {
int det = determinant(matrix);
double[,] res = new double[2, 2];
res[0, 0] = (double)matrix[1, 1] / det;
res[0, 1] = (double)-matrix[0, 1] / det;
res[1, 0] = (double)-matrix[1, 0] / det;
res[1, 1] = (double)matrix[0, 0] / det;
return res; }
public static T[,] multiply<T>(int[,] matrix1, T[,] matrix2) {
T[,] res = new T[2, 2];
for (int i = 0; i < 2; i++) {
    for (int j = 0; j < 2; j++) {
        for (int k = 0; k < 2; k++)
         res[i, j] = (T)((dynamic)res[i, j] + matrix1[i, k] * (dynamic)matrix2[k, j]); } }
return res; }
public static double[,] divide(int[,] matrix1, int[,] matrix2){
double[,] reverse = reverseMatrix(matrix2);
return multiply(matrix1, reverse); }
public static void write<T>(string text, int[,] matrix1, int[,] matrix2, char operation, T[,] res) {
using (StreamWriter writer = new StreamWriter("result.txt", true)) {
writer.WriteLine(text);
char operation1 = '=';
for (int i = 0; i < 2; i++) {
    string op1 = i == 0 ? operation.ToString() : " ";
    string op2 = i == 0 ? operation1.ToString() : " ";
    writer.WriteLine(
        $"{matrix1[i, 0]} {matrix1[i, 1]} {op1} {matrix2[i, 0]} {matrix2[i, 1]} {op2} {res[i, 0]} {res[i, 1]}"); } } }

static void Main() {
File.WriteAllText("result.txt", "");
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
int[][,]matrix = read();
for (int i = 0; i < matrix.Length; i++) {
    using (StreamWriter writer = new StreamWriter("result.txt", true)) {
        writer.WriteLine($"{i + 1} матриця");
        for (int j = 0; j < 2; j++) {
            for (int k = 0; k < 2; k++)
                writer.Write(matrix[i][j, k] + " ");
            writer.WriteLine();
        }
    }
}
int[,] adding = add(matrix[0], matrix[2]);
write("Додавання 1 і 3 матриць", matrix[0], matrix[2], '+', adding);

int[,] differencing = difference(matrix[1], matrix[3]);
write("Віднімання 2 і 4 матриці", matrix[1], matrix[3], '-', differencing);

int[,] multiplying = multiply(matrix[4], matrix[5]);
write("Множення матриці 5 на матрицю 6", matrix[4], matrix[5], '*', multiplying);

double[,] dividing = divide(matrix[6], matrix[7]);
write("Ділення матриці 7 на матрицю 8", matrix[6], matrix[7], '/', dividing);

Console.WriteLine("Результат у файлі \"result.txt\""); 
}
}



