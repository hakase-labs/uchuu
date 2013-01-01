namespace Hakase.Uchuu
{
    partial class CreateRoomDialog
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
            this.roomPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.createButton = new System.Windows.Forms.Button();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.positionGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTextBoxY = new Hakase.Uchuu.NumericTextBox();
            this.numericTextBoxX = new Hakase.Uchuu.NumericTextBox();
            this.numericTextBoxHeight = new Hakase.Uchuu.NumericTextBox();
            this.numericTextBoxWidth = new Hakase.Uchuu.NumericTextBox();
            this.roomPropertiesGroupBox.SuspendLayout();
            this.positionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomPropertiesGroupBox
            // 
            this.roomPropertiesGroupBox.Controls.Add(this.heightLabel);
            this.roomPropertiesGroupBox.Controls.Add(this.widthLabel);
            this.roomPropertiesGroupBox.Controls.Add(this.numericTextBoxHeight);
            this.roomPropertiesGroupBox.Controls.Add(this.numericTextBoxWidth);
            this.roomPropertiesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.roomPropertiesGroupBox.Name = "roomPropertiesGroupBox";
            this.roomPropertiesGroupBox.Size = new System.Drawing.Size(115, 73);
            this.roomPropertiesGroupBox.TabIndex = 0;
            this.roomPropertiesGroupBox.TabStop = false;
            this.roomPropertiesGroupBox.Text = "Dimension";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(12, 91);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(96, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create Room";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(7, 20);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(38, 13);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(7, 46);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 4;
            this.heightLabel.Text = "Height:";
            // 
            // positionGroupBox
            // 
            this.positionGroupBox.Controls.Add(this.label1);
            this.positionGroupBox.Controls.Add(this.numericTextBoxY);
            this.positionGroupBox.Controls.Add(this.label2);
            this.positionGroupBox.Controls.Add(this.numericTextBoxX);
            this.positionGroupBox.Location = new System.Drawing.Point(133, 12);
            this.positionGroupBox.Name = "positionGroupBox";
            this.positionGroupBox.Size = new System.Drawing.Size(115, 73);
            this.positionGroupBox.TabIndex = 5;
            this.positionGroupBox.TabStop = false;
            this.positionGroupBox.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X:";
            // 
            // numericTextBoxY
            // 
            this.numericTextBoxY.AllowSpace = false;
            this.numericTextBoxY.Location = new System.Drawing.Point(54, 43);
            this.numericTextBoxY.Name = "numericTextBoxY";
            this.numericTextBoxY.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxY.TabIndex = 4;
            this.numericTextBoxY.Text = "0";
            // 
            // numericTextBoxX
            // 
            this.numericTextBoxX.AllowSpace = false;
            this.numericTextBoxX.Location = new System.Drawing.Point(54, 17);
            this.numericTextBoxX.Name = "numericTextBoxX";
            this.numericTextBoxX.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxX.TabIndex = 3;
            this.numericTextBoxX.Text = "0";
            // 
            // numericTextBoxHeight
            // 
            this.numericTextBoxHeight.AllowSpace = false;
            this.numericTextBoxHeight.Location = new System.Drawing.Point(54, 43);
            this.numericTextBoxHeight.Name = "numericTextBoxHeight";
            this.numericTextBoxHeight.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxHeight.TabIndex = 2;
            this.numericTextBoxHeight.Text = "15";
            // 
            // numericTextBoxWidth
            // 
            this.numericTextBoxWidth.AllowSpace = false;
            this.numericTextBoxWidth.Location = new System.Drawing.Point(54, 17);
            this.numericTextBoxWidth.Name = "numericTextBoxWidth";
            this.numericTextBoxWidth.Size = new System.Drawing.Size(50, 20);
            this.numericTextBoxWidth.TabIndex = 1;
            this.numericTextBoxWidth.Text = "15";
            // 
            // CreateRoomDialog
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 121);
            this.Controls.Add(this.positionGroupBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.roomPropertiesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRoomDialog";
            this.Text = "Create Room";
            this.roomPropertiesGroupBox.ResumeLayout(false);
            this.roomPropertiesGroupBox.PerformLayout();
            this.positionGroupBox.ResumeLayout(false);
            this.positionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox roomPropertiesGroupBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private NumericTextBox numericTextBoxHeight;
        private NumericTextBox numericTextBoxWidth;
        private NumericTextBox numericTextBoxY;
        private System.Windows.Forms.GroupBox positionGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private NumericTextBox numericTextBoxX;
    }
}