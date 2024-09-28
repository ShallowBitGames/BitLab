// See https://aka.ms/new-console-template for more information
using BitLabyrinth;
using BitLabyrinth.Maze;

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
MazeIO.PrintMaze(maze);

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