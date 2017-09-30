namespace HoundMazePathFinder.Algorithms
{
    using System;
    using System.Drawing;

    public class Node
    {
        private Node parentNode;

        /// <summary>
        /// Is the node walkable?
        /// </summary>
        public bool IsWalkable { get; set; }

        /// <summary>
        /// Cost from start.
        /// </summary>
        public float StartCost { get; private set; }

        /// <summary>
        /// The current Node Status.
        /// </summary>
        public NodeState State { get; set; }

        /// <summary>
        /// Calculates the cost (F = G + H).
        /// </summary>
        public float TotalCost
        {
            get { return this.StartCost + this.EndCost; }
        }

        /// <summary>
        /// The node's location.
        /// </summary>
        public Point Location { get; private set; }       

        /// <summary>
        /// Cost to End.
        /// </summary>
        public float EndCost { get; private set; }

        /// <summary>
        /// Gets or sets the  Parent Node.
        /// </summary>
        public Node ParentNode
        {
            get { return this.parentNode; }
            set
            {
                this.parentNode = value;
                this.StartCost = this.parentNode.StartCost + GetPathCost(this.Location, this.parentNode.Location);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}: {2}", this.Location.X, this.Location.Y, this.State);
        }

        /// <summary>
        /// Distance between 2 points.
        /// </summary>
        internal static float GetPathCost(Point location, Point otherLocation)
        {
            float deltaX = otherLocation.X - location.X;
            float deltaY = otherLocation.Y - location.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public Node(int x, int y, bool isWalkable, Point endLocation)
        {
            this.Location = new Point(x, y);
            this.State = NodeState.Untested;
            this.IsWalkable = isWalkable;
            this.EndCost = GetPathCost(this.Location, endLocation);
            this.StartCost = 0;
        }

        
    }
}
