using AcademicRegistry.ViewModels;
using Avalonia.Controls;
using StudentsViewModel = AcademicRegistry.ViewModels.Students.StudentsViewModel;

namespace AcademicRegistry.Views.Students;

public partial class StudentsView : UserControl
{
    public StudentsView(WindowViewModel windowViewModel)
    {
        InitializeComponent();

        DataContext = new StudentsViewModel(windowViewModel);
    }
}