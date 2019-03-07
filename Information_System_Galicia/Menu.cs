using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Information_System_Galicia
{
    public partial class Menu : Form
    {
        SqlConnection conn = dbClass.getConnection();
        public bool isAdmin;
        public Menu()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc_id();
        }
        public void inc_id() {
            StudentInfo add = new StudentInfo();
            DateTime dt = new DateTime(2019, 07, 28);
            conn.Open();
            SqlCommand sda = new SqlCommand("SELECT ID FROM id_increment", conn);
            SqlDataReader dr = sda.ExecuteReader();
            if (dr.Read())
            {
                add.txtStudId.Text = dt.ToString("yy") + "-" + dr.GetInt32(0);
            }
            add.id_inc = dr.GetInt32(0);
            conn.Close();
            add.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT userLogged FROM session", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(dr.GetString(0));
            }
            conn.Close();
            btnRefresh.TabStop = false;
            logoutBtn.TabStop = false;
            getStudentsInfo();



        }

        public void getStudentsInfo() {
            conn.Open();
            DataTable dt = new DataTable();
            DataTable du = new DataTable();
            DataTable dv = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student_Info", conn);
            sda.Fill(dt);
            countReg.Text = Convert.ToString(dt.Rows.Count);

            SqlDataAdapter sdb = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'MALE'", conn);
            sdb.Fill(du);
            countMale.Text = Convert.ToString(du.Rows.Count);

            SqlDataAdapter sdc = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'FEMALE'", conn);
            sdc.Fill(dv);
            countFemale.Text = Convert.ToString(dv.Rows.Count);


            conn.Close();

        }

        private void viewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewInfo info = new viewInfo();
            info.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getStudentsInfo();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            //Login login = new Login();
            //this.Hide();
            //login.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }


        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
