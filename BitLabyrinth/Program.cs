// See https://aka.ms/new-console-template for more information
using BitLabyrinth;
using BitLabyrinth.Maze;

Console.WriteLine("Hello, World! Here's a maze!");
Console.WriteLine("");

BitLabyrinth.MazeIO testClient = new();
testClient.RunTest();

// MazeIO -> read in maze



// create and use solver

BitLabyrinth.Solver solver = new();