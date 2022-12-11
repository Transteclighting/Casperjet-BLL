namespace CJ.Win
{
    partial class frmTechnician
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWorkshopLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMinPayment = new System.Windows.Forms.TextBox();
            this.lblMinPayment = new System.Windows.Forms.Label();
            this.txtMaxPayment = new System.Windows.Forms.TextBox();
            this.lblMaxPayment = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTechnicianName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTechnicianCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.rdoOwn = new System.Windows.Forms.RadioButton();
            this.rdoThirdParty = new System.Windows.Forms.RadioButton();
            this.rdoVariable = new System.Windows.Forms.RadioButton();
            this.rdoNonVariable = new System.Windows.Forms.RadioButton();
            this.lblThirdParty = new System.Windows.Forms.Label();
            this.grbOwnType = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvWorkType = new System.Windows.Forms.DataGridView();
            this.colIsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWorkTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBrandSkill = new System.Windows.Forms.DataGridView();
            this.chkIsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBrandId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWorkType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAllBrand = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtMobileNo1 = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbOwnType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "WS Location";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWorkshopLocation
            // 
            this.cmbWorkshopLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshopLocation.FormattingEnabled = true;
            this.cmbWorkshopLocation.Location = new System.Drawing.Point(121, 202);
            this.cmbWorkshopLocation.Name = "cmbWorkshopLocation";
            this.cmbWorkshopLocation.Size = new System.Drawing.Size(151, 21);
            this.cmbWorkshopLocation.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(279, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Is Active";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(347, 178);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(151, 21);
            this.cmbIsActive.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(544, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(631, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMinPayment
            // 
            this.txtMinPayment.Location = new System.Drawing.Point(302, 83);
            this.txtMinPayment.Name = "txtMinPayment";
            this.txtMinPayment.Size = new System.Drawing.Size(100, 20);
            this.txtMinPayment.TabIndex = 11;
            // 
            // lblMinPayment
            // 
            this.lblMinPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPayment.Location = new System.Drawing.Point(223, 82);
            this.lblMinPayment.Name = "lblMinPayment";
            this.lblMinPayment.Size = new System.Drawing.Size(79, 20);
            this.lblMinPayment.TabIndex = 10;
            this.lblMinPayment.Text = "Min Payment";
            this.lblMinPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaxPayment
            // 
            this.txtMaxPayment.Location = new System.Drawing.Point(122, 83);
            this.txtMaxPayment.Name = "txtMaxPayment";
            this.txtMaxPayment.Size = new System.Drawing.Size(100, 20);
            this.txtMaxPayment.TabIndex = 9;
            // 
            // lblMaxPayment
            // 
            this.lblMaxPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPayment.Location = new System.Drawing.Point(33, 83);
            this.lblMaxPayment.Name = "lblMaxPayment";
            this.lblMaxPayment.Size = new System.Drawing.Size(90, 20);
            this.lblMaxPayment.TabIndex = 8;
            this.lblMaxPayment.Text = "Max Payment";
            this.lblMaxPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(302, 9);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeCode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Empl. Code";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTechnicianName
            // 
            this.txtTechnicianName.Location = new System.Drawing.Point(122, 33);
            this.txtTechnicianName.Name = "txtTechnicianName";
            this.txtTechnicianName.Size = new System.Drawing.Size(280, 20);
            this.txtTechnicianName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Technician Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTechnicianCode
            // 
            this.txtTechnicianCode.Location = new System.Drawing.Point(122, 9);
            this.txtTechnicianCode.Name = "txtTechnicianCode";
            this.txtTechnicianCode.Size = new System.Drawing.Size(100, 20);
            this.txtTechnicianCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(14, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(105, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Technician Code";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Workshop";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWorkshop
            // 
            this.cmbWorkshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(122, 178);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(150, 21);
            this.cmbWorkshop.TabIndex = 15;
            // 
            // rdoOwn
            // 
            this.rdoOwn.AutoSize = true;
            this.rdoOwn.Location = new System.Drawing.Point(20, 15);
            this.rdoOwn.Name = "rdoOwn";
            this.rdoOwn.Size = new System.Drawing.Size(47, 17);
            this.rdoOwn.TabIndex = 0;
            this.rdoOwn.TabStop = true;
            this.rdoOwn.Text = "Own";
            this.rdoOwn.UseVisualStyleBackColor = true;
            this.rdoOwn.CheckedChanged += new System.EventHandler(this.rdoOwn_CheckedChanged);
            // 
            // rdoThirdParty
            // 
            this.rdoThirdParty.AutoSize = true;
            this.rdoThirdParty.Location = new System.Drawing.Point(84, 17);
            this.rdoThirdParty.Name = "rdoThirdParty";
            this.rdoThirdParty.Size = new System.Drawing.Size(76, 17);
            this.rdoThirdParty.TabIndex = 1;
            this.rdoThirdParty.TabStop = true;
            this.rdoThirdParty.Text = "Third Party";
            this.rdoThirdParty.UseVisualStyleBackColor = true;
            this.rdoThirdParty.CheckedChanged += new System.EventHandler(this.rdoThirdParty_CheckedChanged);
            // 
            // rdoVariable
            // 
            this.rdoVariable.AutoSize = true;
            this.rdoVariable.Location = new System.Drawing.Point(18, 14);
            this.rdoVariable.Name = "rdoVariable";
            this.rdoVariable.Size = new System.Drawing.Size(63, 17);
            this.rdoVariable.TabIndex = 0;
            this.rdoVariable.TabStop = true;
            this.rdoVariable.Text = "Variable";
            this.rdoVariable.UseVisualStyleBackColor = true;
            this.rdoVariable.CheckedChanged += new System.EventHandler(this.rdoVariable_CheckedChanged);
            // 
            // rdoNonVariable
            // 
            this.rdoNonVariable.AutoSize = true;
            this.rdoNonVariable.Location = new System.Drawing.Point(87, 13);
            this.rdoNonVariable.Name = "rdoNonVariable";
            this.rdoNonVariable.Size = new System.Drawing.Size(86, 17);
            this.rdoNonVariable.TabIndex = 1;
            this.rdoNonVariable.TabStop = true;
            this.rdoNonVariable.Text = "Non Variable";
            this.rdoNonVariable.UseVisualStyleBackColor = true;
            this.rdoNonVariable.CheckedChanged += new System.EventHandler(this.rdoNonVariable_CheckedChanged);
            // 
            // lblThirdParty
            // 
            this.lblThirdParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdParty.Location = new System.Drawing.Point(53, 154);
            this.lblThirdParty.Name = "lblThirdParty";
            this.lblThirdParty.Size = new System.Drawing.Size(69, 20);
            this.lblThirdParty.TabIndex = 12;
            this.lblThirdParty.Text = "Third Party";
            this.lblThirdParty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbOwnType
            // 
            this.grbOwnType.Controls.Add(this.rdoVariable);
            this.grbOwnType.Controls.Add(this.rdoNonVariable);
            this.grbOwnType.Location = new System.Drawing.Point(408, 8);
            this.grbOwnType.Name = "grbOwnType";
            this.grbOwnType.Size = new System.Drawing.Size(200, 40);
            this.grbOwnType.TabIndex = 7;
            this.grbOwnType.TabStop = false;
            this.grbOwnType.Text = "Own Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoThirdParty);
            this.groupBox2.Controls.Add(this.rdoOwn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(408, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 40);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Technician Type";
            // 
            // dgvWorkType
            // 
            this.dgvWorkType.AllowUserToAddRows = false;
            this.dgvWorkType.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsCheck,
            this.colWorkTypeID,
            this.colWorkType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkType.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkType.Location = new System.Drawing.Point(12, 254);
            this.dgvWorkType.Name = "dgvWorkType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkType.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkType.Size = new System.Drawing.Size(344, 159);
            this.dgvWorkType.TabIndex = 21;
            // 
            // colIsCheck
            // 
            this.colIsCheck.HeaderText = "Check/Uncheck";
            this.colIsCheck.Name = "colIsCheck";
            // 
            // colWorkTypeID
            // 
            this.colWorkTypeID.HeaderText = "Work Type ID";
            this.colWorkTypeID.Name = "colWorkTypeID";
            this.colWorkTypeID.Visible = false;
            // 
            // colWorkType
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colWorkType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colWorkType.HeaderText = "Work Type";
            this.colWorkType.Name = "colWorkType";
            this.colWorkType.ReadOnly = true;
            this.colWorkType.Width = 200;
            // 
            // dgvBrandSkill
            // 
            this.dgvBrandSkill.AllowUserToAddRows = false;
            this.dgvBrandSkill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrandSkill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBrandSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrandSkill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkIsCheck,
            this.colBrandId,
            this.colBrandName});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBrandSkill.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBrandSkill.Location = new System.Drawing.Point(372, 254);
            this.dgvBrandSkill.Name = "dgvBrandSkill";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrandSkill.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBrandSkill.Size = new System.Drawing.Size(343, 159);
            this.dgvBrandSkill.TabIndex = 24;
            // 
            // chkIsCheck
            // 
            this.chkIsCheck.HeaderText = "Check/Uncheck";
            this.chkIsCheck.Name = "chkIsCheck";
            this.chkIsCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkIsCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colBrandId
            // 
            this.colBrandId.HeaderText = "Brand ID";
            this.colBrandId.Name = "colBrandId";
            this.colBrandId.Visible = false;
            // 
            // colBrandName
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colBrandName.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBrandName.HeaderText = "Brand Name";
            this.colBrandName.Name = "colBrandName";
            this.colBrandName.ReadOnly = true;
            this.colBrandName.Width = 200;
            // 
            // lblWorkType
            // 
            this.lblWorkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkType.Location = new System.Drawing.Point(11, 233);
            this.lblWorkType.Name = "lblWorkType";
            this.lblWorkType.Size = new System.Drawing.Size(66, 15);
            this.lblWorkType.TabIndex = 20;
            this.lblWorkType.Text = "WorkType";
            this.lblWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Brand Skill";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAllBrand
            // 
            this.chkAllBrand.AutoSize = true;
            this.chkAllBrand.Location = new System.Drawing.Point(445, 233);
            this.chkAllBrand.Name = "chkAllBrand";
            this.chkAllBrand.Size = new System.Drawing.Size(37, 17);
            this.chkAllBrand.TabIndex = 23;
            this.chkAllBrand.Text = "All";
            this.chkAllBrand.UseVisualStyleBackColor = true;
            this.chkAllBrand.CheckedChanged += new System.EventHandler(this.chkAllBrand_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Category Skill";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Brand ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Brand Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Brand Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(122, 152);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(382, 25);
            this.ctlInterService1.TabIndex = 13;
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(122, 57);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(280, 21);
            this.cmbSupervisor.TabIndex = 27;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(122, 105);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(100, 20);
            this.txtMobileNo.TabIndex = 28;
            // 
            // txtMobileNo1
            // 
            this.txtMobileNo1.Location = new System.Drawing.Point(122, 128);
            this.txtMobileNo1.Name = "txtMobileNo1";
            this.txtMobileNo1.Size = new System.Drawing.Size(100, 20);
            this.txtMobileNo1.TabIndex = 29;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupervisor.Location = new System.Drawing.Point(52, 60);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(67, 13);
            this.lblSupervisor.TabIndex = 30;
            this.lblSupervisor.Text = "Supervisor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Mobile No 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Mobile No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "[ For SMS Communication ]";
            // 
            // frmTechnician
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.txtMobileNo1);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.chkAllBrand);
            this.Controls.Add(this.dgvBrandSkill);
            this.Controls.Add(this.dgvWorkType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbOwnType);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbWorkshop);
            this.Controls.Add(this.txtMinPayment);
            this.Controls.Add(this.lblMinPayment);
            this.Controls.Add(this.txtMaxPayment);
            this.Controls.Add(this.lblMaxPayment);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.lblThirdParty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTechnicianName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTechnicianCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblWorkType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWorkshopLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTechnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Technician";
            this.Load += new System.EventHandler(this.frmTechnician_Load);
            this.grbOwnType.ResumeLayout(false);
            this.grbOwnType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandSkill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWorkshopLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMinPayment;
        private System.Windows.Forms.Label lblMinPayment;
        private System.Windows.Forms.TextBox txtMaxPayment;
        private System.Windows.Forms.Label lblMaxPayment;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTechnicianName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTechnicianCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWorkshop;
        private System.Windows.Forms.RadioButton rdoOwn;
        private System.Windows.Forms.RadioButton rdoThirdParty;
        private System.Windows.Forms.RadioButton rdoVariable;
        private System.Windows.Forms.RadioButton rdoNonVariable;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Label lblThirdParty;
        private System.Windows.Forms.GroupBox grbOwnType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvWorkType;
        private System.Windows.Forms.DataGridView dgvBrandSkill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAllBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkIsCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandName;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtMobileNo1;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
    }
}