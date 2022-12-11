namespace CJ.Win.DMS
{
    partial class frmDMSDSRs
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
            this.lvwDSRs = new System.Windows.Forms.ListView();
            this.colAreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTerritory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDSRCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDSRName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesignation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFixedSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDailyTADA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDBBLAccno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDBBLMobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBkashAccountNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDSRCode = new System.Windows.Forms.TextBox();
            this.lblDSRCode = new System.Windows.Forms.Label();
            this.lblDSRName = new System.Windows.Forms.Label();
            this.txtDSRName = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.colVariableSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwDSRs
            // 
            this.lvwDSRs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDSRs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAreaName,
            this.colTerritory,
            this.colCustomer,
            this.colDSRCode,
            this.colDSRName,
            this.colDesignation,
            this.colMobile,
            this.colFixedSalary,
            this.colVariableSalary,
            this.colDailyTADA,
            this.colDBBLAccno,
            this.colDBBLMobNo,
            this.colBkashAccountNo,
            this.colGrade,
            this.colPosition,
            this.colIsCurrent});
            this.lvwDSRs.FullRowSelect = true;
            this.lvwDSRs.GridLines = true;
            this.lvwDSRs.HideSelection = false;
            this.lvwDSRs.Location = new System.Drawing.Point(11, 75);
            this.lvwDSRs.Name = "lvwDSRs";
            this.lvwDSRs.Size = new System.Drawing.Size(1124, 373);
            this.lvwDSRs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwDSRs.TabIndex = 28;
            this.lvwDSRs.UseCompatibleStateImageBehavior = false;
            this.lvwDSRs.View = System.Windows.Forms.View.Details;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area Name";
            this.colAreaName.Width = 93;
            // 
            // colTerritory
            // 
            this.colTerritory.Text = "Territory Name";
            this.colTerritory.Width = 102;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer Name";
            this.colCustomer.Width = 103;
            // 
            // colDSRCode
            // 
            this.colDSRCode.Text = "SA Code";
            this.colDSRCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDSRCode.Width = 63;
            // 
            // colDSRName
            // 
            this.colDSRName.Text = "SA Name";
            this.colDSRName.Width = 108;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 69;
            // 
            // colMobile
            // 
            this.colMobile.Text = "SA Mobile";
            this.colMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMobile.Width = 82;
            // 
            // colFixedSalary
            // 
            this.colFixedSalary.Text = "Fixed Salary";
            this.colFixedSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colDailyTADA
            // 
            this.colDailyTADA.DisplayIndex = 8;
            this.colDailyTADA.Text = "Daily TADA";
            this.colDailyTADA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDailyTADA.Width = 70;
            // 
            // colDBBLAccno
            // 
            this.colDBBLAccno.DisplayIndex = 9;
            this.colDBBLAccno.Text = "DBBL Account";
            // 
            // colDBBLMobNo
            // 
            this.colDBBLMobNo.DisplayIndex = 10;
            this.colDBBLMobNo.Text = "DBBL Rocket";
            // 
            // colBkashAccountNo
            // 
            this.colBkashAccountNo.DisplayIndex = 11;
            this.colBkashAccountNo.Text = "Bkash";
            // 
            // colGrade
            // 
            this.colGrade.DisplayIndex = 12;
            this.colGrade.Text = "Grade";
            // 
            // colPosition
            // 
            this.colPosition.DisplayIndex = 13;
            this.colPosition.Text = "Position";
            // 
            // colIsCurrent
            // 
            this.colIsCurrent.DisplayIndex = 14;
            this.colIsCurrent.Text = "IsCurrent";
            this.colIsCurrent.Width = 70;
            // 
            // btnedit
            // 
            this.btnedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.Location = new System.Drawing.Point(1141, 131);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(95, 27);
            this.btnedit.TabIndex = 31;
            this.btnedit.Text = "Update";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(1141, 87);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(95, 27);
            this.btnadd.TabIndex = 30;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1141, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 27);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDSRCode
            // 
            this.txtDSRCode.Location = new System.Drawing.Point(371, 49);
            this.txtDSRCode.Name = "txtDSRCode";
            this.txtDSRCode.Size = new System.Drawing.Size(141, 20);
            this.txtDSRCode.TabIndex = 33;
            // 
            // lblDSRCode
            // 
            this.lblDSRCode.AutoSize = true;
            this.lblDSRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSRCode.Location = new System.Drawing.Point(299, 49);
            this.lblDSRCode.Name = "lblDSRCode";
            this.lblDSRCode.Size = new System.Drawing.Size(56, 13);
            this.lblDSRCode.TabIndex = 34;
            this.lblDSRCode.Text = "SA Code";
            // 
            // lblDSRName
            // 
            this.lblDSRName.AutoSize = true;
            this.lblDSRName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSRName.Location = new System.Drawing.Point(9, 46);
            this.lblDSRName.Name = "lblDSRName";
            this.lblDSRName.Size = new System.Drawing.Size(59, 13);
            this.lblDSRName.TabIndex = 35;
            this.lblDSRName.Text = "SA Name";
            // 
            // txtDSRName
            // 
            this.txtDSRName.Location = new System.Drawing.Point(110, 46);
            this.txtDSRName.Name = "txtDSRName";
            this.txtDSRName.Size = new System.Drawing.Size(178, 20);
            this.txtDSRName.TabIndex = 36;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(532, 46);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 37;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(12, 14);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(95, 13);
            this.lblCustomerName.TabIndex = 38;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(110, 11);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(402, 20);
            this.txtCustomerName.TabIndex = 39;
            // 
            // colVariableSalary
            // 
            this.colVariableSalary.Text = "Variable Salary";
            // 
            // frmDMSDSRs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 460);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.txtDSRName);
            this.Controls.Add(this.lblDSRName);
            this.Controls.Add(this.lblDSRCode);
            this.Controls.Add(this.txtDSRCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lvwDSRs);
            this.Name = "frmDMSDSRs";
            this.Text = "frmDMSDSRs";
            this.Load += new System.EventHandler(this.frmDMSDSRs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDSRs;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colDSRName;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colFixedSalary;
        private System.Windows.Forms.ColumnHeader colDSRCode;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colTerritory;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colDailyTADA;
        private System.Windows.Forms.TextBox txtDSRCode;
        private System.Windows.Forms.Label lblDSRCode;
        private System.Windows.Forms.Label lblDSRName;
        private System.Windows.Forms.TextBox txtDSRName;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colIsCurrent;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ColumnHeader colGrade;
        private System.Windows.Forms.ColumnHeader colPosition;
        private System.Windows.Forms.ColumnHeader colDBBLAccno;
        private System.Windows.Forms.ColumnHeader colDBBLMobNo;
        private System.Windows.Forms.ColumnHeader colBkashAccountNo;
        private System.Windows.Forms.ColumnHeader colVariableSalary;
    }
}