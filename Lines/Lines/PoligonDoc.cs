using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lines
{
    [Serializable]
    public class PoligonDoc
    {
        public List<Poligon> Poligoni { get; set; }

        public PoligonDoc()
        {
            Poligoni = new List<Poligon>();
        }
        public void addPoligon(Poligon p)
        {
            Poligoni.Add(p);
        }
        public void Draw(Graphics g)
        {
            foreach (Poligon p in Poligoni)
            {
                p.Draw(g);
            }
        }
    }
}
