using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BitLabyrinth;
using BitLabyrinth.Maze;

namespace BitLabyrinth
{
    internal interface MazeSolver
    {
        Maze.MazePath SolveMaze(Map maze);


    }
}
