using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Hakase.Uchuu.Models;
using System.ComponentModel;
using System.Linq;

namespace Hakase.Uchuu
{
    public class Room : INotifyPropertyChanged
    {
        static readonly int DEFAULT_X = 0;
        static readonly int DEFAULT_Y = 0;
        static readonly int DEFAULT_WIDTH = 20;
        static readonly int DEFAULT_HEIGHT = 15;

        private int id;
        private int x;
        private int y;
        private int heroSpawnX;
        private int heroSpawnY;
        private int width;
        private int height;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("id")]
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        [JsonProperty("x")]
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        [JsonProperty("y")]
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        [JsonProperty("heroSpawnX", NullValueHandling = NullValueHandling.Ignore)]
        public int HeroSpawnX
        {
            get { return heroSpawnX; }
            set
            {
                heroSpawnX = value;
                OnPropertyChanged("HeroSpawnX");
            }
        }

        [JsonProperty("heroSpawnY", NullValueHandling = NullValueHandling.Ignore)]
        public int HeroSpawnY
        {
            get { return heroSpawnY; }
            set
            {
                heroSpawnY = value;
                OnPropertyChanged("HeroSpawnY");
            }
        }

        [ReadOnlyAttribute(true)]
        [DescriptionAttribute("Width (in tiles) of this room; to change use the \"Edit > Resize option\"")]
        [JsonProperty("width")]
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }

        [ReadOnlyAttribute(true)]
        [DescriptionAttribute("Height (in tiles) of this room; to change use the \"Edit > Resize option\"")]
        [JsonProperty("height")]
        public int Height
        {
            get { return height; }
            set { 
                height = value; 
                OnPropertyChanged("Height"); 
            }
        }

        [BrowsableAttribute(false)]
        [JsonProperty("tile")]
        public IList<int> TileIndicies
        {
            get;
            set;
        }

        [BrowsableAttribute(false)]
        [JsonProperty("attr")]
        public IList<Tile.Attribute> TileAttrbutes
        {
            get;
            set;
        }

        [JsonProperty("cameraBounds")]
        public CameraBounds CameraBounds
        {
            get;
            set;
        }

        [JsonProperty("enemies")]
        public IList<object> Enemies
        {
            get;
            set;
        }

        [JsonProperty("items")]
        public IList<object> Items
        {
            get;
            set;
        }

        [JsonProperty("transitions")]
        public IList<Transition>Transitions
        {
            get;
            set;
        }

        [JsonConstructor()]
        private Room()
        {
        }

        public Room(int id) 
            : this(id, DEFAULT_X, DEFAULT_Y)
        {
            // Construction delegated to other constructor
        }

        public Room(int id, int x, int y)
            : this(id, x, y, DEFAULT_WIDTH, DEFAULT_HEIGHT)
        {
            // Construction delegated to other constructor
        }

        public Room(int id, int x, int y, int width, int height)
        {
            this.ID = id;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Enemies = new List<object>();
            this.Items = new List<object>();
            this.Transitions = new List<Transition>();
            this.TileIndicies = Enumerable.Repeat(0, width * height).ToList();
            this.TileAttrbutes = Enumerable.Repeat(Tile.Attribute.Nothing, width * height).ToList();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
