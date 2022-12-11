namespace CJ.Win.HR
{
    partial class frmPosition
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRoleType = new System.Windows.Forms.ComboBox();
            this.rdoHO = new System.Windows.Forms.RadioButton();
            this.rdoField = new System.Windows.Forms.RadioButton();
            this.rdoArea = new System.Windows.Forms.RadioButton();
            this.rdoTerritory = new System.Windows.Forms.RadioButton();
            this.rdoDistributor = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPositionCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblParentPosition = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gbMarketGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbMarketGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(352, 353);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPositionName
            // 
            this.txtPositionName.Location = new System.Drawing.Point(82, 87);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(255, 20);
            this.txtPositionName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position Des";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(82, 167);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(152, 21);
            this.cmbRole.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Role";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Role Type";
            // 
            // cmbRoleType
            // 
            this.cmbRoleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleType.FormattingEnabled = true;
            this.cmbRoleType.Location = new System.Drawing.Point(82, 140);
            this.cmbRoleType.Name = "cmbRoleType";
            this.cmbRoleType.Size = new System.Drawing.Size(152, 21);
            this.cmbRoleType.TabIndex = 5;
            // 
            // rdoHO
            // 
            this.rdoHO.AutoSize = true;
            this.rdoHO.Location = new System.Drawing.Point(9, 16);
            this.rdoHO.Name = "rdoHO";
            this.rdoHO.Size = new System.Drawing.Size(41, 17);
            this.rdoHO.TabIndex = 7;
            this.rdoHO.TabStop = true;
            this.rdoHO.Text = "HO";
            this.rdoHO.UseVisualStyleBackColor = true;
            this.rdoHO.CheckedChanged += new System.EventHandler(this.rdoHO_CheckedChanged);
            // 
            // rdoField
            // 
            this.rdoField.AutoSize = true;
            this.rdoField.Location = new System.Drawing.Point(61, 16);
            this.rdoField.Name = "rdoField";
            this.rdoField.Size = new System.Drawing.Size(47, 17);
            this.rdoField.TabIndex = 8;
            this.rdoField.TabStop = true;
            this.rdoField.Text = "Field";
            this.rdoField.UseVisualStyleBackColor = true;
            this.rdoField.CheckedChanged += new System.EventHandler(this.rdoField_CheckedChanged);
            // 
            // rdoArea
            // 
            this.rdoArea.AutoSize = true;
            this.rdoArea.Location = new System.Drawing.Point(10, 14);
            this.rdoArea.Name = "rdoArea";
            this.rdoArea.Size = new System.Drawing.Size(47, 17);
            this.rdoArea.TabIndex = 9;
            this.rdoArea.TabStop = true;
            this.rdoArea.Text = "Area";
            this.rdoArea.UseVisualStyleBackColor = true;
            this.rdoArea.CheckedChanged += new System.EventHandler(this.rdoArea_CheckedChanged);
            // 
            // rdoTerritory
            // 
            this.rdoTerritory.AutoSize = true;
            this.rdoTerritory.Location = new System.Drawing.Point(68, 14);
            this.rdoTerritory.Name = "rdoTerritory";
            this.rdoTerritory.Size = new System.Drawing.Size(63, 17);
            this.rdoTerritory.TabIndex = 10;
            this.rdoTerritory.TabStop = true;
            this.rdoTerritory.Text = "Territory";
            this.rdoTerritory.UseVisualStyleBackColor = true;
            this.rdoTerritory.CheckedChanged += new System.EventHandler(this.rdoTerritory_CheckedChanged);
            // 
            // rdoDistributor
            // 
            this.rdoDistributor.AutoSize = true;
            this.rdoDistributor.Location = new System.Drawing.Point(137, 14);
            this.rdoDistributor.Name = "rdoDistributor";
            this.rdoDistributor.Size = new System.Drawing.Size(69, 17);
            this.rdoDistributor.TabIndex = 11;
            this.rdoDistributor.TabStop = true;
            this.rdoDistributor.Text = "Customer";
            this.rdoDistributor.UseVisualStyleBackColor = true;
            this.rdoDistributor.CheckedChanged += new System.EventHandler(this.rdoDistributor_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Area";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(82, 242);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(221, 21);
            this.cmbArea.TabIndex = 12;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(82, 323);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(342, 20);
            this.txtRemarks.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(82, 113);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(255, 21);
            this.cmbDepartment.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Position Code";
            // 
            // txtPositionCode
            // 
            this.txtPositionCode.Location = new System.Drawing.Point(82, 61);
            this.txtPositionCode.Name = "txtPositionCode";
            this.txtPositionCode.Size = new System.Drawing.Size(152, 20);
            this.txtPositionCode.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Territory";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(82, 268);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(221, 21);
            this.cmbTerritory.TabIndex = 20;
            this.cmbTerritory.SelectedIndexChanged += new System.EventHandler(this.cmbTerritory_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Customer";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(82, 295);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(221, 21);
            this.cmbCustomer.TabIndex = 22;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Company";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompany.Location = new System.Drawing.Point(82, 19);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(21, 13);
            this.lblCompany.TabIndex = 25;
            this.lblCompany.Text = "??";
            // 
            // lblParentPosition
            // 
            this.lblParentPosition.AutoSize = true;
            this.lblParentPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblParentPosition.Location = new System.Drawing.Point(82, 39);
            this.lblParentPosition.Name = "lblParentPosition";
            this.lblParentPosition.Size = new System.Drawing.Size(21, 13);
            this.lblParentPosition.TabIndex = 27;
            this.lblParentPosition.Text = "??";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Parent Position";
            // 
            // gbMarketGroup
            // 
            this.gbMarketGroup.Controls.Add(this.rdoDistributor);
            this.gbMarketGroup.Controls.Add(this.rdoTerritory);
            this.gbMarketGroup.Controls.Add(this.rdoArea);
            this.gbMarketGroup.Location = new System.Drawing.Point(215, 193);
            this.gbMarketGroup.Name = "gbMarketGroup";
            this.gbMarketGroup.Size = new System.Drawing.Size(211, 37);
            this.gbMarketGroup.TabIndex = 28;
            this.gbMarketGroup.TabStop = false;
            this.gbMarketGroup.Text = "Market Group";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoField);
            this.groupBox2.Controls.Add(this.rdoHO);
            this.groupBox2.Location = new System.Drawing.Point(82, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 39);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base Station Type";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(274, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 26);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPosition
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 386);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbMarketGroup);
            this.Controls.Add(this.lblParentPosition);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPositionCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRoleType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPositionName);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Position Add";
            this.Load += new System.EventHandler(this.frmHRPositionAdd_Load);
            this.gbMarketGroup.ResumeLayout(false);
            this.gbMarketGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRoleType;
        private System.Windows.Forms.RadioButton rdoHO;
        private System.Windows.Forms.RadioButton rdoField;
        private System.Windows.Forms.RadioButton rdoArea;
        private System.Windows.Forms.RadioButton rdoTerritory;
        private System.Windows.Forms.RadioButton rdoDistributor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPositionCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblParentPosition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbMarketGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
    }
}