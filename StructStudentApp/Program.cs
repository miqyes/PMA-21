using StructStudentApp;

class Program
{
    static void Main()
    {
        string path = "input.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл input.txt не знайдено!");
            return;
        }

        List<Student> students = new List<Student>();
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(' ');

            string firstName = parts[0];
            string lastName = parts[1];
            int day = int.Parse(parts[2]);
            int month = int.Parse(parts[3]);
            int year = int.Parse(parts[4]);

            DateOfBirth dob = new DateOfBirth(day, month, year);

            List<SubjectGrade> grades = new List<SubjectGrade>();
            for (int i = 5; i < parts.Length; i++)
            {
                string[] pair = parts[i].Split(':');
                string subject = pair[0];
                int score = int.Parse(pair[1]);

                grades.Add(new SubjectGrade(subject, score));
            }

            students.Add(new Student(firstName, lastName, dob, grades));
        }
        Student.PrintFailedStudents(students);
    }
}
   