namespace HoundMazePathFinder.Algorithms
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class PathFinder
    {
        private int width;
        private int height;
        private Node[,] nodes;
        private Node startNode;
        private Node endNode;
        private SearchParameters findingParameters;

        /// <summary>
        /// Creates a new PathFinder class inherited from IPathFinder.
        /// </summary>
        /// <param name="searchParameters"></param>
        public PathFinder(SearchParameters searchParameters)
        {
            this.findingParameters = searchParameters;
            InitializePathNodes(searchParameters.Map);
            this.startNode = this.nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            this.startNode.State = NodeState.Open;
            this.endNode = this.nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];
        }

        public List<Point> FindPath()
        {
            List<Point> path = new List<Point>();
            bool success = Search(startNode);
            if (success)
            {
                Node node = this.endNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }

                path.Reverse();
            }

            return path;
        }

        /// <summary>
        /// Draws the grid from a simple list of booleans.
        /// </summary>
        private void InitializePathNodes(List<bool[]> map)
        {
            this.width = map.First().Length;
            this.height = map.Count;
            this.nodes = new Node[this.width, this.height];
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    this.nodes[x, y] = new Node(x, y, map[y][x], this.findingParameters.EndLocation);
                }
            }
        }

        /// <summary>
        /// Searchs over the maze.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private bool Search(Node currentNode)
        {
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetAlongsideWalkNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1.TotalCost.CompareTo(node2.TotalCost));
            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == this.endNode.Location)
                {
                    return true;
                }
                else
                {
                    if (Search(nextNode))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get alongsidelocations.
        /// </summary>
        /// <param name="fromLocation"></param>
        /// <returns></returns>
        private static IEnumerable<Point> GetAlongsideLocations(Point fromLocation)
        {
            return new Point[]
            {
                new Point(fromLocation.X-1, fromLocation.Y  ),
                new Point(fromLocation.X,   fromLocation.Y+1),
                new Point(fromLocation.X+1, fromLocation.Y  ),
                new Point(fromLocation.X,   fromLocation.Y-1)
            };
        }

        /// <summary>
        /// Get Alongside Walkable Nodes.
        /// </summary>
        /// <param name="fromNode"></param>
        /// <returns></returns>
        private List<Node> GetAlongsideWalkNodes(Node fromNode)
        {
            List<Node> walkaNodes = new List<Node>();
            IEnumerable<Point> nextLocations = GetAlongsideLocations(fromNode.Location);

            foreach (var location in nextLocations)
            {
                int x = location.X;
                int y = location.Y;

                if (x < 0 || x >= this.width || y < 0 || y >= this.height)
                    continue;

                Node node = this.nodes[x, y];
                if (!node.IsWalkable)
                    continue;

                if (node.State == NodeState.Closed)
                    continue;

                if (node.State == NodeState.Open)
                {
                    float traversalCost = Node.GetPathCost(node.Location, node.ParentNode.Location);
                    float gTemp = fromNode.StartCost + traversalCost;
                    if (gTemp < node.StartCost)
                    {
                        node.ParentNode = fromNode;
                        walkaNodes.Add(node);
                    }
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkaNodes.Add(node);
                }
            }

            return walkaNodes;
        }
        
    }
}
