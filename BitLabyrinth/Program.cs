// See https://aka.ms/new-console-template for more information
using BitLabyrinth;
using BitLabyrinth.Maze;
using BitLabyrinth.Maze.Solvers;

Dictionary<string, MazeSolver> Solvers = new Dictionary<string, MazeSolver>();

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                                          !
//          Add your solver here!           !
//                                          !
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
Solvers.Add("random", new RandomMS());
//Solvers.Add("YOUR_NAME", new YOUR_CLASS());


MazeSolver solver = SolverSelect();
Map maze = MazeSelect(); 

solver.SetMap(maze);
MazePath path = solver.SolveMaze(100);

MazeIO.AnimatePath(maze, path);

if (maze.IsGoal(path.Last()))
    Console.WriteLine("Hooray! Your mouse solved the maze!");
else
    Console.WriteLine("Your mouse did not manage to find out.");

Console.WriteLine("Steps taken:");
Console.WriteLine(path);


MazeSolver SolverSelect()
{
    // create and use solver
    Console.Clear();
    Console.WriteLine("Pick a solver:");
    int count = 1;
    foreach (var (name, slv) in Solvers)
    {

        Console.WriteLine("[" + count + "] " + name);
        count++;
    }

    string? input = Console.ReadLine();
    int input_int = -1;

    if( !(input is null) )
    {
        Int32.TryParse(input, out input_int);

        if(input_int > 0 && input_int <= count)
        {
            // ugly as all hell but works
            int i = 1;
            foreach(var (name, slv) in Solvers)
            {
                if (i == input_int) return slv;
                i++;
            }

        }

    } 

    //if one of the if conditions failed we didnt get valid input, repeat
    return SolverSelect();
}

Map MazeSelect()
{
    Console.WriteLine("Hello, World!");
    Console.WriteLine("Please pick a maze for the random mouse to try:");
    Console.WriteLine("[1] simple");
    Console.WriteLine("[2] mouse");
    Console.WriteLine("[3] invalid");

    string? input = Console.ReadLine();

    Console.WriteLine("");

    string filePath = "../../../Maze/test-values/mouse.txt";

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

    return maze;
}