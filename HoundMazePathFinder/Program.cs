
namespace HoundMazePathFinder
{
    using HoundMazePathFinder.Algorithms;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    class Program
    {
        private List<bool[]>        map;
        private SearchParameters    findingParameters;
        private const string        WALK_SPACES          = "F";

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            InitializeMapFromFile("Hound Maze(tsv).txt", new Point(54, 77), new Point(12, 20));

            // Feel free to uncomment these two lines in order o test the algorithm with other mazes.
            //InitializeMapFromFile("Sample1(tsv).txt", new Point(25, 0), new Point(13, 11));
            //InitializeMapFromFile("Sample2(tsv).txt", new Point(25, 16), new Point(7, 5));
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
            ShowPathRoute(path);    ///This method draws the entire path to meal, if you don't want to see it, please comment it.
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
            for (int y = 0; y < this.map.Count; y++) 
            {
                for (int x = 0; x < this.map.First().Length; x++)
                {
                    if (this.findingParameters.StartLocation.Equals(new Point(x, y)))
                        // Prints the position where the Hound starts the searching.
                        Console.Write("S");
                    else if (this.findingParameters.EndLocation.Equals(new Point(x, y)))
                        // Prints the position where the meal is.   
                        Console.Write("F");
                    else if (this.map[y][x] == false)
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

        private void InitializeMapFromFile(string fileName, Point startCoordinates, Point finishCoordinates)
        {
            int counter = 0, columnLimit = 0;
            string line;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Mazes\", fileName);
            StreamReader file = new StreamReader(@path); 
            this.map = new List<bool[]>();
            int rowsCount = 0;
            while ((line = file.ReadLine()) != null)    
            {
                if(counter >= 5)
                {
                    string[] characters = line.Substring(5).Split('\t');
                    if (columnLimit == 0)
                    {
                        columnLimit = characters.Length;
                    }
                    
                    this.map.Add(new bool[characters.Length]);
                    for (int j = 0; j < columnLimit; j++)
                    {
                        this.map[rowsCount][j] =  characters[j] == WALK_SPACES;                            
                    }
                    rowsCount++;
                }
                counter++;
            }
            this.map.RemoveAll(r => r.Count() == 0);
            file.Close();

            this.findingParameters = new SearchParameters(startCoordinates, finishCoordinates, map);
        }


        /// <summary>
        /// This is a dummy example to test the algorithm using a string instead a TSV file.
        /// </summary>
        private void InitializeHoundMazeMapFromString()
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
            this.map = new List<bool[]>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] characters = lines[i].Split('\t');
                this.map.Add(new bool[characters.Length]);
                for (int j = 0; j < characters.Length; j++)
                {
                    this.map[i][j] = characters[j] == WALK_SPACES;
                }
            }
            this.map.RemoveAll(r => !r.Any());
            var startCoordinates = new Point(54, 77);
            var finishCoordinates = new Point(12, 20);
            this.findingParameters = new SearchParameters(startCoordinates, finishCoordinates, map);
        }
        
    }
}
