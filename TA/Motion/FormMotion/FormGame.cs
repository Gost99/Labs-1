using System;
using System.Drawing;
using System.Windows.Forms;
namespace FormMotion
{
    public partial class FormGame : Form
    {
        PointF p;
        bool left, right, up, down, left1, right1, up1, down1;
        PointF p1;
        RectangleF rect1;
        RectangleF rect2;
        Timer Mover = new Timer();
        public FormGame()
        {
            KeyPreview = true;
            InitializeComponent();
            Mover.Interval = 10;
            Mover.Tick += timer1_Tick;
            Mover.Start();
            p = new PointF(10, 10);
            p1 = new PointF(1000, 10);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr;
            gr = this.CreateGraphics();
            Pen pen2 = new Pen(Color.Red, 6);
            rect1 = new RectangleF(p.X, p.Y, 90, 70);
            rect2 = new RectangleF(p1.X, p1.Y, 90, 70);
            gr.DrawLine(pen2, 400, 110, 400,500);
            gr.DrawLine(pen2,400,500,700,500);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = 90;
            int w = 70;
            Graphics gr;
            Pen pen = new Pen(Color.Black, 6);
            Pen pen1 = new Pen(Color.White, 6);
            gr = this.CreateGraphics();
            if (rect1.X <= 0)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X + 35, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X >= 1200)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X - 35, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.Y <= 0)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X, rect1.Y + 35, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.Y >= 900)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X, rect1.Y - 35, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect2.X <= 0)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X + 40, rect2.Y, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X >= 1200)
            {

                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X - 40, rect2.Y, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
                if (rect2.Y <= 0)
                {
                    gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                    rect2 = new RectangleF(rect2.X, rect2.Y + 40, a, w);
                    gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
                }
                if (rect2.Y >= 900)
                {
                    gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                    rect2 = new RectangleF(rect2.X, rect2.Y - 40, a, w);
                    gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
                }
            if (rect1.X <= 420&&rect1.X>=400&&rect1.Y<=545&&rect1.Y>=65)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X + 35, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X >= 290&&rect1.X<=320&&rect1.Y<=545&&rect1.Y>=65)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X - 35, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X>=325&&rect1.X<405&&rect1.Y <= 20&&rect1.Y>=0)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X, rect1.Y - 35, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X>=400&&rect1.X<=700 &&rect1.Y<=420 &&rect1.Y >= 400)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X, rect1.Y - 35, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X <= 700&&rect1.X>=400&&rect1.Y>=500&&rect1.Y<=520)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X , rect1.Y + 35, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect1.X > 700 && rect1.X <= 720 && rect1.Y >= 410 && rect1.Y <= 500)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X + 40, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (rect2.X <= 420 && rect2.X >= 400 && rect2.Y <= 545 && rect2.Y >= 65)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X + 35, rect2.Y, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X >= 290 && rect2.X <= 320 && rect2.Y <= 545 && rect2.Y >= 65)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X - 35, rect2.Y, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X >= 325 && rect2.X < 405 && rect2.Y <= 20 && rect2.Y >= 0)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X, rect2.Y - 35, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X >= 400 && rect2.X <= 700 && rect2.Y <= 420 && rect2.Y >= 400)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X, rect2.Y - 35, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X <= 700 && rect2.X >= 400 && rect2.Y >= 500 && rect2.Y <= 520)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect1 = new RectangleF(rect2.X, rect2.Y + 35, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (rect2.X > 700 && rect2.X <= 720 && rect2.Y >= 410 && rect2.Y <= 500)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X + 40, rect2.Y, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
        }
        public void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
            if (rect1.IntersectsWith(rect2))
            {
                MessageBox.Show("Player 2 win! ");
                Environment.Exit(0);
            }
            int a = 90;
            int w = 70;
            Graphics gr;
            gr = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 6);
            Pen pen1 = new Pen(Color.White,6);
            switch (e.KeyCode)
            {
                case Keys.Up: { up = true; break; }
                case Keys.Down: { down = true; break; }
                case Keys.Left: { left = true; break; }
                case Keys.Right: { right = true; break; }
                case Keys.W: { up1 = true; break; }
                case Keys.S: { down1 = true; break; }
                case Keys.A: { left1 = true; break; }
                case Keys.D: { right1 = true; break; }
            }
            if (up)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X , rect1.Y-15, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (down)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X , rect1.Y+15, a, w);
                gr.DrawRectangle(pen, rect1.X , rect1.Y , 90, 70);      
            }
            if (left)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X - 15, rect1.Y, a, w);
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (right)
            {
                gr.DrawRectangle(pen1, rect1.X, rect1.Y, 90, 70);
                rect1 = new RectangleF(rect1.X + 15, rect1.Y, a, w);  
                gr.DrawRectangle(pen, rect1.X, rect1.Y, 90, 70);
            }
            if (up1)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X, rect2.Y - 20, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (down1)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X, rect2.Y + 20, a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (left1)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X - 20, rect2.Y , a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);
            }
            if (right1)
            {
                gr.DrawRectangle(pen1, rect2.X, rect2.Y, 90, 70);
                rect2 = new RectangleF(rect2.X + 20, rect2.Y , a, w);
                gr.DrawRectangle(pen, rect2.X, rect2.Y, 90, 70);           
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) 
        {
            switch (e.KeyCode)
            {
                case Keys.Up: { up = false; break; }
                case Keys.Down: { down = false; break; }
                case Keys.Left: { left = false; break; }
                case Keys.Right: { right = false; break; }
                case Keys.W: { up1 = false; break; }
                case Keys.S: { down1 = false; break; }
                case Keys.A: { left1 = false; break; }
                case Keys.D: { right1 = false; break; }
            }
        }
    }
}
