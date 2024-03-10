using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AStarPoc
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Board tile size.
        /// </summary>
        private const int TILE_SIZE = 30;
        /// <summary>
        /// Time between two steps.
        /// </summary>
        private const int STEP_TIME_MS = 300;
        /// <summary>
        /// Minimum amount of tiles per edge.
        /// </summary>
        private const int MINIMUM_TILES_PER_EDGE = 2;
        /// <summary>
        /// Maximum amount of tiles per edge.
        /// </summary>
        private const int MAXIMUM_TILES_PER_EDGE = 100;
        /// <summary>
        /// Grid controller object.
        /// </summary>
        private TileBoard2D _board;
        /// <summary>
        /// BackgroundWorker used to calculate/visualize the shortest path.
        /// </summary>
        private BackgroundWorker _aStarBw;
        /// <summary>
        /// Astar implementation.
        /// </summary>
        private AStar _aStar;
        /// <summary>
        /// Class initializer.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// FrmMain Load event handler.
        /// </summary>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            CboSelectedTileType.DataSource = Enum.GetValues(typeof(TileTypeEnum));

            NudGridWidth.Minimum = MINIMUM_TILES_PER_EDGE;
            NudGridHeight.Minimum = MINIMUM_TILES_PER_EDGE;
            NudGridWidth.Maximum = MAXIMUM_TILES_PER_EDGE;
            NudGridHeight.Maximum = MAXIMUM_TILES_PER_EDGE;
            NudGridWidth.Value = 10;
            NudGridHeight.Value = 10;
            // Create a new instance of the grid controller.
            _board = new TileBoard2D(PbxGrid.Size, TILE_SIZE, Color.Gray, Color.White);
        }
        /// <summary>
        /// PbxGrid Paint event handler.
        /// </summary>
        private void PbxGrid_Paint(object sender, PaintEventArgs e)
        {
            // Set the background color of the grid.
            PbxGrid.BackColor = _board.CellDefaultColor;
            // Redraws the grid.
            _board.DrawBoard(e.Graphics);
        }
        /// <summary>
        /// 
        /// </summary>
        private void PbxGrid_Click(object sender, EventArgs e)
        {
            // Gets the type of the tile about to be dropped.
            var tileType = (TileTypeEnum)CboSelectedTileType.SelectedItem;

            switch (tileType)
            {
                case TileTypeEnum.Beginning:
                    if (_board.GetTilesByType(TileTypeEnum.Beginning).Count > 0)
                    {
                        MessageBox.Show(this, "A beginning tile is already set.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;

                case TileTypeEnum.End:
                    if (_board.GetTilesByType(TileTypeEnum.End).Count > 0)
                    {
                        MessageBox.Show(this, "An ending tile is already set.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;

                case TileTypeEnum.Path:
                    MessageBox.Show(this, "Cannot set a tile of type path.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            MouseEventArgs me = (MouseEventArgs)e;
            var pbxCoords = me.Location;

            var x = pbxCoords.X / TILE_SIZE;
            var y = pbxCoords.Y / TILE_SIZE;
            var gridCoords = new Point(x, y);

            _board.SetTileType(gridCoords, tileType);
            // Call invalidate to update the screen.
            PbxGrid.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        private void NudGridWidth_ValueChanged(object sender, EventArgs e)
        {
            var width = (int)NudGridWidth.Value;
            var height = (int)NudGridHeight.Value;
            ChangeGridSize(width, height);
        }
        /// <summary>
        /// 
        /// </summary>
        private void NudGridHeight_ValueChanged(object sender, EventArgs e)
        {
            var width = (int)NudGridWidth.Value;
            var height = (int)NudGridHeight.Value;
            ChangeGridSize(width, height);
        }
        /// <summary>
        /// 
        /// </summary>
        private void CenterBoard()
        {
            PbxGrid.Location = new Point((PbxGrid.Parent.ClientSize.Width / 2) - (PbxGrid.Width / 2),
                                        (PbxGrid.Parent.ClientSize.Height / 2) - (PbxGrid.Height / 2));
            // Call invalidate to update the screen.
            PbxGrid.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        private void ChangeGridSize(int width, int height)
        {
            PbxGrid.SuspendLayout();
            try
            {
                PbxGrid.Width = width * TILE_SIZE;
                PbxGrid.Height = height * TILE_SIZE;
                PbxGrid.Anchor = AnchorStyles.None;
                // Creates a new instance of the board controller.
                _board = new TileBoard2D(PbxGrid.Size, TILE_SIZE, Color.Gray, Color.White);
                CenterBoard();
            }
            finally
            {
                PbxGrid.ResumeLayout();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void BtnExecuteAStar_Click(object sender, EventArgs e)
        {
            var startingTile = _board.GetTilesByType(TileTypeEnum.Beginning).FirstOrDefault();

            if (startingTile is null)
            {
                MessageBox.Show(this, "Beginning tile not set.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var endingTile = _board.GetTilesByType(TileTypeEnum.End).FirstOrDefault();

            if (endingTile is null)
            {
                MessageBox.Show(this, "Ending tile not set.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _aStar = new AStar(_board, startingTile, endingTile);
            // Creates a new instance of the bw.
            _aStarBw = new BackgroundWorker()
            {
                WorkerReportsProgress = false,
                WorkerSupportsCancellation = true
            };
            // Subscription to the DoWork event.
            _aStarBw.DoWork += AStarBw_DoWork;
            _aStarBw.RunWorkerAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        private void BtnResetBoard_Click(object sender, EventArgs e)
        {
            var width = (int)NudGridWidth.Value;
            var height = (int)NudGridHeight.Value;
            _board.InitializeBoard(width, height);
            // Call invalidate to update the screen.
            PbxGrid.Invalidate();
        }
        /// <summary>
        /// Main body of the background worker.
        /// </summary>
        private void AStarBw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Calculates the shortest path and returns a list of tiles in the path.
            _aStar.FindPath(out List<Tile> path);
            // Visualizes the path step by step.
            foreach (var tile in path)
            {
                if(tile.Type.Equals(TileTypeEnum.None))
                    tile.Type = TileTypeEnum.Path;
                // Call invalidate to update the screen.
                PbxGrid.Invalidate();
                // Wait for ANT_STEP_TIME_MS before the next step.
                Thread.Sleep(STEP_TIME_MS);
            }
        }
    }
}
