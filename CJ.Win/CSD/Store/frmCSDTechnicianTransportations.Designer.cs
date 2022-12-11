namespace CJ.Win.CSD.Store
{
    partial class frmCSDTechnicianTransportations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSDTechnicianTransportations));
            this.btnReportView = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwTechTranList = new System.Windows.Forms.ListView();
            this.colTechCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTechName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPartialAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTechCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReportView
            // 
            this.btnReportView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportView.Location = new System.Drawing.Point(744, 162);
            this.btnReportView.Name = "btnReportView";
            this.btnReportView.Size = new System.Drawing.Size(83, 27);
            this.btnReportView.TabIndex = 119;
            this.btnReportView.Text = "&Report";
            this.btnReportView.UseVisualStyleBackColor = true;
            this.btnReportView.Click += new System.EventHandler(this.btnReportView_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnApprove.Location = new System.Drawing.Point(744, 129);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(83, 27);
            this.btnApprove.TabIndex = 118;
            this.btnApprove.Tag = "M1.15";
            this.btnApprove.Text = "&Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(75, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 107;
            this.label6.Text = "Status : ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(131, 98);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(343, 23);
            this.cmbStatus.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 103;
            this.label1.Text = "Technician Name : ";
            // 
            // txtTechName
            // 
            this.txtTechName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTechName.Location = new System.Drawing.Point(131, 38);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(343, 21);
            this.txtTechName.TabIndex = 104;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearch.Location = new System.Drawing.Point(481, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 111;
            this.btnSearch.Text = "Get Data";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTo.Location = new System.Drawing.Point(298, 70);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 15);
            this.lblTo.TabIndex = 101;
            this.lblTo.Text = "To :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDate.Location = new System.Drawing.Point(80, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 15);
            this.lblDate.TabIndex = 99;
            this.lblDate.Text = "From : ";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(330, 67);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 21);
            this.dtToDate.TabIndex = 102;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(131, 67);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 21);
            this.dtFromDate.TabIndex = 100;
            // 
            // lvwTechTranList
            // 
            this.lvwTechTranList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTechTranList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTechCode,
            this.colTechName,
            this.colFromDate,
            this.colToDate,
            this.colAmount,
            this.colPartialAmt,
            this.colStatus,
            this.colCreateDate});
            this.lvwTechTranList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lvwTechTranList.FullRowSelect = true;
            this.lvwTechTranList.GridLines = true;
            this.lvwTechTranList.HideSelection = false;
            this.lvwTechTranList.Location = new System.Drawing.Point(12, 129);
            this.lvwTechTranList.MultiSelect = false;
            this.lvwTechTranList.Name = "lvwTechTranList";
            this.lvwTechTranList.Size = new System.Drawing.Size(726, 294);
            this.lvwTechTranList.TabIndex = 112;
            this.lvwTechTranList.UseCompatibleStateImageBehavior = false;
            this.lvwTechTranList.View = System.Windows.Forms.View.Details;
            // 
            // colTechCode
            // 
            this.colTechCode.Text = "Code";
            this.colTechCode.Width = 84;
            // 
            // colTechName
            // 
            this.colTechName.Text = "Technician Name";
            this.colTechName.Width = 159;
            // 
            // colFromDate
            // 
            this.colFromDate.Text = "From Date";
            this.colFromDate.Width = 83;
            // 
            // colToDate
            // 
            this.colToDate.Text = "To Date";
            this.colToDate.Width = 80;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 75;
            // 
            // colPartialAmt
            // 
            this.colPartialAmt.Text = "Partial Amount";
            this.colPartialAmt.Width = 96;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 66;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 79;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(76, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 121;
            this.label5.Text = "Create";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 120;
            this.label3.Text = "Approved";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(744, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 27);
            this.btnClose.TabIndex = 122;
            this.btnClose.Tag = "M1.15";
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 123;
            this.label2.Text = "Technician Code : ";
            // 
            // txtTechCode
            // 
            this.txtTechCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTechCode.Location = new System.Drawing.Point(131, 9);
            this.txtTechCode.Name = "txtTechCode";
            this.txtTechCode.Size = new System.Drawing.Size(343, 21);
            this.txtTechCode.TabIndex = 124;
            // 
            // frmCSDTechnicianTransportations
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTechCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReportView);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTechName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwTechTranList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCSDTechnicianTransportations";
            this.Text = "CSD Technician Transportations";
            this.Load += new System.EventHandler(this.frmCSDTechnicianTransportations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReportView;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTechName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwTechTranList;
        private System.Windows.Forms.ColumnHeader colTechName;
        private System.Windows.Forms.ColumnHeader colFromDate;
        private System.Windows.Forms.ColumnHeader colToDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colPartialAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTechCode;
        private System.Windows.Forms.ColumnHeader colTechCode;
    }
}