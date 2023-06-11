using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.ViewModels
{
    public class DeleteDrillCommand:CommandBase
    {
        private readonly DrillListItemViewModel _drillListItemViewModel;
        private readonly ProjectStore _projectStore;
        public DeleteDrillCommand(DrillListItemViewModel drillListItemViewModel, ProjectStore projectStore)
        {
            _drillListItemViewModel = drillListItemViewModel;
            _projectStore = projectStore;
        }
        public override void Execute(object parameter)
        {
            Drill drill = _drillListItemViewModel._drill;
            _projectStore.Remove(drill.id);
        }
    }
}
