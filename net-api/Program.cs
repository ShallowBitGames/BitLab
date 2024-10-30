// See https://aka.ms/new-console-template for more information
using BitLabyrinth;
using BitLabyrinth.Maze;
using System.Diagnostics;
using System.Runtime.InteropServices;

string wd = AppContext.BaseDirectory;
Console.WriteLine(wd);
int index = wd.IndexOf("net-api");
wd = wd.Remove(index);
wd += "njs";
Console.WriteLine(wd);


/*
System.Diagnostics.Process pr = new();
pr.StartInfo.FileName = "npm.cmd";
pr.StartInfo.WorkingDirectory = wd;
pr.StartInfo.Arguments = "npm run dev";
pr.Start();
pr.WaitForExit();
*/

var processStartInfo = new ProcessStartInfo()
{
    FileName = "cmd",
    RedirectStandardOutput = true,
    RedirectStandardInput = true,
    WorkingDirectory = wd
};

var process = Process.Start(processStartInfo);

if (process == null)
{
    throw new Exception("Process should not be null.");
}

process.StandardInput.WriteLine($"npm run dev &");
//process.WaitForExit();


Console.WriteLine("Hello, World!");
Console.WriteLine("Please pick a maze for the random mouse to try:");
Console.WriteLine("[1] simple");
Console.WriteLine("[2] mouse");
Console.WriteLine("[3] invalid");

string? input = Console.ReadLine();

Console.WriteLine("");

string filePath = "../../../Maze/test-values/mouse.txt";

// TODO: turn into map
switch (input)
{
    case "1":
        filePath = "../../../Maze/test-values/simple.txt";
        break;

    case "2":
        filePath = "../../../Maze/test-values/mouse.txt";
        break;

    case "3":
        filePath = "../../../Maze/test-values/invalid.txt";
        break;

    default:
        Console.WriteLine("Invalid Input. Loading default.");
        break;
}


// MazeIO -> read in maze
Map maze = MazeIO.ReadMap(filePath);
//MazeIO.PrintMaze(maze);

// create and use solver
MazeSolver solver = new BitLabyrinth.Maze.Solvers.RandomMS(maze);
MazePath path = solver.SolveMaze(100);


MazeIO.AnimatePath(maze, path);
if (maze.IsGoal(path.Last()))
    Console.WriteLine("Hooray! Random mouse solved the maze!");
else
    Console.WriteLine("Random mouse did not manage to find out.");

Console.WriteLine("Steps taken:");
Console.WriteLine(path);