using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hakase.Uchuu
{
    public class Tile
    {
        [Flags]
        public enum Attribute {
            Nothing = 0,
            Solid = (1 << 0),
            Ladder = (1 << 1),
            LadderTop = (1 << 2),
            Spikes = (1 << 3),
            Abyss = (1 << 4),
            FlipHorizontal = (1 << 5),
            FlipVertical = (1 << 6),
            RotateBy90 = (1 << 7),
            Water = (1 << 8)
        };

        [JsonProperty("x")]
        public int X
        {
            get;
            set;
        }

        [JsonProperty("y")]
        public int Y
        {
            get;
            set;
        }

        public Tile(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
