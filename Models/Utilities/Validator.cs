using AcademicRegistry.Models.Entities;

namespace AcademicRegistry.Models.Utilities;

public static class Validator
{
    public static bool IsStudentValid(Student student)
    {
        return student.Name.Length != 0 && student.Surname.Length != 0 && student.Patronymic.Length != 0;
    }

    public static bool IsSubjectValid(Subject subject)
    {
        return subject.Name.Length != 0;
    }
}