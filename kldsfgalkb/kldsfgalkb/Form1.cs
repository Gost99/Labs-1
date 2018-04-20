using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kldsfgalkb
{
    public partial class Form1 : Form
    {
        Graphics gr;
        public Form1()
        {
            InitializeComponent();
            gr = CreateGraphics();

        }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Random rand = new Random();
                int n = rand.Next(4, 10);
                int r = rand.Next(100,200);
                Pen blackPen = new Pen(Color.Black, 5);
                Point[] myPointArray = new Point[n];
                Point center = new Point(600, 400);
                for (int i = 0; i < n; i++)
                {
                    bool checker = false;
                    do
                    {
                        int x = rand.Next(1000);
                        int y = rand.Next(700);

                        if (((x - center.X) * (x - center.X) + (y - center.Y) * (y - center.Y)) == r * r)
                        {
                            checker = true;
                            myPointArray[i] = new Point(x, y);
                        }
                    } while (!checker);

                }

                gr.DrawPolygon(blackPen, myPointArray);
            }
        
    }
    
}
