using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal class MazePath
    {
        public MazePath() { Steps = new();  }

        // copy constructor
        public MazePath(MazePath Original) {

            foreach((int, int) step in Original.Steps)
                this.AddStep(step.Item1, step.Item2);

        }
        
        public List<(int X, int Y)> Steps { get; private set; }

        public void Clear() { Steps.Clear(); }

        public bool IsEmpty() { return Steps.Count == 0; }

        public (int, int) Last() { return Steps.Last(); }

        public List<(int, int)> Last(int n) { return Steps.Slice(Steps.Count - (n + 1), n); }

        public bool Contains(int x, int y) { return Contains((x, y)); }

        public bool Contains((int, int) coordinates) { return Steps.Contains(coordinates); }

        public void AddStep(int x, int y) { AddStep((x, y)); }

        public void AddStep((int, int) coordinates) { Steps.Add(coordinates); }
    
        override public string ToString()
        {
            string st = "";

            foreach(var step in Steps)
                st += "(" + step.X + ", " + step.Y + ") ";

            return st;
        }
    }
}
