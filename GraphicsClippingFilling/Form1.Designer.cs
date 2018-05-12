namespace GraphicsClippingFilling
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ver2 = new System.Windows.Forms.Label();
            this.ver1 = new System.Windows.Forms.Label();
            this.drawLinuButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.circleLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.thicknessLabel = new System.Windows.Forms.Label();
            this.thicknessComboBox = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(860, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(751, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Point 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(751, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Point 2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(860, 98);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ver2
            // 
            this.ver2.AutoSize = true;
            this.ver2.Location = new System.Drawing.Point(811, 70);
            this.ver2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ver2.Name = "ver2";
            this.ver2.Size = new System.Drawing.Size(44, 17);
            this.ver2.TabIndex = 6;
            this.ver2.Text = "coord";
            // 
            // ver1
            // 
            this.ver1.AutoSize = true;
            this.ver1.Location = new System.Drawing.Point(811, 12);
            this.ver1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ver1.Name = "ver1";
            this.ver1.Size = new System.Drawing.Size(44, 17);
            this.ver1.TabIndex = 3;
            this.ver1.Text = "coord";
            // 
            // drawLinuButton
            // 
            this.drawLinuButton.Location = new System.Drawing.Point(751, 526);
            this.drawLinuButton.Name = "drawLinuButton";
            this.drawLinuButton.Size = new System.Drawing.Size(209, 35);
            this.drawLinuButton.TabIndex = 7;
            this.drawLinuButton.Text = "DRAW LINE";
            this.drawLinuButton.UseVisualStyleBackColor = true;
            this.drawLinuButton.Click += new System.EventHandler(this.drawLinuButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(732, 549);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // circleLabel
            // 
            this.circleLabel.AutoSize = true;
            this.circleLabel.Location = new System.Drawing.Point(811, 132);
            this.circleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.circleLabel.Name = "circleLabel";
            this.circleLabel.Size = new System.Drawing.Size(44, 17);
            this.circleLabel.TabIndex = 11;
            this.circleLabel.Text = "coord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(751, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Circle";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(860, 156);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Select";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(751, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 37);
            this.button4.TabIndex = 12;
            this.button4.Text = "DRAW CIRCLE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(775, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Radius";
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(878, 206);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(67, 22);
            this.radiusTextBox.TabIndex = 14;
            this.radiusTextBox.Text = "50";
            this.radiusTextBox.Leave += new System.EventHandler(this.radiusTextBox_Leave);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(751, 442);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 35);
            this.button5.TabIndex = 15;
            this.button5.Text = "DRAW THICK LINE ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // thicknessLabel
            // 
            this.thicknessLabel.AutoSize = true;
            this.thicknessLabel.Location = new System.Drawing.Point(764, 252);
            this.thicknessLabel.Name = "thicknessLabel";
            this.thicknessLabel.Size = new System.Drawing.Size(72, 17);
            this.thicknessLabel.TabIndex = 16;
            this.thicknessLabel.Text = "Thickness";
            // 
            // thicknessComboBox
            // 
            this.thicknessComboBox.FormattingEnabled = true;
            this.thicknessComboBox.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7"});
            this.thicknessComboBox.Location = new System.Drawing.Point(878, 249);
            this.thicknessComboBox.Name = "thicknessComboBox";
            this.thicknessComboBox.Size = new System.Drawing.Size(67, 24);
            this.thicknessComboBox.TabIndex = 17;
            this.thicknessComboBox.Text = "1";
            this.thicknessComboBox.SelectedIndexChanged += new System.EventHandler(this.thicknessComboBox_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(751, 401);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(209, 35);
            this.button6.TabIndex = 18;
            this.button6.Text = "DRAW LINE WITH PEN";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(845, 365);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(115, 30);
            this.button8.TabIndex = 20;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 576);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.thicknessComboBox);
            this.Controls.Add(this.thicknessLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.radiusTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.circleLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.drawLinuButton);
            this.Controls.Add(this.ver2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ver1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ver2;
        private System.Windows.Forms.Label ver1;
        private System.Windows.Forms.Button drawLinuButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label circleLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label thicknessLabel;
        private System.Windows.Forms.ComboBox thicknessComboBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
    }
}

