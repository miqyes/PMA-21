using Mapster;
using StudentAPI.DTOs;
using StudentAPI.Models;

namespace StudentAPI.Mapping;

public class StudentMappingConfig
{
    public static void Register()
    {
        TypeAdapterConfig<Student, StudentResponse>
            .NewConfig()
            .Map(
                dest => dest.Course,
                src => GetCourse(src.Group.Name)
            );
    }

    private static int GetCourse(string group)
    {
        int dashIndex = group.IndexOf('-');

        if (dashIndex < 0 || dashIndex + 1 >= group.Length)
        {
            return 0;
        }

        char digit = group[dashIndex + 1];

        if (!char.IsDigit(digit))
        {
            return 0;
        }

        return int.Parse(digit.ToString());
    }
}
