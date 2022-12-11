namespace CJ.Win.BEIL
{
    partial class frmProductionLotDetail
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
            this.cmbLotType = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPONo = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.colWorkType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceiveQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwProductionLot = new System.Windows.Forms.ListView();
            this.colLotNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceiveDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlanQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActualQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQCPass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQCFail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnActual = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnEditPlan = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(911, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 27);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.Text = "Plan";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbLotType
            // 
            this.cmbLotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbLotType.FormattingEnabled = true;
            this.cmbLotType.Location = new System.Drawing.Point(98, 102);
            this.cmbLotType.Name = "cmbLotType";
            this.cmbLotType.Size = new System.Drawing.Size(157, 21);
            this.cmbLotType.TabIndex = 52;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(35, 105);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 13);
            this.lblStatus.TabIndex = 51;
            this.lblStatus.Text = "Lot Type";
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONo.Location = new System.Drawing.Point(47, 79);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(45, 13);
            this.lblPONo.TabIndex = 53;
            this.lblPONo.Text = "Lot No";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(98, 76);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(157, 20);
            this.txtLotNo.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Product Name ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Product Code";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(356, 129);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(375, 20);
            this.txtName.TabIndex = 65;
            // 
            // colWorkType
            // 
            this.colWorkType.Text = "Work Type";
            this.colWorkType.Width = 66;
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(56, 26);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(150, 20);
            this.dtFromdate.TabIndex = 2;
            // 
            // cmbWorkType
            // 
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbWorkType.FormattingEnabled = true;
            this.cmbWorkType.Location = new System.Drawing.Point(356, 98);
            this.cmbWorkType.Name = "cmbWorkType";
            this.cmbWorkType.Size = new System.Drawing.Size(163, 21);
            this.cmbWorkType.TabIndex = 50;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 96;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 59);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(19, 2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(253, 26);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(150, 20);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(225, 26);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(16, 29);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 80;
            // 
            // colReceiveQty
            // 
            this.colReceiveQty.Text = "Receive Qty";
            this.colReceiveQty.Width = 71;
            // 
            // lvwProductionLot
            // 
            this.lvwProductionLot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductionLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotNo,
            this.colRefNo,
            this.colReceiveDate,
            this.colLotType,
            this.colWorkType,
            this.colProductCode,
            this.colProductName,
            this.colReceiveQty,
            this.colPlanQty,
            this.colActualQty,
            this.colQCPass,
            this.colQCFail});
            this.lvwProductionLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwProductionLot.FullRowSelect = true;
            this.lvwProductionLot.GridLines = true;
            this.lvwProductionLot.HideSelection = false;
            this.lvwProductionLot.Location = new System.Drawing.Point(14, 161);
            this.lvwProductionLot.MultiSelect = false;
            this.lvwProductionLot.Name = "lvwProductionLot";
            this.lvwProductionLot.Size = new System.Drawing.Size(891, 255);
            this.lvwProductionLot.TabIndex = 47;
            this.lvwProductionLot.UseCompatibleStateImageBehavior = false;
            this.lvwProductionLot.View = System.Windows.Forms.View.Details;
            // 
            // colLotNo
            // 
            this.colLotNo.Text = "Lot No";
            this.colLotNo.Width = 72;
            // 
            // colRefNo
            // 
            this.colRefNo.Text = "Ref. No";
            this.colRefNo.Width = 67;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.Text = "ReceiveDate";
            this.colReceiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colReceiveDate.Width = 68;
            // 
            // colLotType
            // 
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 70;
            // 
            // colPlanQty
            // 
            this.colPlanQty.Text = "PlanQty";
            // 
            // colActualQty
            // 
            this.colActualQty.Text = "ActualQty";
            // 
            // colQCPass
            // 
            this.colQCPass.Text = "QCPass";
            // 
            // colQCFail
            // 
            this.colQCFail.Text = "QCFail";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(98, 129);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(157, 20);
            this.txtCode.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Ref. No";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(356, 72);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(163, 20);
            this.txtRefNo.TabIndex = 59;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(911, 389);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnActual
            // 
            this.btnActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActual.Location = new System.Drawing.Point(911, 227);
            this.btnActual.Name = "btnActual";
            this.btnActual.Size = new System.Drawing.Size(75, 27);
            this.btnActual.TabIndex = 56;
            this.btnActual.Text = "Actual";
            this.btnActual.UseVisualStyleBackColor = true;
            this.btnActual.Click += new System.EventHandler(this.btnActual_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(739, 125);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(77, 27);
            this.btnGetData.TabIndex = 55;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(281, 102);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(69, 13);
            this.lblCompany.TabIndex = 49;
            this.lblCompany.Text = "Work Type";
            // 
            // btnEditPlan
            // 
            this.btnEditPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPlan.Location = new System.Drawing.Point(911, 194);
            this.btnEditPlan.Name = "btnEditPlan";
            this.btnEditPlan.Size = new System.Drawing.Size(75, 27);
            this.btnEditPlan.TabIndex = 66;
            this.btnEditPlan.Text = "Edit Plan";
            this.btnEditPlan.UseVisualStyleBackColor = true;
            this.btnEditPlan.Click += new System.EventHandler(this.btnEditPlan_Click);
            // 
            // frmProductionLotDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 436);
            this.Controls.Add(this.btnEditPlan);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbLotType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPONo);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbWorkType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvwProductionLot);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActual);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblCompany);
            this.Name = "frmProductionLotDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionLotDetail";
            this.Load += new System.EventHandler(this.frmProductionLotDetail_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbLotType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPONo;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ColumnHeader colWorkType;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colReceiveQty;
        private System.Windows.Forms.ListView lvwProductionLot;
        private System.Windows.Forms.ColumnHeader colLotNo;
        private System.Windows.Forms.ColumnHeader colRefNo;
        private System.Windows.Forms.ColumnHeader colReceiveDate;
        private System.Windows.Forms.ColumnHeader colLotType;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnActual;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ColumnHeader colPlanQty;
        private System.Windows.Forms.ColumnHeader colActualQty;
        private System.Windows.Forms.ColumnHeader colQCPass;
        private System.Windows.Forms.ColumnHeader colQCFail;
        private System.Windows.Forms.Button btnEditPlan;
    }
}