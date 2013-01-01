using System;

namespace Hakase.Uchuu
{
    /// <summary>
    /// Represents a change of tile index and a specific location.
    /// </summary>
    public class TileChange
    {
        public enum Type
        {
            Tile,
            Attribute
        }

        /// <summary>
        /// The X-position (in tiles) of the change.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y-position (in tiles) of the change.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The tile index after this change was made.
        /// </summary>
        public int ToIndex { get; set; }

        /// <summary>
        /// The tile index before this change was made.
        /// </summary>
        public int FromIndex { get; set; }

        public Type Nature { get; set; }

        public Room Room { get; set; }

        public TileChange(int x, int y, int to, int from, Type nature, Room room)
        {
            X = x;
            Y = y;
            ToIndex = to;
            FromIndex = from;
            Nature = nature;
            Room = room;
        }
    }
}
