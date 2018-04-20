using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace HanoiTowers
{
    public partial class FormHanoi : Form
    {
        int n;
        int x = 1;
        int y = 600;
        const int height = 40;
        int[,] size = new int[3, 30];
        Rectangle doska = new Rectangle(60, 600, 1100, 20);
        Rectangle kernel1 = new Rectangle(250, 100, 20, 500);
        Rectangle kernel2 = new Rectangle(650, 100, 20, 500);
        Rectangle kernel3 = new Rectangle(1050, 100, 20, 500);
        public FormHanoi()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {   // base.OnPaint(e);
            // uses if you are override Paint method
            // you are telling the form to call the Paint handler again and again
            // uses for stackoverflowexeption
            Graphics gr = e.Graphics;
            gr.FillRectangle(Brushes.Red, kernel1);
            gr.FillRectangle(Brushes.Red, kernel2);
            gr.FillRectangle(Brushes.Red, kernel3);
            gr.FillRectangle(Brushes.Red, doska);
            Brush b1 = Brushes.Black;
            for (int i = 1; i <= n; ++i)
            {
                x = kernel1.X + kernel1.Width / 2 - size[0, i] / 2;
                y = (doska.Y - i * height);
                gr.FillRectangle(b1, x, y, size[0, i], height);
            }
            for (int i = 1; i <= n; ++i)
            {
                x = kernel2.X + kernel2.Width / 2 - size[1, i] / 2;
                y = (doska.Y - i * height);
                gr.FillRectangle(b1, x, y, size[1, i], height);
            }
            for (int i = 1; i <= n; ++i)
            {
                x = kernel3.X + kernel3.Width / 2 - size[2, i] / 2;
                y = (doska.Y - i * height);
                gr.FillRectangle(b1, x, y, size[2, i], height);
            }
        }
        private void ChangeDisk(int a, int b) // transference between first and second disks
        {
            int DiskA = 0;
            for (int i = 1; i <= n + 1; ++i)
            {
                if (size[a, i] == 0)
                {
                    DiskA = i - 1;
                    break;
                }
            }
            int DiskB = 0;
            for (int i = 1; i <= n + 1; ++i)
            {
                if (size[b, i] == 0)
                {
                    DiskB = i;
                    break;
                }
            }
            size[b, DiskB] = size[a, DiskA];
            size[a, DiskA] = 0;
            Refresh();
            // Invalidate() and Update() together
            //Forces the control to invalidate its client area and immediately redraw itself and any child controls.
            Thread.Sleep(500);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt16(textBox1.Text);
            size[0, 0] = 300;
            for (int i = 1; i <= n; ++i)
            {
                size[0, i] = size[0, i - 1] - 40;
                size[1, i] = 0;
                size[2, i] = 0;
            }
            Refresh();
            ChangeKernel(n, 0, 2, 1);
        }
        private void ChangeKernel(int height, int a, int b, int c) // transference tower with height from A to B with using subsidiary C 
        {
            if (height > 1)
            {
                ChangeKernel(height - 1, a, c, b);
                ChangeDisk(a, b);
                ChangeKernel(height - 1, c, b, a);
            }
            if (height == 1)
            {
                ChangeDisk(a, b);
            }
        }
    }
}
