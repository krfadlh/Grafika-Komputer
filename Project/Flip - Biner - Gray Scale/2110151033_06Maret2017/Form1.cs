using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2110151033_06Maret2017
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void horizontal_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)p1.Image;
            Color pC; //pixelColor
            int size = source.Height;
            if (source.Width < source.Height) size = source.Width;

            Bitmap bmp1 = new Bitmap(size, size);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    pC = source.GetPixel(size - 1 - x, y);
                    bmp1.SetPixel(x, y, Color.FromArgb(pC.R, pC.G, pC.B));
                }
            }
            p2.SizeMode = PictureBoxSizeMode.StretchImage;
            p2.Image = bmp1;

        }

        private void vertikal_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)p1.Image;
            Color pC; //pixelColor
            int size = source.Height;
            if (source.Width < source.Height) size = source.Width;

            Bitmap bmp2 = new Bitmap(size, size);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int a = size - y;
                    pC = source.GetPixel(x, size - 1 - y);
                    bmp2.SetPixel(x, y, Color.FromArgb(pC.R, pC.G, pC.B));
                }

            }
            p3.SizeMode = PictureBoxSizeMode.StretchImage;
            p3.Image = bmp2;

        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                p1.SizeMode = PictureBoxSizeMode.Zoom;
                p1.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void grey_Click(object sender, EventArgs e)
        {
            Bitmap bmp3 = (Bitmap)p1.Image;
            Color pixelColor;
            p4.Image = new Bitmap(p4.Width, p4.Height);
            for (int y = 0; y < bmp3.Height; y++)
            {
                for (int x = 0; x < bmp3.Width; x++)
                {
                    pixelColor = bmp3.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    int rata = (int)(red + green + blue) / 3;
                    bmp3.SetPixel(x, y, Color.FromArgb(rata, rata, rata));
                }
            }
            p4.SizeMode = PictureBoxSizeMode.StretchImage;
            p4.Image = bmp3;

        }

        private void biner_Click(object sender, EventArgs e)
        {
            Bitmap bmp4 = (Bitmap)p1.Image;
            Color pixelColor;
            for (int y = 0; y < bmp4.Height; y++)
            {
                for (int x = 0; x < bmp4.Width; x++)
                {
                    pixelColor = bmp4.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    int rata = (int)(red + green + blue) / 3;
                    if (rata < 128) { rata = 0; } else { rata = 255; }
                    bmp4.SetPixel(x, y, Color.FromArgb(rata, rata, rata));
                }
            }
            p5.SizeMode = PictureBoxSizeMode.StretchImage;
            p5.Image = bmp4;

        }

        private void contrast_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)p1.Image;
            Bitmap bmp1 = new Bitmap(source.Height, source.Width);
            bmp1 = source;
            Color pixelColor;
            int k = 30;
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    pixelColor = source.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    if ((red + k) <= 255) { red = red + k; };
                    if ((green + k) <= 255) { green = green + k; };
                    if ((blue + k) <= 255) { blue = blue + k; };
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            p6.SizeMode = PictureBoxSizeMode.StretchImage;
            p6.Image = bmp1;

        }
    }
}
