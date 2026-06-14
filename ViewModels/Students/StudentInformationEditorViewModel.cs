using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Students;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public partial class StudentInformationEditorViewModel(
    WindowViewModel windowViewModel,
    Student? student
) : ViewModelBase
{
    [ObservableProperty] public partial Student? Student { get; set; } = student;

    [ObservableProperty]
    public partial string Name { get; set; } = student is null
        ? ""
        : student.Name;

    [ObservableProperty]
    public partial string Surname { get; set; } = student is null
        ? ""
        : student.Surname;

    [ObservableProperty]
    public partial string Patronymic { get; set; } = student is null
        ? ""
        : student.Patronymic;

    [ObservableProperty] public partial Subject? Subject { get; set; }

    public ObservableCollection<Subject> Subjects { get; set; } = student is null
        ? []
        : new ObservableCollection<Subject>(student.Subjects);

    [RelayCommand]
    public void ToStudentsView() => windowViewModel.ToStudentsView();

    [RelayCommand]
    public void ToAvailableSubjectsView() => windowViewModel.ToAvailableSubjectsView(this);

    [RelayCommand]
    public void DeleteSubject()
    {
        if (Subject is not null) Subjects.Remove(Subject);
    }

    [RelayCommand]
    public void Save()
    {
        if (Student is null)
        {
            if (!windowViewModel.StudentRepository.Add(new Student(
                        Name,
                        Surname,
                        Patronymic,
                        Subjects.ToImmutableList()
                    )
                )) return;
        }
        else
        {
            if (!windowViewModel.StudentRepository.Update(Student! with
                {
                    Id = Student.Id,
                    Name = Name,
                    Surname = Surname,
                    Patronymic = Patronymic,
                    Subjects = Subjects.ToImmutableList()
                })) return;
        }

        ToStudentsView();
    }
}