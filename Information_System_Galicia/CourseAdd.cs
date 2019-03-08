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

namespace Information_System_Galicia {
    public partial class CourseAdd : Form {
        public string courseid; // passing value here from courseView.cs doubleclick listener
        public bool edit; // editing mode, passing value from courseview.cs doubleclick listener
        SqlConnection connect = dbClass.getConnection();
        public CourseAdd() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            connect.Open();
            // checking if the course is exist
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE CourseName='" + txtCourse.Text + "'", connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            if (dt.Rows.Count > 0) // if course exist
   {
                MessageBox.Show("Course exist!");
            } else { // if course not exist
                try {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.InsertCommand = new SqlCommand("INSERT INTO Course (CourseName, CourseDescription) VALUES (@cname, @cdes)", connect);
                    sda.InsertCommand.Parameters.Add("@cname", SqlDbType.VarChar).Value = txtCourse.Text;
                    sda.InsertCommand.Parameters.Add("@cdes", SqlDbType.VarChar).Value = txtCourseDesc.Text;

                    connect.Open();
                    sda.InsertCommand.ExecuteNonQuery(); // inserting new course to the database
                    connect.Close();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                CourseView cv = new CourseView();
                cv.Show();
                MessageBox.Show("New course added!");
            }
        }

        private void CourseAdd_Load(object sender, EventArgs e) {
            // setting default button and forms to disabled
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
            courseBtnAdd.Enabled = false;
            groupBox1.Enabled = false;
            btnDel.Visible = false;
            btnUpdate.Visible = false;

            Permission perm = new Permission();
            if (perm.GetPermission() == "admin") {
                // if the user logged was admin reverting from disabled to enabled
                btnDel.Enabled = true;
                btnUpdate.Enabled = true;
                courseBtnAdd.Enabled = true;
                groupBox1.Enabled = true;
            }
            if (this.edit == true) { // if editing is true, hiding add button 
                searchCourse(); // showing update and delete button
                courseBtnAdd.Hide();
                btnDel.Visible = true;
                btnUpdate.Visible = true;
            }
        }

        public void searchCourse() // course method this will called when the form is loaded
        {
            try {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE CourseID='" + this.courseid + "'", connect);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    this.txtCourse.Text = dr.GetString(1);
                    this.txtCourseDesc.Text = dr.GetString(2);
                }
                connect.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);

                sda.UpdateCommand = new SqlCommand("UPDATE Course SET CourseName=@cname, CourseDescription=@cdesc WHERE CourseID='" + this.courseid + "'", connect);
                sda.UpdateCommand.Parameters.Add("@cname", SqlDbType.VarChar).Value = txtCourse.Text;
                sda.UpdateCommand.Parameters.Add("@cdesc", SqlDbType.VarChar).Value = txtCourseDesc.Text;
                connect.Open();
                sda.UpdateCommand.ExecuteNonQuery();
                connect.Close();
                this.Close();
                MessageBox.Show("Record successfully updated!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void CourseAdd_FormClosed(object sender, FormClosedEventArgs e) {
            // if the editing is true
            // and the form has been closed, it will open the view course form
            if (this.edit == true) {
                CourseView vv = new CourseView();
                vv.Show();
                vv.TopMost = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                sda.UpdateCommand = new SqlCommand("DELETE FROM Course WHERE CourseID='" + this.courseid + "'", connect);

                connect.Open();
                sda.UpdateCommand.ExecuteNonQuery();
                connect.Close();
                this.Close();
                MessageBox.Show("Record successfully deleted!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}