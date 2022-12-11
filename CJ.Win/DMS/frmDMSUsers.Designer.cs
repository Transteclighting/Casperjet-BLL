namespace CJ.Win.Security
{
    partial class frmDMSUsers
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
            this.txtUserNameLike = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.DistributorID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstview = new System.Windows.Forms.ListView();
            this.RegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Operationdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOptDateChange = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserNameLike
            // 
            this.txtUserNameLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserNameLike.Location = new System.Drawing.Point(107, 5);
            this.txtUserNameLike.Name = "txtUserNameLike";
            this.txtUserNameLike.Size = new System.Drawing.Size(250, 20);
            this.txtUserNameLike.TabIndex = 33;
            this.txtUserNameLike.TextChanged += new System.EventHandler(this.txtUserNameLike_TextChanged);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(19, 8);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(83, 13);
            this.lblOrderNo.TabIndex = 32;
            this.lblOrderNo.Text = "User Name Like";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(909, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 27);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Location = new System.Drawing.Point(914, 98);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(95, 27);
            this.btndelete.TabIndex = 30;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnedit
            // 
            this.btnedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedit.Location = new System.Drawing.Point(914, 65);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(95, 27);
            this.btnedit.TabIndex = 29;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Location = new System.Drawing.Point(914, 32);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(95, 27);
            this.btnadd.TabIndex = 28;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // DistributorID
            // 
            this.DistributorID.Text = "Distributor ID";
            this.DistributorID.Width = 0;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Customer Name";
            this.CustomerName.Width = 218;
            // 
            // lstview
            // 
            this.lstview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DistributorID,
            this.RegionName,
            this.AreaName,
            this.TerritoryName,
            this.CustomerName,
            this.Operationdate,
            this.MobileNo});
            this.lstview.FullRowSelect = true;
            this.lstview.GridLines = true;
            this.lstview.HideSelection = false;
            this.lstview.Location = new System.Drawing.Point(13, 31);
            this.lstview.Name = "lstview";
            this.lstview.Size = new System.Drawing.Size(895, 380);
            this.lstview.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstview.TabIndex = 27;
            this.lstview.UseCompatibleStateImageBehavior = false;
            this.lstview.View = System.Windows.Forms.View.Details;
            // 
            // RegionName
            // 
            this.RegionName.Text = "Region Name";
            this.RegionName.Width = 143;
            // 
            // AreaName
            // 
            this.AreaName.Text = "Area Name";
            this.AreaName.Width = 115;
            // 
            // TerritoryName
            // 
            this.TerritoryName.Text = "Territory Name";
            this.TerritoryName.Width = 99;
            // 
            // Operationdate
            // 
            this.Operationdate.Text = "Operation Date";
            this.Operationdate.Width = 103;
            // 
            // MobileNo
            // 
            this.MobileNo.Text = "Mobile No";
            this.MobileNo.Width = 100;
            // 
            // btnOptDateChange
            // 
            this.btnOptDateChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptDateChange.Location = new System.Drawing.Point(914, 131);
            this.btnOptDateChange.Name = "btnOptDateChange";
            this.btnOptDateChange.Size = new System.Drawing.Size(95, 27);
            this.btnOptDateChange.TabIndex = 34;
            this.btnOptDateChange.Text = "Operation Date Change";
            this.btnOptDateChange.UseVisualStyleBackColor = true;
            this.btnOptDateChange.Click += new System.EventHandler(this.btnOptDateChange_Click);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Location = new System.Drawing.Point(914, 164);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(95, 27);
            this.btnSync.TabIndex = 35;
            this.btnSync.Text = "User Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // frmDMSUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 416);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnOptDateChange);
            this.Controls.Add(this.txtUserNameLike);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lstview);
            this.Name = "frmDMSUsers";
            this.Text = "frmDMSUsers";
            this.Load += new System.EventHandler(this.frmDMSUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNameLike;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ColumnHeader DistributorID;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ListView lstview;
        private System.Windows.Forms.ColumnHeader Operationdate;
        private System.Windows.Forms.Button btnOptDateChange;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.ColumnHeader RegionName;
        private System.Windows.Forms.ColumnHeader AreaName;
        private System.Windows.Forms.ColumnHeader TerritoryName;
        private System.Windows.Forms.ColumnHeader MobileNo;
    }
}