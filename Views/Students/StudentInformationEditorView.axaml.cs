using System.Collections.Immutable;
using AcademicRegistry.Models.Entities;
using AcademicRegistry.ViewModels;
using Avalonia.Controls;
using StudentInformationEditorViewModel = AcademicRegistry.ViewModels.Students.StudentInformationEditorViewModel;

namespace AcademicRegistry.Views.Students;

public partial class StudentInformationEditorView : UserControl
{
    public StudentInformationEditorView(
        StudentInformationEditorViewModel? studentInformationEditorViewModel,
        WindowViewModel windowViewModel,
        Student? student)
    {
        InitializeComponent();

        DataContext = studentInformationEditorViewModel
                      ?? new StudentInformationEditorViewModel(windowViewModel, student);
    }
}