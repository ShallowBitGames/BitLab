using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using BitLabyrinth;
using BitLabyrinth.Maze;

namespace BitLabyrinth
{
    internal abstract class MazeSolver
    {
        internal enum Result
        {
            Uninitialized,
            Runable,            
            Solved,
            Unsolvable,
            Invalid
        }

        internal MazePath PartialPath;
        internal Map Maze;
        internal Result State;
        //internal Log;
        public MazeSolver() {
            PartialPath = new MazePath();
            State = Result.Uninitialized;
        }

        public bool ReachedGoal() { return Maze.IsGoal(PartialPath.Last()); }

        internal void Init(Map maze)
        {
            Maze = maze;
            PartialPath = new();
            PartialPath.AddStep(Maze.StartPosition);
            State = Result.Runable;
        }

        public MazePath SolveMaze(int cutoff)
        {
            if (PartialPath.IsEmpty())
                PartialPath.AddStep(Maze.StartPosition);

            var currentPosition = PartialPath.Last();

            int counter = 0;
            while (!Maze.IsGoal(currentPosition) && counter < cutoff)
            {
                Step();
                currentPosition = PartialPath.Last();
                counter++;
            }

            if (Maze.IsGoal(currentPosition))
                State = Result.Solved;

            return PartialPath;
        }
        
        //public void SetPath()

        //public MazePath ForeshadowSteps()
        
        //internal void AppendLog(string Message) { /*TODO */ }
        internal abstract (int, int) DecideStep();

        public (int, int) Step() {
        
            (int x, int y) nextPosition = DecideStep();
            PartialPath.AddStep(nextPosition);
            //Log 
            return nextPosition;
        }
        public MazePath TakeSteps(int numSteps)
        {
            for (int i = 0; i < numSteps; i++)
                Step();

            return PartialPath;
        }

       /* protected bool ValidatePath()
        {
            //TODO
        }*/

    }
}
