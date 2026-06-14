using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.ViewModels.Students;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Subjects;

[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class AvailableSubjectsViewModel(
    WindowViewModel windowViewModel,
    StudentInformationEditorViewModel studentInformationEditorViewModel
) : ViewModelBase
{
    public ObservableCollection<Subject> AvailableSubjects { get; set; } =
        new(windowViewModel.SubjectRepository.GetAll());

    [ObservableProperty] public partial Subject? Subject { get; set; }

    [RelayCommand]
    public void Cancel() => windowViewModel.ToStudentEditorView(
        studentInformationEditorViewModel,
        studentInformationEditorViewModel.Student);

    [RelayCommand]
    public void Add()
    {
        if (Subject is null) return;

        studentInformationEditorViewModel.Subjects.Add(Subject);

        windowViewModel.ToStudentEditorView(
            studentInformationEditorViewModel,
            studentInformationEditorViewModel.Student);
    }
}