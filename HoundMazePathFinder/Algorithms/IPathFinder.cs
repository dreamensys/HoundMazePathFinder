namespace HoundMazePathFinder.Algorithms
{
    using System.Collections.Generic;
    using System.Drawing;

    public interface IPathFinder
    {
        List<Point> FindPath();
        bool Search(Node currentNode);
    }
}