using BitLabyrinth.Maze.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implementing your own solver:
// (a. Check out the MazeSolver base class and Maze Path for reference)
// (b. Check out RandomMS for an example implementation)
// 1. Implement the step function
// 2. Go to Program.cs and add your solver to the
//    "solvers" dictionary at the top of the file
// 3. Run the program to test your solver. That's it.


/*
 *      Available members: 
 * 
 *  PartialPath
 *  ReachedGoal()
 * 
 */

namespace BitLabyrinth.Maze.Solvers
{
    internal class TemplateMS : MazeSolver
    {
        // OPTIONAL
        // Add private variables and functions for internal use
        // e.g. a function to check if a field is already known, a heuristic or a whole internal map

        // OPTIONAL
        // Make your own constructor
        // public TemplateMS() : base() { }

        
        // REQUIRED
        // Implement step function
        internal override (int, int) DecideStep()
        {
            (int x, int y) currentPosition = PartialPath.Last();
            (int x, int y) nextPosition = currentPosition;
            
            // INSERT MAGIC HERE
            // You have:
            // - PartialPath (the path from the start to now)
            // - currentPosition
            // - bool Map.IsGoal(x,y) / bool Map.IsGoal((x,y))
            // - bool Map.IsPassable(x,y) / bool Map.IsPassable((x,y))
            // ...and anything else you find or write
            // GO WILD

            return nextPosition;
        }

    }

}