using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal class MazePath
    {
        public List<(int x, int y)> Steps { get; private set; } = new();

        public void Clear() { Steps.Clear(); }

        public void AddStep(int x, int y) { Steps.Add((x, y)); }

        public void AddStep(int[] coordinates)
        {
            int x = coordinates[0];
            int y = coordinates[1];

            AddStep(x, y);
        }

    }
}
