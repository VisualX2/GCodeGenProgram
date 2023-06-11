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
    public class ChangeSizesCommand : CommandBase
    {
        private readonly ChangeSizesViewModel _changeSizesViewModel;
        private readonly ProjectStore _projectStore;
        private readonly INavigationService _navigationService;
        public ChangeSizesCommand(ChangeSizesViewModel changeSizesViewModel, ProjectStore projectStore, INavigationService nav)
        {
            _changeSizesViewModel = changeSizesViewModel;
            _projectStore = projectStore;
            _navigationService = nav;
        }
        public override void Execute(object parameter)
        {
            _projectStore.ChangeSizes(Int16.Parse(_changeSizesViewModel.Width), Int16.Parse(_changeSizesViewModel.Height), Int16.Parse(_changeSizesViewModel.Depth));
            _navigationService.NavigateTo<CanvasViewModel>();
        }
    }
}
