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
    public partial class StudentInfo : Form
    {
        SqlConnection connect = dbClass.getConnection();
        viewInfo obj = new viewInfo();

        public StudentInfo()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "SOMEONE@EXAMPLE.COM")
            {
                textBox9.Text = "";
            }
            textBox9.ForeColor = Color.Black;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
                sda.InsertCommand = new SqlCommand("INSERT INTO Student_Info (studentID, FirstName, MiddleName, LastName, Address, BirthDate, Gender, Contact, Email, YearLevel, Course) VALUES (@stud_id, @stud_fname, @stud_mname, @stud_lname, @stud_address, @BirthDate, @Gender, @Contact, @Email, @stud_year, @stud_course)", connect);
                sda.InsertCommand.Parameters.Add("@stud_id", SqlDbType.Int).Value = textBox1.Text;
                sda.InsertCommand.Parameters.Add("@stud_fname", SqlDbType.VarChar).Value = textBox2.Text;
                sda.InsertCommand.Parameters.Add("@stud_mname", SqlDbType.VarChar).Value = textBox3.Text;
                sda.InsertCommand.Parameters.Add("@stud_lname", SqlDbType.VarChar).Value = textBox4.Text;
                sda.InsertCommand.Parameters.Add("@stud_address", SqlDbType.VarChar).Value = textBox5.Text;
                sda.InsertCommand.Parameters.Add("@stud_course", SqlDbType.VarChar).Value = courseBox.Text;
                sda.InsertCommand.Parameters.Add("@stud_year", SqlDbType.VarChar).Value = comboBox1.Text;
                sda.InsertCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar).Value = comboBox3.Text;
                sda.InsertCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = comboBox2.Text;
                sda.InsertCommand.Parameters.Add("@Contact", SqlDbType.VarChar).Value = textBox8.Text;
                sda.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = textBox9.Text;

                connect.Open();
                sda.InsertCommand.ExecuteNonQuery();
                connect.Close();
                //ClearEntry();
                obj.displayInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Record is already added!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}