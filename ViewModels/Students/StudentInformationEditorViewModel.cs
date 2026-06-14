using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Students;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public partial class StudentInformationEditorViewModel : ViewModelBase
{
    public StudentInformationEditorViewModel(
        StudentInformationEditorViewModel? studentInformationEditorViewModel,
        WindowViewModel windowViewModel,
        Student? student
    )
    {
        _windowViewModel = windowViewModel;

        if (studentInformationEditorViewModel is null)
        {
            Student = student;
            Name = student is null
                ? ""
                : student.Name;
            Surname = student is null
                ? ""
                : student.Surname;
            Patronymic = student is null
                ? ""
                : student.Patronymic;
            Subjects = student is null
                ? []
                : new ObservableCollection<Subject>(student.Subjects);
        }
        else
        {
            Student = studentInformationEditorViewModel.Student;
            Name = studentInformationEditorViewModel.Name!;
            Surname = studentInformationEditorViewModel.Surname!;
            Patronymic = studentInformationEditorViewModel.Patronymic!;
            Subjects = studentInformationEditorViewModel.Subjects;
        }
    }

    private readonly WindowViewModel _windowViewModel;

    [ObservableProperty] public partial Student? Student { get; set; }
    [ObservableProperty] public partial string Name { get; set; }
    [ObservableProperty] public partial string Surname { get; set; }
    [ObservableProperty] public partial string Patronymic { get; set; }
    public ObservableCollection<Subject> Subjects { get; set; }

    [ObservableProperty] public partial Subject? Subject { get; set; }

    [RelayCommand]
    public void ToAvailableSubjectsView() => _windowViewModel.ToAvailableSubjectsView(this);

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
            if (!_windowViewModel.StudentRepository.Add(new Student(
                        Name,
                        Surname,
                        Patronymic,
                        Subjects.ToImmutableList()
                    )
                )) return;
        }
        else
        {
            if (!_windowViewModel.StudentRepository.Update(Student! with
                {
                    Id = Student.Id,
                    Name = Name,
                    Surname = Surname,
                    Patronymic = Patronymic,
                    Subjects = Subjects.ToImmutableList()
                })) return;
        }

        _windowViewModel.ToStudentsView();
    }
}