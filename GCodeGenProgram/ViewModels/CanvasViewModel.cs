using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace GCodeGenProgram.ViewModels
{
    public class CanvasViewModel:ViewModelBase
    {
        private readonly ProjectStore _projectStore;
        private readonly ObservableCollection<Drill> _drills;
        
        
        public IEnumerable<Drill> Drills => _drills;

        private int _width;
        private int _height;
        private int _depth;

        public int Width { get => _width; set { _width = value; OnPropertyChanged(); } }
        public int Height { get => _height; set { _height = value; OnPropertyChanged(); } }
        public int Depth { get => _depth; set { _depth = value; OnPropertyChanged(); } }
        public CanvasViewModel(ProjectStore projectStore)
        {
            _projectStore = projectStore;
            Width = _projectStore._width;
            Height = _projectStore._height;
            Depth = _projectStore._depth;
            _drills = new ObservableCollection<Drill>();

            _projectStore.SizesChanged += ProjectStore_SizesChanged;
            _projectStore.DrillLoaded += ProjectStore_DrillLoaded;
            _projectStore.DrillCreated += ProjectStore_DrillAdded;
            _projectStore.DrillDeleted += ProjectStore_DrillDeleted;

            _drills.CollectionChanged += Drills_CollectionChanged;
        }

        private void ProjectStore_SizesChanged(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        private void ProjectStore_DrillLoaded()
        {
            _drills.Clear();
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
            Drill item = _drills.FirstOrDefault(y => y.id == id);

            if (item != null)
            {
                _drills.Remove(item);
            }
        }

        private void Drills_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(_drills));
        }

        private void AddDrill(Drill drill)
        {
            _drills.Add(drill);
        }

    }
}
