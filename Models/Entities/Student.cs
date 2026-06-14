using System;
using System.Collections.Immutable;

namespace AcademicRegistry.Models.Entities;

public record Student(
    string Name,
    string Surname,
    string Patronymic,
    ImmutableList<Subject> Subjects
)
{
    public Guid Id { init; get; } = Guid.CreateVersion7();
}