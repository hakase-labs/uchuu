using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hakase.Uchuu
{
    public class Map
    {
        [JsonProperty("tileset")]
        public string TileSet
        {
            get;
            set;
        }

        [JsonProperty("gridsize")]
        public int GridSize
        {
            get;
            set;
        }

        [JsonProperty("rooms")]
        public IList<Room> Rooms
        {
            get;
            set;
        }

        [JsonConstructor()]
        private Map()
        {

        }

        public Map(string tileSet, int gridSize, IList<Room> rooms)
        {
            this.TileSet = tileSet;
            this.GridSize = gridSize;
            this.Rooms = rooms ?? new List<Room>();
        }
    }
}
