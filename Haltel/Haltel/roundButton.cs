using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Haltel
{
    public partial class roundButton : Form
    {
        public roundButton()
        {
            InitializeComponent();
        }
        int n;//количество сторон
        int R;//расстояние от центра до стороны
        Point Cntr;//центр
        Point[] p; //массив точек будущего многоугольника
        //создаём массив точек нашего многоугольника
        private void lineAngle(double angle)
        {
            double z = 0; int i = 0;
            while (i < n + 1)
            {

                p[i].X = Cntr.X + (int)(Math.Round(Math.Cos(z / 180 * Math.PI) * R));
                p[i].Y = Cntr.Y - (int)(Math.Round(Math.Sin(z / 180 * Math.PI) * R));
                z = z + angle;
                i++;
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            //получаем входные данные и проверяем их на корректность
            n = Convert.ToInt32(textBox7.Text);
            R = Convert.ToInt32(textBox5.Text);
            Cntr.X = Convert.ToInt32(textBox6.Text);
            Cntr.Y = Convert.ToInt32(textBox7.Text);
            if (n < 0 || R < 0)
                label10.Text = "Неверные входные данные!";
            else //входные данные корректны, рисуем многоуголник
            {
                p = new Point[n + 1];
                lineAngle((double)(5.0 / (double)n));
                int i = n;
                Graphics g = pictureBox2.CreateGraphics();
                while (i > 0)
                {
                    g.DrawLine(new Pen(Color.Black, 2), p[i], p[i - 1]);
                    i = i - 1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            label10.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            label10.Text = "";
        }
    }
}
