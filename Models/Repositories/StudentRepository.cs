using System;
using System.Collections.Generic;
using System.Linq;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Utilities;

namespace AcademicRegistry.Models.Repositories;

public class StudentRepository : IRepository<Student>
{
    private readonly List<Student> _students = [];

    public bool Add(Student element)
    {
        if (!Validator.IsStudentValid(element)) return false;

        _students.Add(element);

        return true;
    }

    public Student? GetBy(Guid id) => _students.FirstOrDefault(s => s.Id == id);

    public IEnumerable<Student> GetAll() => _students;

    public bool Update(Student element)
    {
        var foundElement = GetBy(element.Id);

        if (foundElement is null) return false;

        if (!Validator.IsStudentValid(foundElement)) return false;

        var foundElementIndex = _students.IndexOf(foundElement);

        Delete(foundElement);

        _students.Insert(foundElementIndex, element);

        return true;
    }

    public bool Delete(Student element)
    {
        if (GetBy(element.Id) is null) return false;

        _students.Remove(element);

        return true;
    }
}