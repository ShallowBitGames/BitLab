namespace BitLabyrinth.Maze.Solvers
{

    internal class RandomMS : MazeSolver
    {

        /* Executes a step in a random direction
         * OUT: coordinate-tuple of the step taken
         * MODIFIES: attaches one element to partial path
         */
        internal override (int, int) DecideStep()
        {
            var rand = new Random();

            (int, int) currentPosition = PartialPath.Last();

            while (true)
            {
                int index = rand.Next(2);                    // either 0 (x-coordinate) or 1 (y-coordinate)
                int modifier = rand.Next(2) == 0 ? -1 : 1;   // either -1 or +1 

                int x = currentPosition.Item1;
                int y = currentPosition.Item2;

                if (index == 0)
                    x += modifier;
                else
                    y += modifier;

                if (Maze.IsValid(x, y) && Maze.IsPassable(x, y))
                    return (x, y);

            }
        }

    }

}
