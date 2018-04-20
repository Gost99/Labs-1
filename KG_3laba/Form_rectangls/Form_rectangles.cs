using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Form_rectangls
{
    public partial class Form_rectangles : Form
    {
        public Form_rectangles()
        {
            InitializeComponent();
        }
        private void Form_rectangles_Paint(object sender, PaintEventArgs e)
        {
            float P = 0.08F;
            Graphics gr = this.CreateGraphics();
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            Random rand = new Random();
            Pen Third_random_Pen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255)), 3);
            Pen Second_Pen = new Pen(Color.Brown, 2);
            Pen Forth_random_Pen = new Pen(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255)), 3);
            Pen First_Pen = new Pen(Color.Tomato, 2);
            Pen[] Colors = { First_Pen, Second_Pen, Third_random_Pen, Forth_random_Pen };
            float x1 = 20, x2 = 20, y1 = 20, y2 = 400, x3 = 400, x4 = 400, y3 = 400, y4 = 20;
            int i = 1;
            gr.DrawLine(Colors[i % 3], x1, y1, x2, y2);
            gr.DrawLine(Colors[i % 4], x2, y2, x3, y3);
            gr.DrawLine(Colors[i % 3], x3, y3, x4, y4);
            gr.DrawLine(Colors[i % 4], x4, y4, x1, y1);
            for (i = 1; i <= 50; i++)
            {
                x1 = x1 + (x2 - x1) * P;
                y1 = y1 + (y2 - y1) * P;
                x2 = x2 + (x3 - x2) * P;
                y2 = y2 + (y3 - y2) * P;
                x3 = x3 + (x4 - x3) * P;
                y3 = y3 + (y4 - y3) * P;
                x4 = x4 + (x1 - x4) * P;
                y4 = y4 + (y1 - y4) * P;
                gr.DrawLine(Colors[i % 3], x1, y1, x2, y2);
                gr.DrawLine(Colors[i % 3], x2, y2, x3, y3);
                gr.DrawLine(Colors[i % 3], x3, y3, x4, y4);
                gr.DrawLine(Colors[i % 3], x4, y4, x1, y1);
            }
        }
    }
}
