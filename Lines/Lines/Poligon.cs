using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace Lines
{
    [Serializable]
    public class Poligon
    {
        public List<Point> Tocki { get; set; }
        public Color Boja { get; set; }
        public bool poligon { get; set; }
        public Point virtualPoint { get; set; }
        public Pen penkalce { get; set; }
        public Poligon()
        {
            Tocki = new List<Point>();
            Random rnd=new Random();
            this.Boja = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            this.poligon = false;
            virtualPoint = Point.Empty;
            penkalce = new Pen(Color.Black);
            penkalce.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        }
        public bool AddTocka(Point t)
        {
            Tocki.Add(t);
            return poligon = isClosed();
        }
        public bool isClosed()
        {
            if (Tocki.Count > 1)
            {
                if (Math.Abs(Tocki.First().X - Tocki.Last().X) < 5 && Math.Abs(Tocki.First().Y - Tocki.Last().Y) < 5)
                {
                    return true;
                }
            }
            return false;
        }

        public void virPoint(Point p)
        {
            virtualPoint = p;
        }

        public void Draw(Graphics g)
        {
            if (Tocki.Count > 1)
            {
                if (poligon)
                {
                    g.FillPolygon(new SolidBrush(Boja), Tocki.ToArray());
                }

                g.DrawLines(new Pen(new SolidBrush(Color.Black), 2), Tocki.ToArray());
                g.DrawLine(penkalce, Tocki.Last(), virtualPoint);
            }
            else if (Tocki.Count == 1)
            {
                g.DrawLine(penkalce, Tocki.Last(), virtualPoint);
            }
        }
    }
}
