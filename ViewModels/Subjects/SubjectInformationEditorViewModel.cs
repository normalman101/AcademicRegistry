using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Subjects;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class SubjectInformationEditorViewModel(
    WindowViewModel windowViewModel,
    Subject? subject
) : ViewModelBase
{
    [ObservableProperty]
    public partial string Name { get; set; } = subject is null
        ? ""
        : subject.Name;

    [RelayCommand]
    public void Cancel() => windowViewModel.ToSubjectsView();

    [RelayCommand]
    public void Save()
    {
        if (subject is null)
        {
            if (!windowViewModel.SubjectRepository.Add(new Subject(Name))) return;
        }
        else
        {
            if (!windowViewModel.SubjectRepository.Update(subject! with
            {
                Id = subject.Id,
                Name = Name,
            })) return;
        }

        windowViewModel.ToSubjectsView();
    }
}