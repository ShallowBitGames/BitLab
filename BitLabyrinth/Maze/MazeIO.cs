using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BitLabyrinth
{
    public class MazeIO
    {
        
        private Map CurrentMaze = new();

        public void RunTest(string path)
        {

            ReadMaze(path);
            PrintMaze();

        }

        private void ReadMaze(string FilePath)
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

                maze.addLine(lineSep.ToList());
            }


            CurrentMaze = maze;

        }

        public void PrintMaze()
        {
            List<string> stringList = CurrentMaze.GetLinesAsStrings();

            foreach (string str in stringList)
                Console.WriteLine(str);
        }

        private void PostMaze(Map maze)
        {
            HttpClient client = new HttpClient();

            string jsonString = JsonSerializer.Serialize(CurrentMaze);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            string url = "http://localhost:5009/api/maze/maze";

            var response = client.PostAsync(url, content);
            //Console.WriteLine(response.Content.ReadAsStringAsync());


        }

    }
}
