namespace CJ.Win
{
    partial class frmAssignJobs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignJobs));
            this.lvwJobForAssing = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastFeedbackDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colASG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkshop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.untouchedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workInProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportRequiredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readyForTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readyForDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.lblOwnTech = new System.Windows.Forms.Label();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtLFDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtLFDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chkLFDateEnableDisable = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblThirdParty = new System.Windows.Forms.Label();
            this.btnConvertJob = new System.Windows.Forms.Button();
            this.lblJobStatus = new System.Windows.Forms.Label();
            this.cmbJobStatus = new System.Windows.Forms.ComboBox();
            this.lblTechType = new System.Windows.Forms.Label();
            this.cmbTechType = new System.Windows.Forms.ComboBox();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.lblUIType = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwJobForAssing
            // 
            this.lvwJobForAssing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwJobForAssing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colProduct,
            this.colCreateDate,
            this.colLastFeedbackDate,
            this.colStatus,
            this.colCustomerName,
            this.colContactNo,
            this.colAddress,
            this.colASG,
            this.colWorkshop,
            this.colRemarks});
            this.lvwJobForAssing.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwJobForAssing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwJobForAssing.FullRowSelect = true;
            this.lvwJobForAssing.GridLines = true;
            this.lvwJobForAssing.HideSelection = false;
            this.lvwJobForAssing.Location = new System.Drawing.Point(5, 161);
            this.lvwJobForAssing.MultiSelect = false;
            this.lvwJobForAssing.Name = "lvwJobForAssing";
            this.lvwJobForAssing.Size = new System.Drawing.Size(909, 272);
            this.lvwJobForAssing.TabIndex = 24;
            this.lvwJobForAssing.UseCompatibleStateImageBehavior = false;
            this.lvwJobForAssing.View = System.Windows.Forms.View.Details;
            this.lvwJobForAssing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwJobForAssing_MouseDown);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "     Job No";
            this.colJobNo.Width = 102;
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product";
            this.colProduct.Width = 210;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 94;
            // 
            // colLastFeedbackDate
            // 
            this.colLastFeedbackDate.Text = "L. F Date";
            this.colLastFeedbackDate.Width = 94;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Job Status";
            this.colStatus.Width = 115;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 137;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 80;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 140;
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            this.colASG.Width = 85;
            // 
            // colWorkshop
            // 
            this.colWorkshop.Text = "Workshop";
            this.colWorkshop.Width = 75;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.untouchedToolStripMenuItem,
            this.workInProgressToolStripMenuItem,
            this.criticalToolStripMenuItem,
            this.suspendToolStripMenuItem,
            this.returnToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.estimateToolStripMenuItem,
            this.transportRequiredToolStripMenuItem,
            this.repairedToolStripMenuItem,
            this.readyForTestToolStripMenuItem,
            this.readyForDeliveryToolStripMenuItem,
            this.jobDeliveryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 268);
            // 
            // untouchedToolStripMenuItem
            // 
            this.untouchedToolStripMenuItem.Name = "untouchedToolStripMenuItem";
            this.untouchedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.untouchedToolStripMenuItem.Text = "Untouched";
            this.untouchedToolStripMenuItem.Click += new System.EventHandler(this.untouchedToolStripMenuItem_Click);
            // 
            // workInProgressToolStripMenuItem
            // 
            this.workInProgressToolStripMenuItem.Name = "workInProgressToolStripMenuItem";
            this.workInProgressToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.workInProgressToolStripMenuItem.Text = "Work-in-Progress";
            this.workInProgressToolStripMenuItem.Click += new System.EventHandler(this.workInProgressToolStripMenuItem_Click);
            // 
            // criticalToolStripMenuItem
            // 
            this.criticalToolStripMenuItem.Name = "criticalToolStripMenuItem";
            this.criticalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.criticalToolStripMenuItem.Text = "Critical";
            this.criticalToolStripMenuItem.Click += new System.EventHandler(this.criticalToolStripMenuItem_Click);
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.suspendToolStripMenuItem.Text = "Pending";
            this.suspendToolStripMenuItem.Click += new System.EventHandler(this.suspendToolStripMenuItem_Click);
            // 
            // returnToolStripMenuItem
            // 
            this.returnToolStripMenuItem.Name = "returnToolStripMenuItem";
            this.returnToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.returnToolStripMenuItem.Text = "Return";
            this.returnToolStripMenuItem.Click += new System.EventHandler(this.returnToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // estimateToolStripMenuItem
            // 
            this.estimateToolStripMenuItem.Name = "estimateToolStripMenuItem";
            this.estimateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.estimateToolStripMenuItem.Text = "Estimate";
            this.estimateToolStripMenuItem.Click += new System.EventHandler(this.estimateToolStripMenuItem_Click);
            // 
            // transportRequiredToolStripMenuItem
            // 
            this.transportRequiredToolStripMenuItem.Name = "transportRequiredToolStripMenuItem";
            this.transportRequiredToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.transportRequiredToolStripMenuItem.Text = "Transport Required";
            this.transportRequiredToolStripMenuItem.Click += new System.EventHandler(this.transportRequiredToolStripMenuItem_Click);
            // 
            // repairedToolStripMenuItem
            // 
            this.repairedToolStripMenuItem.Name = "repairedToolStripMenuItem";
            this.repairedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.repairedToolStripMenuItem.Text = "Repaired";
            this.repairedToolStripMenuItem.Click += new System.EventHandler(this.repairedToolStripMenuItem_Click);
            // 
            // readyForTestToolStripMenuItem
            // 
            this.readyForTestToolStripMenuItem.Name = "readyForTestToolStripMenuItem";
            this.readyForTestToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.readyForTestToolStripMenuItem.Text = "Ready for Test";
            this.readyForTestToolStripMenuItem.Click += new System.EventHandler(this.readyForTestToolStripMenuItem_Click);
            // 
            // readyForDeliveryToolStripMenuItem
            // 
            this.readyForDeliveryToolStripMenuItem.Name = "readyForDeliveryToolStripMenuItem";
            this.readyForDeliveryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.readyForDeliveryToolStripMenuItem.Text = "Ready for Delivery";
            this.readyForDeliveryToolStripMenuItem.Click += new System.EventHandler(this.readyForDeliveryToolStripMenuItem_Click);
            // 
            // jobDeliveryToolStripMenuItem
            // 
            this.jobDeliveryToolStripMenuItem.Name = "jobDeliveryToolStripMenuItem";
            this.jobDeliveryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.jobDeliveryToolStripMenuItem.Text = "Job Delivery";
            this.jobDeliveryToolStripMenuItem.Click += new System.EventHandler(this.jobDeliveryToolStripMenuItem_Click);
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(75, 58);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(170, 20);
            this.txtJobNo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(719, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "ASG";
            this.label6.Visible = false;
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(749, 60);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(165, 21);
            this.cmbASG.TabIndex = 17;
            this.cmbASG.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Job No";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(724, 128);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(83, 28);
            this.btnGo.TabIndex = 22;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(221, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(121, 20);
            this.dtToDate.TabIndex = 4;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(70, 16);
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
            this.chkAll.Text = "Enable/Disable Date Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Create Date";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(306, 57);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(165, 20);
            this.txtProduct.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Product";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(536, 57);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(180, 20);
            this.txtCustomerName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(249, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Workshop";
            // 
            // cmbWorkshop
            // 
            this.cmbWorkshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(306, 82);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(165, 21);
            this.cmbWorkshop.TabIndex = 11;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(74, 106);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(171, 20);
            this.txtContactNo.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Contact No";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(834, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Service Type";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(75, 82);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(170, 21);
            this.cmbServiceType.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(483, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Job Type";
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(536, 106);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(180, 21);
            this.cmbJobType.TabIndex = 19;
            // 
            // lblOwnTech
            // 
            this.lblOwnTech.AutoSize = true;
            this.lblOwnTech.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnTech.Location = new System.Drawing.Point(473, 85);
            this.lblOwnTech.Name = "lblOwnTech";
            this.lblOwnTech.Size = new System.Drawing.Size(60, 13);
            this.lblOwnTech.TabIndex = 12;
            this.lblOwnTech.Text = "Own Tech.";
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnician.FormattingEnabled = true;
            this.cmbTechnician.Location = new System.Drawing.Point(536, 81);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(180, 21);
            this.cmbTechnician.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dtLFDateTo);
            this.groupBox2.Controls.Add(this.dtLFDateFrom);
            this.groupBox2.Controls.Add(this.chkLFDateEnableDisable);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(375, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 43);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(189, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "To";
            // 
            // dtLFDateTo
            // 
            this.dtLFDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtLFDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLFDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLFDateTo.Location = new System.Drawing.Point(219, 16);
            this.dtLFDateTo.Name = "dtLFDateTo";
            this.dtLFDateTo.Size = new System.Drawing.Size(116, 20);
            this.dtLFDateTo.TabIndex = 4;
            // 
            // dtLFDateFrom
            // 
            this.dtLFDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtLFDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLFDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLFDateFrom.Location = new System.Drawing.Point(61, 16);
            this.dtLFDateFrom.Name = "dtLFDateFrom";
            this.dtLFDateFrom.Size = new System.Drawing.Size(118, 20);
            this.dtLFDateFrom.TabIndex = 2;
            // 
            // chkLFDateEnableDisable
            // 
            this.chkLFDateEnableDisable.AutoSize = true;
            this.chkLFDateEnableDisable.Location = new System.Drawing.Point(12, -1);
            this.chkLFDateEnableDisable.Name = "chkLFDateEnableDisable";
            this.chkLFDateEnableDisable.Size = new System.Drawing.Size(160, 17);
            this.chkLFDateEnableDisable.TabIndex = 0;
            this.chkLFDateEnableDisable.Text = "Enable/Disable Date Range";
            this.chkLFDateEnableDisable.UseVisualStyleBackColor = true;
            this.chkLFDateEnableDisable.CheckedChanged += new System.EventHandler(this.chkLFDateEnableDisable_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "L.F Date";
            // 
            // lblThirdParty
            // 
            this.lblThirdParty.AutoSize = true;
            this.lblThirdParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdParty.Location = new System.Drawing.Point(14, 135);
            this.lblThirdParty.Name = "lblThirdParty";
            this.lblThirdParty.Size = new System.Drawing.Size(58, 13);
            this.lblThirdParty.TabIndex = 20;
            this.lblThirdParty.Text = "Third Party";
            // 
            // btnConvertJob
            // 
            this.btnConvertJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertJob.Location = new System.Drawing.Point(813, 129);
            this.btnConvertJob.Name = "btnConvertJob";
            this.btnConvertJob.Size = new System.Drawing.Size(101, 28);
            this.btnConvertJob.TabIndex = 23;
            this.btnConvertJob.Text = "&Convert Job";
            this.btnConvertJob.UseVisualStyleBackColor = true;
            this.btnConvertJob.Visible = false;
            this.btnConvertJob.Click += new System.EventHandler(this.btnConvertJob_Click);
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobStatus.Location = new System.Drawing.Point(475, 134);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(57, 13);
            this.lblJobStatus.TabIndex = 26;
            this.lblJobStatus.Text = "Job Status";
            // 
            // cmbJobStatus
            // 
            this.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobStatus.FormattingEnabled = true;
            this.cmbJobStatus.Location = new System.Drawing.Point(536, 130);
            this.cmbJobStatus.Name = "cmbJobStatus";
            this.cmbJobStatus.Size = new System.Drawing.Size(180, 21);
            this.cmbJobStatus.TabIndex = 27;
            // 
            // lblTechType
            // 
            this.lblTechType.AutoSize = true;
            this.lblTechType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTechType.Location = new System.Drawing.Point(247, 110);
            this.lblTechType.Name = "lblTechType";
            this.lblTechType.Size = new System.Drawing.Size(59, 13);
            this.lblTechType.TabIndex = 28;
            this.lblTechType.Text = "Tech Type";
            // 
            // cmbTechType
            // 
            this.cmbTechType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechType.FormattingEnabled = true;
            this.cmbTechType.Location = new System.Drawing.Point(306, 107);
            this.cmbTechType.Name = "cmbTechType";
            this.cmbTechType.Size = new System.Drawing.Size(165, 21);
            this.cmbTechType.TabIndex = 29;
            this.cmbTechType.SelectedIndexChanged += new System.EventHandler(this.cmbTechType_SelectedIndexChanged);
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(75, 132);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(403, 25);
            this.ctlInterService1.TabIndex = 21;
            // 
            // lblUIType
            // 
            this.lblUIType.AutoSize = true;
            this.lblUIType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUIType.Location = new System.Drawing.Point(722, 15);
            this.lblUIType.Name = "lblUIType";
            this.lblUIType.Size = new System.Drawing.Size(88, 25);
            this.lblUIType.TabIndex = 30;
            this.lblUIType.Text = "UI Type";
            // 
            // frmAssignJobs
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 482);
            this.Controls.Add(this.lblUIType);
            this.Controls.Add(this.cmbTechType);
            this.Controls.Add(this.lblTechType);
            this.Controls.Add(this.lblJobStatus);
            this.Controls.Add(this.btnConvertJob);
            this.Controls.Add(this.cmbJobStatus);
            this.Controls.Add(this.lblThirdParty);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblOwnTech);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTechnician);
            this.Controls.Add(this.cmbJobType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.cmbWorkshop);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lvwJobForAssing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAssignJobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Jobs";
            this.Load += new System.EventHandler(this.frmAssignJobs_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwJobForAssing;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ColumnHeader colWorkshop;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWorkshop;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem untouchedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workInProgressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estimateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readyForTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readyForDeliveryToolStripMenuItem;
        private System.Windows.Forms.Label lblOwnTech;
        private System.Windows.Forms.ComboBox cmbTechnician;
        private System.Windows.Forms.ToolStripMenuItem repairedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportRequiredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobDeliveryToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtLFDateTo;
        private System.Windows.Forms.DateTimePicker dtLFDateFrom;
        private System.Windows.Forms.CheckBox chkLFDateEnableDisable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader colLastFeedbackDate;
        private System.Windows.Forms.Label lblThirdParty;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Button btnConvertJob;
        private System.Windows.Forms.Label lblJobStatus;
        private System.Windows.Forms.ComboBox cmbJobStatus;
        private System.Windows.Forms.Label lblTechType;
        private System.Windows.Forms.ComboBox cmbTechType;
        private System.Windows.Forms.Label lblUIType;
    }
}