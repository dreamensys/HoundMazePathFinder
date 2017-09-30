

namespace HoundMazePathFinder.Algorithms
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Sets the parameters to find a path across the grid.
    /// </summary>
    public class SearchParameters
    {
        /// <summary>
        /// The initial location.
        /// </summary>
        public Point StartLocation { get; set; }

        /// <summary>
        ///  The Final Location.
        /// </summary>
        public Point EndLocation { get; set; }
        
        /// <summary>
        /// A list of boolean arrays.
        /// </summary>
        public List<bool[]> Map { get; set; }

        public SearchParameters(Point startLocation, Point endLocation, List<bool[]> map)
        {
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;
            this.Map = map;
        }
    }
}
