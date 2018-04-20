using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float x, y,x1,x2,y1,y2,P=(float)0.08;
            Pen blackPen = new Pen(Color.Black, 3);
            x1 = 10;
            x2 = 100;
            y1 = 10;
             y2 = 100;
            e.Graphics.DrawRectangle(blackPen, x1, y1, x2, y2);
            for (int i = 0; i < 50; i++)
            {
                x = x1 + (x2 - x1) * P;
                y = y1 + (y2 - y1) * P;
                e.Graphics.DrawRectangle(blackPen, x1, y1, x2-x, y2-y);
                e.Graphics.RotateTransform(P);
                x1 = x;
                y1 = y;
            }
        }




























            // float x, y,t,k;
            // float x1 = 10, x2 = 100, y1 = 10, y2 = 100; 
            //float p = (float)0.08;
            // Pen redPen = new Pen(Color.Red, 5);
            // RectangleF[10] rects = new RectangleF[10](90,90,10,10);
            // e.Graphics.DrawRectangles(redPen, rects);
            // for(int i = 0; i < 49; i++)
            // {
            //     x = x1 + (x2 - x1) * p;
            //     y = y1 + (y2 - y1) * p;


            //     e.Graphics.DrawRectangle(redPen, x, y,);
            //     //x1 = x;
            //y1 = y;
        }
        }
    

