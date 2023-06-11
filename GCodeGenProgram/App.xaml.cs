using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using GCodeGenProgram.ViewModels;
using GCodeGenProgram.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GCodeGenProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context,services) =>
            {
                services.AddSingleton<AddNewDrillViewModel>();
                services.AddSingleton<CanvasViewModel>();
                services.AddSingleton<ChangeSizesViewModel>();
                services.AddSingleton<DrillListViewModel>();
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<INavigationService, NavigationService>();
                services.AddSingleton<ProjectStore>();
                services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

                services.AddSingleton<MainWindow>(provider => new MainWindow
                {
                    DataContext = provider.GetRequiredService<MainWindowViewModel>()
                });
            }).Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }

        
    }
}
