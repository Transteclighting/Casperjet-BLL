namespace CJ.Win.Security
{
    partial class frmUsers
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
            this.lstview = new System.Windows.Forms.ListView();
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnadd = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.txtUserNameLike = new System.Windows.Forms.TextBox();
            this.btDataPermission = new System.Windows.Forms.Button();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.btnSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstview
            // 
            this.lstview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.UserFullName,
            this.UserName,
            this.colEmployeeName});
            this.lstview.FullRowSelect = true;
            this.lstview.GridLines = true;
            this.lstview.HideSelection = false;
            this.lstview.Location = new System.Drawing.Point(12, 116);
            this.lstview.Name = "lstview";
            this.lstview.Size = new System.Drawing.Size(551, 397);
            this.lstview.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstview.TabIndex = 7;
            this.lstview.UseCompatibleStateImageBehavior = false;
            this.lstview.View = System.Windows.Forms.View.Details;
            this.lstview.DoubleClick += new System.EventHandler(this.lstview_DoubleClick);
            // 
            // UserID
            // 
            this.UserID.Text = "User ID";
            this.UserID.Width = 54;
            // 
            // UserFullName
            // 
            this.UserFullName.Text = "User Full Name";
            this.UserFullName.Width = 140;
            // 
            // UserName
            // 
            this.UserName.Text = "User Name";
            this.UserName.Width = 93;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 245;
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Location = new System.Drawing.Point(571, 116);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(91, 27);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnedit
            // 
            this.btnedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedit.Location = new System.Drawing.Point(571, 149);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(91, 27);
            this.btnedit.TabIndex = 9;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Location = new System.Drawing.Point(571, 453);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(91, 27);
            this.btndelete.TabIndex = 11;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(571, 486);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(32, 12);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(89, 13);
            this.lblOrderNo.TabIndex = 0;
            this.lblOrderNo.Text = "User Name (Like)";
            // 
            // txtUserNameLike
            // 
            this.txtUserNameLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNameLike.Location = new System.Drawing.Point(123, 10);
            this.txtUserNameLike.Name = "txtUserNameLike";
            this.txtUserNameLike.Size = new System.Drawing.Size(250, 20);
            this.txtUserNameLike.TabIndex = 1;
            // 
            // btDataPermission
            // 
            this.btDataPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDataPermission.Location = new System.Drawing.Point(571, 182);
            this.btDataPermission.Name = "btDataPermission";
            this.btDataPermission.Size = new System.Drawing.Size(91, 27);
            this.btDataPermission.TabIndex = 10;
            this.btDataPermission.Text = "Data Permission";
            this.btDataPermission.UseVisualStyleBackColor = true;
            this.btDataPermission.Click += new System.EventHandler(this.btDataPermission_Click);
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserFullName.Location = new System.Drawing.Point(123, 36);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(250, 20);
            this.txtUserFullName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Full Name (Like)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Employee Code";
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(472, 85);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(91, 27);
            this.btnGet.TabIndex = 6;
            this.btnGet.Text = "Get Data";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(123, 62);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(444, 25);
            this.ctlEmployee1.TabIndex = 5;
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Location = new System.Drawing.Point(571, 215);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(91, 27);
            this.btnSync.TabIndex = 36;
            this.btnSync.Text = "User Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // frmUsers
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 525);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDataPermission);
            this.Controls.Add(this.txtUserNameLike);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lstview);
            this.Name = "frmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstview;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader UserFullName;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.TextBox txtUserNameLike;
        private System.Windows.Forms.Button btDataPermission;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label1;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSync;
    }
}