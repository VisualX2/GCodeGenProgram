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
    public class ChangeSizesViewModel : ViewModelBase
    {
        private string _width;
        private string _height;
        private string _depth;

        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public string Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                _depth = value;
                OnPropertyChanged(nameof(Depth));
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
        public ChangeSizesCommand ChangeSizesCommand { get; set; }
        public RelayCommand NavigateToCanvasCommand { get; set; }
        public ChangeSizesViewModel(INavigationService navigationService, ProjectStore projectStore)
        {
            _navigationService = navigationService;
            _projectStore = projectStore;

            ChangeSizesCommand = new ChangeSizesCommand(this, _projectStore, NavigationService);
            NavigateToCanvasCommand = new RelayCommand(o => { NavigationService.NavigateTo<CanvasViewModel>(); }, o => true);

        }
    }
}
