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
    public partial class CourseView : Form
    {
        SqlConnection conn = dbClass.getConnection();
        public CourseView()
        {
            InitializeComponent();
        }

        private void CourseView_Load(object sender, EventArgs e)
        {
            displayInformation();
        }
        public void displayInformation()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Course", conn);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                // auto sizing the size of datagridview
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;

                conn.Close();
            }
            catch (Exception ex) //TO FILTER THE ERROR FROM YOUR SYSTEM
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CourseAdd ca = new CourseAdd();
            ca.courseid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ca.courseBtnAdd.Enabled = false;
            ca.edit = true;
            this.Close();
            ca.Show();
            ca.TopMost = true; // optional, to make sure the courseAdd form is the top most
        }
    }
}
