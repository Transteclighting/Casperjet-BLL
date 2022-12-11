namespace CJ.Win.CSD
{
    partial class frmExchangeOfferMoneyReceiptTransfers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeOfferMoneyReceiptTransfers));
            this.txtMRNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetMR = new System.Windows.Forms.Button();
            this.lvwMR = new System.Windows.Forms.ListView();
            this.colMRNo = new System.Windows.Forms.ColumnHeader();
            this.colMRDate = new System.Windows.Forms.ColumnHeader();
            this.colJob = new System.Windows.Forms.ColumnHeader();
            this.colCreateWH = new System.Windows.Forms.ColumnHeader();
            this.colTransferWH = new System.Windows.Forms.ColumnHeader();
            this.colMRAmount = new System.Windows.Forms.ColumnHeader();
            this.colMRStatus = new System.Windows.Forms.ColumnHeader();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMRNo
            // 
            this.txtMRNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRNo.Location = new System.Drawing.Point(62, 74);
            this.txtMRNo.Name = "txtMRNo";
            this.txtMRNo.Size = new System.Drawing.Size(201, 20);
            this.txtMRNo.TabIndex = 225;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 224;
            this.label7.Text = "MR No:";
            // 
            // btnGetMR
            // 
            this.btnGetMR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetMR.Location = new System.Drawing.Point(511, 70);
            this.btnGetMR.Name = "btnGetMR";
            this.btnGetMR.Size = new System.Drawing.Size(73, 26);
            this.btnGetMR.TabIndex = 223;
            this.btnGetMR.Text = "Get Data";
            this.btnGetMR.UseVisualStyleBackColor = true;
            this.btnGetMR.Click += new System.EventHandler(this.btnGetMR_Click);
            // 
            // lvwMR
            // 
            this.lvwMR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMRNo,
            this.colMRDate,
            this.colJob,
            this.colCreateWH,
            this.colTransferWH,
            this.colMRAmount,
            this.colMRStatus});
            this.lvwMR.FullRowSelect = true;
            this.lvwMR.GridLines = true;
            this.lvwMR.Location = new System.Drawing.Point(12, 100);
            this.lvwMR.Name = "lvwMR";
            this.lvwMR.Size = new System.Drawing.Size(727, 301);
            this.lvwMR.TabIndex = 222;
            this.lvwMR.UseCompatibleStateImageBehavior = false;
            this.lvwMR.View = System.Windows.Forms.View.Details;
            // 
            // colMRNo
            // 
            this.colMRNo.Text = "MR No";
            this.colMRNo.Width = 121;
            // 
            // colMRDate
            // 
            this.colMRDate.Text = "Create Date";
            this.colMRDate.Width = 82;
            // 
            // colJob
            // 
            this.colJob.Text = "JOB No";
            this.colJob.Width = 119;
            // 
            // colCreateWH
            // 
            this.colCreateWH.Text = "Create WH";
            this.colCreateWH.Width = 103;
            // 
            // colTransferWH
            // 
            this.colTransferWH.Text = "Transfer WH";
            this.colTransferWH.Width = 86;
            // 
            // colMRAmount
            // 
            this.colMRAmount.Text = "MR Amount";
            this.colMRAmount.Width = 84;
            // 
            // colMRStatus
            // 
            this.colMRStatus.Text = "MR Status";
            this.colMRStatus.Width = 82;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(56, 35);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(166, 20);
            this.dtFromDate.TabIndex = 227;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 226;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 56);
            this.groupBox1.TabIndex = 228;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 185;
            this.label2.Text = "To";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(246, 23);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(158, 20);
            this.dtToDate.TabIndex = 186;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.Location = new System.Drawing.Point(745, 102);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 229;
            this.btnTransfer.Text = "Transfer MR";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(745, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 230;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmExchangeOfferMoneyReceiptTransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 414);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMRNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGetMR);
            this.Controls.Add(this.lvwMR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExchangeOfferMoneyReceiptTransfers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExchangeOfferMoneyReceiptTransfers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMRNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetMR;
        private System.Windows.Forms.ListView lvwMR;
        private System.Windows.Forms.ColumnHeader colMRNo;
        private System.Windows.Forms.ColumnHeader colMRDate;
        private System.Windows.Forms.ColumnHeader colJob;
        private System.Windows.Forms.ColumnHeader colCreateWH;
        private System.Windows.Forms.ColumnHeader colTransferWH;
        private System.Windows.Forms.ColumnHeader colMRAmount;
        private System.Windows.Forms.ColumnHeader colMRStatus;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnClose;
    }
}