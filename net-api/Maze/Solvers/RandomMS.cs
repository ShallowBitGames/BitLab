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

        public MazePath SolveMaze(int cutoff)
        {

            if (PartialPath.IsEmpty())
                PartialPath.AddStep(Maze.StartPosition);

            var currentPosition = PartialPath.Last();

            int counter = 0;
            while(!Maze.IsGoal(currentPosition) && counter < cutoff)
            {
                Step();
                currentPosition = PartialPath.Last();
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
            
            currentPosition[0] = PartialPath.Last().Item1;
            currentPosition[1] = PartialPath.Last().Item2;

            while (true)
            {
                int index = rand.Next(2);       // either 0 (x-coordinate) or 1 (y-coordinate)
                int modifier = rand.Next(2) == 0 ? -1 : 1;    // either -1 or +1 

                //Console.WriteLine("Index: " + index);
                //Console.WriteLine("Modifier: " + modifier);

                // check if step would go out of bound
                if (currentPosition[index] + modifier < 0)
                {
                    //Console.WriteLine("Next step would take index below 0");
                    continue;
                }

                // TODO: unreadable code
                // x gets greater than row number
                if (index == 0)
                    if (currentPosition[0] + modifier >= Maze.Tiles.Count())
                    {
                        //Console.WriteLine("Next x Step: " + currentPosition[0] + modifier + " is greater than row count: " + Maze.Tiles.Count());
                        continue;
                    }
                
                // y gets greater than column length
                if (index == 1)
                    if (currentPosition[1] + modifier >= Maze.Tiles[currentPosition[0]].Count())
                    {
                        //Console.WriteLine("Next y Step: " + currentPosition[1] + modifier + " is greater than column length: " + Maze.Tiles[currentPosition[0]].Count());
                        continue;
                    }

                //Console.WriteLine("CURRENT Position: (" + currentPosition[0] + ", " + currentPosition[1] + ")");

                int[] nextPosition = [currentPosition[0], currentPosition[1]];
                nextPosition[index] += modifier;

                //Console.WriteLine("Current Position: (" + currentPosition[0] + ", " + currentPosition[1] + ")");
                //Console.WriteLine("Next Position: (" + nextPosition[0] + ", " + nextPosition[1] + ")");

                if (!Maze.IsPassable(nextPosition))
                {
                    //Console.WriteLine("Next Position not passable");
                    continue;
                }
                    
                Tuple<int, int> tup = new(nextPosition[0], nextPosition[1]);
                //Console.WriteLine("Adding to path: " + tup);
                PartialPath.AddStep(tup);
                currentPosition = [nextPosition[0], nextPosition[1]];
                //Console.WriteLine("CURRENT POSITIOn: (" + currentPosition[0] + ", " + currentPosition[1] + ")");
                return tup;

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
