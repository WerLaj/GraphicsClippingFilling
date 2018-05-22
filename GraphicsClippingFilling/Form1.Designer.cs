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
            this.ver1 = new System.Windows.Forms.Label();
            this.drawLinuButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.clipButton = new System.Windows.Forms.Button();
            this.ver2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.fillButton = new System.Windows.Forms.Button();
            this.drawShapeButton = new System.Windows.Forms.Button();
            this.boundaryButton = new System.Windows.Forms.Button();
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
            this.button1.Click += new System.EventHandler(this.selectPointPolygon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(751, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Polygon";
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
            this.drawLinuButton.Click += new System.EventHandler(this.drawLineButton_Click);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(751, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(209, 37);
            this.button4.TabIndex = 12;
            this.button4.Text = "DRAW POLYGON";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.drawPolygon_Click);
            // 
            // clipButton
            // 
            this.clipButton.Location = new System.Drawing.Point(860, 249);
            this.clipButton.Name = "clipButton";
            this.clipButton.Size = new System.Drawing.Size(75, 23);
            this.clipButton.TabIndex = 13;
            this.clipButton.Text = "Clip";
            this.clipButton.UseVisualStyleBackColor = true;
            this.clipButton.Click += new System.EventHandler(this.clipButton_Click);
            // 
            // ver2
            // 
            this.ver2.AutoSize = true;
            this.ver2.Location = new System.Drawing.Point(811, 86);
            this.ver2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ver2.Name = "ver2";
            this.ver2.Size = new System.Drawing.Size(44, 17);
            this.ver2.TabIndex = 16;
            this.ver2.Text = "coord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(751, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Line";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(860, 110);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 14;
            this.button2.Text = "Select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectPointLine_Click);
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(860, 288);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(75, 23);
            this.fillButton.TabIndex = 17;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // drawShapeButton
            // 
            this.drawShapeButton.Location = new System.Drawing.Point(792, 402);
            this.drawShapeButton.Name = "drawShapeButton";
            this.drawShapeButton.Size = new System.Drawing.Size(168, 23);
            this.drawShapeButton.TabIndex = 18;
            this.drawShapeButton.Text = "DrawShape";
            this.drawShapeButton.UseVisualStyleBackColor = true;
            this.drawShapeButton.Click += new System.EventHandler(this.drawShapeButton_Click);
            // 
            // boundaryButton
            // 
            this.boundaryButton.Location = new System.Drawing.Point(792, 374);
            this.boundaryButton.Name = "boundaryButton";
            this.boundaryButton.Size = new System.Drawing.Size(166, 23);
            this.boundaryButton.TabIndex = 19;
            this.boundaryButton.Text = "BoundaryAlgorithm";
            this.boundaryButton.UseVisualStyleBackColor = true;
            this.boundaryButton.Click += new System.EventHandler(this.boundaryButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 576);
            this.Controls.Add(this.boundaryButton);
            this.Controls.Add(this.drawShapeButton);
            this.Controls.Add(this.fillButton);
            this.Controls.Add(this.ver2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.clipButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.drawLinuButton);
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
        private System.Windows.Forms.Label ver1;
        private System.Windows.Forms.Button drawLinuButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button clipButton;
        private System.Windows.Forms.Label ver2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Button drawShapeButton;
        private System.Windows.Forms.Button boundaryButton;
    }
}

