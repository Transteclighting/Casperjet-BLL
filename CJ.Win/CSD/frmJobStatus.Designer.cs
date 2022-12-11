namespace CJ.Win
{
    partial class frmJobStatus
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
            this.btnJobUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwJobs = new System.Windows.Forms.ListView();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colFirstAddress = new System.Windows.Forms.ColumnHeader();
            this.colMobile = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colJobCreationDate = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colISCode = new System.Windows.Forms.ColumnHeader();
            this.colISName = new System.Windows.Forms.ColumnHeader();
            this.colISAddress = new System.Windows.Forms.ColumnHeader();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnJobUpdate
            // 
            this.btnJobUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobUpdate.Location = new System.Drawing.Point(902, 109);
            this.btnJobUpdate.Name = "btnJobUpdate";
            this.btnJobUpdate.Size = new System.Drawing.Size(105, 27);
            this.btnJobUpdate.TabIndex = 10;
            this.btnJobUpdate.Tag = "";
            this.btnJobUpdate.Text = "Job Update";
            this.btnJobUpdate.UseVisualStyleBackColor = true;
            this.btnJobUpdate.Click += new System.EventHandler(this.btnJobUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(902, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwJobs
            // 
            this.lvwJobs.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvwJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwJobs.CheckBoxes = true;
            this.lvwJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colCustomerName,
            this.colFirstAddress,
            this.colMobile,
            this.colRemarks,
            this.colJobCreationDate,
            this.colProductCode,
            this.colProductName,
            this.colISCode,
            this.colISName,
            this.colISAddress});
            this.lvwJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwJobs.FullRowSelect = true;
            this.lvwJobs.GridLines = true;
            this.lvwJobs.HideSelection = false;
            this.lvwJobs.Location = new System.Drawing.Point(3, 109);
            this.lvwJobs.MultiSelect = false;
            this.lvwJobs.Name = "lvwJobs";
            this.lvwJobs.Size = new System.Drawing.Size(893, 364);
            this.lvwJobs.TabIndex = 6;
            this.lvwJobs.UseCompatibleStateImageBehavior = false;
            this.lvwJobs.View = System.Windows.Forms.View.Details;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 99;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 182;
            // 
            // colFirstAddress
            // 
            this.colFirstAddress.Text = "Customer Address";
            this.colFirstAddress.Width = 161;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Contact Number";
            this.colMobile.Width = 156;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 121;
            // 
            // colJobCreationDate
            // 
            this.colJobCreationDate.Text = "JobCreationDate";
            this.colJobCreationDate.Width = 162;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "ProductCode";
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            // 
            // colISCode
            // 
            this.colISCode.Text = "IS Code";
            // 
            // colISName
            // 
            this.colISName.Text = "IS Name";
            // 
            // colISAddress
            // 
            this.colISAddress.Text = "IS Address";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(179, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 95;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(27, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 94;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(205, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(106, 20);
            this.dtToDate.TabIndex = 93;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(65, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(107, 20);
            this.dtFromDate.TabIndex = 92;
            this.dtFromDate.Value = new System.DateTime(2012, 2, 14, 0, 0, 0, 0);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(280, 41);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 23);
            this.btnShow.TabIndex = 91;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(17, 44);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 97;
            this.lblJobNo.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(64, 41);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(210, 20);
            this.txtJobNo.TabIndex = 160;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Elephant", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(421, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(465, 35);
            this.lblTitle.TabIndex = 161;
            this.lblTitle.Text = "Inter Service Job Update Form";
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(9, 86);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(70, 17);
            this.ckbSelect.TabIndex = 162;
            this.ckbSelect.Text = "Select All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // frmJobStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 493);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnJobUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwJobs);
            this.Name = "frmJobStatus";
            this.Text = "Job Status";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmJobStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJobUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwJobs;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colFirstAddress;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colJobCreationDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colISCode;
        private System.Windows.Forms.ColumnHeader colISName;
        private System.Windows.Forms.ColumnHeader colISAddress;
    }
}