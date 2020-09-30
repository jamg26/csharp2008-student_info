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
    public partial class Login : Form
    {
        SqlConnection conn = dbClass.getConnection();
        private string perm;
        private string name;
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        static void menuAttribute(string dbserver, string dbname, string dbuser, string usertype, string usersname, string userlogged) {
            // setting menu items values
            DateTime dtime = DateTime.Now;
            Menu mm = new Menu();
            mm.dbServer.Text = dbserver;
            mm.dbName.Text = dbname;
            mm.dbUser.Text = dbuser;
            mm.lastLog.Text = dtime.ToString("MM/dd/yyyy h:mm tt");
            mm.txtUserType.Text = usertype;
            mm.label12.Text = usersname;
            mm.userLogged.Text = userlogged;
            mm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM security WHERE username = '" + textBox2.Text + "' AND password = '" + textBox1.Text + "' collate Latin1_General_CS_AS", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0) {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dbClass db = new dbClass();
                // Preparing permissions before showing the menu
                Permission permission = new Permission();
                if (dr.Read())
                {
                    this.perm = dr.GetString(4); // passing value from user type to perm variable
                    this.name = dr.GetString(1);
                    conn.Close();
                    permission.UpdatePermission(this.perm);
                }
                menuAttribute(db.dbS, db.dbN, db.dbU, this.perm, this.name, textBox2.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access Denied!");
                textBox2.Clear();
                textBox1.Clear();
                textBox2.Focus();
                button1.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Environment.Exit(0); // exit the app
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font, FontStyle.Bold);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font(label3.Font, FontStyle.Regular);
        }
    }
}