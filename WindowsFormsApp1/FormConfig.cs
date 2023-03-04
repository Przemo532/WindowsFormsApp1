using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormConfig : Form
    {
        public Color EditorBackColor 
        {
            get
            {
                return labelColor.BackColor;
            }
            set
            {
                labelColor.BackColor = value;
            }
        }

        public Color EditorTextColor 
        {
            get
            {
                return labelColor.ForeColor;
            }
            set
            {
                labelColor.ForeColor = value;
            } 
        }

        public Font EditorFont 
        {
            get
            {
                return labelColor.Font;
            }
            set
            {
                labelColor.Font = value;
            }
        }

        public FormConfig()
        {
            InitializeComponent();
        }

        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.Color = EditorBackColor;
            if (CD.ShowDialog() == DialogResult.OK)
            {
                labelColor.BackColor = CD.Color;
            }
        }

        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog CD = new ColorDialog();
            CD.Color = EditorTextColor;
            if (CD.ShowDialog() == DialogResult.OK)
            {
                labelColor.ForeColor = CD.Color;
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog FD = new FontDialog();
            FD.Font = EditorFont;
            if (FD.ShowDialog() == DialogResult.OK)
            {
                labelColor.Font = FD.Font;
            }
        }
    }
}
