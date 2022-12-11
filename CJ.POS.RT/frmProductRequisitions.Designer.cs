namespace CJ.POS.RT
{
    partial class frmProductRequisitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductRequisitions));
            this.lvwItemList = new System.Windows.Forms.ListView();
            this.colRequisitionNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colfromWH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTWH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthrizeRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTransferRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceiveRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btGetData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequisitionNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddReturnToHO = new System.Windows.Forms.Button();
            this.btnAddOtherOutlet = new System.Windows.Forms.Button();
            this.btnAddSendToCSD = new System.Windows.Forms.Button();
            this.btnRequisitionRcv = new System.Windows.Forms.Button();
            this.btnISGMRcv = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVatChallan = new System.Windows.Forms.Button();
            this.btnUpdateVehicleNo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItemList
            // 
            this.lvwItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRequisitionNo,
            this.colDate,
            this.colfromWH,
            this.colTWH,
            this.colRS,
            this.colRRemarks,
            this.colAuthrizeRemarks,
            this.colTransferRemarks,
            this.colReceiveRemarks});
            this.lvwItemList.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItemList.FullRowSelect = true;
            this.lvwItemList.GridLines = true;
            this.lvwItemList.HideSelection = false;
            this.lvwItemList.Location = new System.Drawing.Point(12, 99);
            this.lvwItemList.MultiSelect = false;
            this.lvwItemList.Name = "lvwItemList";
            this.lvwItemList.Size = new System.Drawing.Size(805, 346);
            this.lvwItemList.TabIndex = 6;
            this.lvwItemList.UseCompatibleStateImageBehavior = false;
            this.lvwItemList.View = System.Windows.Forms.View.Details;
            this.lvwItemList.DoubleClick += new System.EventHandler(this.lvwItemList_DoubleClick);
            // 
            // colRequisitionNo
            // 
            this.colRequisitionNo.Text = "Requisition No";
            this.colRequisitionNo.Width = 128;
            // 
            // colDate
            // 
            this.colDate.Text = "Requisition Date";
            this.colDate.Width = 111;
            // 
            // colfromWH
            // 
            this.colfromWH.Text = "From WH";
            this.colfromWH.Width = 90;
            // 
            // colTWH
            // 
            this.colTWH.Text = "To WH";
            this.colTWH.Width = 77;
            // 
            // colRS
            // 
            this.colRS.Text = "Status";
            this.colRS.Width = 111;
            // 
            // colRRemarks
            // 
            this.colRRemarks.Text = "Create Remarks";
            this.colRRemarks.Width = 140;
            // 
            // colAuthrizeRemarks
            // 
            this.colAuthrizeRemarks.Text = "Authrize Remarks";
            this.colAuthrizeRemarks.Width = 140;
            // 
            // colTransferRemarks
            // 
            this.colTransferRemarks.Text = "Transfer Remarks";
            this.colTransferRemarks.Width = 140;
            // 
            // colReceiveRemarks
            // 
            this.colReceiveRemarks.Text = "Receive Remarks";
            this.colReceiveRemarks.Width = 140;
            // 
            // btGetData
            // 
            this.btGetData.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGetData.Location = new System.Drawing.Point(484, 65);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(101, 28);
            this.btGetData.TabIndex = 5;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(265, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(313, 67);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(165, 24);
            this.cmbStatus.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Requisition#";
            // 
            // txtRequisitionNo
            // 
            this.txtRequisitionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequisitionNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequisitionNo.Location = new System.Drawing.Point(94, 68);
            this.txtRequisitionNo.Name = "txtRequisitionNo";
            this.txtRequisitionNo.Size = new System.Drawing.Size(165, 23);
            this.txtRequisitionNo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(212, 19);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 21);
            this.dtToDate.TabIndex = 4;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(55, 19);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(110, 21);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(823, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(823, 132);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 28);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(823, 166);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 28);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(823, 417);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 28);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddReturnToHO
            // 
            this.btnAddReturnToHO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddReturnToHO.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReturnToHO.Location = new System.Drawing.Point(823, 98);
            this.btnAddReturnToHO.Name = "btnAddReturnToHO";
            this.btnAddReturnToHO.Size = new System.Drawing.Size(101, 28);
            this.btnAddReturnToHO.TabIndex = 8;
            this.btnAddReturnToHO.Text = "Add";
            this.btnAddReturnToHO.UseVisualStyleBackColor = true;
            this.btnAddReturnToHO.Click += new System.EventHandler(this.btnAddReturnToHO_Click);
            // 
            // btnAddOtherOutlet
            // 
            this.btnAddOtherOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOtherOutlet.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOtherOutlet.Location = new System.Drawing.Point(823, 98);
            this.btnAddOtherOutlet.Name = "btnAddOtherOutlet";
            this.btnAddOtherOutlet.Size = new System.Drawing.Size(101, 28);
            this.btnAddOtherOutlet.TabIndex = 7;
            this.btnAddOtherOutlet.Text = "Add";
            this.btnAddOtherOutlet.UseVisualStyleBackColor = true;
            this.btnAddOtherOutlet.Click += new System.EventHandler(this.btnAddOtherOutlet_Click);
            // 
            // btnAddSendToCSD
            // 
            this.btnAddSendToCSD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSendToCSD.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSendToCSD.Location = new System.Drawing.Point(823, 98);
            this.btnAddSendToCSD.Name = "btnAddSendToCSD";
            this.btnAddSendToCSD.Size = new System.Drawing.Size(101, 28);
            this.btnAddSendToCSD.TabIndex = 9;
            this.btnAddSendToCSD.Text = "Add";
            this.btnAddSendToCSD.UseVisualStyleBackColor = true;
            this.btnAddSendToCSD.Click += new System.EventHandler(this.btnAddSendToCSD_Click);
            // 
            // btnRequisitionRcv
            // 
            this.btnRequisitionRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequisitionRcv.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequisitionRcv.Location = new System.Drawing.Point(823, 98);
            this.btnRequisitionRcv.Name = "btnRequisitionRcv";
            this.btnRequisitionRcv.Size = new System.Drawing.Size(101, 28);
            this.btnRequisitionRcv.TabIndex = 11;
            this.btnRequisitionRcv.Text = "Receive";
            this.btnRequisitionRcv.UseVisualStyleBackColor = true;
            this.btnRequisitionRcv.Click += new System.EventHandler(this.btnRequisitionRcv_Click);
            // 
            // btnISGMRcv
            // 
            this.btnISGMRcv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnISGMRcv.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnISGMRcv.Location = new System.Drawing.Point(823, 98);
            this.btnISGMRcv.Name = "btnISGMRcv";
            this.btnISGMRcv.Size = new System.Drawing.Size(101, 28);
            this.btnISGMRcv.TabIndex = 10;
            this.btnISGMRcv.Text = "Receive";
            this.btnISGMRcv.UseVisualStyleBackColor = true;
            this.btnISGMRcv.Click += new System.EventHandler(this.btnISGMRcv_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(12, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(140, 18);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "Create";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(197, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Transfer to Branch";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Thistle;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "Approved by HO";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Salmon;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "Rejected by HO";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.CadetBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(464, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 23;
            this.label9.Text = "Received at Branch";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.SandyBrown;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sent to HO";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(823, 200);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(101, 28);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(362, 452);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "Received by Logistics";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnVatChallan
            // 
            this.btnVatChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVatChallan.Enabled = false;
            this.btnVatChallan.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVatChallan.Location = new System.Drawing.Point(823, 234);
            this.btnVatChallan.Name = "btnVatChallan";
            this.btnVatChallan.Size = new System.Drawing.Size(101, 29);
            this.btnVatChallan.TabIndex = 15;
            this.btnVatChallan.Text = "Vat Print (6.5)";
            this.btnVatChallan.UseVisualStyleBackColor = true;
            this.btnVatChallan.Click += new System.EventHandler(this.btnVatChallan_Click);
            // 
            // btnUpdateVehicleNo
            // 
            this.btnUpdateVehicleNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateVehicleNo.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateVehicleNo.Location = new System.Drawing.Point(823, 269);
            this.btnUpdateVehicleNo.Name = "btnUpdateVehicleNo";
            this.btnUpdateVehicleNo.Size = new System.Drawing.Size(101, 29);
            this.btnUpdateVehicleNo.TabIndex = 16;
            this.btnUpdateVehicleNo.Text = "Update Vehicle#";
            this.btnUpdateVehicleNo.UseVisualStyleBackColor = true;
            this.btnUpdateVehicleNo.Click += new System.EventHandler(this.btnUpdateVehicleNo_Click);
            // 
            // frmProductRequisitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(936, 480);
            this.Controls.Add(this.btnUpdateVehicleNo);
            this.Controls.Add(this.btnVatChallan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnISGMRcv);
            this.Controls.Add(this.btnRequisitionRcv);
            this.Controls.Add(this.btnAddSendToCSD);
            this.Controls.Add(this.btnAddOtherOutlet);
            this.Controls.Add(this.btnAddReturnToHO);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRequisitionNo);
            this.Controls.Add(this.lvwItemList);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductRequisitions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Requisitions";
            this.Load += new System.EventHandler(this.frmProductRequisitions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItemList;
        private System.Windows.Forms.ColumnHeader colRequisitionNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colRS;
        private System.Windows.Forms.ColumnHeader colTWH;
        private System.Windows.Forms.ColumnHeader colRRemarks;
        private System.Windows.Forms.ColumnHeader colfromWH;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRequisitionNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddReturnToHO;
        private System.Windows.Forms.Button btnAddOtherOutlet;
        private System.Windows.Forms.Button btnAddSendToCSD;
        private System.Windows.Forms.Button btnRequisitionRcv;
        private System.Windows.Forms.Button btnISGMRcv;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader colAuthrizeRemarks;
        private System.Windows.Forms.ColumnHeader colTransferRemarks;
        private System.Windows.Forms.ColumnHeader colReceiveRemarks;
        private System.Windows.Forms.Button btnVatChallan;
        private System.Windows.Forms.Button btnUpdateVehicleNo;
    }
}