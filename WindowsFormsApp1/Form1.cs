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

        private bool modified = false;

        public string OFNAME
        {
            set
            {
                OFName = value;
                setInfo();
            }
            get
            {
                return OFName;
            }
        }

        public bool Modified1
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                setInfo();
            }
        }

        void setInfo()
        {
            if (OFName == "")
            {
                this.Text = "x";
            }
            else
            {
                this.Text = OFName;
            }
            if (Modified1)
            {
                if (OFName == "")
                {
                    this.Text = "*Notepad1";
                }
                else
                {
                    this.Text = "*" + OFName;
                }
            }
        }

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
            OFNAME = "";
            Modified1 = false;
        }
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //ofd - open file dialog
            ofd.Filter = MyFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richText.Text = File.ReadAllText(ofd.FileName);
                OFNAME = ofd.FileName;
                Modified1 = false;
            }
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OFNAME == "")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(OFNAME, richText.Text);
                Modified1 = false;
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //sfd - save file dialog
            sfd.Filter = MyFilter;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richText.Text);
                OFNAME = sfd.FileName;
                Modified1 = false;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void richText_TextChanged(object sender, EventArgs e)
        {
            Modified1 = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified1)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Plik został zmodyfikowany", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    zapiszToolStripMenuItem_Click(sender, e);
                }
                else if(result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig FC = new FormConfig();
            FC.EditorBackColor = richText.BackColor;
            FC.EditorTextColor = richText.ForeColor;
            FC.EditorFont = richText.Font;
            if (FC.ShowDialog() == DialogResult.OK)
            {
                richText.Font = FC.EditorFont;
                richText.ForeColor = FC.EditorTextColor;
                richText.BackColor = FC.EditorBackColor;
            }
        }
    }
}
