using System;
using System.Collections.Generic;
using System.Linq;

namespace AStarPoc
{
    /// <summary>
    /// A* Pathfinding algorithm implementation.
    /// </summary>
    internal class AStar
    {
        /// <summary>
        /// Starting position tile.
        /// </summary>
        private Tile _startingTile;
        /// <summary>
        /// Ending position tile.
        /// </summary>
        private Tile _endingTile;
        /// <summary>
        /// Open nodes list (open list).
        /// </summary>
        private List<Tile> _fringe;
        /// <summary>
        /// Evaluated tiles list.
        /// </summary>
        private HashSet<Tile> _closedList;
        /// <summary>
        /// Grid object the algorithm will refer to.
        /// </summary>
        private TileBoard2D _tileBoard;
        /// <summary>
        /// 
        /// </summary>
        public AStar(TileBoard2D board, Tile startingTile, Tile endingTile)
        {
            _tileBoard = board;
            _startingTile = startingTile;
            _endingTile = endingTile;
        }
        /// <summary>
        /// Finds a path using the A* algorithm.
        /// 
        /// TODO: SortedList is ordered by the keys (Node implements IComparer).
        /// Try with a heap tree next time.
        /// 
        /// The method updates the parent of the goal node,
        /// so it's possible to trace back the shortest path.
        /// </summary>
        public bool FindPath(out List<Tile> path)
        {
            // Resets closed nodes list.
            _closedList = new HashSet<Tile>();
            // Resets the open nodes list.
            _fringe = new List<Tile>();
            // Puts the starting node into the closed list (FCost is the key).
            _fringe.Add(_startingTile);
            // If the fringe is empty, no route exists between start and goal.
            while (_fringe.Count > 0)
            {
                // Orders the fringe by F cost and subsequently by the H cost.
                _fringe = _fringe.OrderBy(l => l.FCost).ThenBy(l => l.HCost).ToList();
                // Gets the node with the shortest estimated distance to the goal
                // from the fringe list.
                var currentNode = _fringe[0];
                // Removes the currentNode from the fringe list.
                _fringe.RemoveAt(0);
                // Adds the current node to the closed nodes list.
                _closedList.Add(currentNode);
                // Checks if the current node is the goal node.
                if (currentNode == _endingTile)
                {
                    // The search is complete, outputs the path.
                    path = TraceBack();
                    return true;
                }
                // Get all the neighbours of the current node.
                var neighbours = GetTileNeighbours(currentNode);

                foreach (var neighbour in neighbours)
                {
                    // If the node is not walkable or it's already in _closedList,
                    // processes the next one.
                    if (neighbour.Type == TileTypeEnum.Obstacle || _closedList.Contains(neighbour)) continue;

                    var costToNeighbour = currentNode.GCost + ManhattanDistance(currentNode, neighbour);

                    if (costToNeighbour < neighbour.GCost || !_fringe.Contains(neighbour))
                    {
                        // Updates the parent of the neighbour.
                        neighbour.Parent = currentNode;
                        // Updates the G cost (cost from origin).
                        neighbour.GCost = costToNeighbour;
                        // Updates the H cost (cost to goal).
                        neighbour.HCost = ManhattanDistance(neighbour, _endingTile);
                        // Adds the neighbour to the fringe.
                        if (!_fringe.Contains(neighbour))
                            _fringe.Add(neighbour);
                    };
                }
            }
            // The search failed.
            path = null;
            return false;
        }
        /// <summary>
        /// Gets the distance between two nodes on the grid.
        /// Taxicab geometry or Manhattan distance (Minkowski).
        /// A = (x1, y1)
        /// B = (x2, y2)
        /// Lm(A,B) = |x1 - x2| + |y1 - y2|
        /// https://en.wikipedia.org/wiki/Taxicab_geometry
        /// </summary>
        private int ManhattanDistance(Tile a, Tile b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
        /// <summary>
        /// Euclidean distance = straight line distance.
        /// A = (x1, y1)
        /// B = (x2, y2)
        /// Le(A,B) = sqrt((x1 - x2)^2 + (y1 - y2)^2)
        /// 
        /// Not used.
        /// </summary>
        private double EuclideanDistance(Tile a, Tile b)
        {
            return Math.Sqrt((a.X - b.X) ^ 2 + (a.Y - b.Y) ^ 2);
        }
        /// <summary>
        /// Gets the direct neighbours of a Node.
        /// </summary>
        private List<Tile> GetTileNeighbours(Tile node)
        {
            // Nodes will be sorted during the addition to the SortedList
            // by the value of the key.
            var sl = new List<Tile>();

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    // Avoids the node at the center (current node).
                    if (x == 0 && y == 0) continue;
                    // Out of bounds checks.
                    var checkX = node.X + x;
                    var checkY = node.Y + y;

                    if (checkX >= 0 && checkX < _tileBoard.Width &&
                        checkY >= 0 && checkY < _tileBoard.Height)
                    {
                        // Gets the neighbour.
                        var neighbour = _tileBoard.GetTileAt(checkX, checkY);
                        // Puts the node in the neighbours list, and sets the distance from the goal node as the key.
                        sl.Add(neighbour);
                    }
                }
            }
            return sl;
        }
        /// <summary>
        /// Traces back a gets the list of nodes on the path.
        /// </summary>
        private List<Tile> TraceBack()
        {
            var path = new List<Tile>();
            var currentNode = _endingTile;

            while (currentNode != _startingTile)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}