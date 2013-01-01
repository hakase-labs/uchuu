using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;

namespace Hakase.Uchuu
{
    public class TileSet
    {
        private string surfaceName;

        [JsonProperty("surface")]
        public string SurfaceName
        {
            get
            {
                return surfaceName;
            }
            set
            {
                surfaceName = value;

                if (surfaceName != null)
                {
                    try
                    {
                        SurfaceBitmap = Bitmap.FromFile(ContentUtils.ResolveContentPath(SurfaceName)) as Bitmap;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Couldn't load tileset bitmap; reason: " + ex.Message);
                        SurfaceBitmap = null;
                    }
                }
            }
        }

        [JsonProperty("size")]
        public int TileSize
        {
            get;
            set;
        }

        [JsonProperty("tiles")]
        public IList<Tile> Tiles {
            get;
            set;
        }

        [JsonIgnore()]
        public Bitmap SurfaceBitmap
        {
            get;
            private set;
        }

        public TileSet(string surfaceName, int tileSize, IList<Tile> tiles = null)
        {
            this.SurfaceName = surfaceName;
            this.TileSize = tileSize;
            this.Tiles = tiles ?? new List<Tile>();
        }
    }
}
