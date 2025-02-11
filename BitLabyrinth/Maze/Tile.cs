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

            IsPassable = (type == TileType.START
                            || type == TileType.GOAL
                            || type == TileType.FREE);
        }

        internal TileType Type { get; set; }
        internal bool IsPassable { get; set; }
    }
}
