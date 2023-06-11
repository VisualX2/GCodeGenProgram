using GCodeGenProgram.Core;
using GCodeGenProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GCodeGenProgram.ViewModels
{
    public class DrillListItemViewModel : ViewModelBase
    {
        public Drill _drill { get; private set; }

        public string drillName => "X: " + _drill.X.ToString() + " Y: " + _drill.Y;
        
        public DeleteDrillCommand DeleteDrillCommand { get; }

        public DrillListItemViewModel(Drill drill, ProjectStore projectStore, INavigationService navigationService)
        {
            _drill = drill;
            DeleteDrillCommand = new DeleteDrillCommand(this,projectStore);

        }

        
    }
}
