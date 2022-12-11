namespace CJ.Win.Security
{
    partial class frmUserOther
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
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.chkResetPassword = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfimrPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPermittedApp = new System.Windows.Forms.ComboBox();
            this.lblTechnician = new System.Windows.Forms.Label();
            this.ctlCSDTechnician1 = new CJ.Win.ctlCSDTechnician();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(143, 143);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 17);
            this.chkIsActive.TabIndex = 21;
            this.chkIsActive.Text = "Is Active?";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.Visible = false;
            // 
            // chkResetPassword
            // 
            this.chkResetPassword.AutoSize = true;
            this.chkResetPassword.Location = new System.Drawing.Point(27, 143);
            this.chkResetPassword.Name = "chkResetPassword";
            this.chkResetPassword.Size = new System.Drawing.Size(103, 17);
            this.chkResetPassword.TabIndex = 17;
            this.chkResetPassword.Text = "Reset Password";
            this.chkResetPassword.UseVisualStyleBackColor = true;
            this.chkResetPassword.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtConfimrPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 84);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(63, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(307, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfimrPassword
            // 
            this.txtConfimrPassword.Location = new System.Drawing.Point(63, 45);
            this.txtConfimrPassword.Name = "txtConfimrPassword";
            this.txtConfimrPassword.Size = new System.Drawing.Size(307, 20);
            this.txtConfimrPassword.TabIndex = 3;
            this.txtConfimrPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 26);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(442, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 26);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Location = new System.Drawing.Point(86, 37);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(307, 20);
            this.txtUserFullName.TabIndex = 14;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(86, 11);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(307, 20);
            this.txtUserName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "User Full Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "App";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "User Name";
            // 
            // cmbPermittedApp
            // 
            this.cmbPermittedApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPermittedApp.FormattingEnabled = true;
            this.cmbPermittedApp.Location = new System.Drawing.Point(86, 62);
            this.cmbPermittedApp.Name = "cmbPermittedApp";
            this.cmbPermittedApp.Size = new System.Drawing.Size(307, 21);
            this.cmbPermittedApp.TabIndex = 22;
            this.cmbPermittedApp.SelectedIndexChanged += new System.EventHandler(this.cmbPermittedApp_SelectedIndexChanged);
            // 
            // lblTechnician
            // 
            this.lblTechnician.AutoSize = true;
            this.lblTechnician.Location = new System.Drawing.Point(28, 95);
            this.lblTechnician.Name = "lblTechnician";
            this.lblTechnician.Size = new System.Drawing.Size(54, 13);
            this.lblTechnician.TabIndex = 24;
            this.lblTechnician.Text = "Techician";
            // 
            // ctlCSDTechnician1
            // 
            this.ctlCSDTechnician1.Location = new System.Drawing.Point(86, 87);
            this.ctlCSDTechnician1.Name = "ctlCSDTechnician1";
            this.ctlCSDTechnician1.Size = new System.Drawing.Size(443, 31);
            this.ctlCSDTechnician1.TabIndex = 23;
            // 
            // frmUserOther
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 284);
            this.Controls.Add(this.lblTechnician);
            this.Controls.Add(this.ctlCSDTechnician1);
            this.Controls.Add(this.cmbPermittedApp);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.chkResetPassword);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmUserOther";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Other";
            this.Load += new System.EventHandler(this.frmUserOther_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox chkResetPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfimrPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPermittedApp;
        private ctlCSDTechnician ctlCSDTechnician1;
        private System.Windows.Forms.Label lblTechnician;
    }
}