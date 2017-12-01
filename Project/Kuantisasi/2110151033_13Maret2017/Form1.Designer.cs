namespace _2110151033_13Maret2017
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
            this.boxKuan1 = new System.Windows.Forms.PictureBox();
            this.boxKuan2 = new System.Windows.Forms.PictureBox();
            this.boxKuan3 = new System.Windows.Forms.PictureBox();
            this.boxKuan4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan4)).BeginInit();
            this.SuspendLayout();
            // 
            // boxKuan1
            // 
            this.boxKuan1.Location = new System.Drawing.Point(26, 38);
            this.boxKuan1.Name = "boxKuan1";
            this.boxKuan1.Size = new System.Drawing.Size(100, 50);
            this.boxKuan1.TabIndex = 0;
            this.boxKuan1.TabStop = false;
            // 
            // boxKuan2
            // 
            this.boxKuan2.Location = new System.Drawing.Point(181, 38);
            this.boxKuan2.Name = "boxKuan2";
            this.boxKuan2.Size = new System.Drawing.Size(100, 50);
            this.boxKuan2.TabIndex = 1;
            this.boxKuan2.TabStop = false;
            this.boxKuan2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // boxKuan3
            // 
            this.boxKuan3.Location = new System.Drawing.Point(333, 38);
            this.boxKuan3.Name = "boxKuan3";
            this.boxKuan3.Size = new System.Drawing.Size(100, 50);
            this.boxKuan3.TabIndex = 2;
            this.boxKuan3.TabStop = false;
            // 
            // boxKuan4
            // 
            this.boxKuan4.Location = new System.Drawing.Point(491, 38);
            this.boxKuan4.Name = "boxKuan4";
            this.boxKuan4.Size = new System.Drawing.Size(100, 50);
            this.boxKuan4.TabIndex = 10;
            this.boxKuan4.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Kuantisasi 16";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(342, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Kuantisasi 4";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(491, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Kuantisasi 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 261);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boxKuan4);
            this.Controls.Add(this.boxKuan3);
            this.Controls.Add(this.boxKuan2);
            this.Controls.Add(this.boxKuan1);
            this.Name = "Form1";
            this.Text = "n";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxKuan4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boxKuan1;
        private System.Windows.Forms.PictureBox boxKuan2;
        private System.Windows.Forms.PictureBox boxKuan3;
        private System.Windows.Forms.PictureBox boxKuan4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

