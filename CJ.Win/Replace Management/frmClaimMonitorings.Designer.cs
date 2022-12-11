namespace CJ.Win.Replace_Management
{
    partial class frmClaimMonitorings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaimMonitorings));
            this.lblCustCode = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwReplaceClaims = new System.Windows.Forms.ListView();
            this.RegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClaimedForMonth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSettlementType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRep = new System.Windows.Forms.Button();
            this.btnTPKPI = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustCode
            // 
            this.lblCustCode.AutoSize = true;
            this.lblCustCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustCode.Location = new System.Drawing.Point(12, 22);
            this.lblCustCode.Name = "lblCustCode";
            this.lblCustCode.Size = new System.Drawing.Size(92, 13);
            this.lblCustCode.TabIndex = 193;
            this.lblCustCode.Text = "Customer Code";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(110, 49);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 205;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 204;
            this.label3.Text = "Settlement Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(510, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 210;
            this.label4.Text = "Claim From";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(842, 14);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(63, 23);
            this.btnGetData.TabIndex = 209;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(694, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 207;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(722, 17);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 208;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(587, 17);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 206;
            // 
            // lvwReplaceClaims
            // 
            this.lvwReplaceClaims.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReplaceClaims.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RegionName,
            this.AreaName,
            this.TerritoryName,
            this.CustomerCode,
            this.CustomerName,
            this.colCustomerType,
            this.ClaimedForMonth,
            this.colSettlementType,
            this.Remarks});
            this.lvwReplaceClaims.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwReplaceClaims.FullRowSelect = true;
            this.lvwReplaceClaims.GridLines = true;
            this.lvwReplaceClaims.Location = new System.Drawing.Point(12, 73);
            this.lvwReplaceClaims.MultiSelect = false;
            this.lvwReplaceClaims.Name = "lvwReplaceClaims";
            this.lvwReplaceClaims.Size = new System.Drawing.Size(1184, 537);
            this.lvwReplaceClaims.TabIndex = 211;
            this.lvwReplaceClaims.UseCompatibleStateImageBehavior = false;
            this.lvwReplaceClaims.View = System.Windows.Forms.View.Details;
            // 
            // RegionName
            // 
            this.RegionName.Text = "Region";
            this.RegionName.Width = 92;
            // 
            // AreaName
            // 
            this.AreaName.Text = "Area";
            this.AreaName.Width = 80;
            // 
            // TerritoryName
            // 
            this.TerritoryName.Text = "Territory";
            this.TerritoryName.Width = 100;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Text = "Code";
            this.CustomerCode.Width = 61;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Name";
            this.CustomerName.Width = 182;
            // 
            // colCustomerType
            // 
            this.colCustomerType.Text = "DB Type";
            this.colCustomerType.Width = 98;
            // 
            // ClaimedForMonth
            // 
            this.ClaimedForMonth.Text = "Settlement Date";
            this.ClaimedForMonth.Width = 112;
            // 
            // colSettlementType
            // 
            this.colSettlementType.Text = "Settlement Type";
            this.colSettlementType.Width = 112;
            // 
            // Remarks
            // 
            this.Remarks.Text = "Remarks";
            this.Remarks.Width = 318;
            // 
            // btRep
            // 
            this.btRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRep.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRep.Location = new System.Drawing.Point(1205, 79);
            this.btRep.Name = "btRep";
            this.btRep.Size = new System.Drawing.Size(130, 25);
            this.btRep.TabIndex = 212;
            this.btRep.Text = "Add Replacement";
            this.btRep.UseVisualStyleBackColor = true;
            this.btRep.Click += new System.EventHandler(this.btRep_Click);
            // 
            // btnTPKPI
            // 
            this.btnTPKPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTPKPI.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTPKPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTPKPI.Location = new System.Drawing.Point(1205, 110);
            this.btnTPKPI.Name = "btnTPKPI";
            this.btnTPKPI.Size = new System.Drawing.Size(130, 25);
            this.btnTPKPI.TabIndex = 213;
            this.btnTPKPI.Text = "Add TP or KPI";
            this.btnTPKPI.UseVisualStyleBackColor = true;
            this.btnTPKPI.Click += new System.EventHandler(this.btnTPKPI_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(110, 21);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(383, 25);
            this.ctlCustomer1.TabIndex = 194;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1231, 578);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 216;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmClaimMonitorings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 628);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTPKPI);
            this.Controls.Add(this.btRep);
            this.Controls.Add(this.lvwReplaceClaims);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lblCustCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClaimMonitorings";
            this.Text = "Claim Monitorings";
            this.Load += new System.EventHandler(this.frmClaimMonitorings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label lblCustCode;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwReplaceClaims;
        private System.Windows.Forms.ColumnHeader RegionName;
        private System.Windows.Forms.ColumnHeader AreaName;
        private System.Windows.Forms.ColumnHeader TerritoryName;
        private System.Windows.Forms.ColumnHeader CustomerCode;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader ClaimedForMonth;
        private System.Windows.Forms.ColumnHeader colSettlementType;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.Button btRep;
        private System.Windows.Forms.Button btnTPKPI;
        private System.Windows.Forms.ColumnHeader colCustomerType;
        private System.Windows.Forms.Button btnClose;
    }
}