using System;
using Newtonsoft.Json;

namespace Hakase.Uchuu.Models
{
    public class CameraBounds
    {
        private static readonly int DEFAULT_WIDTH = 16;
        private static readonly int DEFAULT_HEIGHT = 15;

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

        [JsonProperty("width")]
        public int Width
        {
            get;
            set;
        }

        [JsonProperty("height")]
        public int Height
        {
            get;
            set;
        }

        public CameraBounds()
            : this(0, 0, DEFAULT_WIDTH, DEFAULT_HEIGHT)
        {

        }

        public CameraBounds(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
