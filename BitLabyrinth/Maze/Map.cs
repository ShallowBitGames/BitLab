using System.Collections.Generic;
using System;


namespace BitLabyrinth.Maze
{
    public class Map
    {
        internal Map(List<List<Tile>> tiles, Tuple<int, int> startPosition, Tuple<int, int> goalPosition)
        {
            Tiles = tiles;
            StartPosition = startPosition;
            GoalPosition = goalPosition;
        }

        internal Map(List<List<Tile>> tiles, int[] sp, int[] gp)
        {
            Tiles = tiles;
            StartPosition = new Tuple<int, int>(sp[0], sp[1]);
            GoalPosition = new Tuple<int, int>(gp[0], gp[1]);
        }

        internal Tuple<int, int> StartPosition { get; set; } = Tuple.Create(0, 0);

        //TODO: multiple goals
        internal Tuple<int, int> GoalPosition { get; set; } = Tuple.Create(0, 0);

        internal List<List<Tile>> Tiles { get; set; } = new List<List<Tile>>();

        internal bool IsGoal(int[] coordinates)
        {
            if(coordinates.Length != 2) return false;

            return (coordinates[0] == GoalPosition.Item1 && coordinates[1] == GoalPosition.Item2);
        }

        internal bool IsGoal(Tuple<int, int> coordinates)
        {
            return (coordinates.Item1 == GoalPosition.Item1 && coordinates.Item2 == GoalPosition.Item2);
        }

        internal bool IsPassable(int[] coordinates)
        {
            if (coordinates.Length != 2) return false;

            Tile tile = Tiles[coordinates[0]][coordinates[1]];
            return tile.IsPassable;
        }

        internal void SetTile(int x, int y, TileType tileType)
        {
            Tiles[x][y] = new Tile(tileType);
        }
    }
}