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
    public partial class printInd : Form
    {
        private string stid;
        public printInd()
        {
            InitializeComponent();
        }

        public string studid {
            get { return this.stid; }
            set { this.stid = value; }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.SelectionFormula = "{Student_Info.StudentID} = '" + studid + "'";
        }

        private void printInd_Load(object sender, EventArgs e)
        {
            //applying fullscreen
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void printInd_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewInfo view = new viewInfo();
            view.Show();
        }
    }
}
