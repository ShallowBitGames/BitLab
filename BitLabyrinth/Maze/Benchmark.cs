using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BitLabyrinth.Maze
{
   
    internal class Benchmark
    {
        int TurnCounter = 0;
        List<Entry> Record = [];

        struct Entry {
            internal int Turn { get; set; }
            internal string MouseName { get; set; }
            internal string MazeName { get; set; }
            internal MazeSolver.Result Result { get; set; }
            internal TimeSpan Time { get; set; }
        }

        public void Time(MazeSolver mouse, string mouseName, Map maze, int stepCutoff) {
            
            Stopwatch Timer = new();
            mouse.Init(maze);
            Timer.Start();
            mouse.SolveMaze(stepCutoff);
            Timer.Stop();

            Entry en = new();
            en.Turn = TurnCounter;
            en.MouseName = mouseName;
            en.MazeName = maze.Name;
            en.Result = mouse.State;
            en.Time = Timer.Elapsed;
            Record.Add(en);

        }

        //Race(MazeSolver mouse1, MazeSolver maze2, int rounds)
    }
}
