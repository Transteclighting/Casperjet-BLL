namespace CJ.Win.DMS
{
    partial class frmDMSUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserNam = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.setpass = new System.Windows.Forms.CheckBox();
            this.Password = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.groupPass = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkEnableSerialNo = new System.Windows.Forms.CheckBox();
            this.tvwPermission = new System.Windows.Forms.TreeView();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbox = new System.Windows.Forms.CheckBox();
            this.txtDMSmobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImei = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtActDate = new System.Windows.Forms.DateTimePicker();
            this.groupPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm";
            // 
            // UserNam
            // 
            this.UserNam.Location = new System.Drawing.Point(17, 6);
            this.UserNam.Name = "UserNam";
            this.UserNam.Size = new System.Drawing.Size(72, 20);
            this.UserNam.TabIndex = 13;
            this.UserNam.Text = "User Name";
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(83, 15);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(295, 20);
            this.TxtPass.TabIndex = 4;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(83, 45);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(295, 20);
            this.txtconfirm.TabIndex = 5;
            this.txtconfirm.UseSystemPasswordChar = true;
            // 
            // setpass
            // 
            this.setpass.Location = new System.Drawing.Point(13, 125);
            this.setpass.Name = "setpass";
            this.setpass.Size = new System.Drawing.Size(108, 19);
            this.setpass.TabIndex = 11;
            this.setpass.Text = "Reset Password";
            this.setpass.UseVisualStyleBackColor = true;
            this.setpass.CheckedChanged += new System.EventHandler(this.setpass_CheckedChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(18, 19);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(63, 16);
            this.Password.TabIndex = 11;
            this.Password.Text = "Password";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(93, 5);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(307, 20);
            this.TxtUserName.TabIndex = 10;
            // 
            // groupPass
            // 
            this.groupPass.Controls.Add(this.label1);
            this.groupPass.Controls.Add(this.TxtPass);
            this.groupPass.Controls.Add(this.txtconfirm);
            this.groupPass.Controls.Add(this.Password);
            this.groupPass.Location = new System.Drawing.Point(9, 145);
            this.groupPass.Name = "groupPass";
            this.groupPass.Size = new System.Drawing.Size(389, 79);
            this.groupPass.TabIndex = 12;
            this.groupPass.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Distributor";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(445, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(359, 477);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "OK";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkEnableSerialNo
            // 
            this.chkEnableSerialNo.Location = new System.Drawing.Point(9, 231);
            this.chkEnableSerialNo.Name = "chkEnableSerialNo";
            this.chkEnableSerialNo.Size = new System.Drawing.Size(154, 19);
            this.chkEnableSerialNo.TabIndex = 19;
            this.chkEnableSerialNo.Text = "Enable Serial Number";
            this.chkEnableSerialNo.UseVisualStyleBackColor = true;
            // 
            // tvwPermission
            // 
            this.tvwPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwPermission.CheckBoxes = true;
            this.tvwPermission.Location = new System.Drawing.Point(9, 263);
            this.tvwPermission.Name = "tvwPermission";
            this.tvwPermission.Size = new System.Drawing.Size(516, 209);
            this.tvwPermission.TabIndex = 21;
            this.tvwPermission.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwPermission_AfterCheck);
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(17, 68);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(72, 20);
            this.lblMobile.TabIndex = 25;
            this.lblMobile.Text = "DB Mobile";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(93, 66);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(159, 20);
            this.txtMobile.TabIndex = 26;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(93, 31);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 25);
            this.ctlCustomer1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "IsActive";
            // 
            // ckbox
            // 
            this.ckbox.AutoSize = true;
            this.ckbox.Location = new System.Drawing.Point(206, 233);
            this.ckbox.Name = "ckbox";
            this.ckbox.Size = new System.Drawing.Size(15, 14);
            this.ckbox.TabIndex = 28;
            this.ckbox.UseVisualStyleBackColor = true;
            // 
            // txtDMSmobile
            // 
            this.txtDMSmobile.Location = new System.Drawing.Point(93, 94);
            this.txtDMSmobile.Name = "txtDMSmobile";
            this.txtDMSmobile.Size = new System.Drawing.Size(158, 20);
            this.txtDMSmobile.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "DMS Mobile:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtImei
            // 
            this.txtImei.Location = new System.Drawing.Point(356, 65);
            this.txtImei.Name = "txtImei";
            this.txtImei.Size = new System.Drawing.Size(158, 20);
            this.txtImei.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(267, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "IMEI NO:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(267, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Activated Date";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dtActDate
            // 
            this.dtActDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtActDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtActDate.Location = new System.Drawing.Point(356, 97);
            this.dtActDate.Name = "dtActDate";
            this.dtActDate.Size = new System.Drawing.Size(112, 20);
            this.dtActDate.TabIndex = 45;
            this.dtActDate.Value = new System.DateTime(2022, 3, 31, 0, 0, 0, 0);
            // 
            // frmDMSUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 510);
            this.Controls.Add(this.dtActDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDMSmobile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImei);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.tvwPermission);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.chkEnableSerialNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNam);
            this.Controls.Add(this.setpass);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.groupPass);
            this.Name = "frmDMSUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDMSUser";
            this.Load += new System.EventHandler(this.frmDMSUser_Load);
            this.groupPass.ResumeLayout(false);
            this.groupPass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserNam;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.CheckBox setpass;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.GroupBox groupPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkEnableSerialNo;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.TreeView tvwPermission;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbox;
        private System.Windows.Forms.TextBox txtDMSmobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImei;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtActDate;
    }
}