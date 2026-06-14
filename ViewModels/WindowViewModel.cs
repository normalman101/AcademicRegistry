using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Repositories;
using AcademicRegistry.ViewModels.Students;
using AcademicRegistry.ViewModels.Subjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public partial class WindowViewModel : ViewModelBase
{
    public WindowViewModel(StudentRepository studentRepository, SubjectRepository subjectRepository)
    {
        StudentRepository = studentRepository;

        SubjectRepository = subjectRepository;

        CurrentViewModel = new StudentsViewModel(this);
    }
    
    [ObservableProperty] public partial StudentRepository StudentRepository { get; set; }

    [ObservableProperty] public partial SubjectRepository SubjectRepository { get; set; }

    [ObservableProperty] public partial ViewModelBase CurrentViewModel { get; set; }
    
    [RelayCommand]
    public void ToStudentsView() => CurrentViewModel = new StudentsViewModel(this);

    [RelayCommand]
    public void ToSubjectsView() => CurrentViewModel = new SubjectsViewModel(this);

    public void ToStudentEditorView(
        StudentInformationEditorViewModel studentInformationEditorViewModel,
        Student? student)
    {
        CurrentViewModel = student is null
            ? new StudentInformationEditorViewModel(studentInformationEditorViewModel, this, null)
            : new StudentInformationEditorViewModel(studentInformationEditorViewModel, this, student);
    }

    public void ToSubjectEditorView(Subject? subject)
    {
        CurrentViewModel = subject is null
            ? new SubjectInformationEditorViewModel(this, null)
            : new SubjectInformationEditorViewModel(this, subject);
    }

    public void ToAvailableSubjectsView(
        StudentInformationEditorViewModel studentInformationEditorViewModel
    ) => CurrentViewModel = CurrentViewModel = new AvailableSubjectsViewModel(this, studentInformationEditorViewModel);
}