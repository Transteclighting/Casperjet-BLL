namespace CJ.Control
{
    partial class frmClaims
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
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwInvoice = new System.Windows.Forms.ListView();
            this.colClaimNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btGetData = new System.Windows.Forms.Button();
            this.colIsInvoice = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(215, 2);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 20);
            this.dtToDate.TabIndex = 165;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(68, 1);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(106, 20);
            this.dtFromDate.TabIndex = 164;
            // 
            // lvwInvoice
            // 
            this.lvwInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colClaimNo,
            this.colCustomer,
            this.colDate,
            this.colIsInvoice});
            this.lvwInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwInvoice.FullRowSelect = true;
            this.lvwInvoice.GridLines = true;
            this.lvwInvoice.HideSelection = false;
            this.lvwInvoice.Location = new System.Drawing.Point(3, 46);
            this.lvwInvoice.MultiSelect = false;
            this.lvwInvoice.Name = "lvwInvoice";
            this.lvwInvoice.Size = new System.Drawing.Size(465, 359);
            this.lvwInvoice.TabIndex = 163;
            this.lvwInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwInvoice.View = System.Windows.Forms.View.Details;
            this.lvwInvoice.DoubleClick += new System.EventHandler(this.lvwInvoice_DoubleClick);
            this.lvwInvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwInvoice_KeyPress);
            // 
            // colClaimNo
            // 
            this.colClaimNo.Text = "Claim No";
            this.colClaimNo.Width = 120;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 200;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(190, 5);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 167;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(31, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 166;
            this.lblDate.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 168;
            this.label1.Text = "Claim No:";
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Location = new System.Drawing.Point(68, 24);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(160, 20);
            this.txtClaimNo.TabIndex = 169;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(193, 406);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(83, 22);
            this.btClose.TabIndex = 170;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btGetData
            // 
            this.btGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGetData.Location = new System.Drawing.Point(233, 22);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(90, 23);
            this.btGetData.TabIndex = 171;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // colIsInvoice
            // 
            this.colIsInvoice.Text = "Status";
            this.colIsInvoice.Width = 100;
            // 
            // frmClaims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 429);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.txtClaimNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwInvoice);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Name = "frmClaims";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Claim List";
            this.Load += new System.EventHandler(this.frmClaims_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwInvoice;
        private System.Windows.Forms.ColumnHeader colClaimNo;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.ColumnHeader colIsInvoice;
    }
}