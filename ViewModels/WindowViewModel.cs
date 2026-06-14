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

        StudentsViewModel = new StudentsViewModel(this);
    }

    [ObservableProperty] public partial StudentRepository StudentRepository { get; set; }

    [ObservableProperty] public partial SubjectRepository SubjectRepository { get; set; }

    [ObservableProperty] public partial ViewModelBase CurrentViewModel { get; set; }

    public StudentsViewModel? StudentsViewModel { get; set; }

    public StudentInformationEditorViewModel? StudentInformationEditorViewModel { get; set; }

    public SubjectsViewModel? SubjectsViewModel { get; set; }

    public SubjectInformationEditorViewModel? SubjectInformationEditorViewModel { get; set; }

    public AvailableSubjectsViewModel? AvailableSubjectsViewModel { get; set; }

    [RelayCommand]
    public void ToStudents() => CurrentViewModel = new StudentsViewModel(this);
    
    public void ToStudentInformationEditor(Student? student)
    {
        StudentInformationEditorViewModel = student is null
            ? new StudentInformationEditorViewModel(this, null)
            : new StudentInformationEditorViewModel(this, student);

        CurrentViewModel = StudentInformationEditorViewModel;
    }

    public void ToStudentInformationEditor() => CurrentViewModel = StudentInformationEditorViewModel!;

    [RelayCommand]
    public void ToSubjects()
    {
        SubjectsViewModel = new SubjectsViewModel(this);

        CurrentViewModel = SubjectsViewModel;
    }

    public void ToSubjectEditorView(Subject? subject)
    {
        SubjectInformationEditorViewModel = subject is null
            ? new SubjectInformationEditorViewModel(this, null)
            : new SubjectInformationEditorViewModel(this, subject);
        
        CurrentViewModel = subject is null
            ? new SubjectInformationEditorViewModel(this, null)
            : new SubjectInformationEditorViewModel(this, subject);
    }

    public void ToAvailableSubjects()
    {
        AvailableSubjectsViewModel = new AvailableSubjectsViewModel(this);

        CurrentViewModel = AvailableSubjectsViewModel;
    }
}