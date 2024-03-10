namespace AStarPoc
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PbxGrid = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NudGridHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NudGridWidth = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CboSelectedTileType = new System.Windows.Forms.ComboBox();
            this.BtnExecuteAStar = new System.Windows.Forms.Button();
            this.BtnResetBoard = new System.Windows.Forms.Button();
            this.TlpMain.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridWidth)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpMain
            // 
            this.TlpMain.ColumnCount = 2;
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.Controls.Add(this.PnlMain, 0, 0);
            this.TlpMain.Controls.Add(this.groupBox1, 0, 1);
            this.TlpMain.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpMain.Location = new System.Drawing.Point(0, 0);
            this.TlpMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TlpMain.Name = "TlpMain";
            this.TlpMain.RowCount = 2;
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpMain.Size = new System.Drawing.Size(1205, 584);
            this.TlpMain.TabIndex = 0;
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Black;
            this.TlpMain.SetColumnSpan(this.PnlMain, 2);
            this.PnlMain.Controls.Add(this.PbxGrid);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(4, 3);
            this.PnlMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1197, 469);
            this.PnlMain.TabIndex = 1;
            // 
            // PbxGrid
            // 
            this.PbxGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbxGrid.BackColor = System.Drawing.Color.Gray;
            this.PbxGrid.Location = new System.Drawing.Point(547, 156);
            this.PbxGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PbxGrid.Name = "PbxGrid";
            this.PbxGrid.Size = new System.Drawing.Size(148, 111);
            this.PbxGrid.TabIndex = 0;
            this.PbxGrid.TabStop = false;
            this.PbxGrid.Click += new System.EventHandler(this.PbxGrid_Click);
            this.PbxGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.PbxGrid_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 478);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 103);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid size:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.NudGridHeight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NudGridWidth, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(148, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NudGridHeight
            // 
            this.NudGridHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudGridHeight.Location = new System.Drawing.Point(77, 53);
            this.NudGridHeight.Name = "NudGridHeight";
            this.NudGridHeight.Size = new System.Drawing.Size(68, 20);
            this.NudGridHeight.TabIndex = 1;
            this.NudGridHeight.ValueChanged += new System.EventHandler(this.NudGridHeight_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // NudGridWidth
            // 
            this.NudGridWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudGridWidth.Location = new System.Drawing.Point(77, 11);
            this.NudGridWidth.Name = "NudGridWidth";
            this.NudGridWidth.Size = new System.Drawing.Size(68, 20);
            this.NudGridWidth.TabIndex = 0;
            this.NudGridWidth.ValueChanged += new System.EventHandler(this.NudGridWidth_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BtnResetBoard, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnExecuteAStar, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(163, 478);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(371, 100);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.CboSelectedTileType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 44);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set beginning/end/obstacle:";
            // 
            // CboSelectedTileType
            // 
            this.CboSelectedTileType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CboSelectedTileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSelectedTileType.FormattingEnabled = true;
            this.CboSelectedTileType.Location = new System.Drawing.Point(3, 16);
            this.CboSelectedTileType.Name = "CboSelectedTileType";
            this.CboSelectedTileType.Size = new System.Drawing.Size(359, 21);
            this.CboSelectedTileType.TabIndex = 0;
            // 
            // BtnExecuteAStar
            // 
            this.BtnExecuteAStar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnExecuteAStar.Location = new System.Drawing.Point(3, 53);
            this.BtnExecuteAStar.Name = "BtnExecuteAStar";
            this.BtnExecuteAStar.Size = new System.Drawing.Size(179, 44);
            this.BtnExecuteAStar.TabIndex = 5;
            this.BtnExecuteAStar.Text = "Find shortest path with A*";
            this.BtnExecuteAStar.UseVisualStyleBackColor = true;
            this.BtnExecuteAStar.Click += new System.EventHandler(this.BtnExecuteAStar_Click);
            // 
            // BtnResetBoard
            // 
            this.BtnResetBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnResetBoard.Location = new System.Drawing.Point(188, 53);
            this.BtnResetBoard.Name = "BtnResetBoard";
            this.BtnResetBoard.Size = new System.Drawing.Size(180, 44);
            this.BtnResetBoard.TabIndex = 6;
            this.BtnResetBoard.Text = "Reset board";
            this.BtnResetBoard.UseVisualStyleBackColor = true;
            this.BtnResetBoard.Click += new System.EventHandler(this.BtnResetBoard_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 584);
            this.Controls.Add(this.TlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A* Shortest Path";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TlpMain.ResumeLayout(false);
            this.PnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudGridWidth)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpMain;
        private System.Windows.Forms.PictureBox PbxGrid;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudGridHeight;
        private System.Windows.Forms.NumericUpDown NudGridWidth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CboSelectedTileType;
        private System.Windows.Forms.Button BtnExecuteAStar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnResetBoard;
    }
}

