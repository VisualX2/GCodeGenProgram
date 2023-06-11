using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenProgram.Model
{
    public class ProjectStore
    {
        public int _width;
        public int _height;
        public int _depth;

        private readonly List<Drill> _drills;
        public IEnumerable<Drill> Drills => _drills;

        public event Action DrillLoaded;
        public event Action<Drill> DrillCreated;
        public event Action<Guid> DrillDeleted;
        public event Action<int, int, int> SizesChanged;

        public ProjectStore()
        {
            _width = 300;
            _height = 200;
            _depth = 2;
            _drills = new List<Drill>();
        }

        public void Load()
        {
            _drills.Clear();
            _drills.AddRange(_drills);

            DrillLoaded?.Invoke();
        }
        public void ChangeSizes(int width, int height, int depth)
        {
            _width = width;
            _height = height;
            _depth = depth;
            SizesChanged?.Invoke(width, height, depth);
        }
        public void Add(Drill drill)
        {
            _drills.Add(drill);
            DrillCreated?.Invoke(drill);
        }

        public void Remove(Guid id)
        {
            _drills.RemoveAll(y => y.id == id);
            DrillDeleted?.Invoke(id);
        }
    }
}
