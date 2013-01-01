using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hakase.Uchuu.Models;

namespace Hakase.Uchuu
{
    public partial class CreateRoomDialog : Form
    {
        private Room newRoom;

        public Room Room
        {
            get
            {
                return newRoom;
            }

            private set
            {
                newRoom = value;
            }
        }

        public CreateRoomDialog()
        {
            InitializeComponent();
            this.Shown += new EventHandler(CreateRoomDialog_Shown);
        }

        void CreateRoomDialog_Shown(object sender, EventArgs e)
        {
            this.Room = null;
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Room = CreateRoom();

            this.Close();
        }

        private Room CreateRoom()
        {
            var x = numericTextBoxX.IntValue;
            var y = numericTextBoxY.IntValue;
            var width = numericTextBoxWidth.IntValue;
            var height = numericTextBoxHeight.IntValue;

            Room newRoom = new Room(-1, x, y, width, height);
            CameraBounds cameraBounds = new CameraBounds();
            cameraBounds.X = 0;
            cameraBounds.Y = 0;
            cameraBounds.Width = width;
            cameraBounds.Height = height;

            newRoom.CameraBounds = cameraBounds;

            return newRoom;
        }
    }
}
