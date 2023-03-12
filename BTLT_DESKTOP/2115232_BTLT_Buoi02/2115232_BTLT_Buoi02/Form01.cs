using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2115232_BTLT_Buoi02
{
    public partial class Form01 : Form
    {
        public Form01()
        {
            InitializeComponent();
        }

        private void Form01_Load(object sender, EventArgs e)
        {

        }

        private void Panel_Click(object sender, EventArgs e)
        {
            var fore = new Panelll();
            fore.ShowDialog();
        }

        private void imageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fore = new ImageList();
            fore.ShowDialog();
        }

        private void menuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fore = new MenuStrippppp();
            fore.ShowDialog();
        }

        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fore = new ToolStripppp();
            fore.ShowDialog();
        }
    }
}
