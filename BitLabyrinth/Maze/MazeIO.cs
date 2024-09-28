using BitLabyrinth.Maze;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;

namespace BitLabyrinth.Maze
{
    
    public static class MazeIO
    {
        //simple double dict, Access via Set and Get
        internal static class SymbolTable
        {
            private static Dictionary<char, TileType> SymbolToType = new();
            private static Dictionary<TileType, char> TypeToSymbol = new();

            static SymbolTable()
            {
                Set('x', TileType.START);
                Set('o', TileType.GOAL);
                Set('#', TileType.WALL);
                Set(' ', TileType.FREE);
            }

            internal static void Set(char c, TileType t)
            {
                SymbolToType[c] = t;
                TypeToSymbol[t] = c;
            }

            internal static void Set(TileType t, char c)
            {
                Set(c, t);
            }

            internal static char Get(TileType type)
            {
                if (TypeToSymbol.ContainsKey(type))
                    return TypeToSymbol[type];
                else
                    return '?';
            }

            internal static TileType Get(char c)
            {
                if (SymbolToType.ContainsKey(c))
                    return SymbolToType[c];
                else
                    return TileType.NONE;
            }

        }

        internal static Map ReadMap(string FilePath)
        {
            
            List<List<char>> values = new();
            List<List<Tile>> tiles = new();
            int[] startPosition = [-1, -1];
            int[] goalPosition = [-1, -1];

            using StreamReader reader = new(FilePath);

            string? line = "";
            while ((line = reader.ReadLine()) != null)
            {
                //char[] lineSep = line.ToCharArray();
                values.Add(line.ToList()); 

            }

            for(int x = 0; x < values.Count(); x++)
            {
                List<Tile> row = new();

                for (int y = 0; y < values[x].Count(); y++)
                {
                    char c = values[x][y];

                    TileType tileType = SymbolTable.Get(c);
                    row.Add(new Tile(tileType));

                    if (tileType == TileType.START)
                        startPosition = [x, y];

                    if (tileType == TileType.GOAL)
                        goalPosition = [x, y];
                }

                tiles.Add(row);
            }

            Map maze = new(tiles, startPosition, goalPosition);

            return maze;

        }

        static void PrintFrame(List<List<char>> frame)
        {
            foreach (var row in frame)
            {
                string rowString = String.Join("", row);
                Console.WriteLine(rowString);
            }
        }

        public static void PrintMaze(Map maze)
        {
            var frame = MapToFrame(maze);
            PrintFrame(frame);
        }

        internal static List<List<char>> MapToFrame(Map maze)
        {
            List<List<char>> frames = new();

            foreach (var rowMaze in maze.Tiles) {

                List<char> rowFrame = new();

                foreach (Tile t in rowMaze)
                {
                    TileType tileType = t.Type;
                    char symbol = SymbolTable.Get(tileType);
                    rowFrame.Add(symbol);
                }
                frames.Add(rowFrame);
            }

            return frames;
                           
        }

        internal static void AnimatePath(Map maze, MazePath path)
        {

            foreach(var step in path.Steps) {

                int x = step.Item1;
                int y = step.Item2;

                List<List<char>> frameBase = MapToFrame(maze);
                var framePlayer = frameBase;

                framePlayer[x][y] = '!';

                //for (int i = 0; i < 3; i++)
                //{
                    //Console.Clear();
                    //PrintFrame(frameBase);
                    //System.Threading.Thread.Sleep(100);
                    Console.Clear();
                    PrintFrame(framePlayer);
                //Console.WriteLine(path.Last());
                    System.Threading.Thread.Sleep(500);
                //}
            }


        }

        internal static void PostMaze(Map maze)
        {
            HttpClient client = new HttpClient();

            string jsonString = JsonSerializer.Serialize(maze);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            string url = "http://localhost:5009/api/maze/maze";

            var response = client.PostAsync(url, content);
            //Console.WriteLine(response.Content.ReadAsStringAsync());


        }

    }
}
