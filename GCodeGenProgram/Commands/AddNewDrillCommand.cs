using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using GCodeGenProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.Commands
{
    public class AddNewDrillCommand:CommandBase
    {
        private readonly AddNewDrillViewModel _addNewDrillViewModel;
        private readonly ProjectStore _projectStore;
        private readonly INavigationService _navigationService;
        public AddNewDrillCommand(AddNewDrillViewModel addNewDrillViewModel, ProjectStore projectStore, INavigationService nav)
        {
            _addNewDrillViewModel = addNewDrillViewModel;
            _projectStore = projectStore;
            _navigationService = nav;
        }
        public override void Execute(object parameter)
        {
            Drill drill = new Drill(Int16.Parse(_addNewDrillViewModel.X), Int16.Parse(_addNewDrillViewModel.Y));
            _projectStore.Add(drill);
            _navigationService.NavigateTo<CanvasViewModel>();
        }


    }
}
