namespace CJ.Win.CSD.CallCenter
{
    partial class frmFeedbackDateChange
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
            this.lvwFeedbackList = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colJobStatus = new System.Windows.Forms.ColumnHeader();
            this.colSubStatus = new System.Windows.Forms.ColumnHeader();
            this.colTechnician = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblNextFollowupDate = new System.Windows.Forms.Label();
            this.dtFeedbackDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.SuspendLayout();
            // 
            // lvwFeedbackList
            // 
            this.lvwFeedbackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colJobStatus,
            this.colSubStatus,
            this.colTechnician,
            this.colRemarks,
            this.colCreateUser,
            this.colCreateDate});
            this.lvwFeedbackList.FullRowSelect = true;
            this.lvwFeedbackList.GridLines = true;
            this.lvwFeedbackList.HideSelection = false;
            this.lvwFeedbackList.Location = new System.Drawing.Point(12, 160);
            this.lvwFeedbackList.MultiSelect = false;
            this.lvwFeedbackList.Name = "lvwFeedbackList";
            this.lvwFeedbackList.Size = new System.Drawing.Size(554, 112);
            this.lvwFeedbackList.TabIndex = 224;
            this.lvwFeedbackList.UseCompatibleStateImageBehavior = false;
            this.lvwFeedbackList.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Feedback Date";
            this.colDate.Width = 90;
            // 
            // colJobStatus
            // 
            this.colJobStatus.Text = "Job Status";
            this.colJobStatus.Width = 100;
            // 
            // colSubStatus
            // 
            this.colSubStatus.Text = "Sub Status";
            this.colSubStatus.Width = 100;
            // 
            // colTechnician
            // 
            this.colTechnician.Text = "Technician";
            this.colTechnician.Width = 100;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 300;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 226;
            this.label1.Text = "Conversation Text";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(13, 106);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(552, 46);
            this.txtRemarks.TabIndex = 225;
            // 
            // lblNextFollowupDate
            // 
            this.lblNextFollowupDate.AutoSize = true;
            this.lblNextFollowupDate.Location = new System.Drawing.Point(15, 65);
            this.lblNextFollowupDate.Name = "lblNextFollowupDate";
            this.lblNextFollowupDate.Size = new System.Drawing.Size(81, 13);
            this.lblNextFollowupDate.TabIndex = 228;
            this.lblNextFollowupDate.Text = "Feedback Date";
            // 
            // dtFeedbackDate
            // 
            this.dtFeedbackDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFeedbackDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFeedbackDate.Location = new System.Drawing.Point(97, 63);
            this.dtFeedbackDate.Name = "dtFeedbackDate";
            this.dtFeedbackDate.Size = new System.Drawing.Size(117, 20);
            this.dtFeedbackDate.TabIndex = 227;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 230;
            this.label2.Text = "Job Number";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(405, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.TabIndex = 232;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(489, 282);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 25);
            this.btnClose.TabIndex = 231;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(97, 37);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(468, 20);
            this.txtCustomerName.TabIndex = 233;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 234;
            this.label3.Text = "Customer Name";
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(97, 10);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(468, 20);
            this.ctlCSDJob1.TabIndex = 229;
            this.ctlCSDJob1.ChangeSelection += new System.EventHandler(this.ctlCSDJob1_ChangeSelection);
            // 
            // frmFeedbackDateChange
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 314);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.lblNextFollowupDate);
            this.Controls.Add(this.dtFeedbackDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lvwFeedbackList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFeedbackDateChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback Date Change";
            this.Load += new System.EventHandler(this.frmFeedbackDateChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFeedbackList;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colJobStatus;
        private System.Windows.Forms.ColumnHeader colSubStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblNextFollowupDate;
        private System.Windows.Forms.DateTimePicker dtFeedbackDate;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colTechnician;
        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
    }
}