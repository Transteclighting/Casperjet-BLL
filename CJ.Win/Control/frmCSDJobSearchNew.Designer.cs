namespace CJ.Win.Control
{
    partial class frmCSDJobSearchNew
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
            this.btnGet = new System.Windows.Forms.Button();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwCSDJobs = new System.Windows.Forms.ListView();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(527, 20);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(89, 27);
            this.btnGet.TabIndex = 164;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(53, 36);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 163;
            this.lblJobNo.Text = "Job No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(371, 9);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(124, 20);
            this.txtContactNo.TabIndex = 162;
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(297, 12);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(71, 13);
            this.lblContactNo.TabIndex = 161;
            this.lblContactNo.Text = "Contact No";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(104, 10);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(182, 20);
            this.txtCustomerName.TabIndex = 160;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(7, 13);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerName.TabIndex = 159;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(104, 33);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(182, 20);
            this.txtJobNo.TabIndex = 158;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(511, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 157;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwCSDJobs
            // 
            this.lvwCSDJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colCustomerName,
            this.colContactNo,
            this.colAddress});
            this.lvwCSDJobs.FullRowSelect = true;
            this.lvwCSDJobs.GridLines = true;
            this.lvwCSDJobs.Location = new System.Drawing.Point(12, 61);
            this.lvwCSDJobs.MultiSelect = false;
            this.lvwCSDJobs.Name = "lvwCSDJobs";
            this.lvwCSDJobs.Size = new System.Drawing.Size(604, 261);
            this.lvwCSDJobs.TabIndex = 156;
            this.lvwCSDJobs.UseCompatibleStateImageBehavior = false;
            this.lvwCSDJobs.View = System.Windows.Forms.View.Details;
            this.lvwCSDJobs.SelectedIndexChanged += new System.EventHandler(this.lvwCSDJobs_SelectedIndexChanged);
            this.lvwCSDJobs.DoubleClick += new System.EventHandler(this.lvwCSDJobs_DoubleClick_1);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 76;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 128;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 93;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 275;
            // 
            // frmCSDJobSearchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 361);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwCSDJobs);
            this.Name = "frmCSDJobSearchNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD Job Search";
            this.Load += new System.EventHandler(this.frmJobSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwCSDJobs;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colAddress;
    }
}