using System;
using System.Collections.Generic;
using System.Linq;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Utilities;

namespace AcademicRegistry.Models.Repositories;

public class SubjectRepository : IRepository<Subject>
{
    private readonly List<Subject> _subjects = [];

    public bool Add(Subject element)
    {
        if (!Validator.IsSubjectValid(element)) return false;

        _subjects.Add(element);

        return true;
    }

    public Subject? GetBy(Guid id) => _subjects.FirstOrDefault(s => s.Id == id);

    public IEnumerable<Subject> GetAll() => _subjects;

    public bool Update(Subject element)
    {
        var foundElement = GetBy(element.Id);

        if (foundElement is null) return false;

        if (!Validator.IsSubjectValid(foundElement)) return false;

        var foundElementIndex = _subjects.IndexOf(foundElement);

        Delete(foundElement);

        _subjects.Insert(foundElementIndex, element);

        return true;
    }

    public bool Delete(Subject element)
    {
        if (GetBy(element.Id) is null) return false;

        _subjects.Remove(element);

        return true;
    }
}