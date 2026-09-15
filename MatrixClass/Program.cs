namespace Task4;
class Program {
public static Matrix[] read() {
    string line = File.ReadAllText("matrix.txt");
    int[] parts = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int n = parts.Length / 4;
Matrix [] matrixs = new Matrix[n];
int index = 0;
for (int i = 0; i < n; i++) {
    double [,] data = new double[2, 2];
    for (int j = 0; j < 2; j++) {
        for (int k = 0; k < 2; k++) {
            data[j,k] = parts[index++]; }
        matrixs[i] = new Matrix(data); } }
return matrixs; }

public static void write(string text, Matrix matrix1, Matrix
matrix2,Matrix res, char operation) {
    File.AppendAllText("result.txt",text+"\n");
using (StreamWriter writer = new StreamWriter("result.txt", true)) {
    for (int i = 0; i < 2; i++) {
        string charOp = i == 0?operation.ToString() : " "; 
        string equal = i == 0 ? "=" : " ";
        writer.WriteLine($"{matrix1[i, 0]} {matrix1[i, 1]} " +  $"{charOp} " +  $"{matrix2[i, 0]} {matrix2[i, 1]} {equal} {res[i, 0]} {res[i, 1]}"); }
        writer.WriteLine(); } }

static void Main() {
File.WriteAllText("result.txt", "");
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
Matrix[] matrixs = read();
File.AppendAllText("result.txt","Всі матриці \n");
for (int i = 0; i < matrixs.Length; i++) {
    using (StreamWriter writer = new StreamWriter("result.txt",true)) {
        writer.WriteLine($"{i + 1} матриця \n {matrixs[i]}"); }
}

write("Додавання 1 і 3 матриць", matrixs[0], matrixs[2],   matrixs[0]+matrixs[2],'+');
write("Віднімання 2 і 4 матриці" , matrixs[1], matrixs[3], matrixs[1]-matrixs[3],'-');
write("Множення матриці 5 на матрицю 6" , matrixs[4], matrixs[5],matrixs[4]*matrixs[5],'*');
write("Ділення матриці 7 на матрицю 8", matrixs[6], matrixs[7],   matrixs[6]/matrixs[7],'/');
Console.WriteLine("Результат у файлі \"result.txt\""); 
} }