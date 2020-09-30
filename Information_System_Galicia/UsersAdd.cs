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
    public partial class UsersAdd : Form {
        public string userid;
        public bool edit;
        SqlConnection connect = dbClass.getConnection();
        public UsersAdd() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (txtUser.Text == "" || txtPass.Text == "" || cmbPerm.Text == "") {
                MessageBox.Show("Fill up all forms!");
            } else {
                if (txtPass.Text != txtRePass.Text) {
                    MessageBox.Show("Password Mismatched!");
                } else {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM security WHERE username = '" + txtUser.Text + "'", connect);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    connect.Close();
                    if (dt.Rows.Count > 0) {
                        MessageBox.Show("User exist!");
                    } else {
                        try {
                            SqlDataAdapter sda = new SqlDataAdapter();
                            sda.InsertCommand = new SqlCommand("INSERT INTO security (fullname, username, password, type) VALUES (@fullname, @user, @pass, @type)", connect);
                            sda.InsertCommand.Parameters.Add("@fullname", SqlDbType.VarChar).Value = txtFullName.Text;
                            sda.InsertCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUser.Text;
                            sda.InsertCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPass.Text;
                            sda.InsertCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = cmbPerm.Text;
                            connect.Open();
                            sda.InsertCommand.ExecuteNonQuery();
                            connect.Close();
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                        this.Close();

                        UserView cv = new UserView();
                        cv.Show();
                        MessageBox.Show("New user added!");
                    }
                }
            }
        }

        private void UsersAdd_Load(object sender, EventArgs e) {
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            if (this.edit == true) {
                this.AcceptButton = updateBtn;
                searchUser();
                updateBtn.Visible = true;
                deleteBtn.Visible = true;
            } else {
                this.AcceptButton = userAddBtn;
            }
        }

        public void searchUser() {
            try {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM security WHERE id='" + this.userid + "'", connect);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    this.txtFullName.Text = dr.GetString(1);
                    this.txtUser.Text = dr.GetString(2);
                    this.txtPass.Text = dr.GetString(3);
                    this.txtRePass.Text = dr.GetString(3);
                    this.cmbPerm.Text = dr.GetString(4);
                }
                connect.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            if (txtUser.Text == "" || txtPass.Text == "" || cmbPerm.Text == "") {
                MessageBox.Show("Fill up all forms!");
            } else {
                if (txtPass.Text == txtRePass.Text) {
                    try {
                        SqlDataAdapter sda = new SqlDataAdapter();
                        sda.UpdateCommand = new SqlCommand("UPDATE security SET fullname=@fullname, username=@username, password=@pass, type=@perm WHERE id='" + this.userid + "'", connect);
                        sda.UpdateCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUser.Text;
                        sda.UpdateCommand.Parameters.Add("@fullname", SqlDbType.VarChar).Value = txtFullName.Text;
                        sda.UpdateCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPass.Text;
                        sda.UpdateCommand.Parameters.Add("@perm", SqlDbType.VarChar).Value = cmbPerm.Text;
                        connect.Open();
                        sda.UpdateCommand.ExecuteNonQuery();
                        connect.Close();
                        this.Close();
                        MessageBox.Show("Record successfully updated!");
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                } else {
                    MessageBox.Show("Password Mismatched!");
                }
            }
        }

        private void UsersAdd_FormClosed(object sender, FormClosedEventArgs e) {
            if (this.edit == true) {
                UserView vv = new UserView();
                vv.Show();
                vv.TopMost = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                sda.UpdateCommand = new SqlCommand("DELETE FROM security WHERE id='" + this.userid + "'", connect);

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