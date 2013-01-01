namespace Hakase.Uchuu
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setContentPatghToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.previewBox = new System.Windows.Forms.GroupBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.scrollingWorkspacePanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.localLocationTilesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.worldLocationTilesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contentPathBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.moveButton = new System.Windows.Forms.ToolStripButton();
            this.pencilButton = new System.Windows.Forms.ToolStripButton();
            this.fillButton = new System.Windows.Forms.ToolStripButton();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.tileLocationPanel = new System.Windows.Forms.Panel();
            this.previewTileControl = new Hakase.Uchuu.TileControl();
            this.tileSetPanel1 = new Hakase.Uchuu.TileSetPanel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.previewBox.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.scrollingWorkspacePanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.gridPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1115, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setContentPatghToolStripMenuItem,
            this.undoMenuItem,
            this.redoMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // setContentPatghToolStripMenuItem
            // 
            this.setContentPatghToolStripMenuItem.Name = "setContentPatghToolStripMenuItem";
            this.setContentPatghToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.setContentPatghToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.setContentPatghToolStripMenuItem.Text = "Set content path...";
            this.setContentPatghToolStripMenuItem.Click += new System.EventHandler(this.setContentPatghToolStripMenuItem_Click);
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoMenuItem.Size = new System.Drawing.Size(242, 22);
            this.undoMenuItem.Text = "Undo";
            this.undoMenuItem.Click += new System.EventHandler(this.undoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoMenuItem.Size = new System.Drawing.Size(242, 22);
            this.redoMenuItem.Text = "Redo";
            this.redoMenuItem.Click += new System.EventHandler(this.redoMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attributesToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // attributesToolStripMenuItem
            // 
            this.attributesToolStripMenuItem.CheckOnClick = true;
            this.attributesToolStripMenuItem.Name = "attributesToolStripMenuItem";
            this.attributesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.attributesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.attributesToolStripMenuItem.Text = "Attributes";
            this.attributesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.attributesToolStripMenuItem_CheckedChanged);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRoomToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // addRoomToolStripMenuItem
            // 
            this.addRoomToolStripMenuItem.Name = "addRoomToolStripMenuItem";
            this.addRoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.addRoomToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addRoomToolStripMenuItem.Text = "Add room...";
            this.addRoomToolStripMenuItem.Click += new System.EventHandler(this.addRoomToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(9, 27);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.previewBox);
            this.splitContainer.Panel1.Controls.Add(this.tileSetPanel1);
            this.splitContainer.Panel1MinSize = 64;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.AutoScrollMinSize = new System.Drawing.Size(16, 16);
            this.splitContainer.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer.Panel2.Controls.Add(this.scrollingWorkspacePanel);
            this.splitContainer.Panel2MinSize = 256;
            this.splitContainer.Size = new System.Drawing.Size(918, 538);
            this.splitContainer.SplitterDistance = 180;
            this.splitContainer.SplitterIncrement = 16;
            this.splitContainer.SplitterWidth = 16;
            this.splitContainer.TabIndex = 1;
            // 
            // previewBox
            // 
            this.previewBox.Controls.Add(this.previewTileControl);
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.previewBox.Location = new System.Drawing.Point(0, 432);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(180, 106);
            this.previewBox.TabIndex = 1;
            this.previewBox.TabStop = false;
            this.previewBox.Text = "Preview";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectButton,
            this.moveButton,
            this.pencilButton,
            this.fillButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(722, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // scrollingWorkspacePanel
            // 
            this.scrollingWorkspacePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollingWorkspacePanel.AutoScroll = true;
            this.scrollingWorkspacePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrollingWorkspacePanel.Controls.Add(this.gridPanel);
            this.scrollingWorkspacePanel.Location = new System.Drawing.Point(0, 28);
            this.scrollingWorkspacePanel.Margin = new System.Windows.Forms.Padding(0);
            this.scrollingWorkspacePanel.Name = "scrollingWorkspacePanel";
            this.scrollingWorkspacePanel.Size = new System.Drawing.Size(704, 507);
            this.scrollingWorkspacePanel.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLocationTilesLabel,
            this.worldLocationTilesLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1115, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // localLocationTilesLabel
            // 
            this.localLocationTilesLabel.AutoSize = false;
            this.localLocationTilesLabel.BackColor = System.Drawing.SystemColors.Control;
            this.localLocationTilesLabel.Name = "localLocationTilesLabel";
            this.localLocationTilesLabel.Size = new System.Drawing.Size(100, 17);
            this.localLocationTilesLabel.Text = "Local";
            this.localLocationTilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.localLocationTilesLabel.ToolTipText = "Room Location (Tiles)";
            // 
            // worldLocationTilesLabel
            // 
            this.worldLocationTilesLabel.AutoSize = false;
            this.worldLocationTilesLabel.Name = "worldLocationTilesLabel";
            this.worldLocationTilesLabel.Size = new System.Drawing.Size(100, 17);
            this.worldLocationTilesLabel.Text = "World";
            this.worldLocationTilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.worldLocationTilesLabel.ToolTipText = "World Location (Tiles)";
            // 
            // contentPathBrowseDialog
            // 
            this.contentPathBrowseDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.contentPathBrowseDialog.ShowNewFolderButton = false;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(930, 27);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(173, 535);
            this.propertyGrid1.TabIndex = 3;
            // 
            // selectButton
            // 
            this.selectButton.CheckOnClick = true;
            this.selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(42, 22);
            this.selectButton.Tag = "selector";
            this.selectButton.Text = "Select";
            // 
            // moveButton
            // 
            this.moveButton.CheckOnClick = true;
            this.moveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.moveButton.Image = ((System.Drawing.Image)(resources.GetObject("moveButton.Image")));
            this.moveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(41, 22);
            this.moveButton.Tag = "mover";
            this.moveButton.Text = "Move";
            // 
            // pencilButton
            // 
            this.pencilButton.CheckOnClick = true;
            this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(43, 22);
            this.pencilButton.Tag = "pencil";
            this.pencilButton.Text = "Pencil";
            // 
            // fillButton
            // 
            this.fillButton.CheckOnClick = true;
            this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
            this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(26, 22);
            this.fillButton.Tag = "fill";
            this.fillButton.Text = "Fill";
            // 
            // gridPanel
            // 
            this.gridPanel.AutoSize = true;
            this.gridPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridPanel.Controls.Add(this.tileLocationPanel);
            this.gridPanel.Location = new System.Drawing.Point(0, 0);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(685, 489);
            this.gridPanel.TabIndex = 2;
            // 
            // tileLocationPanel
            // 
            this.tileLocationPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tileLocationPanel.Location = new System.Drawing.Point(3, 3);
            this.tileLocationPanel.Name = "tileLocationPanel";
            this.tileLocationPanel.Size = new System.Drawing.Size(16, 16);
            this.tileLocationPanel.TabIndex = 4;
            this.tileLocationPanel.Visible = false;
            // 
            // previewTileControl
            // 
            this.previewTileControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewTileControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.previewTileControl.Location = new System.Drawing.Point(64, 21);
            this.previewTileControl.Margin = new System.Windows.Forms.Padding(0);
            this.previewTileControl.MaximumSize = new System.Drawing.Size(64, 64);
            this.previewTileControl.MinimumSize = new System.Drawing.Size(64, 64);
            this.previewTileControl.Name = "previewTileControl";
            this.previewTileControl.Selected = false;
            this.previewTileControl.Size = new System.Drawing.Size(64, 64);
            this.previewTileControl.TabIndex = 0;
            this.previewTileControl.Tile = null;
            this.previewTileControl.TileSet = null;
            // 
            // tileSetPanel1
            // 
            this.tileSetPanel1.AutoSize = true;
            this.tileSetPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tileSetPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tileSetPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSetPanel1.Location = new System.Drawing.Point(0, 0);
            this.tileSetPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tileSetPanel1.MinimumSize = new System.Drawing.Size(64, 64);
            this.tileSetPanel1.Name = "tileSetPanel1";
            this.tileSetPanel1.SelectedTile = null;
            this.tileSetPanel1.Size = new System.Drawing.Size(180, 538);
            this.tileSetPanel1.TabIndex = 0;
            this.tileSetPanel1.TileSet = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 587);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Uchuu";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.previewBox.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.scrollingWorkspacePanel.ResumeLayout(false);
            this.scrollingWorkspacePanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel localLocationTilesLabel;
        private System.Windows.Forms.ToolStripMenuItem setContentPatghToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog contentPathBrowseDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.ToolStripStatusLabel worldLocationTilesLabel;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private TileSetPanel tileSetPanel1;
        private System.Windows.Forms.GroupBox previewBox;
        private TileControl previewTileControl;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem;
        private System.Windows.Forms.Panel tileLocationPanel;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRoomToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton selectButton;
        private System.Windows.Forms.ToolStripButton moveButton;
        private System.Windows.Forms.ToolStripButton pencilButton;
        private System.Windows.Forms.ToolStripButton fillButton;
        private System.Windows.Forms.Panel scrollingWorkspacePanel;
    }
}

