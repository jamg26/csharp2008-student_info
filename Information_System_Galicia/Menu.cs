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
        
        public Menu()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inc_id(); // calling the add student button
        }

        public void inc_id() {
            StudentInfo add = new StudentInfo();
            DateTime dt = new DateTime(2019, 07, 28); // declaring date time format
            conn.Open();
            SqlCommand sda = new SqlCommand("SELECT ID FROM id_increment", conn); // getting id from the last student id value
            SqlDataReader dr = sda.ExecuteReader();
            if (dr.Read())
            {
                add.txtStudId.Text = dt.ToString("yy") + "-" + dr.GetInt32(0); // formatting the student id 19-100000
            }
            add.id_inc = dr.GetInt32(0);
            conn.Close();
            add.Show();
        }

        public void getUserCount()
        {
            SqlCommand sda = new SqlCommand("SELECT COUNT(id) FROM security", conn);
            conn.Open();
            SqlDataReader dr = sda.ExecuteReader();
            if (dr.Read())
            {
                userCount.Text = Convert.ToString(dr.GetInt32(0));
            }
            conn.Close();
        }

        public void getCourseCount()
        {
            SqlCommand sda = new SqlCommand("SELECT COUNT(CourseID) FROM Course", conn);
            conn.Open();
            SqlDataReader dr = sda.ExecuteReader();
            if (dr.Read())
            {
                courseCount.Text = Convert.ToString(dr.GetInt32(0));
            }
            conn.Close();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            getUserCount(); // get stats of users
            getCourseCount(); // get stats of course
            // disabled by default
            addToolStripMenuItem.Enabled = false;
            courseAdd.Enabled = false;
            usersToolStripMenuItem.Visible = false;
            refreshToolStripMenuItem.Visible = false;
            // checking permissions if the logged user is admin
            Permission permission = new Permission();
            if (permission.GetPermission() == "admin")
            {
                // reverting toolstrip to enabled
                addToolStripMenuItem.Enabled = true;
                usersToolStripMenuItem.Visible = true;
                courseAdd.Enabled = true;
            }

            getStudentsInfo();



        }

        public void getStudentsInfo() {
            conn.Open();
            DataTable dt = new DataTable(); 
            DataTable du = new DataTable();
            DataTable dv = new DataTable();
            // getting the count of the students
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student_Info", conn);
            sda.Fill(dt);
            countReg.Text = Convert.ToString(dt.Rows.Count);
            // getting the count of all male students
            SqlDataAdapter sdb = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'MALE'", conn);
            sdb.Fill(du);
            countMale.Text = Convert.ToString(du.Rows.Count);
            // getting the count of all female students
            SqlDataAdapter sdc = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'FEMALE'", conn);
            sdc.Fill(dv);
            countFemale.Text = Convert.ToString(dv.Rows.Count);


            conn.Close();

            getUserCount();
            getCourseCount();

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

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void courseAdd_Click(object sender, EventArgs e)
        {
            CourseAdd course = new CourseAdd();
            course.Show();
        }

        private void courseView_Click(object sender, EventArgs e)
        {
            CourseView course = new CourseView();
            course.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UsersAdd user = new UsersAdd();
            user.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserView user = new UserView();
            user.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getStudentsInfo();
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void refreshToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.ForeColor = Color.Teal;
        }

        private void refreshToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.ForeColor = Color.Black;
        }

        private void logoutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            logoutToolStripMenuItem.ForeColor = Color.Red;
        }

        private void logoutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            logoutToolStripMenuItem.ForeColor = Color.Black;
        }
    }
}
