using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hakase.Uchuu
{
    public class MapRegion
    {
        // List<int> tile;
        // List<int> attr;
        int[,] tile;
        int[,] attr;
        Size size;

        public static int NO_TILE = -1;
        public static int NO_ATTR = -1;

        public MapRegion(Size size, int[,] tile, int[,] attr)
        {
            this.size = size;
            this.tile = tile;
            this.attr = attr;
        }

        #region Public Properties
        /// <summary>
        /// Gets or sets the width of this MapRegion.
        /// </summary>
        public int Width
        {
            get { 
                return size.Width; 
            }
            set { 
                size.Width = value;
                Resize(size);
            }
        }

        /// <summary>
        /// Gets of sets the height of this MapRegion.
        /// </summary>
        public int Height
        {
            get
            {
                return size.Height;
            }
            set
            {
                size.Height = value;
                Resize(size);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the tile index at (x, y). If there is no tile in that location
        /// MapRegion.NO_TILE will be returned.
        /// </summary>
        /// <param name="x">x-coordinate of tile</param>
        /// <param name="y">y-coordinate of tile</param>
        /// <returns>Index of tile at (x, y)</returns>
        public int GetTileAt(int x, int y)
        {
            try
            {
                return tile[x,y];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NO_TILE;
            }
        }

        public void SetTileAt(int x, int y, int index)
        {
            tile[x, y] = index;
        }

        /// <summary>
        /// Gets the tile attribute (x, y). If there is no tile in that location
        /// MapRegion.NO_ATTR will be returned.
        /// </summary>
        /// <param name="x">x-coordinate of tile</param>
        /// <param name="y">y-coordinate of tile</param>
        /// <returns>Attribute of tile at (x, y)</returns>
        public int GetAttrAt(int x, int y)
        {
            try
            {
                return attr[x,y];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NO_ATTR;
            }
        }

        public void SetAttrAt(int x, int y, int attribute)
        {
            attr[x, y] = attribute;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Resizes the tile and attribute layers to a given width and height.
        /// </summary>
        /// <param name="width">New width of map data</param>
        /// <param name="height">New height of map data</param>
        private void Resize(Size size)
        {
            int[,] newTiles = new int[size.Width, size.Height];
            int[,] newAttrs = new int[size.Width, size.Height];

            Array.Copy(this.tile, newTiles, this.tile.Length);
            Array.Copy(this.attr, newAttrs, this.attr.Length);

            this.tile = newTiles;
            this.attr = newAttrs;
        }
        #endregion
    }
}
