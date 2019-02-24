using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Information_System_Galicia
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentInfo add = new StudentInfo();
            add.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void viewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewInfo info = new viewInfo();
            info.Show();
        }
    }
}
