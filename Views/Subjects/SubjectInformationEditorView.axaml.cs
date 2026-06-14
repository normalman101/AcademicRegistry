using AcademicRegistry.Models.Entities;
using AcademicRegistry.ViewModels;
using Avalonia.Controls;
using SubjectInformationEditorViewModel = AcademicRegistry.ViewModels.Subjects.SubjectInformationEditorViewModel;

namespace AcademicRegistry.Views.Subjects;

public partial class SubjectInformationEditorView : UserControl
{
    public SubjectInformationEditorView(WindowViewModel windowViewModel, Subject? subject)
    {
        InitializeComponent();

        DataContext = new SubjectInformationEditorViewModel(windowViewModel, subject);
    }
}