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
        public string perm;
        public string name;
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = button1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM security WHERE username = '" + textBox2.Text + "' AND password = '" + textBox1.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dbClass db = new dbClass();
                Menu mm = new Menu();
                // Preparing permissions before showing the menu
                Permission permission = new Permission();
                if (dr.Read())
                {
                    this.perm = dr.GetString(4); // passing value from user type to perm variable
                    this.name = dr.GetString(1);
                    conn.Close();
                    if (this.perm == "admin") // if the user type of logged user is admin
                    {
                        permission.UpdatePermission(this.perm);
                        // optional put messagebox "You are logged in as admin"
                    }
                    else
                    {
                        permission.UpdatePermission(this.perm);
                        // optional put messagebox "You are logged in as user"
                    }
                }
                // setting menu items values
                DateTime dtime = DateTime.Now;
                mm.dbServer.Text = db.dbS;
                mm.dbName.Text = db.dbN;
                mm.dbUser.Text = db.dbU;
                mm.lastLog.Text = dtime.ToString("MM/dd/yyyy h:mm tt");
                mm.txtUserType.Text = this.perm;
                mm.label12.Text = this.name;
                mm.userLogged.Text = textBox2.Text;
                // calling the menu form
                
                mm.Show();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_MouseHover(object sender, EventArgs e) {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e) {
            
        }

        private void button1_Enter(object sender, EventArgs e) {
            
        }

        private void button1_Leave(object sender, EventArgs e) {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e) {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e) {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e) {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0); // exit the app
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {

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
