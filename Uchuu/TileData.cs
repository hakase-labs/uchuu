using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hakase.Uchuu
{
    public class TileData
    {
        private Size size;
        private List<Rectangle> tiles;
        private string imagePath;

        public TileData(Size size, List<Rectangle> tiles, string imagePath)
        {
            this.size = size;
            this.tiles = tiles;
            this.imagePath = imagePath;
        }

        public Size Size
        {
            get
            {
                return size;
            }
        }

        public Rectangle GetTile(int index)
        {
            return tiles[index];
        }

        public string GetImagePath()
        {
            return imagePath;
        }
    }
}
