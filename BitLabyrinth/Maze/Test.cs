using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BitLab
{
    public class TestClient
    {
        //const int Port = ;
        //private const string TestFile = "test-values/simple.txt";
        private const string TestFile = "../../../Maze/test-values/mouse.txt";
        private string[] TestFiles = { "test-values/simple.txt", "test-values/invalid.txt", "test-values/complex.txt" };

        private Maze CurrentMaze = new Maze();

        public void RunTest()
        {
            //Console.WriteLine("Current directory path: " + Directory.GetCurrentDirectory());

            ReadMaze(TestFile);
            PrintMaze();
            PostMaze(CurrentMaze);


        }


        private void ReadMaze(string FilePath)
        {
            int height;
            int width;
            string[] values;

            Maze maze = new Maze();

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
            CurrentMaze.print();
        }

        private void PostMaze(Maze maze)
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
