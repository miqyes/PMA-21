namespace Task4;
class Program {
public static Vector[] read() {
    
string line = File.ReadAllText("vector.txt");
int[] parts = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int n = parts.Length / 3;
Vector [] vectors = new Vector[n];
int index = 0;
for (int i = 0; i < n; i++) {
    int x = parts[index++];
    int y = parts[index++];
    int z = parts[index++];
    vectors[i] = new Vector(x, y, z); }
return vectors; }

public static void write(string text, Vector vector1, object vector2,Vector res, char operation) {
    
using (StreamWriter writer = new StreamWriter("result.txt", true)) {
    writer.WriteLine(
        text + vector1 + operation + vector2 + "=" + res); } }

static void Main() {
    
File.WriteAllText("result.txt", "");
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
Vector[] vectors = read();
File.AppendAllText("result.txt", "Всі вектори\n");
for (int i = 0; i < vectors.Length; i++) {
    using (StreamWriter writer = new StreamWriter("result.txt",true)) {
        writer.WriteLine($"{i + 1} ) {vectors[i]}"); } }

write("Додавання 1 і 3 векторів\n", vectors[0], vectors[2], vectors[0]+vectors[2], '+');

write("Віднімання 2 і 4 векторів\n", vectors[1], vectors[3], vectors[1]-vectors[3], '-');

Console.WriteLine("На яке число множимо вектор 5:");
double num = double.Parse(Console.ReadLine());
write($"Множення вектора 5 на {num}\n",  vectors[4],num, vectors[4]*num, '*');

Console.WriteLine("На яке число ділимо вектор 6:");
double number = double.Parse(Console.ReadLine());
write($"Ділення вектора 6 на {number}\n", vectors[5],number, vectors[5]/number, '/');

Console.WriteLine("Результат у файлі \"result.txt\""); } }

