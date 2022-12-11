namespace CJ.Win.HR
{
    partial class frmAnnualLeavePlans
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblPONo = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lvwAnnualLeavePlan = new System.Windows.Forms.ListView();
            this.colLeavePlanID = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colDepartmentName = new System.Windows.Forms.ColumnHeader();
            this.colFromDate = new System.Windows.Forms.ColumnHeader();
            this.colToDate = new System.Windows.Forms.ColumnHeader();
            this.colInChargeName = new System.Windows.Forms.ColumnHeader();
            this.colLeaveTotal = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(808, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(467, 63);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(78, 26);
            this.btnGetData.TabIndex = 15;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONo.Location = new System.Drawing.Point(12, 70);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(125, 13);
            this.lblPONo.TabIndex = 13;
            this.lblPONo.Text = "Employee Name like ";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(139, 67);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(311, 20);
            this.txtEmpName.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Location = new System.Drawing.Point(15, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 53);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(19, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(56, 24);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(150, 20);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(253, 24);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(150, 20);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(225, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(16, 27);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // lvwAnnualLeavePlan
            // 
            this.lvwAnnualLeavePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAnnualLeavePlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLeavePlanID,
            this.colCreateDate,
            this.colEmployeeName,
            this.colDepartmentName,
            this.colFromDate,
            this.colToDate,
            this.colInChargeName,
            this.colLeaveTotal});
            this.lvwAnnualLeavePlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwAnnualLeavePlan.FullRowSelect = true;
            this.lvwAnnualLeavePlan.GridLines = true;
            this.lvwAnnualLeavePlan.HideSelection = false;
            this.lvwAnnualLeavePlan.Location = new System.Drawing.Point(15, 99);
            this.lvwAnnualLeavePlan.MultiSelect = false;
            this.lvwAnnualLeavePlan.Name = "lvwAnnualLeavePlan";
            this.lvwAnnualLeavePlan.Size = new System.Drawing.Size(787, 292);
            this.lvwAnnualLeavePlan.TabIndex = 16;
            this.lvwAnnualLeavePlan.UseCompatibleStateImageBehavior = false;
            this.lvwAnnualLeavePlan.View = System.Windows.Forms.View.Details;
            // 
            // colLeavePlanID
            // 
            this.colLeavePlanID.Text = "LeavePlanID";
            this.colLeavePlanID.Width = 77;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "CreateDate";
            this.colCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCreateDate.Width = 86;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 218;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Text = "Department Name";
            this.colDepartmentName.Width = 309;
            // 
            // colFromDate
            // 
            this.colFromDate.Text = "FromDate";
            this.colFromDate.Width = 83;
            // 
            // colToDate
            // 
            this.colToDate.Text = "ToDate";
            this.colToDate.Width = 78;
            // 
            // colInChargeName
            // 
            this.colInChargeName.Text = "InChargeName";
            this.colInChargeName.Width = 182;
            // 
            // colLeaveTotal
            // 
            this.colLeaveTotal.Text = "LeaveTotal";
            this.colLeaveTotal.Width = 70;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(808, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(808, 128);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmAnnualLeavePlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 413);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwAnnualLeavePlan);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblPONo);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmAnnualLeavePlans";
            this.Text = "Annual Leave Plans";
            this.Load += new System.EventHandler(this.frmAnnualLeavePlans_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblPONo;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ListView lvwAnnualLeavePlan;
        private System.Windows.Forms.ColumnHeader colLeavePlanID;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colFromDate;
        private System.Windows.Forms.ColumnHeader colToDate;
        private System.Windows.Forms.ColumnHeader colInChargeName;
        private System.Windows.Forms.ColumnHeader colDepartmentName;
        private System.Windows.Forms.ColumnHeader colLeaveTotal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
    }
}