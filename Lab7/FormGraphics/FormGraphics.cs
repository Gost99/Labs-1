using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace FormGraphics
{
    public partial class FormGraphics : Form
    {
        public FormGraphics()
        {
            InitializeComponent();
        }
        private void FormGraphics_Paint(object sender, PaintEventArgs e)
        {
            Pen pen2 = new Pen(Color.Black, 4);
            Graphics g = e.Graphics;
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
        }
        private void buttonSin_Click(object sender, EventArgs e)
        {
            DrawSin(80, 270, 3);
        }
        private void DrawSin(int x, int y, int n)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            Pen pen2 = new Pen(Color.Black, 4);
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
            Pen pen1 = new Pen(Color.Green, 3);
            int x1 = x;
            int y1 = y;
            int x2 = x + 50;
            int y2 = y - 75;
            int x3 = x + 150;
            int y3 = y + 75;
            int x4 = x + 200;
            int y4 = y;
            if (n > 0)
                DrawSin(x + 200, y, n - 1);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            Point[] curvePoints = { point1, point2, point3, point4 };
            g.DrawCurve(pen1, curvePoints);
        }
        private void buttonCos_Click(object sender, EventArgs e)
        {
            DrawCos(130, 270, 3);
        }
        private void DrawCos(int x, int y, int n)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            Pen pen2 = new Pen(Color.Black, 4);
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
            Pen pen1 = new Pen(Color.Red, 3);
            int x1 = x;
            int y1 = y;
            int x2 = x + 50;
            int y2 = y + 75;
            int x3 = x + 150;
            int y3 = y - 75;
            int x4 = x + 200;
            int y4 = y;
            if (n > 0)
            DrawCos(x + 200, y, n - 1);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            Point[] curvePoints = { point1, point2, point3, point4 };
            g.DrawCurve(pen1, curvePoints);
        }
        private void buttonTg_Click(object sender, EventArgs e)
        {
            DrawTan(280, 270, 4);
        }
        private void DrawTan(int x, int y, int n)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            Pen pen2 = new Pen(Color.Black, 4);
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
            Pen pen3 = new Pen(Color.Black, 2);
            pen3.DashStyle = DashStyle.Dash;
            Pen pen1 = new Pen(Color.Blue, 3);
            int x1 = x - 45;
            int y1 = y + 200;
            int x2 = x - 45;
            int y2 = y;
            int x3 = x + 45;
            int y3 = y;
            int x4 = x + 45;
            int y4 = y - 200;
            if (n > 0)
                DrawTan(x + 100, y, n - 1);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            g.DrawBezier(pen1, point1, point2, point3, point4);
            g.DrawLine(pen3, x - 50, y - 270, x - 50, y + 300);
        }
        private void buttonCtg_Click(object sender, EventArgs e)
        {
            DrawCTan(280, 270, 4);
        }
        private void DrawCTan(int x, int y, int n)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            Pen pen2 = new Pen(Color.Black, 4);
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
            Pen pen3 = new Pen(Color.Black, 2);
            pen3.DashStyle = DashStyle.Dash;
            Pen pen1 = new Pen(Color.Chocolate, 3);
            int x1 = x - 45;
            int y1 = y - 200;
            int x2 = x - 45;
            int y2 = y;
            int x3 = x + 45;
            int y3 = y;
            int x4 = x + 45;
            int y4 = y + 200;
            if (n > 0)
                DrawCTan(x + 100, y, n - 1);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            g.DrawBezier(pen1, point1, point2, point3, point4);
            g.DrawLine(pen3, x - 50, y - 270, x - 50, y + 300);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            Pen pen2 = new Pen(Color.Black, 4);
            g.DrawLine(pen2, 480, 0, 480, 6000);
            g.DrawLine(pen2, 0, 270, 10000, 270);
        }
    }
}
