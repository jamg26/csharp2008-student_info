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
            this.ActiveControl = textBox2;
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
                MessageBox.Show("Access Granted!");
                this.Hide();
                //MainMenu mm = new MainMenu();
                //mm.Show();
                Menu mm = new Menu();
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

    }
}
