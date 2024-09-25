using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze.Solvers
{
    internal class RandomMS : MazeSolver
    {
        public Path SolveMaze(Maze maze)
        {
            Path path = new Path();

            var currentPosition = maze.GetStartPosition();

            while(!maze.IsGoal(currentPosition))
            {
                var rand = new Random();

                while(true)
                {
                    int index = rand.Next(2);       // either 0 (x-coordinate) or 1 (y-coordinate)
                    int modifier = rand.Next(2) == 0 ? -1 : 1;    // either -1 or +1 

                    var nextPosition = currentPosition;
                    nextPosition[index] += modifier;

                    if (maze.IsPassable(nextPosition))
                    {
                        path.AddStep(nextPosition);
                        currentPosition = nextPosition;
                        break;
                    }
                    
                }
                
            }

            return path;
        }
    }
}
