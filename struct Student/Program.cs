namespace Task8;

class Program
{
    static Student ReadStudent(string line)
    {
        string[] parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 4)
            throw new Exception("Insufficient data.");

        string[] pointStrings = parts[3].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (!pointStrings.All(x => int.TryParse(x, out int point) && point >= 0))
        {
            throw new Exception("Points need to be positive numbers.");
        }

        Student student = new Student();

        student.Name = parts[0].Trim();
        student.Surname = parts[1].Trim();
        student.Birthday = parts[2].Trim();

        student.Points = pointStrings.Select(int.Parse).ToArray();

        return student;
    }

    static void Main()
    {
        string[] file = File.ReadAllLines("data.txt");
        List<Student> students = new List<Student>();
        int i = 1;
        foreach (string line in file)
        {
            try
            {
                students.Add(ReadStudent(line));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in {i}-row: " + ex.Message);
            }

            i++;
        }

        foreach (Student student in students)
        {
            if (student.Talon())
            {
                Console.WriteLine(student);
            }
        }
    }
}