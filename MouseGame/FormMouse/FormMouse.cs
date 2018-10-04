using System;
using System.Drawing;
using System.Windows.Forms;
namespace FormMouse
{
    public partial class FormMouse : Form
    {
        int help = 0;
        bool move,move1,move2;
        PointF p,p1,p2;
        PointF t1,t2,t3;
        RectangleF rect1;
        Timer Mover = new Timer();
        public FormMouse()
        {
            InitializeComponent();
            Mover.Interval = 300;  
            Mover.Tick += timer1_Tick;
            Mover.Start();
            p = new PointF(10, 10);
            p1 = new PointF(10, 300);
            p2 = new PointF(10, 500);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            rect1 = new RectangleF(p.X, p.Y, 90, 70);
            graph.DrawRectangle(pen, p.X , p.Y ,50,50);
            Pen sym = new Pen(Color.Red, 5);
            PointF[] points = new PointF[3];
            points[0] = new PointF(p1.X, p1.Y);
            points[1] = new PointF(p1.X + 30, p1.Y - 50);
            points[2] = new PointF(p1.X + 60, p1.Y);
            PointF[] points1 = new PointF[6];
            points1[0] = new PointF(p2.X, p2.Y);
            points1[1] = new PointF(p2.X+20, p2.Y-20);
            points1[2] = new PointF(p2.X+40, p2.Y-20);
            points1[3] = new PointF(p2.X+60, p2.Y);
            points1[4] = new PointF(p2.X+40, p2.Y+20);
            points1[5] = new PointF(p2.X+20, p2.Y+20);
            graph.DrawPolygon(pen, points1);
            graph.DrawPolygon(pen,points);
            graph.DrawLine(sym, 200, 200, 400, 200);
            graph.DrawLine(sym, 200, 100, 500, 100);
            graph.DrawLine(sym, 400, 200, 400, 600);
            graph.DrawLine(sym, 500, 100, 500, 500);
            graph.DrawLine(sym, 400, 600, 700, 600);
            graph.DrawLine(sym, 500, 500, 700, 500);      
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p.X < -20)
            {
                p.X = p.X + 5;
            }
            if (p.X >= 1190)
            {
                p.X = p.X - 5;
            }
            if (p.Y < -10)
            {
                p.Y = p.Y + 5;
            }
            if (p.Y >= 900)
            {
                p.Y = p.Y - 5;
            }
            if (help == 0)
            {
                if (p.X >= 395 && p.X <= 405 && p.Y >= 150 && p.Y <= 600 || p.X >= 445 && p.X <= 455 && p.Y >= 100 && p.Y <= 500 || p.Y >= 95 && p.Y <= 105 && p.X >= 150 && p.X <= 500 || p.Y >= 145 && p.Y <= 155 && p.X >= 150 && p.X <= 400 || p.Y >= 545 && p.Y <= 555 && p.X >= 350 && p.X <= 700 || p.Y >= 495 && p.Y <= 505 && p.X <= 700 && p.X >= 450)
                {
                    help++;
                    MessageBox.Show("Sorry, you lose))");
                    Close();
                }
                if (p.X >= 705) { 
                help++;
                MessageBox.Show("Congratulations,you are win))");
                    Close();
                }
         
                if ((p2.X - p1.X - 30) / (p1.X + 60 - p1.X - 30) == ((p2.Y -p1.Y+50) / (p2.Y-p1.Y+50))){
                    p2.X = p2.X + 30;
                    p1.X = p1.X - 30;
                }
            }
            /*this.*/
            Invalidate();  // use if you doesnt use sync paint,its invalidate picture
        }
        public void Intersection(double ax1, double ay1, double ax2, double ay2, double bx1, double by1, double bx2, double by2)
        {
            double v1, v2, v3, v4;
            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            bool res = (v1 * v2 < 0) && (v3 * v4 < 0);
            if (res) {
                p2.X = p2.X + 30;
                p1.X=p1.X-30;
            }
        }
        public void Intersection1(double ax1, double ay1, double ax2, double ay2, double bx1, double by1, double bx2, double by2)
        {
            double v1, v2, v3, v4;
            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            bool res = (v1 * v2 < 0) && (v3 * v4 < 0);
            if (res)
            {
                p2.X = p2.X - 30;
                p1.X = p1.X + 30;
            }
        }
        public void Intersection2(double ax1, double ay1, double ax2, double ay2, double bx1, double by1, double bx2, double by2)
        {
            double v1, v2, v3, v4;
            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);
            bool res = (v1 * v2 < 0) && (v3 * v4 < 0);
            if (res)
            {
                p2.Y = p2.Y + 30;
                p1.Y = p1.Y - 30;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)     // pointer on  ,click  
        {
            if (e.Button == MouseButtons.Left)
            {
                t1 = new Point(e.X, e.Y);
                if (e.X > rect1.X && e.X < rect1.X +50 && e.Y > rect1.Y && e.Y < rect1.Y + 50)
                    move = true;
            }
            if (e.Button == MouseButtons.Left)
            {
                t2 = new Point(e.X, e.Y);
                if (e.X > p1.X && e.X < p1.X + 60 && e.Y < p1.Y && e.Y > p1.Y -50)
                move1 = true;
            }
            if (e.Button == MouseButtons.Left)
            {
                t3 = new Point(e.X, e.Y);
                if (e.X > p2.X && e.X < p2.X + 60 && e.Y < p2.Y+20 && e.Y > p2.Y-20|| e.X > p2.X+20 && e.X < p2.X + 40 && e.Y < p2.Y + 20 && e.Y > p2.Y - 20|| e.X > p2.X+40&& e.X < p2.X + 60 && e.Y < p2.Y + 20 && e.Y > p2.Y - 20)
                move2 = true;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)  // pointer on ,move
        {
            if (move)
            {
                p.X += e.X - t1.X;
                p.Y += e.Y - t1.Y;
                t1 = e.Location;
            }
            if (move1)
            {
                p1.X += e.X - t2.X;
                p1.Y += e.Y - t2.Y;
                t2 = e.Location;
            }
            if (move2)
            {
                p2.X += e.X - t3.X;
                p2.Y += e.Y - t3.Y;
                t3 = e.Location;
            }
            if (move2 || move1)
            {
                Intersection(p2.X, p2.Y, p2.X + 20, p2.Y - 20, p1.X+60, p1.Y, p1.X + 30, p1.Y - 50);
                Intersection(p2.X, p2.Y, p2.X + 20, p2.Y + 20, p1.X+60, p1.Y, p1.X + 30, p1.Y - 50);
                Intersection1(p2.X+40, p2.Y-20, p2.X + 60, p2.Y, p1.X, p1.Y, p1.X + 30, p1.Y - 50);
                Intersection1(p2.X+60, p2.Y, p2.X + 40, p2.Y + 20, p1.X, p1.Y, p1.X + 30, p1.Y - 50);
                Intersection2(p2.X + 20, p2.Y-20, p2.X + 40, p2.Y-20, p1.X, p1.Y, p1.X + 60, p1.Y);
                Intersection2(p2.X + 60, p2.Y, p2.X + 40, p2.Y - 20, p1.X, p1.Y, p1.X + 60, p1.Y);
                Intersection2(p2.X + 20, p2.Y-20, p2.X , p2.Y, p1.X, p1.Y, p1.X + 60, p1.Y);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)  // after we left our pointer
        {
            move = false;
            move1 = false;
            move2 = false;
        }
    }
}
    