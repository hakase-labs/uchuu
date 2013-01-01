using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;
using System.Drawing;

namespace Hakase.Uchuu
{
    public class Loader
    {
        /// <summary>
        /// Loads a MapRegion from a JSON structure.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MapRegion LoadMap(JsonData json)
        {
            if (json.IsObject)
            {
                int width = (int)json["width"];
                int height = (int)json["height"];

                int[,] tile = new int[width, height];
                int[,] attr = new int[width, height];

                JsonData tileArray = json["tile"];
                JsonData attrArray = json["attr"];

                Console.Out.WriteLine("Tile length: " + tileArray.Count);
                Console.Out.WriteLine("Attr length: " + attrArray.Count);

                for (int y = 0; y < height; y++) 
                {
                    for (int x = 0; x < width; x++)
                    {
                        int pos = x + (y * width);
                        try
                        {
                            tile[x, y] = (int)(tileArray[pos]);
                            attr[x, y] = (int)(attrArray[pos]);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            tile[x, y] = MapRegion.NO_TILE;
                            attr[x, y] = MapRegion.NO_ATTR;
                        }
                    }
                }

                return new MapRegion(new Size(width, height), tile, attr);
            }
            return null;
        }

        public static TileData LoadTiles(JsonData json)
        {
            if (json.IsObject)
            {
                int size = (int)json["size"];
                string imagePath = (string)json["surface"];
                List<Rectangle> tiles = new List<Rectangle>();

                JsonData rectangleArray = json["tiles"];

                for (int i = 0; i < rectangleArray.Count; i++)
                {
                    tiles.Add(
                        new Rectangle(
                            (int)rectangleArray[i]["x"],
                            (int)rectangleArray[i]["y"],
                            size,
                            size
                        )
                    );
                }

                return new TileData(new Size(size, size), tiles, imagePath);
            }
            return null;
        }
    }
}
