using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tolik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PointF[] p1 ={new PointF(120,10),new PointF(140,10),new PointF(160,30),new PointF(160,50),
                            new PointF(140,70),new PointF(120,70),new PointF(100,50),new PointF(100,30)};
        int X = 130;
        int Y = 40;
        float[] x = new float[8];
        float[] y = new float[8];
        int n = 1;
        int m = 1;
        int k = 1;
        int j = 1;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            Brush[] b = { Brushes.Green };
            label1.Text = "YA LYATAYU";
            label1.Location = new Point(label1.Location.X + m, label1.Location.Y + n);
            if (label1.Location.X + 80 >= this.ClientSize.Width)
                m = -m;
            if (label1.Location.Y + 10 >= this.ClientSize.Height)
                n = -n;
            if (label1.Location.Y <= 0)
                n = -n;
            if (label1.Location.X <= 0)
                m = -m;
            //
            float grad = (float)Math.PI / 180;
            for (int i = 0; i < 8; i++)
            {
                x[i] = p1[i].X - X;
                y[i] = p1[i].Y - Y;
                p1[i].X = X + x[i] * (float)Math.Cos(grad) - y[i] * (float)Math.Sin(grad);
                p1[i].Y = Y + x[i] * (float)Math.Sin(grad) + y[i] * (float)Math.Cos(grad);

            }
            gr.Clear(Color.White);
            gr.FillPolygon(b[0], p1);
            X = X + j;
            Y = Y + k;
            for (int i = 0; i < 8; i++)
            {
                p1[i].X = p1[i].X + j;
                p1[i].Y = p1[i].Y + k;
            }
            if ((p1[0].Y >= this.ClientSize.Height) || (p1[1].Y >= this.ClientSize.Height) || (p1[2].Y >= this.ClientSize.Height)
                || (p1[3].Y >= this.ClientSize.Height) || (p1[4].Y >= this.ClientSize.Height) || (p1[5].Y >= this.ClientSize.Height)
                || (p1[6].Y >= this.ClientSize.Height) || (p1[7].Y >= this.ClientSize.Height))
            {
                k = -k;
            }
            if ((p1[0].X >= this.ClientSize.Width) || (p1[1].X >= this.ClientSize.Width) || (p1[2].X >= this.ClientSize.Width)
               || (p1[3].X >= this.ClientSize.Width) || (p1[4].X >= this.ClientSize.Width) || (p1[5].X >= this.ClientSize.Width)
               || (p1[6].X >= this.ClientSize.Width) || (p1[7].X >= this.ClientSize.Width))
            {

                j = -j;
            }
            if ((p1[0].X <= 0) || (p1[1].X <= 0) || (p1[2].X <= 0) || (p1[3].X <= 0) || (p1[4].X <= 0) || (p1[5].X <= 0)
               || (p1[6].X <= 0) || (p1[7].X <= 0))
            {
                j = -j;
            }
            if ((p1[0].Y <= 0) || (p1[1].Y <= 0) || (p1[2].Y <= 0) || (p1[3].Y <= 0) || (p1[4].Y <= 0) || (p1[5].Y <= 0)
               || (p1[6].Y <= 0) || (p1[7].Y <= 0))
            {
                k = -k;
            }
        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
