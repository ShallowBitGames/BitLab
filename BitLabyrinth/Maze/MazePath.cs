using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal class MazePath
    {
        public List<Tuple<int, int>> Steps { get; private set; } = new();

        public void Clear() { Steps.Clear(); }

        public Tuple<int, int> Last()
        {
            return Steps.Last();
        }

        public void AddStep(int x, int y) {

            Tuple<int, int> tuple = Tuple.Create(x, y);
            AddStep(tuple); 
        
        }

        public void AddStep(int[] coordinates)
        {
            int x = coordinates[0];
            int y = coordinates[1];

            AddStep(x, y);
        }

        public void AddStep(Tuple<int, int> coordinates)
        {
            Steps.Add(coordinates);
        }
    }
}
