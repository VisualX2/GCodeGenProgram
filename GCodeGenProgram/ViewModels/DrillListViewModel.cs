using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.ViewModels
{
    public class DrillListViewModel:ViewModelBase
    {
        private readonly ProjectStore _projectStore;
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

        private readonly ObservableCollection<DrillListItemViewModel> _drillListItemViewModels;
        public IEnumerable<DrillListItemViewModel> DrillListItemViewModels => _drillListItemViewModels;

        public DrillListViewModel(ProjectStore projectStore, INavigationService navigationService)
        {
            _projectStore = projectStore;
            _navigationService = navigationService;
            _drillListItemViewModels = new ObservableCollection<DrillListItemViewModel>();

            _projectStore.DrillLoaded += ProjectStore_DrillLoaded;
            _projectStore.DrillCreated += ProjectStore_DrillAdded;
            _projectStore.DrillDeleted += ProjectStore_DrillDeleted;

            _drillListItemViewModels.CollectionChanged += DrillListItemViewModels_CollectionChanged;
        }

        private void ProjectStore_DrillLoaded()
        {
            _drillListItemViewModels.Clear();
            foreach (Drill drill in _projectStore.Drills)
            {
                AddDrill(drill);
            }
        }

        private void ProjectStore_DrillAdded(Drill drill)
        {
            AddDrill(drill);
        }

        private void ProjectStore_DrillDeleted(Guid id) 
        {
            DrillListItemViewModel item = _drillListItemViewModels.FirstOrDefault(y => y._drill?.id == id);

            if(item != null)
            {
                _drillListItemViewModels.Remove(item);
            }
        }
        private void DrillListItemViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DrillListItemViewModels));
        }
        private void AddDrill(Drill drill) 
        {
            DrillListItemViewModel drillListItemViewModel = new DrillListItemViewModel(drill, _projectStore, _navigationService);
            _drillListItemViewModels.Add(drillListItemViewModel);
        }
    }
}
