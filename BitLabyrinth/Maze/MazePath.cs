﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitLabyrinth.Maze
{
    internal class MazePath
    {
        public MazePath() { Steps = new();  }

        // copy constructor
        public MazePath(MazePath Original) {

            foreach((int, int) step in Original.Steps)
                this.AddStep(step.Item1, step.Item2);

        }
        
        public List<(int, int)> Steps { get; private set; }

        public void Clear() { Steps.Clear(); }

        public bool IsEmpty() {  return Steps.Count == 0; }

        public (int, int) Last()
        {
            return Steps.Last();
        }

        public void AddStep(int x, int y) {

            (int, int) tuple = (x, y);
            AddStep(tuple); 
        
        }

        public void AddStep((int, int) coordinates)
        {
            Steps.Add(coordinates);
        }
    
        override public string ToString()
        {
            string st = "";

            foreach(var step in Steps)
                st += "(" + step.Item1 + ", " + step.Item2 + ") ";

            return st;
        }
    }
}
