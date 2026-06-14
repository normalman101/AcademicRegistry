using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AcademicRegistry.ViewModels.Students;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public partial class StudentsViewModel(WindowViewModel windowViewModel) : ViewModelBase
{
    public ObservableCollection<Student> Students { get; set; } =
        new(windowViewModel.StudentRepository.GetAll());

    [ObservableProperty] public partial Student? Student { get; set; }

    [RelayCommand]
    public void Add() => windowViewModel.ToStudentInformationEditor(null);

    [RelayCommand]
    public void Update()
    {
        if (Student is not null) windowViewModel.ToStudentInformationEditor(Student);
    }

    [RelayCommand]
    public void Delete()
    {
        if (Student is null) return;

        windowViewModel.StudentRepository.Delete(Student);
        Students.UpdateWith(windowViewModel.StudentRepository.GetAll());
    }
}