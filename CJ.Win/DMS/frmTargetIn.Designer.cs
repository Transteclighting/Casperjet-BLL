namespace CJ.Win.DMS
{
    partial class frmTargetIn
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
            this.pbTargetIn = new System.Windows.Forms.ProgressBar();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lvwTargetList = new System.Windows.Forms.ListView();
            this.colDistributorID = new System.Windows.Forms.ColumnHeader();
            this.colCustomerCode = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colAreaName = new System.Windows.Forms.ColumnHeader();
            this.colRouteID = new System.Windows.Forms.ColumnHeader();
            this.colRouteN = new System.Windows.Forms.ColumnHeader();
            this.colLMSale = new System.Windows.Forms.ColumnHeader();
            this.colTargetDate = new System.Windows.Forms.ColumnHeader();
            this.colASGID = new System.Windows.Forms.ColumnHeader();
            this.colBrandID = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.rdoTargetTR = new System.Windows.Forms.RadioButton();
            this.rdoASGTR = new System.Windows.Forms.RadioButton();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // pbTargetIn
            // 
            this.pbTargetIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTargetIn.Location = new System.Drawing.Point(12, 41);
            this.pbTargetIn.Name = "pbTargetIn";
            this.pbTargetIn.Size = new System.Drawing.Size(843, 23);
            this.pbTargetIn.TabIndex = 73;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Location = new System.Drawing.Point(123, 15);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 20);
            this.txtCustomerName.TabIndex = 75;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(12, 18);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(105, 13);
            this.lblOrderNo.TabIndex = 74;
            this.lblOrderNo.Text = "Customer Name Like";
            // 
            // lvwTargetList
            // 
            this.lvwTargetList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTargetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDistributorID,
            this.colCustomerCode,
            this.colCustomerName,
            this.colAreaName,
            this.colRouteID,
            this.colRouteN,
            this.colLMSale,
            this.colTargetDate,
            this.colASGID,
            this.colBrandID});
            this.lvwTargetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTargetList.FullRowSelect = true;
            this.lvwTargetList.GridLines = true;
            this.lvwTargetList.HideSelection = false;
            this.lvwTargetList.Location = new System.Drawing.Point(12, 75);
            this.lvwTargetList.MultiSelect = false;
            this.lvwTargetList.Name = "lvwTargetList";
            this.lvwTargetList.Size = new System.Drawing.Size(843, 373);
            this.lvwTargetList.TabIndex = 76;
            this.lvwTargetList.UseCompatibleStateImageBehavior = false;
            this.lvwTargetList.View = System.Windows.Forms.View.Details;
            // 
            // colDistributorID
            // 
            this.colDistributorID.Text = "CustomerID";
            this.colDistributorID.Width = 100;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 150;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area Name";
            this.colAreaName.Width = 150;
            // 
            // colRouteID
            // 
            this.colRouteID.Text = "RouteID";
            // 
            // colRouteN
            // 
            this.colRouteN.Text = "Route Name";
            this.colRouteN.Width = 150;
            // 
            // colLMSale
            // 
            this.colLMSale.Text = "LMSale";
            this.colLMSale.Width = 100;
            // 
            // colTargetDate
            // 
            this.colTargetDate.Text = "Target Date";
            this.colTargetDate.Width = 150;
            // 
            // colASGID
            // 
            this.colASGID.Text = "ASGID";
            // 
            // colBrandID
            // 
            this.colBrandID.Text = "BrandID";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(862, 136);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 27);
            this.btnClose.TabIndex = 78;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(861, 103);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(77, 27);
            this.btnProcess.TabIndex = 77;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // rdoTargetTR
            // 
            this.rdoTargetTR.AutoSize = true;
            this.rdoTargetTR.Checked = true;
            this.rdoTargetTR.Location = new System.Drawing.Point(390, 16);
            this.rdoTargetTR.Name = "rdoTargetTR";
            this.rdoTargetTR.Size = new System.Drawing.Size(74, 17);
            this.rdoTargetTR.TabIndex = 79;
            this.rdoTargetTR.TabStop = true;
            this.rdoTargetTR.Text = "Target TO";
            this.rdoTargetTR.UseVisualStyleBackColor = true;
            // 
            // rdoASGTR
            // 
            this.rdoASGTR.AutoSize = true;
            this.rdoASGTR.Location = new System.Drawing.Point(470, 16);
            this.rdoASGTR.Name = "rdoASGTR";
            this.rdoASGTR.Size = new System.Drawing.Size(81, 17);
            this.rdoASGTR.TabIndex = 80;
            this.rdoASGTR.Text = "ASG Target";
            this.rdoASGTR.UseVisualStyleBackColor = true;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(750, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 84;
            this.lblTo.Text = "To";
            this.lblTo.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(557, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 83;
            this.lblDate.Text = "From";
            this.lblDate.Visible = false;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(775, 17);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 82;
            this.dtToDate.Visible = false;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(594, 17);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 20);
            this.dtFromDate.TabIndex = 81;
            this.dtFromDate.Visible = false;
            // 
            // frmTargetIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 460);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.rdoTargetTR);
            this.Controls.Add(this.rdoASGTR);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lvwTargetList);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.pbTargetIn);
            this.Name = "frmTargetIn";
            this.Text = "DMS Target";
            this.Load += new System.EventHandler(this.frmTargetIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbTargetIn;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.ListView lvwTargetList;
        private System.Windows.Forms.ColumnHeader colDistributorID;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colRouteID;
        private System.Windows.Forms.ColumnHeader colRouteN;
        private System.Windows.Forms.ColumnHeader colLMSale;
        private System.Windows.Forms.ColumnHeader colTargetDate;
        private System.Windows.Forms.ColumnHeader colASGID;
        private System.Windows.Forms.ColumnHeader colBrandID;
        private System.Windows.Forms.RadioButton rdoTargetTR;
        private System.Windows.Forms.RadioButton rdoASGTR;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
    }
}