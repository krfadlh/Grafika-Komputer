using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2110151033_13Maret2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)boxKuan1.Image;
            Color pixelColor;
            int K = 16;
            int th = (int)256 / K;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    int rata = (int)(red + green + blue) / 3;
                    int kuantisasi = (int)(rata / th);
                    int result = (int)th * kuantisasi;
                    bmp1.SetPixel(x, y, Color.FromArgb(result, result, result));
                }
            }
            boxKuan2.Image = new Bitmap(boxKuan2.Width, boxKuan2.Height);
            boxKuan2.SizeMode = PictureBoxSizeMode.StretchImage;
            boxKuan2.Image = bmp1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)boxKuan1.Image;
            Color pixelColor;
            int K = 4;
            int th = (int)256 / K;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    int rata = (int)(red + green + blue) / 3;
                    int kuantisasi = (int)(rata / th);
                    int result = (int)th * kuantisasi;
                    bmp1.SetPixel(x, y, Color.FromArgb(result, result, result));
                }
            }
            boxKuan3.Image = new Bitmap(boxKuan3.Width, boxKuan3.Height);
            boxKuan3.SizeMode = PictureBoxSizeMode.StretchImage;
            boxKuan3.Image = bmp1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)boxKuan1.Image;
            Color pixelColor;
            int K = 2;
            int th = (int)256 / K;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    int rata = (int)(red + green + blue) / 3;
                    int kuantisasi = (int)(rata / th);
                    int result = (int)th * kuantisasi;
                    bmp1.SetPixel(x, y, Color.FromArgb(result, result, result));
                }
            }
            boxKuan4.Image = new Bitmap(boxKuan4.Width, boxKuan4.Height);
            boxKuan4.SizeMode = PictureBoxSizeMode.StretchImage;
            boxKuan4.Image = bmp1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                boxKuan1.SizeMode = PictureBoxSizeMode.Zoom;
                boxKuan1.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
