namespace AStarPoc
{
    /// <summary>
    /// A tile of the board.
    /// </summary>
    internal class Tile
    {
        /// <summary>
        /// States if the node is walkable or not.
        /// </summary>
        public TileTypeEnum Type { get; set; }
        /// <summary>
        /// Distance from the origin node.
        /// </summary>
        public int GCost { get; set; }
        /// <summary>
        /// Distance from the destination node (Heuristic).
        /// </summary>
        public int HCost { get; set; }
        /// <summary>
        /// Total cost of the node.
        /// </summary>
        public int FCost { get { return GCost + HCost; } }
        /// <summary>
        /// Eventual parent node, needed to trace back the path.
        /// </summary>
        public Tile Parent { get; set; }
        /// <summary>
        /// X Position on the board.
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Y Position on the board.
        /// </summary>
        public int Y { get; private set; }
        /// <summary>
        /// Node constructor.
        /// </summary>
        public Tile(TileTypeEnum tileType, int x, int y)
        {
            Type = tileType;
            X = x;
            Y = y;
        }
    }
}
