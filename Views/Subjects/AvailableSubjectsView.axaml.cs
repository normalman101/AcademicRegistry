using AcademicRegistry.ViewModels;
using AcademicRegistry.ViewModels.Students;
using AcademicRegistry.ViewModels.Subjects;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AcademicRegistry.Views.Subjects;

public partial class AvailableSubjectsView : UserControl
{
    public AvailableSubjectsView(
        WindowViewModel windowViewModel,
        StudentInformationEditorViewModel studentInformationEditorViewModel
    )
    {
        InitializeComponent();

        DataContext = new AvailableSubjectsViewModel(windowViewModel, studentInformationEditorViewModel);
    }
}