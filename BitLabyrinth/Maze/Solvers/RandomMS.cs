using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze.Solvers
{

    internal class RandomMS : MazeSolver
    {
        public RandomMS(Map map)
        {
            ResetTo(map);
        }

        private MazePath PartialPath = new();
        private Map Maze;

        internal void ResetTo(Map maze)
        {
            Maze = maze;
            PartialPath = new();
            PartialPath.AddStep(Maze.StartPosition);
        }

        public bool ReachedGoal() { return Maze.IsGoal(PartialPath.Last()); }

        public MazePath SolveMaze(Map maze, int cutoff)
        {
            this.ResetTo(maze);

            var currentPosition = PartialPath.Last();

            int counter = 0;
            while(!maze.IsGoal(currentPosition) && counter < cutoff)
            {
                currentPosition = PartialPath.Last();
                Step();
                counter++;
            }

            return PartialPath;
        }

        /* Executes a step in a random direction
         * OUT: coordinate-tuple of the step taken
         * MODIFIES: attaches one element to partial path
         */
        private Tuple<int, int> Step()
        {
            var rand = new Random();

            int[] currentPosition = [0, 0];
            currentPosition[0] = Maze.StartPosition.Item1;
            currentPosition[1] = Maze.StartPosition.Item2;

            while (true)
            {
                int index = rand.Next(2);       // either 0 (x-coordinate) or 1 (y-coordinate)
                int modifier = rand.Next(2) == 0 ? -1 : 1;    // either -1 or +1 

                if (currentPosition[index] + modifier < 0)
                    continue;

                var nextPosition = currentPosition;
                nextPosition[index] += modifier;

                if (Maze.IsPassable(nextPosition))
                {
                    Tuple<int, int> tup = new(nextPosition[0], nextPosition[1]);

                    PartialPath.AddStep(tup);
                    return tup;
                }

            }
        }

        public MazePath NextSteps(int numSteps)
        {
            MazePath steps = new();

            for(int i = 0; i < numSteps; i++)
                steps.AddStep(Step());

            return steps;
        }
    }

}
