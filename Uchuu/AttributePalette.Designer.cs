namespace Hakase.Uchuu
{
    partial class AttributePalette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.solidAttributeCheckbox = new System.Windows.Forms.CheckBox();
            this.ladderAttributeCheckBOx = new System.Windows.Forms.CheckBox();
            this.ladderTopAttributeCheckbox = new System.Windows.Forms.CheckBox();
            this.spikeAttributeCheckbox = new System.Windows.Forms.CheckBox();
            this.abyssAttrbitueCheckbox = new System.Windows.Forms.CheckBox();
            this.attributeValueLabel = new System.Windows.Forms.Label();
            this.waterAttrbitueCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // solidAttributeCheckbox
            // 
            this.solidAttributeCheckbox.AutoSize = true;
            this.solidAttributeCheckbox.Location = new System.Drawing.Point(12, 12);
            this.solidAttributeCheckbox.Name = "solidAttributeCheckbox";
            this.solidAttributeCheckbox.Size = new System.Drawing.Size(58, 17);
            this.solidAttributeCheckbox.TabIndex = 0;
            this.solidAttributeCheckbox.Text = "SOLID";
            this.solidAttributeCheckbox.UseVisualStyleBackColor = true;
            // 
            // ladderAttributeCheckBOx
            // 
            this.ladderAttributeCheckBOx.AutoSize = true;
            this.ladderAttributeCheckBOx.Location = new System.Drawing.Point(12, 35);
            this.ladderAttributeCheckBOx.Name = "ladderAttributeCheckBOx";
            this.ladderAttributeCheckBOx.Size = new System.Drawing.Size(70, 17);
            this.ladderAttributeCheckBOx.TabIndex = 1;
            this.ladderAttributeCheckBOx.Text = "LADDER";
            this.ladderAttributeCheckBOx.UseVisualStyleBackColor = true;
            // 
            // ladderTopAttributeCheckbox
            // 
            this.ladderTopAttributeCheckbox.AutoSize = true;
            this.ladderTopAttributeCheckbox.Location = new System.Drawing.Point(12, 58);
            this.ladderTopAttributeCheckbox.Name = "ladderTopAttributeCheckbox";
            this.ladderTopAttributeCheckbox.Size = new System.Drawing.Size(95, 17);
            this.ladderTopAttributeCheckbox.TabIndex = 2;
            this.ladderTopAttributeCheckbox.Text = "LADDER TOP";
            this.ladderTopAttributeCheckbox.UseVisualStyleBackColor = true;
            // 
            // spikeAttributeCheckbox
            // 
            this.spikeAttributeCheckbox.AutoSize = true;
            this.spikeAttributeCheckbox.Location = new System.Drawing.Point(12, 81);
            this.spikeAttributeCheckbox.Name = "spikeAttributeCheckbox";
            this.spikeAttributeCheckbox.Size = new System.Drawing.Size(57, 17);
            this.spikeAttributeCheckbox.TabIndex = 3;
            this.spikeAttributeCheckbox.Text = "SPIKE";
            this.spikeAttributeCheckbox.UseVisualStyleBackColor = true;
            // 
            // abyssAttrbitueCheckbox
            // 
            this.abyssAttrbitueCheckbox.AutoSize = true;
            this.abyssAttrbitueCheckbox.Location = new System.Drawing.Point(12, 104);
            this.abyssAttrbitueCheckbox.Name = "abyssAttrbitueCheckbox";
            this.abyssAttrbitueCheckbox.Size = new System.Drawing.Size(61, 17);
            this.abyssAttrbitueCheckbox.TabIndex = 4;
            this.abyssAttrbitueCheckbox.Text = "ABYSS";
            this.abyssAttrbitueCheckbox.UseVisualStyleBackColor = true;
            // 
            // attributeValueLabel
            // 
            this.attributeValueLabel.AutoSize = true;
            this.attributeValueLabel.Location = new System.Drawing.Point(12, 240);
            this.attributeValueLabel.Name = "attributeValueLabel";
            this.attributeValueLabel.Size = new System.Drawing.Size(46, 13);
            this.attributeValueLabel.TabIndex = 6;
            this.attributeValueLabel.Text = "Value: 0";
            // 
            // waterAttrbitueCheckbox
            // 
            this.waterAttrbitueCheckbox.AutoSize = true;
            this.waterAttrbitueCheckbox.Location = new System.Drawing.Point(12, 125);
            this.waterAttrbitueCheckbox.Name = "waterAttrbitueCheckbox";
            this.waterAttrbitueCheckbox.Size = new System.Drawing.Size(66, 17);
            this.waterAttrbitueCheckbox.TabIndex = 5;
            this.waterAttrbitueCheckbox.Text = "WATER";
            this.waterAttrbitueCheckbox.UseVisualStyleBackColor = true;
            // 
            // AttributePalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(115, 262);
            this.ControlBox = false;
            this.Controls.Add(this.waterAttrbitueCheckbox);
            this.Controls.Add(this.attributeValueLabel);
            this.Controls.Add(this.abyssAttrbitueCheckbox);
            this.Controls.Add(this.spikeAttributeCheckbox);
            this.Controls.Add(this.ladderTopAttributeCheckbox);
            this.Controls.Add(this.ladderAttributeCheckBOx);
            this.Controls.Add(this.solidAttributeCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AttributePalette";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Tile Attribute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox solidAttributeCheckbox;
        private System.Windows.Forms.CheckBox ladderAttributeCheckBOx;
        private System.Windows.Forms.CheckBox ladderTopAttributeCheckbox;
        private System.Windows.Forms.CheckBox spikeAttributeCheckbox;
        private System.Windows.Forms.CheckBox abyssAttrbitueCheckbox;
        private System.Windows.Forms.Label attributeValueLabel;
        private System.Windows.Forms.CheckBox waterAttrbitueCheckbox;
    }
}