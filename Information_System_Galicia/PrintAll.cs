using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Information_System_Galicia {
    public partial class PrintAll : Form {
        public PrintAll() {
            InitializeComponent();
        }

        private void PrintAll_Load(object sender, EventArgs e) {
            //applying fullscreen
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
