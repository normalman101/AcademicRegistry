using AcademicRegistry.ViewModels;
using Avalonia.Controls;

namespace AcademicRegistry.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();

        DataContext = new HomeViewModel();
    }
}