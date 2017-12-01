using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2110151033
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RED_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(200, 140);
            Color merah = Color.FromArgb(255, 0, 0);
            Color putih = Color.FromArgb(255, 255, 255);
            for (int y = 0; y < 70; y++)
            {
                for (int x = 0; x < 200; x++)
                {
                    bmp1.SetPixel(x, y, merah);
                }
            }
            for (int y = 70; y < 140; y++)
            {
                for (int x = 0; x < 200; x++)
                {
                    bmp1.SetPixel(x, y, putih);
                }
            }
            pictureBox6.Image = new Bitmap(bmp1.Height, bmp1.Width);
            pictureBox6.Image = bmp1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number1, number2, number3;
            Int32.TryParse(textBox1.Text, out number1);
            Int32.TryParse(textBox2.Text, out number2);
            Int32.TryParse(textBox3.Text, out number3);
            //panel4.BackColor = Color.FromArgb(number1, number2, number3);
            Bitmap bitCampur = new Bitmap(100, 100);

            Bitmap bitRed = new Bitmap(100, 100);
            Bitmap bitGreen = new Bitmap(100, 100);
            Bitmap bitBlue = new Bitmap(100, 100);
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
            Color campur = Color.FromArgb(number1, number2, number3);

            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    bitRed.SetPixel(x, y, red);
                    bitGreen.SetPixel(x, y, green);
                    bitBlue.SetPixel(x, y, blue);
                    bitCampur.SetPixel(x, y, campur);
                }
            }

            pictureBox2.Image = new Bitmap(bitRed.Height, bitRed.Width);
            pictureBox2.Image = bitRed;
            pictureBox3.Image = new Bitmap(bitGreen.Height, bitGreen.Width);
            pictureBox3.Image = bitGreen;
            pictureBox4.Image = new Bitmap(bitBlue.Height, bitBlue.Width);
            pictureBox4.Image = bitBlue;
            pictureBox5.Image = new Bitmap(bitCampur.Height, bitCampur.Width);
            pictureBox5.Image = bitCampur;

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox7.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)pictureBox7.Image;
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
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.Image = bmp1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)pictureBox7.Image;
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
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.Image = bmp2;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp3 = (Bitmap)pictureBox7.Image;
            Color pixelColor;
            pictureBox10.Image = new Bitmap(pictureBox10.Width, pictureBox10.Height);
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
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Image = bmp3;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap source = (Bitmap)pictureBox7.Image;
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
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.Image = bmp1;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp4 = (Bitmap)pictureBox7.Image;
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
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Image = bmp4;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox13.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox13.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox13.Image;
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
            pictureBox14.Image = new Bitmap(pictureBox14.Width, pictureBox14.Height);
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.Image = bmp1;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox13.Image;
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
            pictureBox15.Image = new Bitmap(pictureBox15.Width, pictureBox15.Height);
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.Image = bmp1;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox13.Image;
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
            pictureBox16.Image = new Bitmap(pictureBox16.Width, pictureBox16.Height);
            pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox16.Image = bmp1;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox19.Image;
            Color pixelColor;
            int K = 50;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    if ((red + K) <= 255) { red = red + K; }
                    if ((green + K) <= 255) { green = green + K; }
                    if ((blue + K) <= 255) { blue = blue + K; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
           pictureBox17.Image = new Bitmap(pictureBox17.Width, pictureBox17.Height);
            pictureBox17.SizeMode = PictureBoxSizeMode.StretchImage;
           pictureBox17.Image = bmp1;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox19.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox19.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox19.Image;
            Color pixelColor;
            float K = 0.7f;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    red = (int)(K * red);
                    green = (int)(K * green);
                    blue = (int)(K * blue);
                    if (red > 255) { red = 255; }
                    if (green > 255) { green = 255; }
                    if (blue > 255) { blue = 255; }
                    if (red < 0) { red = 0; }
                    if (green < 0) { green = 0; }
                    if (blue < 0) { blue = 0; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
           pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox18.Image = bmp1;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox20.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox20.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox20.Image;
            Color pixelColor;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = 255 - pixelColor.R;
                    int green = 255 - pixelColor.G;
                    int blue = 255 - pixelColor.B;
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
           pictureBox21.Image = new Bitmap(pictureBox21.Width,pictureBox21.Height);
            pictureBox21.SizeMode = PictureBoxSizeMode.StretchImage;
           pictureBox21.Image = bmp1;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox20.Image;
            Color pixelColor;
            int K = 50;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    red = (int)(K * Math.Log(red, 10));
                    green = (int)(K * Math.Log(green, 10));
                    blue = (int)(K * Math.Log(blue, 10));
                    if (red > 255) { red = 255; }
                    if (green > 255) { green = 255; }
                    if (blue > 255) { blue = 255; }
                    if (red < 0) { red = 0; }
                    if (green < 0) { green = 0; }
                    if (blue < 0) { blue = 0; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
           pictureBox21.Image = new Bitmap(pictureBox21.Width, pictureBox21.Height);
            pictureBox21.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox21.Image = bmp1;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox21.Image;
            Color pixelColor;
            int K = 50;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    red = (int)(10 * Math.Exp(red / K));
                    green = (int)(10 * Math.Exp(green / K));
                    blue = (int)(10 * Math.Exp(blue / K));
                    if (red > 255) { red = 255; }
                    if (green > 255) { green = 255; }
                    if (blue > 255) { blue = 255; }
                    if (red < 0) { red = 0; }
                    if (green < 0) { green = 0; }
                    if (blue < 0) { blue = 0; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox22.Image = new Bitmap(pictureBox22.Width, pictureBox22.Height);
            pictureBox22.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox22.Image = bmp1;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox20.Image;
            Color pixelColor;
            float K = 0.4f;
            float K2 = 1.5f;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    red = (int)(K * red * Math.Exp(K2));
                    green = (int)(K * green * Math.Exp(K2));
                    blue = (int)(K * blue * Math.Exp(K2));
                    if (red > 255) { red = 255; }
                    if (green > 255) { green = 255; }
                    if (blue > 255) { blue = 255; }
                    if (red < 0) { red = 0; }
                    if (green < 0) { green = 0; }
                    if (blue < 0) { blue = 0; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox21.Image = new Bitmap(pictureBox21.Width, pictureBox21.Height);
           pictureBox21.SizeMode = PictureBoxSizeMode.StretchImage;
           pictureBox21.Image = bmp1;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox20.Image;
            Color pixelColor;
            float K = 0.6f;
            float K2 = 1.5f;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    red = (int)(K * red * Math.Exp(1 / K2));
                    green = (int)(K * green * Math.Exp(1 / K2));
                    blue = (int)(K * blue * Math.Exp(1 / K2));
                    if (red > 255) { red = 255; }
                    if (green > 255) { green = 255; }
                    if (blue > 255) { blue = 255; }
                    if (red < 0) { red = 0; }
                    if (green < 0) { green = 0; }
                    if (blue < 0) { blue = 0; }
                    bmp1.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox21.Image = new Bitmap(pictureBox21.Width, pictureBox21.Height);
            pictureBox21.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox21.Image = bmp1;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox23.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox23.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox24.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox24.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)pictureBox23.Image;
            Bitmap bmp2 = (Bitmap)pictureBox24.Image;
            Bitmap bmp3 = (Bitmap)pictureBox24.Image;
            int height = bmp1.Height;
            int width = bmp1.Width;
            if (bmp1.Height > bmp2.Height) height = bmp2.Height;
            if (bmp1.Width > bmp2.Width) width = bmp2.Width;
            Color pixelColor1;
            Color pixelColor2;

            pictureBox25.Image = new Bitmap(pictureBox25.Width, pictureBox25.Height);
            pictureBox25.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox25.Image = bmp3;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    pixelColor1 = bmp1.GetPixel(x, y);
                    int red = pixelColor1.R;
                    int green = pixelColor1.G;
                    int blue = pixelColor1.B;

                    pixelColor2 = bmp2.GetPixel(x, y);
                    int red2 = pixelColor2.R;
                    int green2 = pixelColor2.G;
                    int blue2 = pixelColor2.B;

                    red = (int)((0.25 * red + 0.75 * red2) / 2);
                    green = (int)((0.25 * green + 0.75 * green2) / 2);
                    blue = (int)((0.25 * blue + 0.75 * blue2) / 2);
                    bmp3.SetPixel(x, y, Color.FromArgb(red, green, blue));

                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Bitmap bmp5 = (Bitmap)pictureBox26.Image;
            for (int x = 0; x < bmp5.Width; x++)
                for (int y = 0; y < bmp5.Height; y++)
                {
                    Color w = bmp5.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    bmp5.SetPixel(x, y, wb);
                }
            pictureBox27.Image = bmp5;

        }

        private void button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox26.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox26.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            Bitmap bmp6 = (Bitmap)pictureBox26.Image;
            Bitmap bmp7 = (Bitmap)pictureBox26.Image;

           // objBitmap1 = new Bitmap(objBitmap1);
            Random r = new Random();
            for (int x = 0; x < bmp6.Width; x++)
                for (int y = 0; y < bmp6.Height; y++)
                {
                    Color w = bmp6.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20)
                    {
                        int ns = r.Next(0, 256) - 128;
                        xb = (int)(xg + ns);
                        if (xb < 0) xb = -xb;
                        if (xb > 255) xb = 255;
                    }
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp7.SetPixel(x, y, wb);
                }
            pictureBox28.Image = bmp7;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Bitmap bmp8 = (Bitmap)pictureBox26.Image;
            Bitmap bmp9 = (Bitmap)pictureBox26.Image;
            //objBitmap1 = new Bitmap(objBitmap);
            Random r = new Random();
            for (int x = 0; x < bmp8.Width; x++)
                for (int y = 0; y < bmp9.Height; y++)
                {
                    Color w = bmp8.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20) xb = 0;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp9.SetPixel(x, y, wb);
                }
            pictureBox29.Image = bmp9;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Bitmap bmp10 = (Bitmap)pictureBox26.Image;
            Bitmap bmp11 = (Bitmap)pictureBox26.Image;
           // objBitmap1 = new Bitmap(objBitmap);
            Random r = new Random();
            for (int x = 0; x < bmp10.Width; x++)
                for (int y = 0; y < bmp10.Height; y++)
                {
                    Color w = bmp10.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp11.SetPixel(x, y, wb);
                }
            pictureBox30.Image = bmp11;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox31.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox31.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox31.Image;
            for (int x = 0; x < bmp12.Width; x++)
                for (int y = 0; y < bmp12.Height; y++)
                {
                    Color w = bmp12.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox31.Image = bmp12;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Bitmap bmp13 = (Bitmap)pictureBox31.Image;
            for (int x = 1; x < bmp13.Width; x++)
                for (int y = 1; y < bmp13.Height; y++)
                {
                    Color w1 = bmp13.GetPixel(x - 1, y);
                    Color w2 = bmp13.GetPixel(x, y);
                    Color w3 = bmp13.GetPixel(x, y - 1);
                    Color w4 = bmp13.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xb = (int)((x2 - x1) + (x4 - x3));
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp13.SetPixel(x, y, wb);
                }
            pictureBox32.Image = bmp13;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Bitmap bmp14 = (Bitmap)pictureBox31.Image;
            //objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < bmp14.Width - 1; x++)
                for (int y = 1; y < bmp14.Height - 1; y++)
                {
                    Color w1 = bmp14.GetPixel(x - 1, y - 1);
                    Color w2 = bmp14.GetPixel(x - 1, y);
                    Color w3 = bmp14.GetPixel(x - 1, y + 1);
                    Color w4 = bmp14.GetPixel(x, y - 1);
                    Color w5 = bmp14.GetPixel(x, y);
                    Color w6 = bmp14.GetPixel(x, y + 1);
                    Color w7 = bmp14.GetPixel(x + 1, y - 1);
                    Color w8 = bmp14.GetPixel(x + 1, y);
                    Color w9 = bmp14.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xh = (int)(-x1 - x4 - x7 + x3 + x6 + x9);
                    int xv = (int)(-x1 - x2 - x3 + x7 + x8 + x9);
                    int xb = (int)(xh + xv);
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp14.SetPixel(x, y, wb);
                }
            pictureBox32.Image = bmp14;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Bitmap bmp15 = (Bitmap)pictureBox31.Image;
            for (int x = 1; x < bmp15.Width - 1; x++)
                for (int y = 1; y < bmp15.Height - 1; y++)
                {
                    Color w1 = bmp15.GetPixel(x - 1, y - 1);
                    Color w2 = bmp15.GetPixel(x - 1, y);
                    Color w3 = bmp15.GetPixel(x - 1, y + 1);
                    Color w4 = bmp15.GetPixel(x, y - 1);
                    Color w5 = bmp15.GetPixel(x, y);
                    Color w6 = bmp15.GetPixel(x, y + 1);
                    Color w7 = bmp15.GetPixel(x + 1, y - 1);
                    Color w8 = bmp15.GetPixel(x + 1, y);
                    Color w9 = bmp15.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xh = (int)(-x1 - 2 * x4 - x7 + x3 + 2 * x6 + x9);
                    int xv = (int)(-x1 - 2 * x2 - x3 + x7 + 2 * x8 + x9);
                    int xb = (int)(xh + xv);
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp15.SetPixel(x, y, wb);
                }
            pictureBox32.Image = bmp15;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Bitmap bmp16 = (Bitmap)pictureBox31.Image;
            for (int x = 1; x < bmp16.Width - 1; x++)
                for (int y = 1; y < bmp16.Height - 1; y++)
                {
                    Color w1 = bmp16.GetPixel(x - 1, y - 1);
                    Color w2 = bmp16.GetPixel(x - 1, y);
                    Color w3 = bmp16.GetPixel(x - 1, y + 1);
                    Color w4 = bmp16.GetPixel(x, y - 1);
                    Color w5 = bmp16.GetPixel(x, y);
                    Color w6 = bmp16.GetPixel(x, y + 1);
                    Color w7 = bmp16.GetPixel(x + 1, y - 1);
                    Color w8 = bmp16.GetPixel(x + 1, y);
                    Color w9 = bmp16.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)(x1 - 2 * x2 + x3 - 2 * x4 + 4 * x5 - 2 * x6 + x7 - 2 * x8 + x9);
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp16.SetPixel(x, y, wb);
                }
            pictureBox32.Image = bmp16;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox33.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox33.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Bitmap bmp18 = (Bitmap)pictureBox33.Image;
            for (int x = 0; x < bmp18.Width; x++)
                for (int y = 0; y < bmp18.Height; y++)
                {
                    Color w = bmp18.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    bmp18.SetPixel(x, y, wb);
                }
            pictureBox33.Image = bmp18;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Bitmap bmp19 = (Bitmap)pictureBox33.Image;
            float[] h = new float[256];
            int i;
            for (i = 0; i < 256; i++) h[i] = 0;
            for (int x = 0; x < bmp19.Width; x++)
                for (int y = 0; y < bmp19.Height; y++)
                {
                    Color w = bmp19.GetPixel(x, y);
                    int xg = w.R;
                    h[xg] = h[xg] + 1;
                }
            for (i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, h[i]);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Bitmap bmp20 = (Bitmap)pictureBox33.Image;
            float[] h = new float[256];
            float[] c = new float[256];
            int i;
            for (i = 0; i < 256; i++) h[i] = 0;
            for (int x = 0; x < bmp20.Width; x++)
                for (int y = 0; y < bmp20.Height; y++)
                {
                    Color w = bmp20.GetPixel(x, y);
                    int xg = w.R;
                    h[xg] = h[xg] + 1;
                }
            c[0] = h[0];
            for (i = 1; i < 256; i++) c[i] = c[i - 1] + h[i];
            for (i = 0; i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, c[i]);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox34.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox34.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox34.Image;
            for (int x = 0; x < bmp12.Width; x++)
                for (int y = 0; y < bmp12.Height; y++)
                {
                    Color w = bmp12.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox34.Image = bmp12;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox34.Image;
            float[] a = new float[5];
            a[1] = (float)0.2;
            a[2] = (float)0.2;
            a[3] = (float)0.2;
            a[4] = (float)0.2;
            a[0] = (float)0.2;
           // objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < bmp12.Width - 1; x++)
                for (int y = 1; y < bmp12.Height - 1; y++)
                {
                    Color w1 = bmp12.GetPixel(x - 1, y);
                    Color w2 = bmp12.GetPixel(x + 1, y);
                    Color w3 = bmp12.GetPixel(x, y - 1);
                    Color w4 = bmp12.GetPixel(x, y + 1);
                    Color w = bmp12.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xg = w.R;
                    int xb = (int)(a[0] * xg);
                    xb = (int)(xb + a[1] * x1 + a[2] * x2 + a[3] * x3 + a[3] * x4);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox35.Image = bmp12;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox34.Image;
            float[] a = new float[10];
            a[1] = (float)0.1;
            a[2] = (float)0.1;
            a[3] = (float)0.1;
            a[4] = (float)0.1;
            a[5] = (float)0.2;
            a[6] = (float)0.1;
            a[7] = (float)0.1;
            a[8] = (float)0.1;
            a[9] = (float)0.1;
         //   objBitmap1 = new Bitmap(objBitmap);
            for (int x = 1; x < bmp12.Width - 1; x++)
                for (int y = 1; y < bmp12.Height - 1; y++)
                {
                    Color w1 = bmp12.GetPixel(x - 1, y - 1);
                    Color w2 = bmp12.GetPixel(x - 1, y);
                    Color w3 = bmp12.GetPixel(x - 1, y + 1);
                    Color w4 = bmp12.GetPixel(x, y - 1);
                    Color w5 = bmp12.GetPixel(x, y);
                    Color w6 = bmp12.GetPixel(x, y + 1);
                    Color w7 = bmp12.GetPixel(x + 1, y - 1);
                    Color w8 = bmp12.GetPixel(x + 1, y);
                    Color w9 = bmp12.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)(a[1] * x1 + a[2] * x2 + a[3] * x3);
                    xb = (int)(xb + a[4] * x4 + a[5] * x5 + a[6] * x6);
                    xb = (int)(xb + a[7] * x7 + a[8] * x8 + a[9] * x9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox36.Image = bmp12;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox37.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox37.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox37.Image;
            for (int x = 1; x < bmp12.Width - 1; x++)
                for (int y = 1; y < bmp12.Height - 1; y++)
                {
                    Color w1 = bmp12.GetPixel(x - 1, y - 1);
                    Color w2 = bmp12.GetPixel(x - 1, y);
                    Color w3 = bmp12.GetPixel(x - 1, y + 1);
                    Color w4 = bmp12.GetPixel(x, y - 1);
                    Color w5 = bmp12.GetPixel(x, y);
                    Color w6 = bmp12.GetPixel(x, y + 1);
                    Color w7 = bmp12.GetPixel(x + 1, y - 1);
                    Color w8 = bmp12.GetPixel(x + 1, y);
                    Color w9 = bmp12.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox39.Image = bmp12;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox37.Image;
            for (int x = 1; x < bmp12.Width - 1; x++)
                for (int y = 1; y < bmp12.Height - 1; y++)
                {
                    Color w1 = bmp12.GetPixel(x - 1, y - 1);
                    Color w2 = bmp12.GetPixel(x - 1, y);
                    Color w3 = bmp12.GetPixel(x - 1, y + 1);
                    Color w4 = bmp12.GetPixel(x, y - 1);
                    Color w5 = bmp12.GetPixel(x, y);
                    Color w6 = bmp12.GetPixel(x, y + 1);
                    Color w7 = bmp12.GetPixel(x + 1, y - 1);
                    Color w8 = bmp12.GetPixel(x + 1, y);
                    Color w9 = bmp12.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xb = (int)((x1 + x2 + x3 + x4 + 4 * x5 + x6 + x7 + x8 + x9) / 13);
                    if (xb < 0) xb = 0;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox39.Image = bmp12;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox37.Image;
            int[] xt = new int[10];
            for (int x = 1; x < bmp12.Width - 1; x++)
                for (int y = 1; y < bmp12.Height - 1; y++)
                {
                    Color w1 = bmp12.GetPixel(x - 1, y - 1);
                    Color w2 = bmp12.GetPixel(x - 1, y);
                    Color w3 = bmp12.GetPixel(x - 1, y + 1);
                    Color w4 = bmp12.GetPixel(x, y - 1);
                    Color w5 = bmp12.GetPixel(x, y);
                    Color w6 = bmp12.GetPixel(x, y + 1);
                    Color w7 = bmp12.GetPixel(x + 1, y - 1);
                    Color w8 = bmp12.GetPixel(x + 1, y);
                    Color w9 = bmp12.GetPixel(x + 1, y + 1);
                    xt[1] = w1.R;
                    xt[2] = w2.R;
                    xt[3] = w3.R;
                    xt[4] = w4.R;
                    xt[5] = w5.R;
                    xt[6] = w6.R;
                    xt[7] = w7.R;
                    xt[8] = w8.R;
                    xt[9] = w9.R;
                    for (int i = 1; i < 9; i++)
                        for (int j = 1; j < 9; j++)
                        {
                            if (xt[j] > xt[j + 1])
                            {
                                int a = xt[j];
                                xt[j] = xt[j + 1];
                                xt[j + 1] = a;
                            }
                        }
                    int xb = xt[5];
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox39.Image = bmp12;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Bitmap bmp12 = (Bitmap)pictureBox37.Image;
            for (int x = 0; x < bmp12.Width; x++)
                for (int y = 0; y < bmp12.Height; y++)
                {
                    Color w = bmp12.GetPixel(x, y);
                    int r = w.R;
                    int g = w.G;
                    int b = w.B;
                    int xg = (int)((r + g + b) / 3);
                    Color wb = Color.FromArgb(xg, xg, xg);
                    bmp12.SetPixel(x, y, wb);
                }
            pictureBox37.Image = bmp12;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Bitmap bmp6 = (Bitmap)pictureBox37.Image;
            Bitmap bmp7 = (Bitmap)pictureBox37.Image;

            // objBitmap1 = new Bitmap(objBitmap1);
            Random r = new Random();
            for (int x = 0; x < bmp6.Width; x++)
                for (int y = 0; y < bmp6.Height; y++)
                {
                    Color w = bmp6.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20)
                    {
                        int ns = r.Next(0, 256) - 128;
                        xb = (int)(xg + ns);
                        if (xb < 0) xb = -xb;
                        if (xb > 255) xb = 255;
                    }
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp7.SetPixel(x, y, wb);
                }
            pictureBox38.Image = bmp7;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            Bitmap bmp8 = (Bitmap)pictureBox37.Image;
            Bitmap bmp9 = (Bitmap)pictureBox37.Image;
            //objBitmap1 = new Bitmap(objBitmap);
            Random r = new Random();
            for (int x = 0; x < bmp8.Width; x++)
                for (int y = 0; y < bmp9.Height; y++)
                {
                    Color w = bmp8.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20) xb = 0;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp9.SetPixel(x, y, wb);
                }
            pictureBox38.Image = bmp9;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Bitmap bmp10 = (Bitmap)pictureBox37.Image;
            Bitmap bmp11 = (Bitmap)pictureBox37.Image;
            // objBitmap1 = new Bitmap(objBitmap);
            Random r = new Random();
            for (int x = 0; x < bmp10.Width; x++)
                for (int y = 0; y < bmp10.Height; y++)
                {
                    Color w = bmp10.GetPixel(x, y);
                    int xg = w.R;
                    int xb = xg;
                    int nr = r.Next(0, 100);
                    if (nr < 20) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    bmp11.SetPixel(x, y, wb);
                }
            pictureBox38.Image = bmp11;
        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void button51_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox40.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox40.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            int[] binRed = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue = new int[256];
            Bitmap bmp1 = (Bitmap)pictureBox40.Image;
            Color pixelColor;
            for (int y = 0; y < bmp1.Height; y++)
            {
                for (int x = 0; x < bmp1.Width; x++)
                {
                    pixelColor = bmp1.GetPixel(x, y);
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }
            }
            for (int i = 0; i < 255; i++)
            {
                this.chart2.Series["red"].Points.AddXY(i, binRed[i]);
                this.chart3.Series["green"].Points.AddXY(i, binGreen[i]);
                this.chart4.Series["blue"].Points.AddXY(i, binBlue[i]);
            }


        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
