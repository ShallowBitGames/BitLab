using BitLabyrinth.Maze.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implementing your own solver:
// Setup:
// 1. Copy this file in this directory
// 2. Rename both the file and the class below
// 3. Go to Program.cs and add your solver at the top
// -> You can now run and test it!
//
// The actual work:
// 4. Implement the DecideStep function

// For an example implementation check out Maze/Solvers/RandomMS.cs
// For a template with additional comments check out  


namespace BitLabyrinth.Maze.Solvers
{
    internal class AlexMS : MazeSolver
    {

        internal override (int, int) DecideStep()
        {
            (int x, int y) currentPosition = PartialPath.Last();
            
            int x = currentPosition.Item1;
            int y = currentPosition.Item2;


            // IMPLEMENT LOGIC HERE



            var nextPosition = (x+1, y+1);

            if(!Maze.IsValid(nextPosition) || !Maze.IsPassable(nextPosition))
            {
                nextPosition = (x, y);
            }


                                  

            return nextPosition;
        }

    }

}