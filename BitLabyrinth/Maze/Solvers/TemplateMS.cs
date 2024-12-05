using BitLabyrinth.Maze.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implementing your own solver:
// 1. Create a new class file in the Maze/Solvers directory
// 2. Copy over the content of this file
// 3. Change the name TemplateMS to your class name
// 4. Go to Program.cs and add your solver at the top
// -> You can now run and test it!
// 5. Implement the DecideStep function

// For an example implementation check out Maze/Solvers/RandomMS.cs


namespace BitLabyrinth.Maze.Solvers
{
    internal class TemplateMS : MazeSolver
    {
        // OPTIONAL
        // Add private variables and functions for internal use
        // e.g. a function to check if a field is already known, a heuristic or a whole internal map
        // example helper functions:
        // bool AlreadyVisited(int x, int y)        check whether 
        // int UnseenTiles(direction)               calculate how much of the maze is unknown
        //                                          in one direction relative to the current position 
        // example variables:
        // enum Directions {Up, Down, Left, Right}
        // Map Explored = new Map();

        // OPTIONAL
        // Make your own constructor, in case you need to initialize
        // additional data structures
        // public TemplateMS() : base() { }


        // REQUIRED
        // Implement step function

        // Internal state of the solver class:
        // The map of the current maze
        // A PartialPath variable representing the path from the start to this point
        // You may assume that both variables are valid and kept up to date outside
        // of this function. This function should NOT modify PartialPath or Maze directly.

        internal override (int, int) DecideStep()
        {
            (int x, int y) currentPosition = PartialPath.Last();
            (int x, int y) nextPosition = currentPosition;

            // INSERT MAGIC HERE
            // To start, you have:
            //
            // PartialPath: (the path from the start to now)
            //   PartialPath.Last() -> (int x, int y)
            //   PartialPath.Last(int n) -> List<(int x, int y)>
            //   PartialPath.Contains()
            // 
            // Maze: the maze to solve
            //   Maze.IsGoal(x,y) -> bool
            //   Maze.IsPassable(x,y) -> bool
            //   Maze.IsValid(x,y) -> bool
            // 
            // For more, check out the Solver/Map and Solver/MazePath classes
            //
            // You have the whole maze visible to you from the start
            // It is up to you how far your solver can "see" or if it knows the entire maze
            //
            // Examples to implement:
            // Some "common sense" checks:
            // - if a tile next to you is the goal, go there
            // - don't immediately go back to the last tile you came from
            // - prefer tiles you haven't seen yet
            // A memory or the ability to see a few tiles ahead
            // Depth first/breadth first search
            // Human heuristics: https://de.wikipedia.org/wiki/L%C3%B6sungsalgorithmen_f%C3%BCr_Irrg%C3%A4rten
            //
            // GO WILD

            return nextPosition;
        }

    }

}