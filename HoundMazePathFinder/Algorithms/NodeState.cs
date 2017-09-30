namespace HoundMazePathFinder.Algorithms
{
    /// <summary>
    /// The Node State
    /// </summary>
    public enum NodeState
    {
        /// <summary>
        /// The node is identified as a possible step.
        /// </summary>
        Open,

        /// <summary>
        /// The node has not been considered.
        /// </summary>
        Untested,

        /// <summary>
        /// The node is included in a path and will be discarded.
        /// </summary>
        Closed
    }
}
