namespace Information_System_Galicia
{
    partial class UsersAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpUserReg = new System.Windows.Forms.GroupBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.userAddBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPerm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRePass = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpUserReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(6, 73);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(192, 20);
            this.txtUser.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 9);
            this.label2.TabIndex = 7;
            this.label2.Text = "USERNAME";
            // 
            // grpUserReg
            // 
            this.grpUserReg.Controls.Add(this.deleteBtn);
            this.grpUserReg.Controls.Add(this.updateBtn);
            this.grpUserReg.Controls.Add(this.userAddBtn);
            this.grpUserReg.Controls.Add(this.label3);
            this.grpUserReg.Controls.Add(this.cmbPerm);
            this.grpUserReg.Controls.Add(this.label4);
            this.grpUserReg.Controls.Add(this.label1);
            this.grpUserReg.Controls.Add(this.label5);
            this.grpUserReg.Controls.Add(this.label2);
            this.grpUserReg.Controls.Add(this.txtRePass);
            this.grpUserReg.Controls.Add(this.txtFullName);
            this.grpUserReg.Controls.Add(this.txtPass);
            this.grpUserReg.Controls.Add(this.txtUser);
            this.grpUserReg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpUserReg.Location = new System.Drawing.Point(12, 12);
            this.grpUserReg.Name = "grpUserReg";
            this.grpUserReg.Size = new System.Drawing.Size(204, 260);
            this.grpUserReg.TabIndex = 8;
            this.grpUserReg.TabStop = false;
            this.grpUserReg.Text = "User Information";
            // 
            // deleteBtn
            // 
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteBtn.Location = new System.Drawing.Point(87, 223);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 11;
            this.deleteBtn.Text = "DELETE";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateBtn.Location = new System.Drawing.Point(6, 223);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 10;
            this.updateBtn.Text = "UPDATE";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // userAddBtn
            // 
            this.userAddBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userAddBtn.Location = new System.Drawing.Point(6, 223);
            this.userAddBtn.Name = "userAddBtn";
            this.userAddBtn.Size = new System.Drawing.Size(75, 23);
            this.userAddBtn.TabIndex = 4;
            this.userAddBtn.Text = "REGISTER";
            this.userAddBtn.UseVisualStyleBackColor = true;
            this.userAddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(6, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 9);
            this.label3.TabIndex = 9;
            this.label3.Text = "USER TYPE";
            // 
            // cmbPerm
            // 
            this.cmbPerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerm.FormattingEnabled = true;
            this.cmbPerm.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.cmbPerm.Location = new System.Drawing.Point(6, 182);
            this.cmbPerm.Name = "cmbPerm";
            this.cmbPerm.Size = new System.Drawing.Size(109, 21);
            this.cmbPerm.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 9);
            this.label4.TabIndex = 7;
            this.label4.Text = "RE TYPE PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 9);
            this.label1.TabIndex = 7;
            this.label1.Text = "PASSWORD";
            // 
            // txtRePass
            // 
            this.txtRePass.Location = new System.Drawing.Point(6, 145);
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.PasswordChar = '*';
            this.txtRePass.Size = new System.Drawing.Size(192, 20);
            this.txtRePass.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(6, 108);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(192, 20);
            this.txtPass.TabIndex = 1;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(6, 34);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(192, 20);
            this.txtFullName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 9);
            this.label5.TabIndex = 7;
            this.label5.Text = "FULL NAME";
            // 
            // UsersAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(229, 288);
            this.Controls.Add(this.grpUserReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UsersAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UsersAdd_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UsersAdd_FormClosed);
            this.grpUserReg.ResumeLayout(false);
            this.grpUserReg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpUserReg;
        private System.Windows.Forms.ComboBox cmbPerm;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtRePass;
        public System.Windows.Forms.Button userAddBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtFullName;
    }
}