namespace _2110151033_06Maret2017
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
            this.load = new System.Windows.Forms.Button();
            this.horizontal = new System.Windows.Forms.Button();
            this.vertikal = new System.Windows.Forms.Button();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p3 = new System.Windows.Forms.PictureBox();
            this.grey = new System.Windows.Forms.Button();
            this.biner = new System.Windows.Forms.Button();
            this.contrast = new System.Windows.Forms.Button();
            this.p4 = new System.Windows.Forms.PictureBox();
            this.p6 = new System.Windows.Forms.PictureBox();
            this.p5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).BeginInit();
            this.SuspendLayout();
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(40, 28);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 23);
            this.load.TabIndex = 0;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // horizontal
            // 
            this.horizontal.Location = new System.Drawing.Point(246, 28);
            this.horizontal.Name = "horizontal";
            this.horizontal.Size = new System.Drawing.Size(101, 23);
            this.horizontal.TabIndex = 1;
            this.horizontal.Text = "Flip Horizontal";
            this.horizontal.UseVisualStyleBackColor = true;
            this.horizontal.Click += new System.EventHandler(this.horizontal_Click);
            // 
            // vertikal
            // 
            this.vertikal.Location = new System.Drawing.Point(488, 28);
            this.vertikal.Name = "vertikal";
            this.vertikal.Size = new System.Drawing.Size(75, 23);
            this.vertikal.TabIndex = 2;
            this.vertikal.Text = "Flip Vertikal";
            this.vertikal.UseVisualStyleBackColor = true;
            this.vertikal.Click += new System.EventHandler(this.vertikal_Click);
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(24, 94);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(100, 100);
            this.p1.TabIndex = 3;
            this.p1.TabStop = false;
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(247, 94);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(100, 100);
            this.p2.TabIndex = 4;
            this.p2.TabStop = false;
            // 
            // p3
            // 
            this.p3.Location = new System.Drawing.Point(475, 94);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(100, 100);
            this.p3.TabIndex = 5;
            this.p3.TabStop = false;
            // 
            // grey
            // 
            this.grey.Location = new System.Drawing.Point(40, 237);
            this.grey.Name = "grey";
            this.grey.Size = new System.Drawing.Size(75, 23);
            this.grey.TabIndex = 6;
            this.grey.Text = "Grayscale";
            this.grey.UseVisualStyleBackColor = true;
            this.grey.Click += new System.EventHandler(this.grey_Click);
            // 
            // biner
            // 
            this.biner.Location = new System.Drawing.Point(247, 237);
            this.biner.Name = "biner";
            this.biner.Size = new System.Drawing.Size(75, 23);
            this.biner.TabIndex = 7;
            this.biner.Text = "biner";
            this.biner.UseVisualStyleBackColor = true;
            this.biner.Click += new System.EventHandler(this.biner_Click);
            // 
            // contrast
            // 
            this.contrast.Location = new System.Drawing.Point(488, 237);
            this.contrast.Name = "contrast";
            this.contrast.Size = new System.Drawing.Size(75, 23);
            this.contrast.TabIndex = 8;
            this.contrast.Text = "Contrast";
            this.contrast.UseVisualStyleBackColor = true;
            this.contrast.Click += new System.EventHandler(this.contrast_Click);
            // 
            // p4
            // 
            this.p4.Location = new System.Drawing.Point(24, 291);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(100, 100);
            this.p4.TabIndex = 9;
            this.p4.TabStop = false;
            // 
            // p6
            // 
            this.p6.Location = new System.Drawing.Point(475, 291);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(100, 100);
            this.p6.TabIndex = 10;
            this.p6.TabStop = false;
            // 
            // p5
            // 
            this.p5.Location = new System.Drawing.Point(247, 291);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(100, 100);
            this.p5.TabIndex = 11;
            this.p5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 470);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p6);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.contrast);
            this.Controls.Add(this.biner);
            this.Controls.Add(this.grey);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.vertikal);
            this.Controls.Add(this.horizontal);
            this.Controls.Add(this.load);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button horizontal;
        private System.Windows.Forms.Button vertikal;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.PictureBox p3;
        private System.Windows.Forms.Button grey;
        private System.Windows.Forms.Button biner;
        private System.Windows.Forms.Button contrast;
        private System.Windows.Forms.PictureBox p4;
        private System.Windows.Forms.PictureBox p6;
        private System.Windows.Forms.PictureBox p5;
    }
}

