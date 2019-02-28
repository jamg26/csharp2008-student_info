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
        public Login()
        {
            InitializeComponent();
            //this.ActiveControl = textBox2;
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
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM security WHERE username = '" + textBox2.Text + "' AND password = '" + textBox1.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Access Granted!");
                this.Hide();
                //MainMenu mm = new MainMenu();
                //mm.Show();
                dbClass db = new dbClass();
                Menu mm = new Menu();

                mm.dbServer.Text = db.dbS;
                mm.dbName.Text = db.dbN;
                mm.dbUser.Text = db.dbU;

                mm.userLogged.Text = textBox2.Text;
                mm.Show();
                
            }
            else
            {
                MessageBox.Show("Access Denied!");
                textBox2.Clear();
                textBox1.Clear();
                textBox2.Focus();
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

        }

        private void button1_MouseHover(object sender, EventArgs e) {
            //button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e) {
            //button1.ForeColor = Color.Black;
        }

        private void button1_Enter(object sender, EventArgs e) {
            //button1.ForeColor = Color.Red;
        }

        private void button1_Leave(object sender, EventArgs e) {
            //button1.ForeColor = Color.Black;
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

    }
}
