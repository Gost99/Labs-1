using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp293
{
    public partial class Form_Serpinskiy : Form
    {
        public Form_Serpinskiy()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {    
            float x1 = 100, x2 = 190, x3 = 10, y1 = 10, y2 = 270, y3 = 270;                
            BuildSerpinsky( x1, y1, x2, y2, x3, y3, 7);
        }
        void BuildSerpinsky(float x1, float y1, float x2, float y2, float x3, float y3, int iterations)
        {
            Graphics gr = this.CreateGraphics();
            Pen red = new Pen(Color.Black, 1);
            gr.DrawLine(red, x1, y1, x2, y2);
            gr.DrawLine(red, x2, y2, x3, y3);
            gr.DrawLine(red, x1, y1, x3, y3);
            iterations--;
            if (iterations > 0)
            {
                float x12, y12, x23, y23, x13, y13;
                x12 = x1 + (x2 - x1) / 2;
                y12 = y1 + (y2 - y1) / 2;
                x13 = x1 + (x3 - x1) / 2;
                y13 = y1 + (y2 - y1) / 2;
                x23 = x2 + (x3 - x2) / 2;
                y23 = y2 + (y3 - y2) / 2;
                BuildSerpinsky(x1, y1, x12, y12, x13, y13, iterations);
                BuildSerpinsky(x12, y12, x2, y2, x23, y23, iterations);
                BuildSerpinsky(x13, y13, x23, y23, x3, y3, iterations);
            }
        }
    }
}
