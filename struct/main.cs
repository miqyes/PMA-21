class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string filePath = "students.txt";

        FileManager fileManager = new FileManager(filePath);

        List<Student> students = fileManager.ReadAll();

        if (students.Count == 0)
        {
            Console.WriteLine("Дані для аналізу відсутні.");
            return;
        }

        StudentReport.PrintFailedStudents(students);
    }
}
