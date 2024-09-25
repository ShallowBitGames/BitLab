using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal interface MazeSolver
    {
        Path SolveMaze(Maze maze);


    }
}
