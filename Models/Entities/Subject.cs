using System;

namespace AcademicRegistry.Models.Entities;

public record Subject(
    string Name
)
{
    public Guid Id { init; get; } = Guid.CreateVersion7();
}