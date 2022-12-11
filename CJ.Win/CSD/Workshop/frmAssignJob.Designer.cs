namespace CJ.Win
{
    partial class frmAssignJob
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lvwTechnicianJob = new System.Windows.Forms.ListView();
            this.colTechnicianName = new System.Windows.Forms.ColumnHeader();
            this.colW = new System.Windows.Forms.ColumnHeader();
            this.colH = new System.Windows.Forms.ColumnHeader();
            this.colI = new System.Windows.Forms.ColumnHeader();
            this.colTotal = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvJob = new System.Windows.Forms.DataGridView();
            this.txtJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTechnicianCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtTechnician = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TechnicianID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTW = new System.Windows.Forms.TextBox();
            this.txtTH = new System.Windows.Forms.TextBox();
            this.txtTI = new System.Windows.Forms.TextBox();
            this.txtGTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoThirdPartyTech = new System.Windows.Forms.RadioButton();
            this.rdoOwnTech = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTechCode = new System.Windows.Forms.TextBox();
            this.btnSearchTechnician = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwTechnicianJob
            // 
            this.lvwTechnicianJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTechnicianJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTechnicianName,
            this.colW,
            this.colH,
            this.colI,
            this.colTotal});
            this.lvwTechnicianJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTechnicianJob.FullRowSelect = true;
            this.lvwTechnicianJob.GridLines = true;
            this.lvwTechnicianJob.HideSelection = false;
            this.lvwTechnicianJob.Location = new System.Drawing.Point(619, 137);
            this.lvwTechnicianJob.MultiSelect = false;
            this.lvwTechnicianJob.Name = "lvwTechnicianJob";
            this.lvwTechnicianJob.Size = new System.Drawing.Size(287, 304);
            this.lvwTechnicianJob.TabIndex = 10;
            this.lvwTechnicianJob.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicianJob.View = System.Windows.Forms.View.Details;
            // 
            // colTechnicianName
            // 
            this.colTechnicianName.Text = "Technician Name";
            this.colTechnicianName.Width = 127;
            // 
            // colW
            // 
            this.colW.Text = "W";
            this.colW.Width = 38;
            // 
            // colH
            // 
            this.colH.Text = "H";
            this.colH.Width = 38;
            // 
            // colI
            // 
            this.colI.Text = "I";
            this.colI.Width = 35;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            this.colTotal.Width = 45;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(621, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Technician Wise Unsettled Job";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvJob
            // 
            this.dgvJob.AllowUserToAddRows = false;
            this.dgvJob.AllowUserToDeleteRows = false;
            this.dgvJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtJobNo,
            this.txtTechnicianCode,
            this.txtSearch,
            this.txtTechnician,
            this.txtCustomer,
            this.txtProduct,
            this.txtJobID,
            this.TechnicianID,
            this.colJobStatus,
            this.colThanaID,
            this.colJobID});
            this.dgvJob.Location = new System.Drawing.Point(5, 137);
            this.dgvJob.Name = "dgvJob";
            this.dgvJob.Size = new System.Drawing.Size(607, 307);
            this.dgvJob.TabIndex = 1;
            this.dgvJob.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJob_CellValueChanged);
            this.dgvJob.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJob_CellContentClick);
            // 
            // txtJobNo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtJobNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtJobNo.HeaderText = "Job No";
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            // 
            // txtTechnicianCode
            // 
            this.txtTechnicianCode.HeaderText = "Code";
            this.txtTechnicianCode.Name = "txtTechnicianCode";
            this.txtTechnicianCode.Width = 50;
            // 
            // txtSearch
            // 
            this.txtSearch.HeaderText = "?";
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Width = 30;
            // 
            // txtTechnician
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTechnician.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtTechnician.HeaderText = "Technician";
            this.txtTechnician.Name = "txtTechnician";
            this.txtTechnician.ReadOnly = true;
            this.txtTechnician.Width = 150;
            // 
            // txtCustomer
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtCustomer.HeaderText = "Customer";
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Width = 130;
            // 
            // txtProduct
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProduct.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtProduct.HeaderText = "Product";
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Width = 150;
            // 
            // txtJobID
            // 
            this.txtJobID.HeaderText = "JobID";
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.ReadOnly = true;
            this.txtJobID.Visible = false;
            // 
            // TechnicianID
            // 
            this.TechnicianID.HeaderText = "TechnicianID";
            this.TechnicianID.Name = "TechnicianID";
            this.TechnicianID.ReadOnly = true;
            this.TechnicianID.Visible = false;
            // 
            // colJobStatus
            // 
            this.colJobStatus.HeaderText = "Status";
            this.colJobStatus.Name = "colJobStatus";
            this.colJobStatus.ReadOnly = true;
            this.colJobStatus.Visible = false;
            // 
            // colThanaID
            // 
            this.colThanaID.HeaderText = "ThanaID";
            this.colThanaID.Name = "colThanaID";
            this.colThanaID.ReadOnly = true;
            this.colThanaID.Visible = false;
            // 
            // colJobID
            // 
            this.colJobID.HeaderText = "JobID";
            this.colJobID.Name = "colJobID";
            this.colJobID.ReadOnly = true;
            this.colJobID.Visible = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(63, 89);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(128, 20);
            this.txtCustomerName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Customer";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(251, 63);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(143, 20);
            this.txtProductName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Product";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(63, 64);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(128, 20);
            this.txtJob.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Job No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(11, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(236, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(121, 20);
            this.dtToDate.TabIndex = 4;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(83, 16);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(118, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Create Date";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(530, 84);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 28);
            this.btnGo.TabIndex = 15;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(462, 449);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(73, 26);
            this.btnAssign.TabIndex = 11;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(541, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTW
            // 
            this.txtTW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTW.Location = new System.Drawing.Point(748, 455);
            this.txtTW.Name = "txtTW";
            this.txtTW.ReadOnly = true;
            this.txtTW.Size = new System.Drawing.Size(39, 20);
            this.txtTW.TabIndex = 14;
            // 
            // txtTH
            // 
            this.txtTH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTH.Location = new System.Drawing.Point(786, 455);
            this.txtTH.Name = "txtTH";
            this.txtTH.ReadOnly = true;
            this.txtTH.Size = new System.Drawing.Size(40, 20);
            this.txtTH.TabIndex = 15;
            // 
            // txtTI
            // 
            this.txtTI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTI.Location = new System.Drawing.Point(825, 455);
            this.txtTI.Name = "txtTI";
            this.txtTI.ReadOnly = true;
            this.txtTI.Size = new System.Drawing.Size(37, 20);
            this.txtTI.TabIndex = 16;
            // 
            // txtGTotal
            // 
            this.txtGTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGTotal.Location = new System.Drawing.Point(861, 455);
            this.txtGTotal.Name = "txtGTotal";
            this.txtGTotal.ReadOnly = true;
            this.txtGTotal.Size = new System.Drawing.Size(45, 20);
            this.txtGTotal.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(619, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Total >>";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(190, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Job Type";
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(251, 90);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(143, 21);
            this.cmbJobType.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(382, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Workshop";
            // 
            // cmbWorkshop
            // 
            this.cmbWorkshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(448, 33);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(147, 21);
            this.cmbWorkshop.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(413, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "ASG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(448, 60);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(147, 21);
            this.cmbASG.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbServiceType);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbWorkshop);
            this.groupBox2.Controls.Add(this.cmbJobType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbASG);
            this.groupBox2.Controls.Add(this.btnGo);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtJob);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 122);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Option";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(397, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "S. Type";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(448, 88);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(78, 21);
            this.cmbServiceType.TabIndex = 14;
            // 
            // txtTechName
            // 
            this.txtTechName.Location = new System.Drawing.Point(663, 58);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(236, 20);
            this.txtTechName.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(616, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "T.Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoAll);
            this.groupBox3.Controls.Add(this.rdoThirdPartyTech);
            this.groupBox3.Controls.Add(this.rdoOwnTech);
            this.groupBox3.Location = new System.Drawing.Point(621, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 40);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Technician Type";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(6, 17);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoThirdPartyTech
            // 
            this.rdoThirdPartyTech.AutoSize = true;
            this.rdoThirdPartyTech.Location = new System.Drawing.Point(126, 16);
            this.rdoThirdPartyTech.Name = "rdoThirdPartyTech";
            this.rdoThirdPartyTech.Size = new System.Drawing.Size(76, 17);
            this.rdoThirdPartyTech.TabIndex = 0;
            this.rdoThirdPartyTech.TabStop = true;
            this.rdoThirdPartyTech.Text = "Third Party";
            this.rdoThirdPartyTech.UseVisualStyleBackColor = true;
            // 
            // rdoOwnTech
            // 
            this.rdoOwnTech.AutoSize = true;
            this.rdoOwnTech.Location = new System.Drawing.Point(64, 16);
            this.rdoOwnTech.Name = "rdoOwnTech";
            this.rdoOwnTech.Size = new System.Drawing.Size(47, 17);
            this.rdoOwnTech.TabIndex = 2;
            this.rdoOwnTech.TabStop = true;
            this.rdoOwnTech.Text = "Own";
            this.rdoOwnTech.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(618, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "T.Code";
            // 
            // txtTechCode
            // 
            this.txtTechCode.Location = new System.Drawing.Point(663, 32);
            this.txtTechCode.Name = "txtTechCode";
            this.txtTechCode.Size = new System.Drawing.Size(82, 20);
            this.txtTechCode.TabIndex = 5;
            // 
            // btnSearchTechnician
            // 
            this.btnSearchTechnician.Location = new System.Drawing.Point(838, 103);
            this.btnSearchTechnician.Name = "btnSearchTechnician";
            this.btnSearchTechnician.Size = new System.Drawing.Size(68, 25);
            this.btnSearchTechnician.TabIndex = 9;
            this.btnSearchTechnician.Text = "&Get";
            this.btnSearchTechnician.UseVisualStyleBackColor = true;
            this.btnSearchTechnician.Click += new System.EventHandler(this.btnSearchTechnician_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Job No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Technician";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Product";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "JobID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "TechnicianID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Status";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // frmAssignJob
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 486);
            this.Controls.Add(this.btnSearchTechnician);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTechCode);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTechName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGTotal);
            this.Controls.Add(this.txtTI);
            this.Controls.Add(this.txtTH);
            this.Controls.Add(this.txtTW);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.dgvJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwTechnicianJob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAssignJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign to Technician (Walk-in Job)";
            this.Load += new System.EventHandler(this.frmAssignJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJob)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwTechnicianJob;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colW;
        private System.Windows.Forms.ColumnHeader colH;
        private System.Windows.Forms.ColumnHeader colI;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvJob;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTW;
        private System.Windows.Forms.TextBox txtTH;
        private System.Windows.Forms.TextBox txtTI;
        private System.Windows.Forms.TextBox txtGTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWorkshop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox txtTechName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoThirdPartyTech;
        private System.Windows.Forms.RadioButton rdoOwnTech;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTechCode;
        private System.Windows.Forms.Button btnSearchTechnician;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTechnicianCode;
        private System.Windows.Forms.DataGridViewButtonColumn txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTechnician;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TechnicianID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbServiceType;
    }
}