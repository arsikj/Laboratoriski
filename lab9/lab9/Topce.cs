using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab9
{
    [Serializable]
    class Topce
    {
        public int radius { get; set; }
        public Color color { get; set; }
        public Point centar { get; set; }

        public Topce(int r, Color c, Point p)
        {
            radius = r;
            color = c;
            centar = p;
        }

        public void draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, centar.X - radius, centar.Y - radius, 2 * radius, 2 * radius);
            brush.Dispose();
        }
    }
}
