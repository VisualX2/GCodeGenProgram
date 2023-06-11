using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GCodeGenProgram.Model
{
    public class GCodeGen
    {
        private ProjectStore _store;

        private List<string> lines;

        private int safeZ;
        public void InitialPositionLine() {
            lines.Add("N" + lines.Count.ToString() +"0 G00 X0 Y0 Z"+ safeZ.ToString() + " F50");
        }

        public void AddNewDrill()
        {
            foreach (var drill in _store.Drills)
            {
                lines.Add("N" + lines.Count.ToString() + "0 G00 X" + drill.X.ToString() + " Y" + drill.Y.ToString() + " F50");
                lines.Add("N" + lines.Count.ToString() + "0 G01 Z0" + " F80");
                lines.Add("N" + lines.Count.ToString() + "0 G01 Z" + safeZ.ToString() + " F80");
            }
        }

        public void SaveGCode()
        {
            TextWriter textWriter = new StreamWriter("NCOperation.cnc");
            foreach (string s in lines)
            {
                textWriter.WriteLine(s);
            }
            textWriter.Close();
        }

        public GCodeGen(ProjectStore store) {
            _store = store;
            lines = new List<string>();
            lines.Add("%NCOperation");
            safeZ = _store._depth + 3;

            InitialPositionLine();
            AddNewDrill();
            InitialPositionLine();
            SaveGCode();
        }



    }
}
