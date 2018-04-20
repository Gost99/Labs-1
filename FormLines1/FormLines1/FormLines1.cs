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
namespace FormLines1
{
    public partial class FormLines1 : Form
    {
        public FormLines1()
        {
            InitializeComponent();
        }
        private void FormLines1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = CreateGraphics();
            Pen redPen = new Pen(Color.Red, 5);
            redPen.DashStyle = DashStyle.Dash;
            Pen greenPen = new Pen(Color.Green, 5);
            greenPen.DashStyle = DashStyle.Dot;
            Pen yellowPen = new Pen(Color.Yellow, 5);
            gr.DrawLine(redPen, 10, 10, 50, 10);
            e.Graphics.DrawLine(redPen, 10, 10, 10, 100);
            e.Graphics.DrawLine(redPen, 10, 100, 50, 100);
            e.Graphics.DrawLine(redPen, 60, 10, 60, 100);
            e.Graphics.DrawLine(redPen, 60, 100, 100, 10);
            e.Graphics.DrawLine(redPen, 100, 10, 100, 100);
            e.Graphics.DrawLine(redPen, 110, 10, 110, 100);
            e.Graphics.DrawLine(redPen, 110, 10, 130, 50);
            e.Graphics.DrawLine(redPen, 130, 50, 150, 10);
            e.Graphics.DrawLine(redPen, 150, 10, 150, 100);
            e.Graphics.DrawEllipse(redPen, 160, 10, 40, 90);
            e.Graphics.DrawLine(redPen, 210, 10, 210, 100);
            e.Graphics.DrawLine(redPen, 210, 55, 250, 55);
            e.Graphics.DrawLine(redPen, 250, 10, 250, 100);
            e.Graphics.DrawLine(redPen, 260, 10, 260, 100);
            e.Graphics.DrawLine(redPen, 260, 10, 300, 10);
            e.Graphics.DrawLine(redPen, 260, 55, 300, 55);
            e.Graphics.DrawLine(redPen, 260, 100, 300, 100);
            e.Graphics.DrawLine(redPen, 310, 10, 310, 100);
            e.Graphics.DrawLine(redPen, 310, 55, 350, 55);
            e.Graphics.DrawLine(redPen, 350, 10, 350, 100);
            e.Graphics.DrawLine(redPen, 360, 10, 360, 100);
            e.Graphics.DrawLine(redPen, 360, 55, 400, 100);
            e.Graphics.DrawLine(redPen, 360, 55, 400, 10);
            e.Graphics.DrawEllipse(redPen, 400, 10, 40, 90);
            //Rectangle rect = new Rectangle();
            e.Graphics.DrawLine(greenPen, 10, 110, 10, 200);
            e.Graphics.DrawArc(greenPen, -5, 110, 45, 40, 0.0F, 110.0F);
            e.Graphics.DrawArc(greenPen, -5, 110, 45, 40, 250.0F, 110.0F);
            e.Graphics.DrawArc(greenPen, -5, 150, 60, 50, 0.0F, 130.0F);
            e.Graphics.DrawArc(greenPen, -5, 150, 60, 50, 230.0F, 130.0F);
            e.Graphics.DrawLine(greenPen, 60, 200, 80, 110);
            e.Graphics.DrawLine(greenPen, 80, 110, 100, 200);
            e.Graphics.DrawLine(greenPen, 110, 200, 130, 110);
            e.Graphics.DrawLine(greenPen, 130, 110, 150, 200);
            e.Graphics.DrawLine(greenPen, 115, 175, 145, 175);
            e.Graphics.DrawLine(greenPen, 160, 200, 160, 175);
            e.Graphics.DrawLine(greenPen, 200, 200, 200, 175);
            e.Graphics.DrawLine(greenPen, 160, 175, 200, 175);
            e.Graphics.DrawLine(greenPen, 170, 175, 180, 110);
            e.Graphics.DrawLine(greenPen, 190, 175, 180, 110);
            e.Graphics.DrawLine(greenPen, 210, 110, 210, 200);
            e.Graphics.DrawLine(greenPen, 210, 200, 250, 110);
            e.Graphics.DrawLine(greenPen, 250, 110, 250, 200);
            e.Graphics.DrawArc(greenPen, 260, 110, 40, 90, 55.0F, 250.0F);
            e.Graphics.DrawLine(greenPen, 310, 200, 330, 110);
            e.Graphics.DrawLine(greenPen, 330, 110, 350, 200);
            e.Graphics.DrawLine(greenPen, 360, 200, 380, 110);
            e.Graphics.DrawLine(greenPen, 380, 110, 400, 200);
            e.Graphics.DrawLine(greenPen, 365, 175, 395, 175);
            e.Graphics.DrawLine(greenPen, 410, 110, 410, 200);
            e.Graphics.DrawArc(greenPen, 395, 110, 45, 40, 0.0F, 110.0F);
            e.Graphics.DrawArc(greenPen, 395, 110, 45, 40, 250.0F, 110.0F);
            e.Graphics.DrawArc(greenPen, 395, 150, 60, 50, 0.0F, 130.0F);
            e.Graphics.DrawArc(greenPen, 395, 150, 60, 50, 230.0F, 130.0F);
            e.Graphics.DrawLine(yellowPen, 10, 210, 10, 300);
            e.Graphics.DrawLine(yellowPen, 10, 210, 30, 250);
            e.Graphics.DrawLine(yellowPen, 30, 250, 50, 210);
            e.Graphics.DrawLine(yellowPen, 50, 210, 50, 300);
            e.Graphics.DrawLine(yellowPen, 60, 210, 60, 300);
            e.Graphics.DrawLine(yellowPen, 60, 300, 100, 210);
            e.Graphics.DrawLine(yellowPen, 100, 210, 100, 300);
            e.Graphics.DrawLine(yellowPen, 110, 300, 150, 210);
            e.Graphics.DrawLine(yellowPen, 110, 210, 150, 300);
            e.Graphics.DrawLine(yellowPen, 160, 300, 180, 210);
            e.Graphics.DrawLine(yellowPen, 180, 210, 200, 300);
            e.Graphics.DrawLine(yellowPen, 165, 275, 195, 275);
            e.Graphics.DrawLine(yellowPen, 210, 210, 210, 300);
            e.Graphics.DrawLine(yellowPen, 210, 300, 250, 210);
            e.Graphics.DrawLine(yellowPen, 250, 210, 250, 300);
            e.Graphics.DrawLine(yellowPen, 217, 205, 243, 205);
            e.Graphics.DrawLine(yellowPen, 260, 300, 280, 210);
            e.Graphics.DrawLine(yellowPen, 280, 210, 300, 300);
            e.Graphics.DrawEllipse(yellowPen, 310, 210, 40, 90);
            e.Graphics.DrawLine(yellowPen, 360, 210, 360, 300);
            e.Graphics.DrawArc(yellowPen, 345, 210, 45, 40, 0.0F, 110.0F);
            e.Graphics.DrawArc(yellowPen, 345, 210, 45, 40, 250.0F, 110.0F);
            e.Graphics.DrawArc(yellowPen, 345, 250, 60, 50, 0.0F, 130.0F);
            e.Graphics.DrawArc(yellowPen, 345, 250, 60, 50, 230.0F, 130.0F);
            e.Graphics.DrawLine(yellowPen, 415, 210, 415, 300);
            e.Graphics.DrawLine(yellowPen, 415, 300, 455, 210);
            e.Graphics.DrawLine(yellowPen, 455, 210, 455, 300);
            e.Graphics.DrawLine(yellowPen, 505, 210, 505, 300);
            e.Graphics.DrawArc(yellowPen, 465, 210, 40, 40, 0.0F, 170.0F);
            e.Graphics.DrawLine(yellowPen, 465, 210, 465, 235);
        }
    }
}
