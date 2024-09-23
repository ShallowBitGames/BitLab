using System.Collections.Generic;
using System;

namespace BitLab
{
    public class Maze
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public List<List<char>> Tiles { get; } = new List<List<char>>();


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
    }
}