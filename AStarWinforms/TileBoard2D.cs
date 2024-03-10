using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace AStarPoc
{
    /// <summary>
    /// The tile board.
    /// </summary>
    internal class TileBoard2D
    {
        /// <summary>
        /// Colored grid.
        /// </summary>
        private Tile[,] _board;
        /// <summary>
        /// Size of the squared cells of the grid.
        /// </summary>
        private int _tileSize;
        /// <summary>
        /// Cell's default color.
        /// </summary>
        public Color CellDefaultColor { get; private set; } = Color.Transparent;
        /// <summary>
        /// Grid lines color.
        /// </summary>
        private Color _boardColor;
        /// <summary>
        /// Returns the board width in tiles.
        /// </summary>
        public int Width
        {
            get { return _board.GetLength(0);  }
        }
        /// <summary>
        /// Returns the board height in tiles.
        /// </summary>
        public int Height
        {
            get { return _board.GetLength(1); }
        }
        /// <summary>
        /// Class initializer 0.
        /// </summary>
        public TileBoard2D(Size hostControlSize, int cellSize, Color boardColor)
        {
            _tileSize = cellSize;
            _boardColor = boardColor;
            InitializeBoard(hostControlSize.Width / _tileSize, hostControlSize.Height / _tileSize);
        }
        /// <summary>
        /// Class initializer 1.
        /// </summary>
        public TileBoard2D(Size hostControlSize, int cellSize, Color boardColor, Color defaultCellColor)
        {
            _tileSize = cellSize;
            _boardColor = boardColor;
            CellDefaultColor = defaultCellColor;
            InitializeBoard(hostControlSize.Width / _tileSize, hostControlSize.Height / _tileSize);
        }

        /// <summary>
        /// Initializes the board with the specified size.
        /// </summary>
        public void InitializeBoard(int width, int height)
        {
            _board = new Tile[width, height];

            for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    _board[i, j] = new Tile(TileTypeEnum.None, i, j);
        }
        /// <summary>
        /// Returns the tile at the coordinates given by the Point struct,
        /// null if the coordinates are out-of-bounds.
        /// </summary>
        public Tile GetTileAt(Point pos)
        {
            if (pos.X >= _board.GetLength(0) || pos.Y >= _board.GetLength(1) || pos.X < 0 || pos.Y < 0)
                return null;
            return _board[pos.X, pos.Y];
        }
        /// <summary>
        /// Returns the tile at the coordinates given by the x and y parameters,
        /// null if the coordinates are out-of-bounds.
        /// </summary>
        public Tile GetTileAt(int x, int y)
        {
            if (x >= _board.GetLength(0) || y >= _board.GetLength(1) || x < 0 || y < 0)
                return null;
            return _board[x, y];
        }
        /// <summary>
        /// Returns a list of tiles by type.
        /// </summary>
        public IList<Tile> GetTilesByType(TileTypeEnum tileType)
        {
            var tiles = new List<Tile>();
            for (int y = 0; y <= _board.GetLength(1) - 1; ++y)
            {
                for (int x = 0; x <= _board.GetLength(0) - 1; ++x)
                {
                    if (_board[x, y].Type.Equals(tileType))
                        tiles.Add(_board[x, y]);
                }
            }
            return tiles;
        }
        /// <summary>
        /// Sets the type of the tile at the coordinates given by the Point struct.
        /// </summary>
        public void SetTileType(Point pos, TileTypeEnum type)
        {
            if (pos.X >= _board.GetLength(0) || pos.Y >= _board.GetLength(1) || pos.X < 0 || pos.Y < 0)
                return;
            _board[pos.X, pos.Y].Type = type;
        }
        /// <summary>
        /// Sets the type of the tile at the coordinates given by the parameters x and y.
        /// </summary>
        public void SetTileType(int x, int y, TileTypeEnum type)
        {
            if (x >= _board.GetLength(0) || y >= _board.GetLength(1) || x < 0 || y < 0)
                return;
            _board[x, y].Type = type;
        }
        /// <summary>
        /// Draws the tile board.
        /// </summary>
        public void DrawBoard(Graphics g)
        {
            // Updates the tile colors.
            for (int y = 0; y <= _board.GetLength(1) - 1; ++y)
            {
                for (int x = 0; x <= _board.GetLength(0) - 1; ++x)
                {
                    var tile = _board[x, y].Type;
                    SolidBrush brush;

                    switch (tile)
                    {
                        case TileTypeEnum.None:
                            brush = new SolidBrush(Color.Transparent);
                            break;

                        case TileTypeEnum.Beginning:
                            brush = new SolidBrush(Color.LightGreen);
                            break;

                        case TileTypeEnum.End:
                            brush = new SolidBrush(Color.Yellow);
                            break;

                        case TileTypeEnum.Obstacle:
                            brush = new SolidBrush(Color.Coral);
                            break;

                        case TileTypeEnum.Path:
                            brush = new SolidBrush(Color.CornflowerBlue);
                            break;

                        default:
                            throw new Exception($"Tile [{x},{y}] does not have a valid type");
                    }

                    g.FillRectangle(brush, x * _tileSize, y * _tileSize, _tileSize, _tileSize);
                    brush.Dispose();
                }
            }
            // Draws the board squares.
            using (var p = new Pen(_boardColor))
            {
                for (int y = 0; y <= _board.GetLength(1); ++y)
                    g.DrawLine(p, 0, y * _tileSize, _board.GetLength(0) * _tileSize, y * _tileSize);

                for (int x = 0; x <= _board.GetLength(0); ++x)
                    g.DrawLine(p, x * _tileSize, 0, x * _tileSize, _board.GetLength(1) * _tileSize);
            }
        }
    }
}
