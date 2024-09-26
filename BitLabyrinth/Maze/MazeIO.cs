using BitLabyrinth.Maze;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace BitLabyrinth.Maze
{
    public static class MazeIO
    {

        internal static Map ReadMap(string FilePath)
        {
            int height;
            int width;
            string[] values;

            Map maze = new();

            using StreamReader reader = new(FilePath);

            string? line = "";
            while ((line = reader.ReadLine()) != null)
            {
                char[] lineSep = line.ToCharArray();

                width = lineSep.Length;

                maze.addLine(lineSep.ToList());

                /*
                foreach(char c in lineSep){
                    if(c == 'x')
                    {
                        startPosition
                    }
                }*/
            }

            return maze;

        }

        internal static void PrintMaze(Map maze) {

            List<string> stringList = maze.GetLinesAsStrings();

            foreach (string str in stringList)
                Console.WriteLine(str);
        }

        internal static void AnimatePath(Map maze, MazePath path)
        {

            foreach(var step in path.Steps) {

                int x = step.Item1;
                int y = step.Item2;
                 
                Map frame = maze;
                frame.SetTile(x, y, '!');

                for (int i = 0; i < 3; i++)
                {
                    PrintMaze(maze);
                    System.Threading.Thread.Sleep(500);
                    PrintMaze(frame);
                    System.Threading.Thread.Sleep(500);
                }
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
