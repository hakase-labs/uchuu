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

        [JsonProperty("specialRooms")]
        public IDictionary<string, int> SpecialRooms
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

        //
        // Add the dictionary to the constructor
        //
        public Map(string tileSet, int gridSize, IDictionary<string, int> specialRooms, IList<Room> rooms)
        {
            this.TileSet = tileSet;
            this.GridSize = gridSize;
            this.SpecialRooms = specialRooms ?? new Dictionary<string, int>();
            this.Rooms = rooms ?? new List<Room>();
        }
    }
}
