using System.Collections.Generic;
using System;

namespace BitLabyrinth
{
    public class Map
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public Tuple<int, int> StartPosition { get; private set; } = Tuple.Create(0, 0);

        //TODO: multiple goals
        public Tuple<int, int> GoalPosition { get; private set; } = Tuple.Create(0, 0);

        public List<List<char>> Tiles { get; private set; } = new List<List<char>>();

        public void addLine(List<char> line)
        {
            List<char> nextLine = new List<char>();

            foreach (char c in line)
            {
                nextLine.Add(c);
            }

            Tiles.Add(nextLine);

        }

        public void print()
        {
            foreach (List<char> row in Tiles)
            {
                foreach (char tile in row)
                {
                    Console.Write(tile);
                }
                Console.WriteLine();
            }
        }

        public List<string> GetLinesAsStrings()
        {
            List<string> stringList = new();

            foreach(List<char> line in Tiles) 
            {
                string lineString = "";
                foreach(char c in line)
                    lineString += c;

                stringList.Add(lineString);
            }

            return stringList;
        }

        public bool IsGoal(int[] coordinates)
        {
            if(coordinates.Length != 2) return false;

            Tuple<int, int> tup = new(coordinates[0], coordinates[1]);

            return IsGoal(tup);
        }

        public bool IsGoal(Tuple<int, int> coordinates)
        {
            return coordinates == GoalPosition;
        }

        public bool IsPassable(int[] coordinates)
        {
            if (coordinates.Length != 2) return false;

            char tile = Tiles[coordinates[0]][coordinates[1]];
            return tile == ' ';
        }

        internal void SetTile(int x, int y, char tileSymbol)
        {
            Tiles[x][y] = tileSymbol;
        }
    }
}