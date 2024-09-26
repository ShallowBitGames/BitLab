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

string path = "../../../Maze/test-values/mouse.txt";

// TODO: turn into map
switch (input)
{
    case "1": 
        path = "../../../Maze/test-values/simple.txt";
        break;

    case "2":
        path = "../../../Maze/test-values/mouse.txt";
        break;

    case "3":
        path = "../../../Maze/test-values/invalid.txt";
        break;

    default:
        Console.WriteLine("Invalid Input. Loading default.");
        break;
}


MazeIO IOClient = new();
IOClient.RunTest(path);

// MazeIO -> read in maze



// create and use solver

//MazeSolver solver = new BitLabyrinth.Maze.Solvers.RandomMS();


string m = "ᘛ⁐̤ᕐᐷ";