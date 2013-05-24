using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab9
{
    public partial class Form1 : Form
    {

        TopceDoc topcedoc;
        Color color;
        private string FileName;


        public Form1()
        {
            InitializeComponent();
            color = Color.Black;
            topcedoc = new TopceDoc();
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            topcedoc.drawTopceDoc(e.Graphics);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Topce topce = new Topce(25, color, new Point(e.X, e.Y));
            topcedoc.addTopce(topce);
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == colorToolStripMenuItem)
            {

                ColorDialog colordialog = new ColorDialog();
                DialogResult dialog = colordialog.ShowDialog();
                if (dialog == System.Windows.Forms.DialogResult.OK)
                {
                    color = colordialog.Color;
                }
            }
        }

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Topce doc file (*.topce)|*.topce";
                saveFileDialog.Title = "Save topce doc";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, topcedoc);
                }
            }
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Topce doc file (*.topce)|*.topce";
            openFileDialog.Title = "Open topce file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        topcedoc = (TopceDoc)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }


    }
}
