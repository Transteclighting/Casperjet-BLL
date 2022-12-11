namespace CJ.Win
{
    partial class frmTechnicians
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lvwTechnicians = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colTechnicianName = new System.Windows.Forms.ColumnHeader();
            this.colWorkshopName = new System.Windows.Forms.ColumnHeader();
            this.colWorkshopLocation = new System.Windows.Forms.ColumnHeader();
            this.colSupervisorName = new System.Windows.Forms.ColumnHeader();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colIsVariable = new System.Windows.Forms.ColumnHeader();
            this.colThirdParty = new System.Windows.Forms.ColumnHeader();
            this.colMobileNo = new System.Windows.Forms.ColumnHeader();
            this.colMobileNo1 = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtTechnicianName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTechnicianCode = new System.Windows.Forms.TextBox();
            this.lblPartCode = new System.Windows.Forms.Label();
            this.lblTechnicianType = new System.Windows.Forms.Label();
            this.cmbTechnicianType = new System.Windows.Forms.ComboBox();
            this.lblWorkshop = new System.Windows.Forms.Label();
            this.cmbWorkshopType = new System.Windows.Forms.ComboBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThirdPartyName = new System.Windows.Forms.Label();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(963, 144);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Tag = "M34.2.2";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(963, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(963, 116);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 10;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "M34.2.1";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvwTechnicians
            // 
            this.lvwTechnicians.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTechnicians.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colTechnicianName,
            this.colWorkshopName,
            this.colWorkshopLocation,
            this.colSupervisorName,
            this.colIsActive,
            this.colCreatedBy,
            this.colType,
            this.colIsVariable,
            this.colThirdParty,
            this.colMobileNo,
            this.colMobileNo1,
            this.colCreateDate});
            this.lvwTechnicians.FullRowSelect = true;
            this.lvwTechnicians.GridLines = true;
            this.lvwTechnicians.Location = new System.Drawing.Point(8, 116);
            this.lvwTechnicians.MultiSelect = false;
            this.lvwTechnicians.Name = "lvwTechnicians";
            this.lvwTechnicians.Size = new System.Drawing.Size(946, 359);
            this.lvwTechnicians.TabIndex = 9;
            this.lvwTechnicians.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicians.View = System.Windows.Forms.View.Details;
            this.lvwTechnicians.DoubleClick += new System.EventHandler(this.lvwWorkshops_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            // 
            // colTechnicianName
            // 
            this.colTechnicianName.Text = "Technician Name";
            this.colTechnicianName.Width = 146;
            // 
            // colWorkshopName
            // 
            this.colWorkshopName.Text = "Workshop Name";
            this.colWorkshopName.Width = 117;
            // 
            // colWorkshopLocation
            // 
            this.colWorkshopLocation.Text = "WS Location";
            this.colWorkshopLocation.Width = 96;
            // 
            // colSupervisorName
            // 
            this.colSupervisorName.Text = "Supervisor";
            this.colSupervisorName.Width = 71;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            this.colIsActive.Width = 62;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 91;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colIsVariable
            // 
            this.colIsVariable.Text = "Is Variable";
            this.colIsVariable.Width = 56;
            // 
            // colThirdParty
            // 
            this.colThirdParty.Text = "Third Party";
            this.colThirdParty.Width = 98;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            // 
            // colMobileNo1
            // 
            this.colMobileNo1.Text = "Mobile No 2";
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 109;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(579, 80);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 27);
            this.btnGetData.TabIndex = 8;
            this.btnGetData.TabStop = false;
            this.btnGetData.Tag = "";
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtTechnicianName
            // 
            this.txtTechnicianName.Location = new System.Drawing.Point(80, 60);
            this.txtTechnicianName.Name = "txtTechnicianName";
            this.txtTechnicianName.Size = new System.Drawing.Size(208, 20);
            this.txtTechnicianName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tech. Name";
            // 
            // txtTechnicianCode
            // 
            this.txtTechnicianCode.Location = new System.Drawing.Point(80, 37);
            this.txtTechnicianCode.Name = "txtTechnicianCode";
            this.txtTechnicianCode.Size = new System.Drawing.Size(207, 20);
            this.txtTechnicianCode.TabIndex = 1;
            // 
            // lblPartCode
            // 
            this.lblPartCode.AutoSize = true;
            this.lblPartCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartCode.Location = new System.Drawing.Point(5, 40);
            this.lblPartCode.Name = "lblPartCode";
            this.lblPartCode.Size = new System.Drawing.Size(73, 13);
            this.lblPartCode.TabIndex = 0;
            this.lblPartCode.Text = "Tech. Code";
            // 
            // lblTechnicianType
            // 
            this.lblTechnicianType.AutoSize = true;
            this.lblTechnicianType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechnicianType.Location = new System.Drawing.Point(291, 41);
            this.lblTechnicianType.Name = "lblTechnicianType";
            this.lblTechnicianType.Size = new System.Drawing.Size(72, 13);
            this.lblTechnicianType.TabIndex = 4;
            this.lblTechnicianType.Text = "Tech. Type";
            // 
            // cmbTechnicianType
            // 
            this.cmbTechnicianType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnicianType.FormattingEnabled = true;
            this.cmbTechnicianType.Location = new System.Drawing.Point(367, 37);
            this.cmbTechnicianType.Name = "cmbTechnicianType";
            this.cmbTechnicianType.Size = new System.Drawing.Size(206, 21);
            this.cmbTechnicianType.TabIndex = 5;
            // 
            // lblWorkshop
            // 
            this.lblWorkshop.AutoSize = true;
            this.lblWorkshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkshop.Location = new System.Drawing.Point(299, 65);
            this.lblWorkshop.Name = "lblWorkshop";
            this.lblWorkshop.Size = new System.Drawing.Size(64, 13);
            this.lblWorkshop.TabIndex = 6;
            this.lblWorkshop.Text = "Workshop";
            // 
            // cmbWorkshopType
            // 
            this.cmbWorkshopType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshopType.FormattingEnabled = true;
            this.cmbWorkshopType.Location = new System.Drawing.Point(367, 61);
            this.cmbWorkshopType.Name = "cmbWorkshopType";
            this.cmbWorkshopType.Size = new System.Drawing.Size(206, 21);
            this.cmbWorkshopType.TabIndex = 7;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(80, 83);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(208, 20);
            this.txtMobile.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mobile";
            // 
            // lblThirdPartyName
            // 
            this.lblThirdPartyName.AutoSize = true;
            this.lblThirdPartyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdPartyName.Location = new System.Drawing.Point(8, 15);
            this.lblThirdPartyName.Name = "lblThirdPartyName";
            this.lblThirdPartyName.Size = new System.Drawing.Size(69, 13);
            this.lblThirdPartyName.TabIndex = 15;
            this.lblThirdPartyName.Text = "Third Party";
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(367, 85);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(206, 21);
            this.cmbSupervisor.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(298, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Supervisor";
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(80, 12);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(500, 25);
            this.ctlInterService1.TabIndex = 16;
            // 
            // frmTechnicians
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 487);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblThirdPartyName);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.cmbWorkshopType);
            this.Controls.Add(this.lblWorkshop);
            this.Controls.Add(this.cmbTechnicianType);
            this.Controls.Add(this.lblTechnicianType);
            this.Controls.Add(this.txtTechnicianName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTechnicianCode);
            this.Controls.Add(this.lblPartCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwTechnicians);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTechnicians";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technicians";
            this.Load += new System.EventHandler(this.frmTechnicians_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListView lvwTechnicians;
        private System.Windows.Forms.ColumnHeader colWorkshopName;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colWorkshopLocation;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtTechnicianName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTechnicianCode;
        private System.Windows.Forms.Label lblPartCode;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colIsVariable;
        private System.Windows.Forms.ColumnHeader colThirdParty;
        private System.Windows.Forms.Label lblTechnicianType;
        private System.Windows.Forms.ComboBox cmbTechnicianType;
        private System.Windows.Forms.Label lblWorkshop;
        private System.Windows.Forms.ComboBox cmbWorkshopType;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ColumnHeader colMobileNo1;
        private System.Windows.Forms.ColumnHeader colSupervisorName;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThirdPartyName;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.Label label3;
    }
}