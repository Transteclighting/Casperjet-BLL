namespace CJ.Win
{
    partial class frmStatusUpdatesForcely
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
            this.lvwCSDJobs = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastFeedBackDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStatusUpdate = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.SuspendLayout();
            // 
            // lvwCSDJobs
            // 
            this.lvwCSDJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colJobType,
            this.colJobStatus,
            this.colSubStatus,
            this.colServiceType,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCreateDate,
            this.colLastFeedBackDate});
            this.lvwCSDJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDJobs.FullRowSelect = true;
            this.lvwCSDJobs.GridLines = true;
            this.lvwCSDJobs.HideSelection = false;
            this.lvwCSDJobs.Location = new System.Drawing.Point(12, 70);
            this.lvwCSDJobs.MultiSelect = false;
            this.lvwCSDJobs.Name = "lvwCSDJobs";
            this.lvwCSDJobs.Size = new System.Drawing.Size(730, 297);
            this.lvwCSDJobs.TabIndex = 5;
            this.lvwCSDJobs.UseCompatibleStateImageBehavior = false;
            this.lvwCSDJobs.View = System.Windows.Forms.View.Details;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job#";
            this.colJobNo.Width = 92;
            // 
            // colJobType
            // 
            this.colJobType.Text = "Job Type";
            this.colJobType.Width = 88;
            // 
            // colJobStatus
            // 
            this.colJobStatus.Text = "Job Status";
            this.colJobStatus.Width = 92;
            // 
            // colSubStatus
            // 
            this.colSubStatus.Text = "Sub Status";
            this.colSubStatus.Width = 74;
            // 
            // colServiceType
            // 
            this.colServiceType.Text = "Service Type";
            this.colServiceType.Width = 94;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 129;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Text = "Customer Address";
            this.colCustomerAddress.Width = 134;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 89;
            // 
            // colLastFeedBackDate
            // 
            this.colLastFeedBackDate.Text = "L.F. Date";
            this.colLastFeedBackDate.Width = 86;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(748, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStatusUpdate
            // 
            this.btnStatusUpdate.Location = new System.Drawing.Point(748, 70);
            this.btnStatusUpdate.Name = "btnStatusUpdate";
            this.btnStatusUpdate.Size = new System.Drawing.Size(90, 28);
            this.btnStatusUpdate.TabIndex = 4;
            this.btnStatusUpdate.Text = "Status Update";
            this.btnStatusUpdate.UseVisualStyleBackColor = true;
            this.btnStatusUpdate.Click += new System.EventHandler(this.btnStatusUpdate_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(652, 36);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(90, 28);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Location = new System.Drawing.Point(13, 30);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(41, 13);
            this.lblJobNo.TabIndex = 0;
            this.lblJobNo.Text = "Job No";
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(58, 27);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(502, 20);
            this.ctlCSDJob1.TabIndex = 6;
            // 
            // frmStatusUpdatesForcely
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 379);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnStatusUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvwCSDJobs);
            this.Name = "frmStatusUpdatesForcely";
            this.Text = "Forcely Status Update";
            this.Load += new System.EventHandler(this.frmForcelyStatusUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCSDJobs;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colJobStatus;
        private System.Windows.Forms.ColumnHeader colSubStatus;
        private System.Windows.Forms.ColumnHeader colServiceType;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCustomerAddress;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colLastFeedBackDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStatusUpdate;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblJobNo;
        private ctlCSDJob ctlCSDJob1;
    }
}