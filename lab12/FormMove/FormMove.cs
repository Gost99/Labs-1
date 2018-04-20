using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormMove
{
    public partial class FormMove : Form
    {
        Graphics gr;
        double angle;
        int Xtext = 0, Ytext = 0;
        Pen pen = new Pen(Color.Blue, 3);
        PointF p1, p2, p3, p4, p5, p6, p7, p8, p9, k1, k2, k3, k4, k5, k6, k7, dop8, dop9;

        PointF[] points;
        PointF[] doppoints;
        public FormMove()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();
            gr.TranslateTransform(panel1.Width / 2, panel1.Height / 2);
            p1 = new PointF(20, 20);
            p2 = new PointF(30, 10);
            p3 = new PointF(80, 10);
            p4 = new PointF(90, 20);
            p5 = new PointF(90, 60);
            p6 = new PointF(80, 70);
            p7 = new PointF(30, 70);
            p8 = new PointF(20, 60);
            p9 = new PointF(20, 20);
            points = new PointF[] { p1, p2, p3, p4, p5, p6, p7, p8, p9 };
            doppoints = new PointF[] { k1, k2, k3, k4, k5, k6, k7, dop8, dop9 };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(SystemColors.Control);
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < 9; i++)
                    points[i].X = points[i].X + Convert.ToInt32(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < 9; i++)
                    points[i].X = points[i].X - Convert.ToInt32(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < 9; i++)
                    points[i].Y = points[i].Y - Convert.ToInt32(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 0; i < 9; i++)
                    points[i].Y = points[i].Y + Convert.ToInt32(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 4)
            {
                angle = Convert.ToDouble(textBox1.Text) * Math.PI / 180;
                for (int i = 0; i < 9; i++)
                {
                    doppoints[i].X = points[i].X * (float)Math.Cos(angle) - points[i].Y * (float)Math.Sin(angle);
                    doppoints[i].Y = points[i].X * (float)Math.Sin(angle) + points[i].Y * (float)Math.Cos(angle);
                }
                for (int i = 0; i < 9; i++)
                    points[i] = doppoints[i];
            }
            if (comboBox1.SelectedIndex == 5)
            {
                for (int i = 0; i < 9; i++)
                    points[i].X = -points[i].X;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                for (int i = 0; i < 9; i++)
                    points[i].Y = -points[i].Y;
            }
            gr.DrawLines(pen, points);
            gr.DrawLine(pen, points[8], points[0]);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            gr.Clear(SystemColors.Control);
            if (comboBox2.SelectedIndex == 0)
            {
                Xtext += Convert.ToInt32(textBox2.Text);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Xtext -= Convert.ToInt32(textBox2.Text);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                Ytext -= Convert.ToInt32(textBox2.Text);
            }
            if (comboBox2.SelectedIndex == 3)
            {
                Ytext += Convert.ToInt32(textBox2.Text);
            }
            Font font = new Font("Arial ", 32);
            gr.DrawString(textBox3.Text, font, new SolidBrush(Color.Black), Xtext, Ytext);
        }
        private void FormMove_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }
    }
}
