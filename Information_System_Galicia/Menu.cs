﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            StudentInfo add = new StudentInfo();
            add.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            getStudentsInfo();

        }

        public void getStudentsInfo() {
            conn.Open();
            DataTable dt = new DataTable();
            DataTable du = new DataTable();
            DataTable dv = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student_Info", conn);
            sda.Fill(dt);
            countReg.Text = Convert.ToString(dt.Rows.Count);

            SqlDataAdapter sdb = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'MALE'", conn);
            sdb.Fill(du);
            countMale.Text = Convert.ToString(du.Rows.Count);

            SqlDataAdapter sdc = new SqlDataAdapter("SELECT * FROM Student_Info WHERE Gender = 'FEMALE'", conn);
            sdc.Fill(dv);
            countFemale.Text = Convert.ToString(dv.Rows.Count);


            conn.Close();

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
    }
}