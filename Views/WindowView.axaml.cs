using AcademicRegistry.Models.Repositories;
using AcademicRegistry.ViewModels;
using Avalonia.Controls;

namespace AcademicRegistry.Views;

public partial class WindowView : Window
{
    public WindowView(StudentRepository studentRepository, SubjectRepository subjectRepository)
    {
        InitializeComponent();

        DataContext = new WindowViewModel(studentRepository, subjectRepository);
    }
}