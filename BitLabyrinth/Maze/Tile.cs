using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    enum TileType
    {
        NONE,
        START,
        GOAL,
        FREE,
        WALL
    }

    internal class Tile
    {
        internal Tile(TileType type)
        {
            Type = type;

            IsPassable = (     type == TileType.START
                            || type == TileType.GOAL
                            || type == TileType.FREE);
        }

        internal TileType Type { get; set; }
        internal bool IsPassable { get; set; }
    }
}
