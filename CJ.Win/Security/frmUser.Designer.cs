namespace CJ.Win.Security
{
    partial class frmUser
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
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.UserNam = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPass = new System.Windows.Forms.GroupBox();
            this.setpass = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tvwPermission = new System.Windows.Forms.TreeView();
            this.lvwSBUs = new System.Windows.Forms.ListView();
            this.colSBUCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSBUName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlNewEmployee = new CJ.Win.ctlEmployee();
            this.groupPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(83, 19);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(295, 20);
            this.TxtPass.TabIndex = 4;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(18, 19);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(72, 16);
            this.Password.TabIndex = 11;
            this.Password.Text = "Password";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(96, 38);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(307, 20);
            this.TxtUserName.TabIndex = 1;
            // 
            // UserNam
            // 
            this.UserNam.Location = new System.Drawing.Point(16, 40);
            this.UserNam.Name = "UserNam";
            this.UserNam.Size = new System.Drawing.Size(74, 20);
            this.UserNam.TabIndex = 9;
            this.UserNam.Text = "User Name";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(382, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "OK";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(83, 45);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(295, 20);
            this.txtconfirm.TabIndex = 5;
            this.txtconfirm.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm";
            // 
            // groupPass
            // 
            this.groupPass.Controls.Add(this.label1);
            this.groupPass.Controls.Add(this.TxtPass);
            this.groupPass.Controls.Add(this.txtconfirm);
            this.groupPass.Controls.Add(this.Password);
            this.groupPass.Location = new System.Drawing.Point(11, 239);
            this.groupPass.Name = "groupPass";
            this.groupPass.Size = new System.Drawing.Size(389, 79);
            this.groupPass.TabIndex = 3;
            this.groupPass.TabStop = false;
            // 
            // setpass
            // 
            this.setpass.Location = new System.Drawing.Point(15, 214);
            this.setpass.Name = "setpass";
            this.setpass.Size = new System.Drawing.Size(108, 19);
            this.setpass.TabIndex = 2;
            this.setpass.Text = "Reset Password";
            this.setpass.UseVisualStyleBackColor = true;
            this.setpass.CheckedChanged += new System.EventHandler(this.setpass_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(468, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Location = new System.Drawing.Point(96, 12);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(307, 20);
            this.txtUserFullName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "User Full Name";
            // 
            // tvwPermission
            // 
            this.tvwPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwPermission.CheckBoxes = true;
            this.tvwPermission.Location = new System.Drawing.Point(11, 324);
            this.tvwPermission.Name = "tvwPermission";
            this.tvwPermission.Size = new System.Drawing.Size(539, 211);
            this.tvwPermission.TabIndex = 6;
            this.tvwPermission.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwPermission_AfterCheck);
            // 
            // lvwSBUs
            // 
            this.lvwSBUs.CheckBoxes = true;
            this.lvwSBUs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSBUCode,
            this.colSBUName});
            this.lvwSBUs.Location = new System.Drawing.Point(94, 102);
            this.lvwSBUs.Name = "lvwSBUs";
            this.lvwSBUs.Size = new System.Drawing.Size(456, 97);
            this.lvwSBUs.TabIndex = 57;
            this.lvwSBUs.UseCompatibleStateImageBehavior = false;
            this.lvwSBUs.View = System.Windows.Forms.View.Details;
            // 
            // colSBUCode
            // 
            this.colSBUCode.Text = "SBU Code";
            this.colSBUCode.Width = 100;
            // 
            // colSBUName
            // 
            this.colSBUName.Text = "SBU Name";
            this.colSBUName.Width = 350;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "User\'s SBU(s)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "Empoyee";
            // 
            // ctlNewEmployee
            // 
            this.ctlNewEmployee.Location = new System.Drawing.Point(94, 67);
            this.ctlNewEmployee.Name = "ctlNewEmployee";
            this.ctlNewEmployee.Size = new System.Drawing.Size(454, 25);
            this.ctlNewEmployee.TabIndex = 61;
            // 
            // frmUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(571, 582);
            this.Controls.Add(this.ctlNewEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwSBUs);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tvwPermission);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.setpass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.UserNam);
            this.Controls.Add(this.groupPass);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.groupPass.ResumeLayout(false);
            this.groupPass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label UserNam;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupPass;
        private System.Windows.Forms.CheckBox setpass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvwPermission;
        private System.Windows.Forms.ListView lvwSBUs;
        private System.Windows.Forms.ColumnHeader colSBUCode;
        private System.Windows.Forms.ColumnHeader colSBUName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private ctlEmployee ctlNewEmployee;
    }
}