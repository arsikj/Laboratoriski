using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = this.CreateGraphics();
            g.FillEllipse(new SolidBrush(Color.Gray), new Rectangle(50, 50, 50, 10));
            g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(55, 55, 40, 7));
            Point[] points = new Point[4];
            points[0] = new Point(55, 62);
            points[3] = new Point(95, 62);
            points[1] = new Point(40, 82);
            points[2] = new Point(110, 82);
            g.FillPolygon(new SolidBrush(Color.Green), points);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(40, 82, 70, 4));
            points[0] = new Point(39, 86);
            points[3] = new Point(30, 106);
            points[1] = new Point(111, 86);
            points[2] = new Point(120, 106);
            g.FillPolygon(new SolidBrush(Color.Green), points);
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(30, 106, 90, 60));
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(30, 166, 90, 22));
            g.DrawString("Heinken", new Font("Arial", 16), new SolidBrush(Color.White), new Rectangle(30, 166, 90, 20));
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(30, 188, 90, 60));
        }
    }
}
