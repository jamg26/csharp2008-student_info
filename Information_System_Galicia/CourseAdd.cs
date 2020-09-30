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
        private string courseid; // passing value here from courseView.cs doubleclick listener
        private bool edit; // editing mode, passing value from courseview.cs doubleclick listener
        SqlConnection connect = dbClass.getConnection();

        public bool Edit {
            get { return this.edit; }
            set { this.edit = value; }
        }

        public CourseAdd() {
            InitializeComponent();
        }

        public string cid {
            get { return this.courseid; }
            set { this.courseid = value; }
        }

        static void dbInsert(string query) {
            dbQuery db = new dbQuery();
            db.dbInsert(query);
        }
        static void showCv() {
            CourseView cv = new CourseView();
            cv.Show();
            MessageBox.Show("New course added!");
        }
        private System.Data.DataTable courseCheck() {
            connect.Open();
            // checking if the course is exist
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE CourseName='" + txtCourse.Text + "'", connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            return dt;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (txtCourse.Text == "" || txtCourseDesc.Text == "") {
                MessageBox.Show("Fill up all forms!");
            } else {
                if (courseCheck().Rows.Count > 0) {
                    MessageBox.Show("Course exist!");
                } else { // if course not exist
                    try {
                        dbInsert("INSERT INTO Course (CourseName, CourseDescription) VALUES ('" + txtCourse.Text + "','" + txtCourseDesc.Text + "')");
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    this.Close();
                    showCv();
                }
            }
        }

        private void courseState(bool state) {
            // setting button state
            btnDel.Enabled = state;
            btnUpdate.Enabled = state;
            courseBtnAdd.Enabled = state;
            groupBox1.Enabled = state;
        }

        private void btnVisible(bool state) {
            btnDel.Visible = state;
            btnUpdate.Visible = state;
        }

        private void CourseAdd_Load(object sender, EventArgs e) {
            btnVisible(false);
            courseState(false);
            Permission perm = new Permission();
            if (perm.GetPermission() == "admin") {
                courseState(true);
            }
            if (this.edit == true) { // if editing is true, hiding add button 
                searchCourse(); // showing update and delete button
                courseBtnAdd.Hide();
                btnVisible(true);
                this.AcceptButton = btnUpdate;
            } else {
                this.AcceptButton = courseBtnAdd;
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

        static void dbUpdate(string query) {
            dbQuery db = new dbQuery();
            db.dbUpdate(query);
        }

        private void button1_Click_1(object sender, EventArgs e) {
            if (txtCourse.Text == "" || txtCourseDesc.Text == "") {
                MessageBox.Show("Fill up all forms!"); 
            } else {
                try {
                    dbUpdate("UPDATE Course SET CourseName='" + txtCourse.Text + "', CourseDescription='" + txtCourseDesc.Text + "' WHERE CourseID='" + this.courseid + "'");
                    this.Close();
                    MessageBox.Show("Record successfully updated!");
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
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

        static void dbDel(string query) {
            dbQuery db = new dbQuery();
            db.dbDelete(query);
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                dbDel("DELETE FROM Course WHERE CourseID='" + this.courseid + "'");
                this.Close();
                MessageBox.Show("Record successfully deleted!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}