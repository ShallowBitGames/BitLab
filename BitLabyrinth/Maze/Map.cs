using System.Collections.Generic;
using System;


namespace BitLabyrinth.Maze
{
    public class Map
    {
        internal Map(List<List<Tile>> tiles, (int, int) startPosition, (int, int) goalPosition)
        {
            Tiles = tiles;
            StartPosition = startPosition;
            GoalPosition = goalPosition;
        }

        internal (int X, int Y) StartPosition { get; set; } = (0, 0);

        //TODO: multiple goals
        internal (int X, int Y) GoalPosition { get; set; } = (0, 0);

        internal List<List<Tile>> Tiles { get; set; } = new List<List<Tile>>();

        internal bool IsGoal(int x, int y)
        {
            return (x == GoalPosition.X && y == GoalPosition.Y);
        }

        internal bool IsGoal((int X, int Y) coordinates)
        {
            return IsGoal(coordinates.X, coordinates.Y);
        }

        internal bool IsPassable(int x, int y)
        {
            Tile tile = Tiles[x][y];
            return tile.IsPassable;
        }

        //checks if tiles exist at all
        internal bool IsValid(int x, int y)
        {
            return (
                    x >= 0
                && y >= 0
                && x < Tiles.Count
                && y < Tiles[x].Count);
        }

        internal bool IsPassable((int, int) coordinates)
        {
            return IsPassable(coordinates.Item1, coordinates.Item2);
        }


        internal void SetTile(int x, int y, TileType tileType)
        {
            Tiles[x][y] = new Tile(tileType);
        }

        internal Tile GetTile(int x, int y) { return Tiles[x][y]; }
    }
}