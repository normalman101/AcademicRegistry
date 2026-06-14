using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Subjects;

[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class AvailableSubjectsViewModel(WindowViewModel windowViewModel) : ViewModelBase
{
    public ObservableCollection<Subject> AvailableSubjects { get; set; } =
        new(windowViewModel.SubjectRepository.GetAll());

    [ObservableProperty] public partial Subject? Subject { get; set; }

    [RelayCommand]
    public void Cancel()
    {
        windowViewModel.AvailableSubjectsViewModel = null;
        windowViewModel.ToStudentInformationEditor();
    }

    [RelayCommand]
    public void Add()
    {
        if (Subject is null) return;

        windowViewModel.StudentInformationEditorViewModel!.Subjects.Add(Subject);

        windowViewModel.AvailableSubjectsViewModel = null;
        windowViewModel.ToStudentInformationEditor();
    }
}