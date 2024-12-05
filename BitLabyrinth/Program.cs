// See https://aka.ms/new-console-template for more information
using BitLabyrinth;
using BitLabyrinth.Maze;
using BitLabyrinth.Maze.Solvers;
using static System.Runtime.InteropServices.JavaScript.JSType;

Dictionary<string, MazeSolver> Solvers = new Dictionary<string, MazeSolver>();

// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                                          !
//          Add your solver here!           !
//                                          !
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
Solvers.Add("random", new RandomMS());
//Solvers.Add("YOUR_NAME", new YOUR_CLASS());


MazeSolver solver = SolverSelect();
Map maze = MazeSelect("simple");
int cutoff = StepSelect(100);

solver.SetMap(maze);

MazePath path = solver.SolveMaze(cutoff);

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
Map MazeSelect(string def)
{
    Console.Clear();
    Console.WriteLine("Please pick a maze for your mouse to try (Default: " + def + ")");
    Console.WriteLine("[1] simple");
    Console.WriteLine("[2] mouse");
    Console.WriteLine("[3] invalid");

    string? input = Console.ReadLine();

    Console.WriteLine("");

    string filePath = "../../../Maze/test-values/mouse.txt";

    switch (input)
    {
        case "":
            filePath = "../../../Maze/test-values/" + def + ".txt";
            break;

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
            return MazeSelect(def);
            
    }


    // MazeIO -> read in maze
    Map maze = MazeIO.ReadMap(filePath);
    //MazeIO.PrintMaze(maze);

    return maze;
}
int StepSelect(int def)
{
    Console.Clear();
    Console.WriteLine("How many steps does your mouse get ? (Default: " + def + ")");
    string input = Console.ReadLine();


    if (!(input is null))
    {
        if (input == "")
            return def;

        int input_int = -1;
        Int32.TryParse(input, out input_int);

        if (input_int > 0)
            return input_int;
        
    }

    return StepSelect(def);
}