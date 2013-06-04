using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Lines
{
    public partial class Form1 : Form
    {
        public PoligonDoc p { get; set; }
        public Poligon current { get; set; }
        public string FileName { get; set; }

        public Form1()
        {
            InitializeComponent();
            p = new PoligonDoc();
            current = new Poligon();
        }

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Poligon doc file (*.pol)|*.pol";
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
                    formatter.Serialize(fileStream, p);
                }
            }
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Poligon doc file (*.pol)|*.pol";
            openFileDialog.Title = "Open topce file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        p = (PoligonDoc)formater.Deserialize(fileStream);
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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (current.AddTocka(e.Location))
            {
                p.addPoligon(current);
                current = new Poligon();
            }
            
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            p.Draw(e.Graphics);
            current.Draw(e.Graphics);
        }

       

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            current.virPoint(e.Location);
            toolStripStatusLabel1.Text = string.Format("X= {0} -- Y= {1}", e.X, e.Y);
            Invalidate(true);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            p = new PoligonDoc();
            current = new Poligon();
            Invalidate();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton_Click(sender,e);
        }
       
       
    }
}
