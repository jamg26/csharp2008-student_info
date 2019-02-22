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
    public partial class StudentInfo : Form
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "SOMEONE@EXAMPLE.COM") {
                textBox9.Text = "";
            }
            textBox9.ForeColor = Color.Black;
        }

        private void textBox9_TextChanged(object sender, EventArgs e) {

        }

    }
}
