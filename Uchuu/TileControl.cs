using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hakase.Uchuu
{
    public partial class TileControl : UserControl
    {
        private TileSet tileSet;
        private Tile tile;
        private Bitmap renderedTile;
        private bool selected;

        public TileSet TileSet
        {
            get
            {
                return tileSet;
            }
            set
            {
                tileSet = value;
                RenderTileToBitmap();
                // this.Size = new Size(TileSet.TileSize, TileSet.TileSize);
            }
        }

        public Tile Tile
        {
            get
            {
                return tile;
            }
            set
            {
                tile = value;
                RenderTileToBitmap();
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                this.Invalidate();
            }
        }

        public TileControl()
        {
            InitializeComponent();
            GDIUtils.SetDoubleBuffered(this);
            renderedTile = null;

            this.MouseEnter += new EventHandler(HandleMouseEnter);
            this.MouseLeave += new EventHandler(HandleMouseLeave);
        }

        void HandleMouseEnter(object sender, EventArgs e)
        {
            Selected = true;
        }

        void HandleMouseLeave(object sender, EventArgs e)
        {
            Selected = false;
        }

        private void RenderTileToBitmap()
        {
            if (TileSet != null && Tile != null)
            {
                renderedTile = new Bitmap(ClientSize.Width, ClientSize.Height);

                using (Graphics g = Graphics.FromImage(renderedTile))
                {
                    if (TileSet.SurfaceBitmap != null)
                    {
                        Rectangle sourceRect = new Rectangle();
                        sourceRect.X = Tile.X;
                        sourceRect.Y = Tile.Y;
                        sourceRect.Width = TileSet.TileSize;
                        sourceRect.Height = TileSet.TileSize;

                        Rectangle destRect = new Rectangle();
                        destRect.X = 0;
                        destRect.Y = 0;
                        destRect.Width = ClientSize.Width;
                        destRect.Height = ClientSize.Height;

                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        g.DrawImage(TileSet.SurfaceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (renderedTile != null)
            {
                Graphics g = e.Graphics;
                {
                    g.DrawImage(renderedTile, 0, 0);

                    if (Selected)
                    {
                        using (var pen = new Pen(Color.FromArgb(128, Color.White), 1.0f))
                        {
                            if(TileSet != null) {
                                g.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
