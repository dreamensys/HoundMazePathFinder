/// <summary>
/// 
/// </summary>

namespace HoundMazePathFinder
{
    using HoundMazePathFinder.Algorithms;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private bool[,]             map;
        private SearchParameters    findingParameters;
        private const char          WALK_SPACES          = 'F';

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {

            Ini();

            return;





            InitializeHoundMazeMap();
            PathFinder pathFinder = new PathFinder(findingParameters);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            List<Point> path = pathFinder.FindPath();
            timer.Stop();
            Console.WriteLine(string.Format("Time: {0} seconds", timer.Elapsed.TotalSeconds));
            Console.WriteLine(string.Format("The coordinates of path are: "));
            foreach (var item in path)
            {
                Console.Write(string.Format("[{0},{1}],", item.X, item.Y));
            }
           // ShowPathRoute(path);    ///This method draws the entire path to meal, if you don't want to see it, please comment it.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        /// <summary>
        /// Draws the entire route from start to finish.
        /// </summary>
        /// <param name="path"></param>     
        private void ShowPathRoute(IEnumerable<Point> path)
        {
            Console.WriteLine(); 
            for (int y = 0; y < this.map.GetLength(1) - 1; y++) 
            {
                for (int x = 0; x < this.map.GetLength(0); x++)
                {
                    if (this.findingParameters.StartLocation.Equals(new Point(x, y)))
                        // Prints the position where the Hound starts the searching.
                        Console.Write("S");
                    else if (this.findingParameters.EndLocation.Equals(new Point(x, y)))
                        // Prints the position where the meal is.   
                        Console.Write("F");
                    else if (this.map[x, y] == false)
                        // Draws the walls.
                        Console.Write("░");
                    else if (path.Where(p => p.X == x && p.Y == y).Any())
                    {
                        // Draws the path.
                        Console.Write('*');
                    }
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void Ini()
        {

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\Hound Maze(tsv).txt");
            this.map = new bool[55, 55];
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                if(counter == 5)
                {
                    int rowsCount = 0;
                    char[] characters = line.Substring(5).ToCharArray();
                    for (int j = 0; j < characters.Length; j++)
                    {
                        this.map[j, rowsCount] = characters[j] == WALK_SPACES;
                    }
                    rowsCount++;
                }
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();


            for (int i = 0; i < lines.Length; i++)
            {
                char[] characters = lines[i].ToCharArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    this.map[j, i] = characters[j] == WALK_SPACES;
                }
            }

            var startCoordinates = new Point(54, 77);
            var finishCoordinates = new Point(12, 20);
            this.findingParameters = new SearchParameters(startCoordinates, finishCoordinates, map);
        }

        private void InitializeHoundMazeMap()
        {

            StringBuilder mazeBuilder = new StringBuilder();
            mazeBuilder.Append("FFFFFFFFFFFFFFFFFFFFFFFFFFFXFXFFFXXXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("FXXXXXXXXXXXXXXXXXFFFXFXXXFXFXFFFXXXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("FFFXXXFFFFFXFFFFFXFFFXFXXXFXFXFFFXFFFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXXXXXFXXXFXFXXXFXFFFXFXXXFXFXFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFFFFFXFXFXFXXXFXFFFXFXXXFXFFFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFXXXXXFXFXFXXXFXFFFXFXXXFXXXFFFXFXFFFFFFFFFFFXXXXXXXX,");
            mazeBuilder.Append("XXFXXXFFFFFXFXXXFFFFFXFXXXFFFFFFFXFXFFFFFFFFFFFFFFFFFFF,");
            mazeBuilder.Append("XXFXXXFXXXXXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFXXXXXXXXXXXF,");
            mazeBuilder.Append("XXFXXXFXFFFXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFFFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXXXFXFXFXFXXXXXFFFXFXXXFFFXXXXXFXFXXXXXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFXFXFXFXFXFFFXFFFXFXXXFFFXXXXXFXFFFFFXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFXFXXXFXFXXXFXXXXXFXXXFFFXXXXXFXXXFXXXFXFFFXXXXXXXF,");
            mazeBuilder.Append("XXFXFFFFFFFXFXXXFFFFFFFFFXFFFXXXXXFXFFFFFXFXFFFXFFFFFFF,");
            mazeBuilder.Append("XXFXXXXXXXXXFXXXFXXXFFFFFXXXXXXXXXFXFFFFFXFXFFFXFXXXXXF,");
            mazeBuilder.Append("XXFFFFFFFFFFFXXXFFFXFFFFFXXXFFFXXXFXFFFFFXFXFFFXFXFFFFF,");
            mazeBuilder.Append("XXFXXXXXXXXXXXXXXXFXXXXXXXXXFFFXXXFXXXXXXXFXFFFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFFFFFFFFFFFFFFFFFFFFFXFFFFFFFXFFFFFFFXFFFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXXXXXFXFXFFFXXXFXXXXXFXXXXXFXFXXXXXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFFFFFFFXFXFFFXFFFFFFFFFFFXFXFXFFFFFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXXXXXXXFXXXXXFFFFFFFFFFFXFXFXXXXXXXF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFFFFFFFXXXXXFFFFFFFFFFFXFXFXFFFXFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXXXXXXXXXXXFFFFFFFFFFFXFXFXFFFXFXX,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFFFXFFFFFFFFFFFFFFFFFFFFFXFXFFFFFXFFF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXFFFFFFFXXXFFFFFFFFFFFXFXFXXXXXXXF,");
            mazeBuilder.Append("FFFFFXFXFFFFFFFFFFFXFXFFFFFFFXFXFFFFFFFFFFFXFFFFFFFXFFF,");
            mazeBuilder.Append("XXXXFXFXFXXXXXXXXXXXFXFFFFFFFXFXXXFXFXXXXXXXFXXXXXXXFXF,");
            mazeBuilder.Append("FFFFFXFXFXFFFFFFFFFXFXFFFFFFFXFFFXFXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("XXXXFXFXFXFXXXXXXXFXXXFXXXXXFXXXFXFXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFXFXFXXXXXXXFFFFFXFFFFFFFXFFFXFFFFFFFXFXFFFFFFFXF,");
            mazeBuilder.Append("FFFXFXFXXXFXXXXXXXXXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXXXF,");
            mazeBuilder.Append("FFFXFXFFFFFXXXXXXXXXXXFXFFFFFFFFFFFFFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFXXXXXXXXXXXXXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXFXF,");
            mazeBuilder.Append("FFFXFXFFFFFFFXFFFFFXXXFXFFFFFFFXXXXXFFFFFFFXFXFFFFFXFFF,");
            mazeBuilder.Append("FFFXFXXXXXFFFXFXXXFXXXFXFXFXXXFXXXXXXXXXFXFXXXFFFFFXFXX,");
            mazeBuilder.Append("FFFXFXXXXXFFFXFXFFFFFFFXFXFFFXFXXXXXXXXXFXFFFFFFFFFXFFF,");
            mazeBuilder.Append("FXFXFXXXXXFFFXFXXXXXXXXXFXFFFXFXXXXXXXXXFXXXXXXXXXXXXXF,");
            mazeBuilder.Append("FXFXFFFFFXFFFXFFFFFFFFFFFXFFFXFFFFFFFFFXFFFFFFFFFXFFFXF,");
            mazeBuilder.Append("FXFXXXXXFXXXXXFXXXXXXXXXXXFFFXXXXXXXXXFXFFFFFFFFFXFXXXF,");
            mazeBuilder.Append("FXFXXXXXFXFFFFFFFFFFFFFXFXFFFFFFFFFFFXFXFFFFFFFFFXFFFFF,");
            mazeBuilder.Append("XXFXXXXXFXFXFFFFFFFFFFFXFXFXXXFFFFFFFXFXXXFXFXXXXXFXXXX,");
            mazeBuilder.Append("FFFXXXXXFXFXFFFFFFFFFFFFFXFXXXFFFFFFFFFXXXFXFFFFFFFXXXX,");
            mazeBuilder.Append("FXXXXXXXFXFXFFFFFFFFFFFXXXFXXXXXXXFXXXFXXXFXXXXXXXXXXXX,");
            mazeBuilder.Append("FFFXFFFFFXFXFFFFFFFFFFFXXXFXXXXXXXFXFFFXXXFFFFFFFFFFFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXXXFXXXXXXXFXFXFXXXXXXXXXXXXXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFFFXFFFFFFFXFXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXFXXXXXXXFXFXXXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXFFFFFFFFFFFXFFFFFFFXFXFFFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFXXXXXXXXXXXXXFXXXFXFXFXXXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFXFFFFFXFFFFFFFXXXXXFFFXXXFXFXFXXXFFFFFFFFFFFFFFFXFXX,");
            mazeBuilder.Append("FXFXXXFXXXXXXXXXFXXXXXFXXXXXFXXXFXXXXXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXFFFFFXFFFFFXXXFXXXXXFXFFFFFFFFFXXXFXFFFFFFFFFXFFFXFXX,");
            mazeBuilder.Append("FXXXXXXXFXXXFXXXFXXXXXFXFFFXFXXXXXXXFXXXXXXXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFXXXXXFXFFFXFFFXFFFFFFFXFFFXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFXXXXXXXFFFXXXFXFFFFFFFXFXFXXXXXXXFXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXFFFFFFFFFFFXFFFFFFFFFFFXFXFFFFFFFFFXFFF,");
            mazeBuilder.Append("FFFFFFFFFXFXFXXXXXXXXXXXFFFXXXXXFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFFFXXXFFFFFFFXXXXXFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXXXXXXXFXXXFXXXFFFXXXXXXXXXXXXXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFFFFFFFFFFFXFXFFFFFFFFFXFXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFXXXXXXXXXFXFXXXXXXXFXXXXXF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXFFFXFXFFFFFFFFFFFXFFFFFXFXXXFFF,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFXXXXXXXFXFXXXXXXXXXXXFFFFFXFXXXFXX,");
            mazeBuilder.Append("FFFFFFFFFXFFFFFXFXXXFFFFFFFXFXFXXXXXXXXXXXFFFFFXFXXXFXX,");
            mazeBuilder.Append("XXFXXXXXFXFFFFFXFXXXXXXXXXFXFXFXXXXXXXXXXXFXXXFXFXXXFXX,");
            mazeBuilder.Append("FFFFFFFXFXFFFFFXFFFFFFFFFXFXFFFFFFFXXXXXXXFXFFFXFFFXFFF,");
            mazeBuilder.Append("FXXXXXFXFXFFFFFXXXXXXXXXFXFXFFFFFFFXXXXXXXXXFXFXXXXXXXF,");
            mazeBuilder.Append("FXXXXXFXFFFFFFFXXXXXXXXXFXFXFFFFFFFXFFFFFFFFFXFFFFFFFFF,");
            mazeBuilder.Append("FXXXXXFXXXXXFXXXXXXXXXXXFXFXFFFFFFFXFXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("FXXXXXFFFXFFFXXXXXXXXXXXFXFXFFFFFFFXFXFFFFFXFFFFFFFFFXF,");
            mazeBuilder.Append("FXXXXXXXFXXXXXXXXXXXXXXXFXFXFXXXXXXXFXFXXXFXFFFFFFFFFXF,");
            mazeBuilder.Append("FXFFFFFXFFFFFFFXXXXXXXXXFXFFFXXXXXXXFXFXFFFXFFFFFFFFFFF,");
            mazeBuilder.Append("FXXXFXFXXXXXXXFXXXXXXXXXFXXXXXXXXXXXFXFXXXXXXXXXFXXXXXF,");
            mazeBuilder.Append("FFFFFXFFFFFFFXFFFFFFFFFFFFFFFFFFFFFFFXFFFFFFFFFFFXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");
            mazeBuilder.Append("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXF,");

            string[] lines = mazeBuilder.ToString().Split(',');
            this.map = new bool[55, lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                char[] characters = lines[i].ToCharArray();
                for (int j = 0; j < characters.Length; j++)
                {
                    this.map[j, i] = characters[j] == WALK_SPACES;
                }
            }

            var startCoordinates = new Point(54, 77);
            var finishCoordinates = new Point(12, 20);
            this.findingParameters = new SearchParameters(startCoordinates, finishCoordinates, map);
        }
        
    }
}
