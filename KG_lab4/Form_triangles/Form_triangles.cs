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
namespace Form_triangles
{
    public partial class Form_triangles : Form
    {
        private GraphicsPath path = new GraphicsPath();
        public Form_triangles(Graphics g, Point[] A1, Point B)
        {
            InitializeComponent();
        }
        private void Form_triangles_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}