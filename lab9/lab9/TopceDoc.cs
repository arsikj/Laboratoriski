using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab9
{
    [Serializable]
    class TopceDoc
    {
        public List<Topce> topceDoc { get; set; }

        public TopceDoc()
        {
            topceDoc = new List<Topce>();
        }

        public void addTopce(Topce topce)
        {
            topceDoc.Add(topce);
        }

        public void drawTopceDoc(Graphics g)
        {
            foreach (Topce t in topceDoc)
            {
                t.draw(g);
            }
        }
    }
}
