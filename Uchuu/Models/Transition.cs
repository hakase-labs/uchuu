using System;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Hakase.Uchuu.Models
{
    public class Transition
    {
        public static readonly string DirectionUp = "up";
        public static readonly string DirectionForward = "forward";
        public static readonly string DirectionDown = "down";
        public static readonly string DirectionBackward = "backward";
        public static readonly string DirectionTeleport = "teleport";

        [JsonProperty("to")]
        public int ToRoomIndex
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

        [JsonProperty("direction")]
        public string Direction
        {
            get;
            set;
        }

        public Transition()
        {
            Direction = DirectionTeleport;
        }
    }
}
