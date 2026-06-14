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

        CurrentPage = new HomeView();

        _homePage = new HomeView();
    }

    // [ObservableProperty] public partial Student? Student { get; set; } = null;

    [ObservableProperty] public partial StudentRepository StudentRepository { get; set; }

    [ObservableProperty] public partial SubjectRepository SubjectRepository { get; set; }

    [ObservableProperty] public partial UserControl CurrentPage { get; set; }

    private readonly UserControl _homePage;


    [RelayCommand]
    public void ToHomeView() => CurrentPage = _homePage;

    [RelayCommand]
    public void ToStudentsView() => CurrentPage = new StudentsView(this);

    [RelayCommand]
    public void ToSubjectsView() => CurrentPage = new SubjectsView(this);

    public void ToStudentEditorView(
        StudentInformationEditorViewModel? studentInformationEditorViewModel,
        Student? student)
    {
        CurrentPage = student is null
            ? new StudentInformationEditorView(studentInformationEditorViewModel, this, null)
            : new StudentInformationEditorView(studentInformationEditorViewModel, this, student);
    }

    public void ToSubjectEditorView(Subject? subject)
    {
        CurrentPage = subject is null
            ? new SubjectInformationEditorView(this, null)
            : new SubjectInformationEditorView(this, subject);
    }

    public void ToAvailableSubjectsView(
        StudentInformationEditorViewModel studentInformationEditorViewModel
    ) => CurrentPage = CurrentPage = new AvailableSubjectsView(this, studentInformationEditorViewModel);
}