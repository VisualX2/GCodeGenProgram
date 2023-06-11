using GCodeGenProgram.Commands;
using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace GCodeGenProgram.ViewModels
{
    public class AddNewDrillViewModel : ViewModelBase
    {
        private string _x;
        private string _y;
        private string _z;

        public string X { 
            get { 
                return _x; 
            } 
            set { 
                _x = value; 
                OnPropertyChanged(nameof(X)); 
            } 
        }

        public string Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public string Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                OnPropertyChanged(nameof(Z));
            }
        }

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

        public ProjectStore _projectStore { get; }
        public AddNewDrillCommand AddNewDrillCommand { get; set; }
        public RelayCommand NavigateToCanvasCommand { get; set; }
        public AddNewDrillViewModel(INavigationService navigationService, ProjectStore projectStore)
        {
            _navigationService = navigationService;
            _projectStore = projectStore;

            AddNewDrillCommand = new AddNewDrillCommand(this, _projectStore, NavigationService);
            NavigateToCanvasCommand = new RelayCommand(o => { NavigationService.NavigateTo<CanvasViewModel>(); }, o => true);

        }
    }
}
