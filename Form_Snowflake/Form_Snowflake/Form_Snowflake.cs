using System;
using System.Drawing;
using System.Windows.Forms;
namespace Form_Snowflake
{
    public partial class button : Form
    {
        bool loaded = false;
        static Graphics g;
        Pen blackPen = new Pen(Color.Black, 1);
        public button()
        {
            InitializeComponent();
        }
        private void btnTr_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            g.Clear(Color.White);
            Point side1 = new Point(Snowflake.Left + 130, Snowflake.Top + 88);
            Point side2 = new Point(Snowflake.Left - 70, Snowflake.Top + 88);
            Point side3 = new Point(Snowflake.Left + 30, Snowflake.Top - 88);
            TrIter(side1, side2, side3, 5);
            TrIter(side2, side3, side1, 5);
            TrIter(side3, side1, side2, 5);
            TrIter(side1, side2, side3, 1);
            TrIter(side2, side3, side1, 1);
            TrIter(side3, side1, side2, 1);
        }
        private int TrIter(Point side1, Point side2, Point side3, int iteration)
        {
            if (iteration > 0)
            {
                var lp = new Point((side2.X + 2 * side1.X) / 3, (side2.Y + 2 * side1.Y) / 3);
                var rp = new Point((2 * side2.X + side1.X) / 3, (side1.Y + 2 * side2.Y) / 3);
                var dp = new Point((side2.X + side1.X) / 2, (side2.Y + side1.Y) / 2);
                var up = new Point((4 * dp.X - side3.X) / 3, (4 * dp.Y - side3.Y) / 3);
                g.DrawLine(blackPen, lp, up);
                g.DrawLine(blackPen, rp, up);
                g.DrawLine(blackPen, lp, rp);
                TrIter(lp, up, rp, iteration - 1);
                TrIter(up, rp, lp, iteration - 1);
                TrIter(side1, lp, new Point((2 * side1.X + side3.X) / 3, (2 * side1.Y + side3.Y) / 3), iteration - 1);
                TrIter(rp, side2, new Point((2 * side2.X + side3.X) / 3, (2 * side2.Y + side3.Y) / 3), iteration - 1);
            }
            return iteration;
        }
        private void Form_Snowflake_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
            {
                g = CreateGraphics();
                g.Clear(Color.White);
                Point draw1 = new Point(Snowflake.Left + 130, Snowflake.Top + 88);
                Point draw2 = new Point(Snowflake.Left - 70, Snowflake.Top + 88);
                Point draw3 = new Point(Snowflake.Left + 30, Snowflake.Top - 88);
                g.DrawLine(blackPen, draw1, draw2);
                g.DrawLine(blackPen, draw2, draw3);
                g.DrawLine(blackPen, draw3, draw1);
                loaded = true;
            }
        }    
    }
}
    

