using GCodeGenProgram.Commands;
using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        public DrillListViewModel DrillListViewModel { get; }
        public ProjectStore _projectStore { get; }
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToCanvasCommand { get; set; }
        public RelayCommand NavigateToAddDrillCommand { get; set; }
        public RelayCommand NavigateToEditDrillCommand { get; set; }
        public RelayCommand NavigateToChangeSizesCommand { get; set; }
        
        public GenerateGCodeCommand GenerateGCodeCommand { get; set; }
        public MainWindowViewModel(INavigationService navigationService, ProjectStore projectStore) 
        {
            _navigationService = navigationService;
            _projectStore = projectStore;
            DrillListViewModel = new DrillListViewModel(_projectStore, _navigationService);
            NavigateToCanvasCommand = new RelayCommand(o => { NavigationService.NavigateTo<CanvasViewModel>(); }, o => true);
            NavigateToAddDrillCommand = new RelayCommand(o => { NavigationService.NavigateTo<AddNewDrillViewModel>(); }, o => true);
            NavigateToChangeSizesCommand = new RelayCommand(o => { NavigationService.NavigateTo<ChangeSizesViewModel>(); }, o => true);

            GenerateGCodeCommand = new GenerateGCodeCommand(_projectStore);

            NavigateToCanvasCommand.Execute(null);

        }
    }
}
