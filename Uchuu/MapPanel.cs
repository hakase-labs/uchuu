using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hakase.Uchuu
{
    public partial class MapPanel : UserControl
    {
        private Map mapData;
        private Room room;
        private TileSet tileData;
        private Bitmap tileSetBitmap;
        private Bitmap renderedTileMap;
        private Bitmap renderedAttributeMap;
        private Bitmap grayscaleRenderedMap;
        private bool isGridEnabled;
        private bool selected;

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public MapPanel()
        {
            InitializeComponent();
            GDIUtils.SetDoubleBuffered(this);
            tileSetBitmap = null;
            room = null;
            Selected = false;
            ShowAttributes = false;

            this.LocationChanged += new EventHandler(HandleControlLocationChanged);
        }

        void HandleControlLocationChanged(object sender, EventArgs e)
        {
            if (mapData != null)
            {
                int newRoomX = Location.X / mapData.GridSize;
                int newRoomY = Location.Y / mapData.GridSize;

                bool mustReposition = false;

                if (Math.Abs(Location.X % mapData.GridSize) != 0)
                {
                    mustReposition = true;
                }

                if (Math.Abs(Location.Y % mapData.GridSize) != 0)
                {
                    mustReposition = true;
                }

                if (mustReposition)
                {
                    //Location = new Point(newRoomX * mapData.GridSize, newRoomY * mapData.GridSize);
                }

                if (Room != null)
                {
                    Room.X = newRoomX;
                    Room.Y = newRoomY;
                }
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

        public bool IsGridEnabled
        {
            get { return isGridEnabled; }
            set
            {
                isGridEnabled = value;
                RenderMapToBitmap();
            }
        }

        public bool ShowAttributes
        {
            get;
            set;
        }

        public Map Map
        {
            get
            {
                return mapData;
            }
            set
            {
                mapData = value;
                RenderMapToBitmap();
                this.Invalidate();
            }
        }

        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;

                if (Map != null)
                {
                    Size = new Size(Room.Width * Map.GridSize, Room.Height * Map.GridSize);
                    Location = new Point(Room.X * Map.GridSize, Room.Y * Map.GridSize);
                }

                RenderMapToBitmap();
                this.Invalidate();
            }
        }

        public TileSet Tiles
        {
            get { 
                return tileData; 
            }
            set { 
                tileData = value;
                
                if (tileData != null)
                {
                    tileSetBitmap = tileData.SurfaceBitmap;
                    RenderMapToBitmap();
                }

                this.Invalidate();
            }
        }

        public void RedrawTileAtIndex(int x, int y)
        {
            if (Room != null && tileData != null)
            {
                if (x >= 0 && x < Room.Width && y >= 0 && y < Room.Height)
                {
                    var tilesetIndex = Room.TileIndicies[(y * Room.Width) + x];
                    var attributeIndex = Room.TileAttrbutes[(y * Room.Width) + x];

                    using (Graphics g = Graphics.FromImage(this.renderedTileMap))
                    {
                        DrawTile(x, y, tilesetIndex, g);
                    }

                    using (Graphics g2 = Graphics.FromImage(this.renderedAttributeMap))
                    {
                        DrawAttribute(x, y, attributeIndex, g2);
                    }
                }
            }
        }

        private void RenderMapToBitmap()
        {
            if (this.Map != null && this.room != null && this.tileData != null)
            {
                this.renderedTileMap = new Bitmap(Map.GridSize * Room.Width, Map.GridSize * Room.Height);
                this.renderedAttributeMap = new Bitmap(Map.GridSize * Room.Width, Map.GridSize * Room.Height);

                if (this.Tiles != null)
                {
                    using (Graphics mapGraphics = Graphics.FromImage(this.renderedTileMap))
                    {
                        using (Graphics attributeGraphics = Graphics.FromImage(this.renderedAttributeMap))
                        {
                            int tileWidth = tileData.TileSize;
                            int tileHeight = tileData.TileSize;

                            // TODO: Apply tile culling later
                            if (tileSetBitmap != null && tileData != null)
                            {
                                DrawMap(mapGraphics, attributeGraphics);
                            }

                            this.grayscaleRenderedMap = BitmapUtils.MakeGrayscale3(this.renderedTileMap);
                        }
                    }
                }

                if (this.Room.TileAttrbutes != null)
                {

                }
            }
        }

        private void DrawTile(int x, int y, int tileIndex, Graphics mapGraphics)
        {
            var tileInstance = tileData.Tiles[tileIndex];

            if (tileIndex < tileData.Tiles.Count)
            {
                Rectangle sourceRect = new Rectangle();
                sourceRect.X = tileInstance.X;
                sourceRect.Y = tileInstance.Y;
                sourceRect.Width = mapData.GridSize;
                sourceRect.Height = mapData.GridSize;

                Rectangle destRect = new Rectangle();
                destRect.X = x * mapData.GridSize;
                destRect.Y = y * mapData.GridSize;
                destRect.Width = mapData.GridSize;
                destRect.Height = mapData.GridSize;

                var oldClip = mapGraphics.Clip;
                mapGraphics.Clip = new System.Drawing.Region(destRect);
                mapGraphics.Clear(Color.Transparent);
                mapGraphics.Clip = oldClip;
                mapGraphics.DrawImage(tileSetBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
            }
        }

        private void DrawAttribute(int x, int y, Tile.Attribute tileAttribute, Graphics attributeGraphics)
        {
            Bitmap attributeImage = Properties.Resources.attributes;
            Color color = Color.FromArgb(64, 255, 255, 255);

            Rectangle destRect = new Rectangle();
            destRect.X = x * mapData.GridSize;
            destRect.Y = y * mapData.GridSize;
            destRect.Width = mapData.GridSize;
            destRect.Height = mapData.GridSize;

            var oldClip = attributeGraphics.Clip;
            attributeGraphics.Clip = new System.Drawing.Region(destRect);
            attributeGraphics.Clear(Color.Transparent);
            attributeGraphics.Clip = oldClip;

            if (tileAttribute != Tile.Attribute.Nothing)
            {
                attributeGraphics.FillRectangle(new SolidBrush(color), destRect);

                if (tileAttribute.HasFlag(Tile.Attribute.Solid))
                {
                    attributeGraphics.DrawImage(attributeImage, destRect, new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);
                }

                if (tileAttribute.HasFlag(Tile.Attribute.Spikes))
                {
                    // attributeGraphics.FillRectangle(new SolidBrush(Color.FromArgb(64, 0, 255, 0)), destRect);
                    attributeGraphics.DrawImage(attributeImage, destRect, new Rectangle(16, 0, 16, 16), GraphicsUnit.Pixel);
                }

                if (tileAttribute.HasFlag(Tile.Attribute.Ladder))
                {
                    // attributeGraphics.FillRectangle(new SolidBrush(Color.FromArgb(64, 255, 255, 0)), destRect);
                    attributeGraphics.DrawImage(attributeImage, destRect, new Rectangle(32, 0, 16, 16), GraphicsUnit.Pixel);
                }

                if (tileAttribute.HasFlag(Tile.Attribute.LadderTop))
                {
                    // attributeGraphics.FillRectangle(new SolidBrush(Color.FromArgb(64, 0, 255, 0)), destRect);
                    attributeGraphics.DrawImage(attributeImage, destRect, new Rectangle(48, 0, 16, 16), GraphicsUnit.Pixel);
                }
            }
        }

        private void DrawMap(Graphics mapGraphics, Graphics attributeGraphics)
        {
            using (var pen = new Pen(Color.FromArgb(64, Color.White), 1.0f))
            {
                for (int x = 0; x < Room.Width; x++)
                {
                    for (int y = 0; y < Room.Height; y++)
                    {
                        int tileIndexOffset = y * Room.Width + x;
                        int tileIndex = room.TileIndicies[tileIndexOffset];
                        var tileAttribute = room.TileAttrbutes[tileIndexOffset];

                        DrawTile(x, y, tileIndex, mapGraphics);
                        DrawAttribute(x, y, tileAttribute, attributeGraphics);

                        if (IsGridEnabled)
                        {
                            // Draw tile bounds
                            mapGraphics.DrawRectangle(
                                pen,
                                x * mapData.GridSize,
                                y * mapData.GridSize,
                                mapData.GridSize,
                                mapData.GridSize
                            );
                        }
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.renderedTileMap != null)
            {
                Graphics g = e.Graphics;
                {
                    g.DrawImage(this.renderedTileMap, new Point(0, 0));

                    if (ShowAttributes)
                    {
                        g.DrawImage(this.renderedAttributeMap, new Point(0, 0));
                    }
                }
                
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Right || keyData == Keys.Down || keyData == Keys.Left)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }
    }
}
