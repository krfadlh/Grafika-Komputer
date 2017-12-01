using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] proyeksi = new int[500];
        int[] proyeksi2 = new int[500];

        private void button4_Click(object sender, EventArgs e)
        {
           // int diff = 0;
            int ver1 = 0;
            int hor1 = 0;
           // int diffTot = int.Parse(textBox2.Text) * int.Parse(textBox2.Text);
           // String text = "";
            String text2 = "";
           
            //float presentage = 0;

            for (int i = 0; i < (int.Parse(textBox2.Text)); i++)
            {
               /* diff += Math.Abs(proyeksi[i] - proyeksi3[i]);
                diff += Math.Abs(proyeksi2[i] - proyeksi4[i]);
                if (proyeksi[i] == 0 && proyeksi3[i] == 0)
                {
                    diffTot--;
                }
                else if (proyeksi2[i] == 0 && proyeksi4[i] == 0)
                {
                    diffTot--;
                } */
                ver1 += proyeksi3[i];
                hor1 += proyeksi4[i];

            }
            /*presentage = 100 - ((diff * 100) / diffTot);
            text = "" + presentage; */
            if (ver1 == 148 && hor1 == 148)
            {
                text2 = "ALIF";
            }
            else if (ver1 == 358 && hor1 == 358)
            {
                text2 = "BA / AIN";
            }
            else if (ver1 == 392 && hor1 == 392)
            {
                text2 = "TA";
            }
            else if (ver1 == 385 && hor1 == 385)
            {
                text2 = "TSA";
            }
            else if (ver1 == 374 && hor1 == 374)
            {
                text2 = "JIM";
            }
            else if (ver1 == 338 && hor1 == 338)
            {
                text2 = "HA";
            }
            else if (ver1 == 366 && hor1 == 366)
            {
                text2 = "KHA";
            }
            else if (ver1 == 220 && hor1 == 220)
            {
                text2 = "DAL";
            }
            else if (ver1 == 286 && hor1 == 286)
            {
                text2 = "DZAL";
            }
            else if (ver1 == 175 && hor1 == 175)
            {
                text2 = "RA";
            }
            else if (ver1 == 218 && hor1 == 218)
            {
                text2 = "ZA";
            }
            else if (ver1 == 494 && hor1 == 494)
            {
                text2 = "SIN";
            }
            else if (ver1 == 539 && hor1 == 539)
            {
                text2 = "SYIN";
            }
            else if (ver1 == 705 && hor1 == 714)
            {
                text2 = "SAD";
            }
            else if (ver1 == 751 && hor1 == 751)
            {
                text2 = "DAD";
            }
            else if (ver1 == 429 && hor1 == 429)
            {
                text2 = "THA";
            }
            else if (ver1 == 467 && hor1 == 467)
            {
                text2 = "DHA";
            }
            else if (ver1 == 406 && hor1 == 406)
            {
                text2 = "GHAYN";
            }
            else if (ver1 == 444 && hor1 == 444)
            {
                text2 = "FA";
            }
            else if (ver1 == 407 && hor1 == 407)
            {
                text2 = "QAF";
            }
            else if (ver1 == 436 && hor1 == 436)
            {
                text2 = "KAF";
            }
            else if (ver1 == 324 && hor1 == 324)
            {
                text2 = "LAM";
            }
            else if (ver1 == 284 && hor1 == 284)
            {
                text2 = "MIM";
            }
            else if (ver1 == 349 && hor1 == 349)
            {
                text2 = "NUN";
            }
            else if (ver1 == 396 && hor1 == 396)
            {
                text2 = "HA";
            }
            else if (ver1 == 233 && hor1 == 233)
            {
                text2 = "WAU";
            }
            else if (ver1 == 416 && hor1 == 416)
            {
                text2 = "YA";
            }

            //text22 = "" + ver1;
            //text3 = "" + hor1;
            label5.Text = text2;
            //label7.Text = text22;
            //label8.Text = text3;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            String text = "";
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                text += proyeksi2[i] + " ";
            }
            MessageBox.Show(text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String text = "";
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                text += proyeksi[i] + " ";
            }
            MessageBox.Show(text);
        }
        int[] proyeksi3 = new int[500];
        int[] proyeksi4 = new int[500];

        private void button10_Click(object sender, EventArgs e)
        {
            String text = "";
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                text += proyeksi4[i] + " ";
            }
            MessageBox.Show(text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String text = "";
            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                text += proyeksi3[i] + " ";
            }
            MessageBox.Show(text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png (*.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox4.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Color pixelColor;
            int count = 0;
            int total = 0;
            int num = 0;

            Bitmap source = (Bitmap)pictureBox4.Image;
            int blokH = source.Height / int.Parse(textBox2.Text);
            int sisaH = source.Height - (blokH * int.Parse(textBox2.Text));
            int blokW = source.Width / int.Parse(textBox2.Text);
            int sisaW = source.Width - (blokW * int.Parse(textBox2.Text));
            int startH = 0;
            int finishH = blokH;
            if (sisaH > 0)
            {
                finishH++;
                sisaH--;
            }
            int startW = 0;
            int finishW = 0;

            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                num = 0;
                finishW = blokW;
                if (sisaW > 0)
                {
                    finishW++;
                    sisaW--;
                }
                for (int j = 0; j < int.Parse(textBox2.Text); j++)
                {
                    total = 0;
                    count = 0;
                    for (int y = startH; y < finishH; y++)
                    {
                        for (int x = startW; x < finishW; x++)
                        {
                            total++;
                            pixelColor = source.GetPixel(x, y);
                            int red = pixelColor.R;
                            int green = pixelColor.G;
                            int blue = pixelColor.B;
                            int rata = (int)(red + green + blue) / 3;
                            if (rata < 128)
                            {
                                count++;
                            }
                        }
                    }

                    startW = finishW;
                    if (sisaW > 0)
                    {
                        finishW = finishW + blokW + 1;
                        sisaW--;
                    }
                    else
                    {
                        finishW = finishW + blokW;
                    }

                    if (count > (total / 2))
                    {
                        num++;
                    }

                }

                startH = finishH;
                if (sisaH > 0)
                {
                    finishH = finishH + blokH + 1;
                    sisaH--;
                }
                else
                {
                    finishH = finishH + blokH;
                }

                proyeksi3[i] = num;
            }

            Bitmap bmp = new Bitmap(int.Parse(textBox2.Text), int.Parse(textBox2.Text));
            for (int y = 0; y < int.Parse(textBox2.Text); y++)
            {
                for (int x = 0; x < proyeksi3[y]; x++)
                {
                    bmp.SetPixel(x, y, Color.Black);
                }

            }
            pictureBox5.Image = bmp;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Color pixelColor;
            int count = 0;
            int total = 0;
            int num = 0;

            Bitmap source = (Bitmap)pictureBox4.Image;
            int blokH = source.Height / int.Parse(textBox2.Text);
            int sisaH = source.Height - (blokH * int.Parse(textBox2.Text));
            int blokW = source.Width / int.Parse(textBox2.Text);
            int sisaW = source.Width - (blokW * int.Parse(textBox2.Text));
            int startW = 0;
            int finishW = blokW;
            if (sisaW > 0)
            {
                finishW++;
                sisaW--;
            }
            int startH = 0;
            int finishH = 0;

            for (int i = 0; i < int.Parse(textBox2.Text); i++)
            {
                num = 0;
                finishH = blokH;
                if (sisaH > 0)
                {
                    finishH++;
                    sisaH--;
                }
                for (int j = 0; j < int.Parse(textBox2.Text); j++)
                {
                    total = 0;
                    count = 0;
                    for (int y = startW; y < finishW; y++)
                    {
                        for (int x = startH; x < finishH; x++)
                        {
                            total++;
                            pixelColor = source.GetPixel(y, x);
                            int red = pixelColor.R;
                            int green = pixelColor.G;
                            int blue = pixelColor.B;
                            int rata = (int)(red + green + blue) / 3;
                            if (rata < 128)
                            {
                                count++;
                            }
                        }
                    }

                    startH = finishH;
                    if (sisaH > 0)
                    {
                        finishH = finishH + blokH + 1;
                        sisaH--;
                    }
                    else
                    {
                        finishH = finishH + blokH;
                    }

                    if (count > (total / 2))
                    {
                        num++;
                    }

                }

                startW = finishW;
                if (sisaW > 0)
                {
                    finishW = finishW + blokW + 1;
                    sisaW--;
                }
                else
                {
                    finishW = finishW + blokW;
                }

                proyeksi4[i] = num;
            }

            Bitmap bmp = new Bitmap(int.Parse(textBox2.Text), int.Parse(textBox2.Text));
            for (int y = 0; y < int.Parse(textBox2.Text); y++)
            {
                for (int x = 0; x < proyeksi4[y]; x++)
                {
                    bmp.SetPixel(y, x, Color.Black);
                }

            }
            pictureBox6.Image = bmp;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
