using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hakase.Uchuu
{
    public partial class AttributePalette : Form
    {
        private Tile.Attribute tileAttribute;

        public Tile.Attribute TileAttribute
        {
            get
            {
                return tileAttribute;
            }
            private set
            {
                tileAttribute = value;
                UpdateAttributeValueLabel();
            }
        }

        public AttributePalette()
        {
            InitializeComponent();

            TileAttribute = Tile.Attribute.Nothing;

            solidAttributeCheckbox.CheckedChanged += new EventHandler(HandleAttributeSelection);
            solidAttributeCheckbox.Tag = Tile.Attribute.Solid;

            ladderAttributeCheckBOx.CheckedChanged += new EventHandler(HandleAttributeSelection);
            ladderAttributeCheckBOx.Tag = Tile.Attribute.Ladder;

            ladderTopAttributeCheckbox.CheckedChanged += new EventHandler(HandleAttributeSelection);
            ladderTopAttributeCheckbox.Tag = Tile.Attribute.LadderTop;

            spikeAttributeCheckbox.CheckedChanged += new EventHandler(HandleAttributeSelection);
            spikeAttributeCheckbox.Tag = Tile.Attribute.Spikes;

            abyssAttrbitueCheckbox.CheckedChanged += new EventHandler(HandleAttributeSelection);
            abyssAttrbitueCheckbox.Tag = Tile.Attribute.Abyss;

            waterAttrbitueCheckbox.CheckedChanged += new EventHandler(HandleAttributeSelection);
            waterAttrbitueCheckbox.Tag = Tile.Attribute.Water;
        }

        private void HandleAttributeSelection(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;

            if (checkbox != null)
            {
                var attributeTag = checkbox.Tag;
                var attribute = (Tile.Attribute)attributeTag;

                if (checkbox.Checked)
                {
                    TileAttribute = TileAttribute | attribute;
                }
                else
                {
                    TileAttribute = TileAttribute & ~(attribute);
                }
            }
        }

        private void UpdateAttributeValueLabel()
        {
            attributeValueLabel.Text = String.Format("Value: {0}", (int)tileAttribute);
        }


    }
}
