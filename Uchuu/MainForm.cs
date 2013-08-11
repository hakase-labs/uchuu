using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Hakase.Uchuu
{
    public partial class MainForm : Form
    {
        private enum ToolType
        {
            SELECTOR,
            MOVER,
            PENCIL,
            FILL
        }

        private TileSet tileData;
        private Map mapData;
        private Tile selectedTile;
        private MapPanel selectedMapPanel;
        private ToolType selectedTool;

        private UndoState currentUndo;
        private Stack<UndoState> undoBuffer;
        private Stack<UndoState> redoBuffer;

        private string currentFilePath;

        private AttributePalette attributePaletteForm;
        private CreateRoomDialog createRoomDialog;

        private MapPanel SelectedMapPanel
        {
            get
            {
                return selectedMapPanel;
            }
            set
            {
                if (selectedMapPanel != null)
                {
                    selectedMapPanel.Selected = false;
                }

                selectedMapPanel = value;

                if (selectedMapPanel != null)
                {
                    selectedMapPanel.Selected = true;
                    selectedMapPanel.Focus();
                    propertyGrid1.SelectedObject = SelectedMapPanel.Room;
                }
            }
        }

        public MainForm()
        {
            currentUndo = null;
            selectedTile = null;
            undoBuffer = new Stack<UndoState>();
            redoBuffer = new Stack<UndoState>();
            selectedTool = ToolType.SELECTOR;

            InitializeComponent();
            UpdateUndoRedoItems();

            attributePaletteForm = new AttributePalette();
            attributePaletteForm.Owner = this;

            createRoomDialog = new CreateRoomDialog();
            createRoomDialog.Owner = this;

            GDIUtils.SetDoubleBuffered(this);

            this.tileSetPanel1.TileSelected += new TileSetPanel.TileSelectedHandler(HandleTileSelection);

            var toolButtons = this.toolStrip.Items;

            foreach (ToolStripItem item in toolButtons)
            {
                item.Click += new EventHandler(HandleToolStripItemClick);
            }

            SetShowAttributes(false);
        }

        private void HandleTileSelection(TileSet tileSet, Tile selectedTile)
        {
            if (selectedTile != null && tileSet != null)
            {
                previewBox.Text = String.Format("Preview ({0})", tileSet.Tiles.IndexOf(selectedTile));
                previewTileControl.TileSet = tileSet;
                previewTileControl.Tile = selectedTile;

                this.selectedTile = selectedTile;
            }
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            var roomPanel = sender as MapPanel;

            if (roomPanel != null)
            {
                var map = roomPanel.Map;
                var room = roomPanel.Room;

                if (room != null)
                {
                    var gridSize = map.GridSize;
                    var offsetX = room.X;
                    var offsetY = room.Y;

                    var localX = e.X / gridSize;
                    var localY = e.Y / gridSize;
                    var worldX = localX + offsetX;
                    var worldY = localY + offsetY;

                    string tilePositionString = "({0}, {1})";

                    localLocationTilesLabel.Text = String.Format(tilePositionString, localX, localY);
                    worldLocationTilesLabel.Text = String.Format(tilePositionString, worldX, worldY);

                    if (roomPanel.Selected)
                    {
                        PerformToolOperation(sender, e);
                    }

                    // Update tile position marker
                    // tileLocationPanel.Location = new Point(worldX * map.GridSize, worldY * map.GridSize);

                    gridPanel.Refresh();
                }
            }
        }

        private void setContentPatghToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentPathBrowseDialog.SelectedPath = Properties.Settings.Default.ContentPath;
            var result = contentPathBrowseDialog.ShowDialog();

            if(result.HasFlag(DialogResult.OK)) {
                var newContentPath = contentPathBrowseDialog.SelectedPath;

                if(!newContentPath.EndsWith("/") || !newContentPath.EndsWith("\\")) {
                    newContentPath = newContentPath + Path.DirectorySeparatorChar;
                }

                Properties.Settings.Default.ContentPath = newContentPath;
                Properties.Settings.Default.Save();

                MessageBox.Show(String.Format("Content path now set to: \"{0}\"", newContentPath));
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.openFileDialog.ShowDialog();

            if (result.HasFlag(DialogResult.OK))
            {
                string mapFilePath = openFileDialog.FileName;

                BeginEditingMap(mapFilePath);
            }
            
        }

        private void BeginEditingMap(string mapFilePath)
        {
            Map map = LoadMapFromFile(mapFilePath);

            TileSet tileSet = LoadTileSetFromFile(map.TileSet);

            this.mapData = map;
            this.tileData = tileSet;
            this.selectedTile = null; // TODO: Set this to the first tile?
            tileSetPanel1.TileSet = tileSet;

            var panels = GeneratePanelsForMap(map);

            if (panels != null)
            {
                this.gridPanel.Controls.Clear();

                foreach (MapPanel panel in panels)
                {
                    panel.Map = this.mapData;
                    panel.Tiles = this.tileData;
                    this.gridPanel.Controls.Add(panel);
                }

                // this.gridPanel.Controls.Add(tileLocationPanel);
            }

            if (panels.Count > 0)
            {
                SelectedMapPanel = panels[0];
            }

            undoBuffer.Clear();
            redoBuffer.Clear();
        }

        Map LoadMapFromFile(string fileName)
        {
            Map loadedMap = null;

            try
            {
                fileName = ContentUtils.ResolveContentPath(fileName);

                using (StreamReader sr = new StreamReader(fileName))
                {
                    string mapFileContents = sr.ReadToEnd();
                    loadedMap = JsonConvert.DeserializeObject<Map>(mapFileContents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return loadedMap;
        }

        TileSet LoadTileSetFromFile(string fileName)
        {
            TileSet loadedTileSet = null;

            try
            {
                fileName = ContentUtils.ResolveContentPath(fileName);

                using (StreamReader sr = new StreamReader(fileName))
                {
                    string tileSetFileContents = sr.ReadToEnd();
                    loadedTileSet = JsonConvert.DeserializeObject<TileSet>(tileSetFileContents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return loadedTileSet;
        }

        private IList<MapPanel> GeneratePanelsForMap(Map map)
        {
            if (map == null)
            {
                return null;
            }

            List<MapPanel> panels = new List<MapPanel>(map.Rooms.Count);

            int index = 0;
            foreach(Room room in map.Rooms) {
                var panel = GenerateMapPanelForRoom(map, room);
                panel.TabIndex = index;
                panels.Add(panel);
                index++;
            }

            return panels;
        }

        private MapPanel GenerateMapPanelForRoom(Map map, Room room)
        {
            MapPanel panel = new MapPanel();

            panel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            panel.BackColor = System.Drawing.SystemColors.ControlDark;
            panel.Font = new System.Drawing.Font("Consolas", 8F);
            panel.Location = new System.Drawing.Point(room.X * map.GridSize, room.Y * map.GridSize);
            panel.Margin = new System.Windows.Forms.Padding(0);
            panel.Size = new System.Drawing.Size(room.Width * map.GridSize, room.Height * map.GridSize);
            panel.MouseDown += new MouseEventHandler(panel_MouseDown);
            panel.MouseUp += new MouseEventHandler(panel_MouseUp);
            panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseMove);
            panel.MouseClick += new MouseEventHandler(HandleMapPanelClick);
            panel.MouseEnter += new EventHandler(mapPanel_MouseEnter);
            panel.MouseLeave += new EventHandler(mapPanel_MouseLeave);
            panel.KeyDown += new KeyEventHandler(HandleKeyDownForMapPanel);

            panel.Map = map;
            panel.Tiles = null;
            panel.Room = room;

            return panel;
        }

        void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedTool == ToolType.PENCIL)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    StartUndo();
                    // Forward this to get the actual editing done
                    mapPanel_MouseMove(sender, e);
                }
            }
        }

        void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedTool == ToolType.PENCIL)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    CommitUndo();
                }
            }

            UpdateUndoRedoItems();
        }

        void HandleMapPanelClick(object sender, MouseEventArgs e)
        {
            var mapPanel = sender as MapPanel;

            if (mapPanel != null)
            {
                SelectedMapPanel = mapPanel;
                SelectedMapPanel.Focus();
                SelectedMapPanel.BringToFront();
                PerformToolOperation(sender, e);
            }
        }

        private void PerformToolOperation(object sender, MouseEventArgs e)
        {
            //
            // Tool-level activity
            //
            switch (selectedTool)
            {
                case ToolType.PENCIL:
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (SelectedMapPanel != null)
                        {
                            if (this.selectedTile != null && this.tileData != null)
                            {
                                int x = e.X / this.mapData.GridSize;
                                int y = e.Y / this.mapData.GridSize;
                                var room = selectedMapPanel.Room;

                                if (x < 0 || x >= room.Width || y < 0 || y >= room.Height)
                                {
                                    return;
                                }

                                var linearTileOffset = (y * room.Width) + x;

                                // Editing attributes
                                if (attributesToolStripMenuItem.Checked)
                                {
                                    
                                    var attrs = room.TileAttrbutes;
                                    var oldAttrValue = attrs[linearTileOffset];
                                    var newAttrValue = attributePaletteForm.TileAttribute;

                                    // Only apply change if value is different
                                    if (oldAttrValue != newAttrValue)
                                    {
                                        attrs[linearTileOffset] = newAttrValue;

                                        AddTileUndo(x, y, (int)oldAttrValue, (int)newAttrValue, TileChange.Type.Attribute, room);
                                        selectedMapPanel.RedrawTileAtIndex(x, y);
                                        selectedMapPanel.Invalidate();
                                    }
                                }
                                // Editing tile indicies
                                else
                                {
                                    var tile = tileData.Tiles.IndexOf(selectedTile);
                                    var tiles = room.TileIndicies;
                                    var oldTileValue = tiles[linearTileOffset];

                                    // Only apply change if value is different
                                    if (oldTileValue != tile)
                                    {
                                        tiles[linearTileOffset] = tile;

                                        AddTileUndo(x, y, oldTileValue, tile, TileChange.Type.Tile, room);
                                        selectedMapPanel.RedrawTileAtIndex(x, y);
                                        selectedMapPanel.Invalidate();
                                    }
                                }
                            }
                        }
                    }
                    break;

                case ToolType.FILL:
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (SelectedMapPanel != null)
                        {
                            if (this.selectedTile != null && this.tileData != null)
                            {
                                int x = e.X / this.mapData.GridSize;
                                int y = e.Y / this.mapData.GridSize;
                                var room = selectedMapPanel.Room;

                                if (x < 0 || x >= room.Width || y < 0 || y >= room.Height)
                                {
                                    return;
                                }

                                var linearTileOffset = (y * room.Width) + x;

                                // Editing attributes
                                if (attributesToolStripMenuItem.Checked)
                                {
                                }
                                // Editing tile indicies
                                else
                                {
                                    var tile = tileData.Tiles.IndexOf(selectedTile);
                                    var tiles = room.TileIndicies;
                                    var oldTileValue = tiles[linearTileOffset];

                                    StartUndo();
                                    PerformFloodFill(room, x, y, oldTileValue, tile);

                                    foreach (TileChange change in currentUndo.Changes)
                                    {
                                        selectedMapPanel.RedrawTileAtIndex(change.X, change.Y);
                                    }
                                    selectedMapPanel.Invalidate();

                                    CommitUndo();
                                }
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void PerformFloodFill(Room room, int x, int y, int fromValue, int toValue)
        {
            if (x < 0 || x >= room.Width || y < 0 || y >= room.Height)
            {
                return;
            }

            var linearTileOffset = (y * room.Width) + x;
            var tiles = room.TileIndicies;
            var oldTileValue = tiles[linearTileOffset];

            if (oldTileValue == fromValue && oldTileValue != toValue)
            {
                tiles[linearTileOffset] = toValue;

                AddTileUndo(x, y, oldTileValue, toValue, TileChange.Type.Tile, room);

                // Top
                PerformFloodFill(room, x, y - 1, fromValue, toValue);
                // Right
                PerformFloodFill(room, x + 1, y, fromValue, toValue);
                // Bottom
                PerformFloodFill(room, x, y + 1, fromValue, toValue);
                // Left
                PerformFloodFill(room, x - 1, y, fromValue, toValue);
            }
        }

        void HandleKeyDownForMapPanel(object sender, KeyEventArgs e)
        {
            var gridSize = mapData.GridSize;

            if (SelectedMapPanel != null)
            {
                switch (selectedTool)
                {
                    case ToolType.MOVER:
                        if (e.KeyCode == Keys.Up)
                        {
                            SelectedMapPanel.Location = new Point(SelectedMapPanel.Location.X, SelectedMapPanel.Location.Y - gridSize);
                        }
                        else if (e.KeyCode == Keys.Right)
                        {
                            SelectedMapPanel.Location = new Point(SelectedMapPanel.Location.X + gridSize, SelectedMapPanel.Location.Y);
                        }
                        else if (e.KeyCode == Keys.Down)
                        {
                            SelectedMapPanel.Location = new Point(SelectedMapPanel.Location.X, SelectedMapPanel.Location.Y + gridSize);
                        }
                        else if (e.KeyCode == Keys.Left)
                        {
                            SelectedMapPanel.Location = new Point(SelectedMapPanel.Location.X - gridSize, SelectedMapPanel.Location.Y);
                        }

                        break;

                    default:
                        break;
                }

                // TODO: Can this be done in a cleaner way?
                propertyGrid1.SelectedObject = SelectedMapPanel.Room;
            }
        }

        private void mapPanel_MouseEnter(object sender, EventArgs e)
        {
            MapPanel panel = sender as MapPanel;

            if (panel != null)
            {
                //panel.Selected = true;
                //propertyGrid1.SelectedObject = panel.Room;

                //tileLocationPanel.Visible = true;
                //tileLocationPanel.BringToFront();
            }
        }

        private void mapPanel_MouseLeave(object sender, EventArgs e)
        {
            MapPanel panel = sender as MapPanel;

            if (panel != null)
            {
                //panel.Selected = false;

                //tileLocationPanel.Visible = false;
            }
        }

        void HandleToolStripItemClick(object sender, EventArgs e)
        {
            EmulateButtonGroupBehavior(sender as ToolStripButton);
        }

        private void HandleToolSelection(string toolName)
        {
            if (toolName != null)
            {
                if (toolName == "selector")
                {
                    selectedTool = ToolType.SELECTOR;
                }
                else if (toolName == "mover")
                {
                    selectedTool = ToolType.MOVER;
                }
                else if (toolName == "fill")
                {
                    selectedTool = ToolType.FILL;
                }
                else if (toolName == "pencil")
                {
                    selectedTool = ToolType.PENCIL;
                }
            }
        }

        private void EmulateButtonGroupBehavior(ToolStripButton button)
        {
            if (button != null)
            {
                foreach (ToolStripButton item in button.GetCurrentParent().Items)
                {
                    if (item == button)
                    {
                        item.Checked = true;
                    }
                    if ((item != null) && (item != button))
                    {
                        item.Checked = false;
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog();

            if (result.HasFlag(DialogResult.OK))
            {
                var selectedFilePath = saveFileDialog.FileName;
                var serializedMapData = JsonConvert.SerializeObject(this.mapData, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(selectedFilePath))
                {
                    sw.Write(serializedMapData);
                }
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // EmulateButtonGroupBehavior(sender as ToolStripButton);
            HandleToolSelection(e.ClickedItem.Tag as string);
        }

        #region Undo/Redo State Management
        //
        // Undo / Redo State Management
        //
        private void UpdateUndoRedoItems()
        {
            undoMenuItem.Enabled = undoBuffer.Count > 0;
            redoMenuItem.Enabled = redoBuffer.Count > 0;
        }

        private void Undo()
        {
            if (undoBuffer.Count > 0)
            {
                UndoState undo = undoBuffer.Pop();
                ApplyUndo(undo, false);
                redoBuffer.Push(undo);
                selectedMapPanel.Refresh();
            }
        }

        private void Redo()
        {
            if (redoBuffer.Count > 0)
            {
                UndoState redo = redoBuffer.Pop();
                ApplyUndo(redo, true);
                undoBuffer.Push(redo);
                selectedMapPanel.Refresh();
            }
        }

        private void StartUndo()
        {
            redoBuffer.Clear();
            currentUndo = new UndoState();
        }

        private void AddTileUndo(int x, int y, int from, int to, TileChange.Type nature, Room room)
        {
            currentUndo.Changes.Push(new TileChange(x, y, to, from, nature, room));
        }

        private void CommitUndo()
        {
            if (currentUndo != null)
            {
                undoBuffer.Push(currentUndo);
            }
        }

        private void ApplyUndo(UndoState state, bool redo)
        {
            MapPanel mapPanel = null;

            foreach (TileChange change in state.Changes)
            {
                int x = change.X;
                int y = change.Y;
                int changeValue = redo ? change.ToIndex : change.FromIndex;

                var room = change.Room;
                
                if (x < 0 || x >= room.Width || y < 0 || y >= room.Height)
                {
                    continue;
                }

                var linearTileOffset = (y * room.Width) + x;
                var tiles = room.TileIndicies;
                var attrs = room.TileAttrbutes;

                if (change.Nature == TileChange.Type.Tile)
                {
                    tiles[linearTileOffset] = changeValue;
                }
                else if (change.Nature == TileChange.Type.Attribute)
                {
                    attrs[linearTileOffset] = (Tile.Attribute)changeValue;
                }

                foreach (Control control in this.gridPanel.Controls)
                {
                    mapPanel = control as MapPanel;

                    if (mapPanel != null)
                    {
                        // Find the panel that hold the room we edited...
                        if (mapPanel.Room == room)
                        {
                            mapPanel.RedrawTileAtIndex(x, y);
                            break;
                        }
                    }
                }
            }

            if (mapPanel != null)
            {
                mapPanel.Invalidate();
            }
        }

        #endregion

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
            UpdateUndoRedoItems();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
            UpdateUndoRedoItems();
        }

        private void attributesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if(item != null) {
                SetShowAttributes(item.Checked);
            }
        }

        private void SetShowAttributes(bool showAttributes)
        {
            var mapPanelControls = this.gridPanel.Controls;

            foreach (Control control in mapPanelControls)
            {
                var mapPanelControl = control as MapPanel;

                if (mapPanelControl != null)
                {
                    mapPanelControl.ShowAttributes = showAttributes;
                    mapPanelControl.Refresh();
                }
            }

            if (showAttributes)
            {
                attributePaletteForm.Show();
            }
            else
            {
                attributePaletteForm.Hide();
            }
        }

        private void SetShowCameraBounds(bool showCameraBounds)
        {
            var mapPanelControls = this.gridPanel.Controls;

            foreach (Control control in mapPanelControls)
            {
                var mapPanelControl = control as MapPanel;

                if (mapPanelControl != null)
                {
                    mapPanelControl.ShowCameraBounds = showCameraBounds;
                    mapPanelControl.Refresh();
                }
            }
        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = createRoomDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var newRoom = createRoomDialog.Room;

                if (newRoom != null)
                {
                    if (mapData != null)
                    {
                        mapData.Rooms.Add(newRoom);

                        var newPanel = GenerateMapPanelForRoom(mapData, newRoom);
                        newPanel.Map = mapData;
                        newPanel.Tiles = tileData;

                        this.gridPanel.Controls.Add(newPanel);
                    }
                }
            }
        }

        private void cameraBoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item != null)
            {
                SetShowCameraBounds(item.Checked);
            }
        }
    }

    
}
