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
        public bool isAdmin;
        public viewInfo()
        {
            InitializeComponent();
        }

        private void viewInfo_Load(object sender, EventArgs e)
        {
            displayInformation();
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
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
                     dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                     dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentInfo SI = new StudentInfo();
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
