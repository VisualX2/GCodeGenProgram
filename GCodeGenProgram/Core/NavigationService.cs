using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCodeGenProgram.Core
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        void NavigateTo<T>() where T: ViewModelBase;
    }
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView 
        { 
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type,ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        public void NavigateTo<T>() where T: ViewModelBase
        {
            ViewModelBase viewModelBase = _viewModelFactory.Invoke(typeof(T));
            
            CurrentView = viewModelBase;
        }
    }
}
