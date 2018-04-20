using System;
using System.Drawing;
using System.Windows.Forms;
namespace Polygon
{
    public partial class PolygonForm : Form
    {
        public PolygonForm()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int radius = 250;
            int x0 = 300;
            int y0 = 300;
            int x, y;
            Point[] points = new Point[n];
            for (int i = 0; i <= n - 1; i++){
                x = x0 + Convert.ToInt16(radius * Math.Cos(2 * i * Math.PI / n)); // x=x0+r*cos(alpha)
                y = y0 + Convert.ToInt16(radius * Math.Sin(2 * i * Math.PI / n)); 
                points[i] = new Point(x, y);
            }
            for (int i = 0; i <= n - 1; i++){
                if (n == 2)
                {
                    Cut(points[0], points[1]);
                }
                else
                {
                    if (i == 0)
                    {
                        Draw(points[1], points[0], points[n - 1]);
                    }
                    else
                    {
                        if (i == n - 1)
                        {
                            Draw(points[i - 1], points[i], points[0]);
                        }
                        else
                        {
                            Draw(points[i - 1], points[i], points[i + 1]);
                        }
                    }
                }
            }
        }
        void Cut(PointF p1, PointF p2)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen,50,270,550,270);
            g.DrawLine(pen, 50, 330, 550, 330);
            g.DrawArc(pen, 20, 270, 60, 60, 90, 180); 
            g.DrawArc(pen, 520, 270, 60, 60, 270, 180);
        }
        void Draw(PointF p1, PointF p2, PointF d3)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            float x1 = (p1.X + p2.X) / 2;
            float y1 = (p1.Y + p2.Y) / 2;
            float x2 = (p2.X + d3.X) / 2;
            float y2 = (p2.Y + d3.Y) / 2;
            g.DrawBezier(pen, x1, y1, p2.X, p2.Y, p2.X, p2.Y, x2, y2);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
        }
    }
}
