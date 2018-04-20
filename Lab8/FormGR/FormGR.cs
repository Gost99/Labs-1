using System;
using System.Drawing;
using System.Windows.Forms;
namespace FormGR
{
    public partial class FormGR : Form
    {       
        Graphics graph;
        PointF p1;
        PointF p2;
        int x = 50;
        int y = 60;
        Pen pen = new Pen(Color.Black, 3);
        public FormGR()
        {
            time.Interval = 100;
            time.Tick += Timer;
            time.Start();
            InitializeComponent();
        }
        static Timer time = new Timer();
        private void Timer(Object newObject, EventArgs e)
        {
            p1 = p2;
            p2 = new PointF(p1.X + x, p1.Y + y);
            if (p2.X <= 20 || p2.X >= 400)
            {
                x = -x;
            }
            if (p2.Y <= 20 || p2.Y >= 400)
            {
                y = -y;
            }
            Refresh();
            graph = panel1.CreateGraphics();
            Image img = Image.FromFile("C:\\Users\\PC\\Desktop\\Прога\\KG\\smile1.png");
            graph.DrawImage(img, p1);
            graph.DrawLine(pen, 420, 0, 420, 440);
            graph.DrawLine(pen, 420, 440, 0, 440);
        }
    }
}
