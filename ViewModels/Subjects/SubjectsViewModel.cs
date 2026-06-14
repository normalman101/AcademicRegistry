using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Subjects;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class SubjectsViewModel(WindowViewModel windowViewModel) : ViewModelBase
{
    public ObservableCollection<Subject> Subjects { get; set; } =
        new(windowViewModel.SubjectRepository.GetAll());

    [ObservableProperty] public partial Subject? Subject { get; set; }

    [RelayCommand]
    public void Add() => windowViewModel.ToSubjectEditorView(null);

    [RelayCommand]
    public void Update()
    {
        if (Subject is not null) windowViewModel.ToSubjectEditorView(Subject);
    }

    [RelayCommand]
    public void Delete()
    {
        if (Subject is null) return;

        windowViewModel.SubjectRepository.Delete(Subject);
        Subjects.UpdateWith(windowViewModel.SubjectRepository.GetAll());
    }
}