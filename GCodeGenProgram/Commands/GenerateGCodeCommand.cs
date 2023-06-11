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
    public class GenerateGCodeCommand : CommandBase
    {
        private readonly ProjectStore _projectStore;
        public GenerateGCodeCommand(ProjectStore projectStore)
        {
            _projectStore = projectStore;
        }
        public override void Execute(object parameter)
        {
            GCodeGen gCodeGen = new GCodeGen(_projectStore);
            gCodeGen.SaveGCode();
            gCodeGen = null;
        }
    }
}
