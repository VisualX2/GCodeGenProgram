using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.Model
{
    public class Drill
    {
        public Guid id;
        private int _x;
        private int _y;

        public int X
        {
            get => _x; set => _x = value;
        }

        public int Y
        {
            get => _y; set => _y = value;
        }

        public Drill(int x, int y) 
        {
            id = Guid.NewGuid();
            X = x;
            Y = y;
        }

        
    }
}
