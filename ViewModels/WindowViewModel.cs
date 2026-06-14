using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Repositories;
using AcademicRegistry.ViewModels.Students;
using AcademicRegistry.Views;
using AcademicRegistry.Views.Subjects;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentInformationEditorView = AcademicRegistry.Views.Students.StudentInformationEditorView;
using StudentsView = AcademicRegistry.Views.Students.StudentsView;
using SubjectInformationEditorView = AcademicRegistry.Views.Subjects.SubjectInformationEditorView;
using SubjectsView = AcademicRegistry.Views.Subjects.SubjectsView;

namespace AcademicRegistry.ViewModels;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public partial class WindowViewModel : ViewModelBase
{
    public WindowViewModel(StudentRepository studentRepository, SubjectRepository subjectRepository)
    {
        StudentRepository = studentRepository;

        SubjectRepository = subjectRepository;

        CurrentView = new StudentsView(this);
    }
    
    [ObservableProperty] public partial StudentRepository StudentRepository { get; set; }

    [ObservableProperty] public partial SubjectRepository SubjectRepository { get; set; }

    [ObservableProperty] public partial UserControl CurrentView { get; set; }
    
    [RelayCommand]
    public void ToStudentsView() => CurrentView = new StudentsView(this);

    [RelayCommand]
    public void ToSubjectsView() => CurrentView = new SubjectsView(this);

    public void ToStudentEditorView(
        StudentInformationEditorViewModel? studentInformationEditorViewModel,
        Student? student)
    {
        CurrentView = student is null
            ? new StudentInformationEditorView(studentInformationEditorViewModel, this, null)
            : new StudentInformationEditorView(studentInformationEditorViewModel, this, student);
    }

    public void ToSubjectEditorView(Subject? subject)
    {
        CurrentView = subject is null
            ? new SubjectInformationEditorView(this, null)
            : new SubjectInformationEditorView(this, subject);
    }

    public void ToAvailableSubjectsView(
        StudentInformationEditorViewModel studentInformationEditorViewModel
    ) => CurrentView = CurrentView = new AvailableSubjectsView(this, studentInformationEditorViewModel);
}