using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Praktikum2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(100, 50);
            Color merah = Color.FromArgb(255, 0, 0);
            Color putih = Color.FromArgb(255, 255, 255);
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 50; x++)
                {
                    bmp1.SetPixel(x, y, merah);
                }
            }
            for (int y = 25; y < 50; y++)
            {
                for (int x = 50; x < 100; x++)
                {
                    bmp1.SetPixel(x, y, putih);
                }
            }
            pictureBox5.Image = new Bitmap(bmp1.Height, bmp1.Width);
            pictureBox5.Image = bmp1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number1, number2, number3;
            Int32.TryParse(tb_1.Text, out number1);
            Int32.TryParse(tb_2.Text, out number2);
            Int32.TryParse(tb_3.Text, out number3);
            //panel4.BackColor = Color.FromArgb(number1, number2, number3);
            Bitmap bitCampur = new Bitmap(100, 100);

            Bitmap bitRed = new Bitmap(100, 50);
            Bitmap bitGreen = new Bitmap(100, 50);
            Bitmap bitBlue = new Bitmap(100, 50);
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
            Color campur = Color.FromArgb(number1, number2, number3);

            for (int y = 0; y < 50; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    bitRed.SetPixel(x, y, red);
                    bitGreen.SetPixel(x, y, green);
                    bitBlue.SetPixel(x, y, blue);
                    bitCampur.SetPixel(x, y, campur);
                }
            }

            pictureBox1.Image = new Bitmap(bitRed.Height, bitRed.Width);
            pictureBox1.Image = bitRed;
            pictureBox2.Image = new Bitmap(bitGreen.Height, bitGreen.Width);
            pictureBox2.Image = bitGreen;
            pictureBox3.Image = new Bitmap(bitBlue.Height, bitBlue.Width);
            pictureBox3.Image = bitBlue;
            pictureBox4.Image = new Bitmap(bitCampur.Height, bitCampur.Width);
            pictureBox4.Image = bitCampur;

        }
    }
}
