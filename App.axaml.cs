using AcademicRegistry.Models.Entities;
using AcademicRegistry.Models.Repositories;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AcademicRegistry.ViewModels;
using AcademicRegistry.ViewModels.Students;
using AcademicRegistry.ViewModels.Subjects;
using AcademicRegistry.Views;
using AcademicRegistry.Views.Students;
using AcademicRegistry.Views.Subjects;
using Avalonia.Styling;
using Microsoft.Extensions.DependencyInjection;

namespace AcademicRegistry;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        
        services.AddSingleton<StudentRepository>();
        services.AddSingleton<SubjectRepository>();
        
        services.AddTransient<WindowView>();
        services.AddTransient<WindowViewModel>();

        services.AddTransient<SubjectsView>();
        services.AddTransient<SubjectsViewModel>();
        services.AddTransient<SubjectInformationEditorView>();
        services.AddTransient<SubjectInformationEditorViewModel>();

        services.AddTransient<StudentsView>();
        services.AddTransient<StudentsViewModel>();
        services.AddTransient<StudentInformationEditorView>();
        services.AddTransient<StudentInformationEditorViewModel>();
        
        var serviceProvider = services.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            RequestedThemeVariant = ThemeVariant.Light;

            desktop.MainWindow = serviceProvider.GetRequiredService<WindowView>();
            {
                DataContext = serviceProvider.GetRequiredService<WindowViewModel>();
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}