namespace CJ.Win
{
    partial class frmVehicleSchedules
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
            System.Windows.Forms.ColumnHeader colAddress;
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lvwVehicleSchedule = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colED = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEDTimeFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEDTimeTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScheduleDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScheduleTimeFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScheduleTimeTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReqType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnSchedulePreparation = new System.Windows.Forms.Button();
            this.btnReSchedule = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbReqType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtToScheduleDate = new System.Windows.Forms.DateTimePicker();
            this.dtToExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkScheduleDate = new System.Windows.Forms.CheckBox();
            this.dtFromScheduleDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkExpectedDate = new System.Windows.Forms.CheckBox();
            this.dtFromExpectedDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtToCreateDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkCreateDate = new System.Windows.Forms.CheckBox();
            this.dtFromCreateDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSchedulePrint = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbServiceCenter = new System.Windows.Forms.ComboBox();
            colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // colAddress
            // 
            colAddress.Text = "Address";
            colAddress.Width = 250;
            // 
            // txtContactNo
            // 
            this.txtContactNo.AcceptsReturn = true;
            this.txtContactNo.Location = new System.Drawing.Point(446, 67);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(252, 20);
            this.txtContactNo.TabIndex = 12;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(375, 69);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(71, 13);
            this.lblContact.TabIndex = 11;
            this.lblContact.Text = "Contact No";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AcceptsReturn = true;
            this.txtCustomerName.Location = new System.Drawing.Point(446, 41);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(252, 20);
            this.txtCustomerName.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(351, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(95, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Customer Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(732, 413);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 27);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(732, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(732, 245);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(88, 27);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvwVehicleSchedule
            // 
            this.lvwVehicleSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwVehicleSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colStatus,
            this.colJobNo,
            this.colName,
            this.colContactNo,
            this.colLocation,
            colAddress,
            this.colCreateDate,
            this.colCreatedBy,
            this.colED,
            this.colEDTimeFrom,
            this.colEDTimeTo,
            this.colScheduleDate,
            this.colScheduleTimeFrom,
            this.colScheduleTimeTo,
            this.colProduct,
            this.colJobType,
            this.colRemarks,
            this.colReqType});
            this.lvwVehicleSchedule.FullRowSelect = true;
            this.lvwVehicleSchedule.GridLines = true;
            this.lvwVehicleSchedule.Location = new System.Drawing.Point(14, 244);
            this.lvwVehicleSchedule.Name = "lvwVehicleSchedule";
            this.lvwVehicleSchedule.Size = new System.Drawing.Size(705, 287);
            this.lvwVehicleSchedule.TabIndex = 2;
            this.lvwVehicleSchedule.UseCompatibleStateImageBehavior = false;
            this.lvwVehicleSchedule.View = System.Windows.Forms.View.Details;
            this.lvwVehicleSchedule.DoubleClick += new System.EventHandler(this.lvwVehicleSchedule_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 63;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 76;
            // 
            // colName
            // 
            this.colName.Text = "Customer Name";
            this.colName.Width = 117;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 114;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Area";
            this.colLocation.Width = 80;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 120;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 80;
            // 
            // colED
            // 
            this.colED.Text = "Expected Date";
            this.colED.Width = 80;
            // 
            // colEDTimeFrom
            // 
            this.colEDTimeFrom.Text = "EDT (From)";
            this.colEDTimeFrom.Width = 70;
            // 
            // colEDTimeTo
            // 
            this.colEDTimeTo.Text = "EDT (To)";
            // 
            // colScheduleDate
            // 
            this.colScheduleDate.Text = "Schedule Date (SD)";
            this.colScheduleDate.Width = 80;
            // 
            // colScheduleTimeFrom
            // 
            this.colScheduleTimeFrom.Text = "SDT(From)";
            this.colScheduleTimeFrom.Width = 70;
            // 
            // colScheduleTimeTo
            // 
            this.colScheduleTimeTo.Text = "SDT(To)";
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product Name";
            this.colProduct.Width = 150;
            // 
            // colJobType
            // 
            this.colJobType.Text = "Job Type";
            this.colJobType.Width = 100;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 120;
            // 
            // colReqType
            // 
            this.colReqType.Text = "Req. Type";
            this.colReqType.Width = 70;
            // 
            // txtID
            // 
            this.txtID.AcceptsReturn = true;
            this.txtID.Location = new System.Drawing.Point(446, 119);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(252, 20);
            this.txtID.TabIndex = 16;
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.AutoSize = true;
            this.lblComplainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainNo.Location = new System.Drawing.Point(424, 122);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(20, 13);
            this.lblComplainNo.TabIndex = 15;
            this.lblComplainNo.Text = "ID";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(725, 207);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(71, 26);
            this.btnGo.TabIndex = 21;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnSchedulePreparation
            // 
            this.btnSchedulePreparation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSchedulePreparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedulePreparation.Location = new System.Drawing.Point(732, 281);
            this.btnSchedulePreparation.Name = "btnSchedulePreparation";
            this.btnSchedulePreparation.Size = new System.Drawing.Size(88, 27);
            this.btnSchedulePreparation.TabIndex = 4;
            this.btnSchedulePreparation.Text = "&Schedule";
            this.btnSchedulePreparation.UseVisualStyleBackColor = true;
            this.btnSchedulePreparation.Click += new System.EventHandler(this.btnSchedulePreparation_Click);
            // 
            // btnReSchedule
            // 
            this.btnReSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSchedule.Location = new System.Drawing.Point(732, 314);
            this.btnReSchedule.Name = "btnReSchedule";
            this.btnReSchedule.Size = new System.Drawing.Size(88, 27);
            this.btnReSchedule.TabIndex = 5;
            this.btnReSchedule.Text = "Re-Schedule";
            this.btnReSchedule.UseVisualStyleBackColor = true;
            this.btnReSchedule.Click += new System.EventHandler(this.btnReSchedule_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(732, 347);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(88, 27);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(732, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuspend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuspend.Location = new System.Drawing.Point(732, 380);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(88, 27);
            this.btnSuspend.TabIndex = 7;
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(512, 540);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Done";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(353, 540);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Schedule";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(275, 540);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Requisition";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(583, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Suspend";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(654, 540);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Cancel";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.DarkKhaki;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(424, 540);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "Re-Schedule";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(446, 146);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(252, 21);
            this.cmbStatus.TabIndex = 18;
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(401, 149);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(43, 13);
            this.lblComplainStatus.TabIndex = 17;
            this.lblComplainStatus.Text = "Status";
            // 
            // cmbReqType
            // 
            this.cmbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReqType.FormattingEnabled = true;
            this.cmbReqType.Location = new System.Drawing.Point(446, 173);
            this.cmbReqType.Name = "cmbReqType";
            this.cmbReqType.Size = new System.Drawing.Size(252, 21);
            this.cmbReqType.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Req. Type";
            // 
            // txtJobNo
            // 
            this.txtJobNo.AcceptsReturn = true;
            this.txtJobNo.Location = new System.Drawing.Point(446, 16);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(252, 20);
            this.txtJobNo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Job No";
            // 
            // txtLocation
            // 
            this.txtLocation.AcceptsReturn = true;
            this.txtLocation.Location = new System.Drawing.Point(446, 93);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(252, 20);
            this.txtLocation.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Area";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbServiceCenter);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtToScheduleDate);
            this.groupBox1.Controls.Add(this.dtToExpectedDate);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtToCreateDate);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtJobNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbReqType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.lblComplainStatus);
            this.groupBox1.Controls.Add(this.txtContactNo);
            this.groupBox1.Controls.Add(this.lblContact);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lblComplainNo);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 226);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(219, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "To";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(220, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "To";
            // 
            // dtToScheduleDate
            // 
            this.dtToScheduleDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToScheduleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToScheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToScheduleDate.Location = new System.Drawing.Point(243, 166);
            this.dtToScheduleDate.Name = "dtToScheduleDate";
            this.dtToScheduleDate.Size = new System.Drawing.Size(97, 20);
            this.dtToScheduleDate.TabIndex = 6;
            // 
            // dtToExpectedDate
            // 
            this.dtToExpectedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToExpectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToExpectedDate.Location = new System.Drawing.Point(244, 102);
            this.dtToExpectedDate.Name = "dtToExpectedDate";
            this.dtToExpectedDate.Size = new System.Drawing.Size(97, 20);
            this.dtToExpectedDate.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkScheduleDate);
            this.groupBox4.Controls.Add(this.dtFromScheduleDate);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(5, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 58);
            this.groupBox4.TabIndex = 246;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "    ";
            // 
            // chkScheduleDate
            // 
            this.chkScheduleDate.AutoSize = true;
            this.chkScheduleDate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkScheduleDate.Location = new System.Drawing.Point(8, 1);
            this.chkScheduleDate.Name = "chkScheduleDate";
            this.chkScheduleDate.Size = new System.Drawing.Size(160, 17);
            this.chkScheduleDate.TabIndex = 0;
            this.chkScheduleDate.Text = "Enable/Disable Data Range";
            this.chkScheduleDate.UseVisualStyleBackColor = true;
            this.chkScheduleDate.CheckedChanged += new System.EventHandler(this.chkScheduleDate_CheckedChanged);
            // 
            // dtFromScheduleDate
            // 
            this.dtFromScheduleDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromScheduleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromScheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromScheduleDate.Location = new System.Drawing.Point(103, 24);
            this.dtFromScheduleDate.Name = "dtFromScheduleDate";
            this.dtFromScheduleDate.Size = new System.Drawing.Size(105, 20);
            this.dtFromScheduleDate.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Schedule Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkExpectedDate);
            this.groupBox2.Controls.Add(this.dtFromExpectedDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 58);
            this.groupBox2.TabIndex = 247;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkExpectedDate
            // 
            this.chkExpectedDate.AutoSize = true;
            this.chkExpectedDate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkExpectedDate.Location = new System.Drawing.Point(8, 1);
            this.chkExpectedDate.Name = "chkExpectedDate";
            this.chkExpectedDate.Size = new System.Drawing.Size(160, 17);
            this.chkExpectedDate.TabIndex = 0;
            this.chkExpectedDate.Text = "Enable/Disable Data Range";
            this.chkExpectedDate.UseVisualStyleBackColor = true;
            this.chkExpectedDate.CheckedChanged += new System.EventHandler(this.chkExpectedDate_CheckedChanged);
            // 
            // dtFromExpectedDate
            // 
            this.dtFromExpectedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromExpectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromExpectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromExpectedDate.Location = new System.Drawing.Point(103, 24);
            this.dtFromExpectedDate.Name = "dtFromExpectedDate";
            this.dtFromExpectedDate.Size = new System.Drawing.Size(105, 20);
            this.dtFromExpectedDate.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Expected Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(220, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "To";
            // 
            // dtToCreateDate
            // 
            this.dtToCreateDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToCreateDate.Location = new System.Drawing.Point(244, 38);
            this.dtToCreateDate.Name = "dtToCreateDate";
            this.dtToCreateDate.Size = new System.Drawing.Size(97, 20);
            this.dtToCreateDate.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkCreateDate);
            this.groupBox3.Controls.Add(this.dtFromCreateDate);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(6, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 58);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "    ";
            // 
            // chkCreateDate
            // 
            this.chkCreateDate.AutoSize = true;
            this.chkCreateDate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkCreateDate.Location = new System.Drawing.Point(8, 1);
            this.chkCreateDate.Name = "chkCreateDate";
            this.chkCreateDate.Size = new System.Drawing.Size(160, 17);
            this.chkCreateDate.TabIndex = 0;
            this.chkCreateDate.Text = "Enable/Disable Data Range";
            this.chkCreateDate.UseVisualStyleBackColor = true;
            this.chkCreateDate.CheckedChanged += new System.EventHandler(this.chkCreateDate_CheckedChanged);
            // 
            // dtFromCreateDate
            // 
            this.dtFromCreateDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromCreateDate.Location = new System.Drawing.Point(102, 24);
            this.dtFromCreateDate.Name = "dtFromCreateDate";
            this.dtFromCreateDate.Size = new System.Drawing.Size(105, 20);
            this.dtFromCreateDate.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(21, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Create Date";
            // 
            // btnSchedulePrint
            // 
            this.btnSchedulePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSchedulePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedulePrint.Location = new System.Drawing.Point(15, 535);
            this.btnSchedulePrint.Name = "btnSchedulePrint";
            this.btnSchedulePrint.Size = new System.Drawing.Size(100, 27);
            this.btnSchedulePrint.TabIndex = 0;
            this.btnSchedulePrint.Text = "Schedule Print";
            this.btnSchedulePrint.UseVisualStyleBackColor = true;
            this.btnSchedulePrint.Click += new System.EventHandler(this.btnSchedulePrint_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Green;
            this.btnHistory.Location = new System.Drawing.Point(732, 446);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 27);
            this.btnHistory.TabIndex = 9;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(352, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 249;
            this.label4.Text = "Service Center";
            // 
            // cmbServiceCenter
            // 
            this.cmbServiceCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceCenter.FormattingEnabled = true;
            this.cmbServiceCenter.Items.AddRange(new object[] {
            "All",
            "Samsung",
            "Other"});
            this.cmbServiceCenter.Location = new System.Drawing.Point(446, 200);
            this.cmbServiceCenter.Name = "cmbServiceCenter";
            this.cmbServiceCenter.Size = new System.Drawing.Size(252, 21);
            this.cmbServiceCenter.TabIndex = 248;
            // 
            // frmVehicleSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 571);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnSchedulePrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnReSchedule);
            this.Controls.Add(this.btnSchedulePreparation);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwVehicleSchedule);
            this.Controls.Add(this.btnGo);
            this.Name = "frmVehicleSchedules";
            this.Text = "Vehicle Schedules";
            this.Load += new System.EventHandler(this.frmVehicleSchedules_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListView lvwVehicleSchedule;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colED;
        private System.Windows.Forms.ColumnHeader colScheduleDate;
        private System.Windows.Forms.ColumnHeader colScheduleTimeFrom;
        private System.Windows.Forms.ColumnHeader colScheduleTimeTo;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colReqType;
        private System.Windows.Forms.ColumnHeader colEDTimeFrom;
        private System.Windows.Forms.ColumnHeader colEDTimeTo;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.Button btnSchedulePreparation;
        private System.Windows.Forms.Button btnReSchedule;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbReqType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSchedulePrint;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtToScheduleDate;
        private System.Windows.Forms.DateTimePicker dtToExpectedDate;
        private System.Windows.Forms.DateTimePicker dtFromScheduleDate;
        private System.Windows.Forms.DateTimePicker dtFromExpectedDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkScheduleDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkExpectedDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtToCreateDate;
        private System.Windows.Forms.DateTimePicker dtFromCreateDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkCreateDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbServiceCenter;
    }
}