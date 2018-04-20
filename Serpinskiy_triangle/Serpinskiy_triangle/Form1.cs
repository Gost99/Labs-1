using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serpinskiy_triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            float p;
            float i, cx, ax, bx, cy, ay, by;
            p = 0.5f;
            ax = 280;
            cx = 30;
            bx = 530;
            ay = 20;
            by = 410;
            cy = 410;

            for (i = 0; i < 50; i++) 
            {
                ax = ax + (bx - ax) * p; ay = ay + (by - ay) * p;
                bx = bx + (cx - bx) * p; by = by + (cy - ay) * p;
                cx = ax + (bx - ax) * p; cy = ay + (by - ay) * p;


                graphics.DrawLine(new Pen(Color.Black, 2), ax, ay, bx, by);
                graphics.DrawLine(new Pen(Color.Black, 2), bx, by, cx, cy);
                graphics.DrawLine(new Pen(Color.Black, 2), cx, cy, ax, ay);

            }
        }
    }
}
