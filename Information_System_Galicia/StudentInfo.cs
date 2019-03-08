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
using System.Net.Mail;

namespace Information_System_Galicia {
    public partial class StudentInfo : Form {
        SqlConnection connect = dbClass.getConnection();
        public string studid;
        public bool edit;
        public int id_inc;
        public StudentInfo() {
            InitializeComponent();
        }

        private void textBox9_Enter(object sender, EventArgs e) {
            if (txtEmail.Text == "SOMEONE@EXAMPLE.COM") {
                txtEmail.Text = "";
            }
            txtEmail.ForeColor = Color.Black;
        }

        private void course() {
            try {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * FROM Course", connect);
                da.Fill(dt);
                connect.Open();
                for (int i = 0; i < dt.Rows.Count; i++) {
                    cmbCourse.Items.Add(dt.Rows[i]["CourseName"]);
                }
                connect.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            //SmtpClient client = new SmtpClient();
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("jammmg26@gmail.com", "12261994");

            //MailAddress from = new MailAddress("jammmg26@gmail.com", "Student Registration");
            //MailAddress to = new MailAddress(textBox9.Text, textBox2.Text);
            //MailMessage mm = new MailMessage(from, to);
            //mm.Subject = "You have successfully registered";
            //mm.Body = "Hello " + textBox2.Text;
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //client.Send(mm);

            string bday = bdayM.Text + " " + bdayD.Text + " " + bdayY.Text;
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                sda.InsertCommand = new SqlCommand("INSERT INTO Student_Info (studentID, FirstName, MiddleName, LastName, Address, BirthDate, Gender, Contact, Email, YearLevel, Course) VALUES (@stud_id, @stud_fname, @stud_mname, @stud_lname, @stud_address, @BirthDate, @Gender, @Contact, @Email, @stud_year, @stud_course)", connect);
                sda.InsertCommand.Parameters.Add("@stud_id", SqlDbType.VarChar).Value = txtStudId.Text;
                sda.InsertCommand.Parameters.Add("@stud_fname", SqlDbType.VarChar).Value = txtFname.Text;
                sda.InsertCommand.Parameters.Add("@stud_mname", SqlDbType.VarChar).Value = txtMname.Text;
                sda.InsertCommand.Parameters.Add("@stud_lname", SqlDbType.VarChar).Value = txtLname.Text;
                sda.InsertCommand.Parameters.Add("@stud_address", SqlDbType.VarChar).Value = txtAdd.Text;
                sda.InsertCommand.Parameters.Add("@stud_course", SqlDbType.VarChar).Value = cmbCourse.Text;
                sda.InsertCommand.Parameters.Add("@stud_year", SqlDbType.VarChar).Value = cmbYr.Text;
                sda.InsertCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = bday;
                sda.InsertCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = txtGender.Text;
                sda.InsertCommand.Parameters.Add("@Contact", SqlDbType.VarChar).Value = txtContact.Text;
                sda.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                connect.Open();
                sda.InsertCommand.ExecuteNonQuery();
                connect.Close();
                ClearEntry();
                SqlDataAdapter da = new SqlDataAdapter();
                // when new student is added, the current id in the database will be incremented by 1
                da.UpdateCommand = new SqlCommand("UPDATE id_increment SET ID = " + (id_inc + 1) + " WHERE ID = " + id_inc, connect);
                connect.Open();
                da.UpdateCommand.ExecuteNonQuery();
                connect.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            this.Close();
            viewInfo obj = new viewInfo();
            obj.Show();
            MessageBox.Show("Record is already added!");
        }

        void ClearEntry() {
            txtFname.Text = "";
            txtMname.Text = "";
            txtLname.Text = "";
            txtAdd.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            cmbYr.SelectedIndex = -1;
            txtGender.SelectedIndex = -1;
            bdayM.SelectedIndex = -1;
            bdayD.SelectedIndex = -1;
            bdayY.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
        }

        private void StudentInfo_Load(object sender, EventArgs e) {
            // disabling admin tools by default
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            Permission perm = new Permission();
            if (perm.GetPermission() == "admin") {
                // if user logged in is admin reverting the tools to enabled
                btnDel.Enabled = true;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            // if editing is true hiding add button else hiding update and delete button
            if (this.edit == true) {
                course();
                searchStudent();
                btnAdd.Hide();
            } else {
                course();
                btnDel.Enabled = false;
                btnUpdate.Enabled = false;
                btnDel.Hide();
                btnUpdate.Hide();
            }
        }

        public void searchStudent() {
            try {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student_Info WHERE StudentID='" + studid + "'", connect);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    // putting data to textboxes
                    this.txtStudId.Text = dr.GetString(0);
                    this.txtFname.Text = dr.GetString(1);
                    this.txtMname.Text = dr.GetString(2);
                    this.txtLname.Text = dr.GetString(3);
                    this.txtAdd.Text = dr.GetString(4);

                    string mth = dr.GetString(5).Split(' ')[0];
                    string day = dr.GetString(5).Split(' ')[1];
                    string yr = dr.GetString(5).Split(' ')[2];
                    this.bdayM.Text = mth; // month combo box text
                    this.bdayD.Text = day; // day combo box text
                    this.bdayY.Text = yr; // year combo box text

                    this.txtGender.Text = dr.GetString(6);
                    this.txtContact.Text = dr.GetString(7);
                    this.txtEmail.Text = dr.GetString(8);
                    this.txtEmail.ForeColor = Color.Black;
                    this.cmbYr.Text = dr.GetString(9);
                    this.cmbCourse.Text = dr.GetString(10);
                }
                connect.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            string bday = this.bdayM.Text + " " + this.bdayD.Text + " " + this.bdayY.Text;
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);

                sda.UpdateCommand = new SqlCommand("UPDATE Student_Info SET FirstName=@stud_fname, MiddleName=@stud_mname, LastName=@stud_lname, Address=@stud_address, BirthDate=@BirthDate, Gender=@Gender, Contact=@Contact, Email=@Email, YearLevel=@stud_year, Course=@stud_course WHERE StudentID='" + studid + "'", connect);
                sda.UpdateCommand.Parameters.Add("@stud_fname", SqlDbType.VarChar).Value = txtFname.Text;
                sda.UpdateCommand.Parameters.Add("@stud_mname", SqlDbType.VarChar).Value = txtMname.Text;
                sda.UpdateCommand.Parameters.Add("@stud_lname", SqlDbType.VarChar).Value = txtLname.Text;
                sda.UpdateCommand.Parameters.Add("@stud_address", SqlDbType.VarChar).Value = txtAdd.Text;
                sda.UpdateCommand.Parameters.Add("@stud_course", SqlDbType.VarChar).Value = cmbCourse.Text;
                sda.UpdateCommand.Parameters.Add("@stud_year", SqlDbType.VarChar).Value = cmbYr.Text;
                sda.UpdateCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = bday;
                sda.UpdateCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = txtGender.Text;
                sda.UpdateCommand.Parameters.Add("@Contact", SqlDbType.VarChar).Value = txtContact.Text;
                sda.UpdateCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                connect.Open();
                sda.UpdateCommand.ExecuteNonQuery();
                connect.Close();
                this.Close();
                MessageBox.Show("Record successfully updated!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e) {
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                sda.UpdateCommand = new SqlCommand("DELETE FROM Student_Info WHERE StudentID='" + studid + "'", connect);

                connect.Open();
                sda.UpdateCommand.ExecuteNonQuery();
                connect.Close();
                this.Close();
                MessageBox.Show("Record successfully deleted!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentInfo_FormClosed(object sender, FormClosedEventArgs e) {
            // if editing is true and form is closed open the view student form
            if (this.edit == true) {
                viewInfo vv = new viewInfo();
                vv.Show();
                vv.TopMost = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) {
            this.TopMost = false;
        }
    }
}