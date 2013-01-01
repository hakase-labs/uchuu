using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hakase.Uchuu
{
    public partial class TileSetPanel : UserControl
    {
        private TileSet tileSet;
        private Tile selectedTile;

        public delegate void TileSelectedHandler(TileSet tileSet, Tile tile);

        public TileSelectedHandler TileSelected;

        public TileSetPanel()
        {
            InitializeComponent();
            GDIUtils.SetDoubleBuffered(this);
            
            this.Layout += new LayoutEventHandler(TileSetPanel_Layout);
        }

        void TileSetPanel_Layout(object sender, LayoutEventArgs e)
        {
            RecalculateComponentGrid();
        }

        public TileSet TileSet
        {
            get
            {
                return tileSet;
            }
            set
            {
                var previousTileSet = tileSet;

                tileSet = value;

                if (previousTileSet != tileSet)
                {
                    this.Controls.Clear();
                    var controls = GenerateTileControls();

                    foreach (TileControl control in controls)
                    {
                        control.Click += new EventHandler(HandleTileControlClick);
                        this.Controls.Add(control);
                    }

                    if (TileSet != null && TileSet.Tiles.Count > 0)
                    {
                        controls[0].Selected = true;
                        SelectedTile = TileSet.Tiles[0];
                    }
                }
            }
        }

        public Tile SelectedTile
        {
            get
            {
                return selectedTile;
            }
            set
            {
                selectedTile = value;

                if (TileSet != null && SelectedTile != null)
                {
                    TileSelected(TileSet, SelectedTile);
                }
            }
        }

        void HandleTileControlClick(object sender, EventArgs e)
        {
            var tileControl = sender as TileControl;

            if (tileControl != null)
            {
                SelectedTile = tileControl.Tile;
            }
        }

        private IList<TileControl> GenerateTileControls()
        {
            var controls = new List<TileControl>();

            if (TileSet != null)
            {
                if (TileSet.SurfaceBitmap != null)
                {
                    foreach (Tile tile in TileSet.Tiles)
                    {
                        var tileControl = new TileControl();
                        tileControl.TileSet = TileSet;
                        tileControl.Tile = tile;

                        controls.Add(tileControl);
                    }
                }
            }

            return controls;
        }

        private void RecalculateComponentGrid()
        {
            if (TileSet != null)
            {
                int gridSize = TileSet.TileSize;
                int cx = ClientRectangle.Width / gridSize;
                int cy = ClientRectangle.Height / gridSize;
                var controls = Controls;
                bool keepGoing = true;

                for (int row = 0; keepGoing && row < cy; ++row)
                {
                    for (int col = 0; col < cx; ++col)
                    {
                        var controlIndex = row * cx + col;

                        if (controlIndex >= controls.Count)
                        {
                            keepGoing = false;
                            break;
                        }

                        var control = controls[controlIndex];

                        control.SetBounds(gridSize * col, gridSize * row, gridSize, gridSize);
                    }
                }
            }
        }
    }
}
