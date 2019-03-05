using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Information_System_Galicia
{
    public partial class viewInfo : Form
    {
        SqlConnection conn = dbClass.getConnection();
        public viewInfo()
        {
            InitializeComponent();
        }

        private void viewInfo_Load(object sender, EventArgs e)
        {
            displayInformation();
        }

        public void displayInformation()
             {
                 try
                 {
                     conn.Open();
                     DataTable dt = new DataTable();
                     SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student_Info", conn);
                     sda.Fill(dt);
                     dataGridView1.DataSource = dt;
                     //dataGridView1.Columns[0].Width = 100;
                     //dataGridView1.Columns[1].Width = 100;
                     //dataGridView1.Columns[2].Width = 100;
                     //dataGridView1.Columns[3].Width = 100;
                     //dataGridView1.Columns[4].Width = 100;
                     //dataGridView1.Columns[5].Width = 100;
                     //dataGridView1.Columns[6].Width = 100;

                     dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                     dataGridView1.Columns[0].ReadOnly = true;
                     dataGridView1.Columns[1].ReadOnly = true;
                     dataGridView1.Columns[2].ReadOnly = true;
                     dataGridView1.Columns[3].ReadOnly = true;
                     dataGridView1.Columns[4].ReadOnly = true;
                     dataGridView1.Columns[5].ReadOnly = true;
                     dataGridView1.Columns[6].ReadOnly = true;
                     dataGridView1.Columns[7].ReadOnly = true;
                     dataGridView1.Columns[8].ReadOnly = true;
                     dataGridView1.Columns[9].ReadOnly = true;
                     dataGridView1.Columns[10].ReadOnly = true;

                     conn.Close();
                 }
                 catch (Exception ex) //TO FILTER THE ERROR FROM YOUR SYSTEM
                 {
                    MessageBox.Show(ex.Message);
                 }
             }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentInfo SI = new StudentInfo();
            //SI.txtStudId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SI.studid = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            SI.txtStudId.Enabled = false;
            SI.btnAdd.Enabled = false;
            SI.edit = true;
            this.Close();
            SI.Show();
            SI.TopMost = true;
        }

    }
}
