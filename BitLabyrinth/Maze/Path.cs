using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal class Path
    {
        public void AddStep(int x, int y) { Steps.Add((x, y)); }
        
        public void Clear() { Steps.Clear(); }

        public List<(int x, int y)> Steps { get; private set; } = new();


    }
}
