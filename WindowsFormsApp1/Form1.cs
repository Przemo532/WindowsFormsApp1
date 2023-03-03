using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string MyFilter = "Plik tekstowy|*.txt|Skrypty|*.bat|Wszystkie pliki|*.*";
        private string OFName = ""; //OFName - Open File Name
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Text = "";
            OFName = "";
        }
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //ofd - open file dialog
            ofd.Filter = MyFilter;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                richText.Text = File.ReadAllText(ofd.FileName);
                OFName = ofd.FileName;
            }
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OFName == "")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(OFName, richText.Text);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //sfd - save file dialog
            sfd.Filter = MyFilter;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richText.Text);
                OFName = sfd.FileName;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
