using AcademicRegistry.ViewModels;
using Avalonia.Controls;
using SubjectsViewModel = AcademicRegistry.ViewModels.Subjects.SubjectsViewModel;

namespace AcademicRegistry.Views.Subjects;

public partial class SubjectsView : UserControl
{
    public SubjectsView(WindowViewModel windowViewModel)
    {
        InitializeComponent();

        DataContext = new SubjectsViewModel(windowViewModel);
    }
}