namespace CJ.Win.SupplyChain
{
    partial class frmSCMLCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMLCS));
            this.btnLCProcessingDate = new System.Windows.Forms.Button();
            this.btnNONLC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btnLCProcess = new System.Windows.Forms.Button();
            this.btnPIReceived = new System.Windows.Forms.Button();
            this.lvwLC = new System.Windows.Forms.ListView();
            this.colPINO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPIReceiveDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPSINo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLCRequisitionNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLCNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPINo = new System.Windows.Forms.Label();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPSINo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintLCRequisition = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLCProcessingDate
            // 
            this.btnLCProcessingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLCProcessingDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnLCProcessingDate.Location = new System.Drawing.Point(989, 206);
            this.btnLCProcessingDate.Name = "btnLCProcessingDate";
            this.btnLCProcessingDate.Size = new System.Drawing.Size(104, 27);
            this.btnLCProcessingDate.TabIndex = 16;
            this.btnLCProcessingDate.Text = "LC Process Date";
            this.btnLCProcessingDate.UseVisualStyleBackColor = true;
            this.btnLCProcessingDate.Click += new System.EventHandler(this.btnLCProcessingDate_Click);
            // 
            // btnNONLC
            // 
            this.btnNONLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNONLC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnNONLC.Location = new System.Drawing.Point(989, 304);
            this.btnNONLC.Name = "btnNONLC";
            this.btnNONLC.Size = new System.Drawing.Size(104, 26);
            this.btnNONLC.TabIndex = 18;
            this.btnNONLC.Text = "NON LC";
            this.btnNONLC.UseVisualStyleBackColor = true;
            this.btnNONLC.Click += new System.EventHandler(this.btnNONLC_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(19, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Order#";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtOrderNo.Location = new System.Drawing.Point(73, 139);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(206, 23);
            this.txtOrderNo.TabIndex = 4;
            // 
            // btnLCProcess
            // 
            this.btnLCProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLCProcess.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnLCProcess.Location = new System.Drawing.Point(989, 272);
            this.btnLCProcess.Name = "btnLCProcess";
            this.btnLCProcess.Size = new System.Drawing.Size(104, 26);
            this.btnLCProcess.TabIndex = 17;
            this.btnLCProcess.Text = "LC Open";
            this.btnLCProcess.UseVisualStyleBackColor = true;
            this.btnLCProcess.Click += new System.EventHandler(this.btnLCProcess_Click);
            // 
            // btnPIReceived
            // 
            this.btnPIReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPIReceived.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPIReceived.Location = new System.Drawing.Point(989, 174);
            this.btnPIReceived.Name = "btnPIReceived";
            this.btnPIReceived.Size = new System.Drawing.Size(104, 26);
            this.btnPIReceived.TabIndex = 15;
            this.btnPIReceived.Text = "PI Received";
            this.btnPIReceived.UseVisualStyleBackColor = true;
            this.btnPIReceived.Click += new System.EventHandler(this.btnPIReceived_Click);
            // 
            // lvwLC
            // 
            this.lvwLC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPINO,
            this.colPIReceiveDate,
            this.colOrderNo,
            this.colPSINo,
            this.colCompany,
            this.colSupplier,
            this.colLCRequisitionNo,
            this.colLCNo,
            this.colStatus});
            this.lvwLC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwLC.FullRowSelect = true;
            this.lvwLC.GridLines = true;
            this.lvwLC.HideSelection = false;
            this.lvwLC.Location = new System.Drawing.Point(14, 174);
            this.lvwLC.MultiSelect = false;
            this.lvwLC.Name = "lvwLC";
            this.lvwLC.Size = new System.Drawing.Size(969, 350);
            this.lvwLC.TabIndex = 14;
            this.lvwLC.UseCompatibleStateImageBehavior = false;
            this.lvwLC.View = System.Windows.Forms.View.Details;
            // 
            // colPINO
            // 
            this.colPINO.Text = "PI NO";
            // 
            // colPIReceiveDate
            // 
            this.colPIReceiveDate.Text = "PI Receive Date";
            this.colPIReceiveDate.Width = 108;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Order No";
            this.colOrderNo.Width = 82;
            // 
            // colPSINo
            // 
            this.colPSINo.Text = "PSI No";
            this.colPSINo.Width = 102;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 195;
            // 
            // colSupplier
            // 
            this.colSupplier.Text = "Supplier";
            this.colSupplier.Width = 141;
            // 
            // colLCRequisitionNo
            // 
            this.colLCRequisitionNo.Text = "LC Requisition#";
            this.colLCRequisitionNo.Width = 107;
            // 
            // colLCNo
            // 
            this.colLCNo.Text = "LC #";
            this.colLCNo.Width = 101;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 128;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetData.Location = new System.Drawing.Point(565, 137);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 31);
            this.btnGetData.TabIndex = 13;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(353, 110);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(206, 23);
            this.cmbSupplier.TabIndex = 12;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(294, 115);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 15);
            this.lblSupplier.TabIndex = 11;
            this.lblSupplier.Text = "Supplier";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(353, 139);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(206, 23);
            this.cmbStatus.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(306, 141);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(353, 83);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(206, 23);
            this.cmbCompany.TabIndex = 10;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCompany.Location = new System.Drawing.Point(285, 86);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(62, 15);
            this.lblCompany.TabIndex = 9;
            this.lblCompany.Text = "Company";
            // 
            // lblPINo
            // 
            this.lblPINo.AutoSize = true;
            this.lblPINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblPINo.Location = new System.Drawing.Point(42, 84);
            this.lblPINo.Name = "lblPINo";
            this.lblPINo.Size = new System.Drawing.Size(25, 15);
            this.lblPINo.TabIndex = 1;
            this.lblPINo.Text = "PI#";
            // 
            // txtPINo
            // 
            this.txtPINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPINo.Location = new System.Drawing.Point(73, 81);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.Size = new System.Drawing.Size(206, 23);
            this.txtPINo.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Location = new System.Drawing.Point(30, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 61);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(22, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(182, 19);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(57, 28);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(130, 23);
            this.dtFromdate.TabIndex = 3;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(243, 28);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(130, 23);
            this.dtTodate.TabIndex = 0;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(215, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(19, 31);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 15);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "From";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Silver;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label15.Location = new System.Drawing.Point(717, 539);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 19;
            this.label15.Text = "Billing";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Green;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label14.Location = new System.Drawing.Point(621, 539);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "ReadyForGRD";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Cyan;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label13.Location = new System.Drawing.Point(560, 539);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Release";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Yellow;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label11.Location = new System.Drawing.Point(437, 539);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "CustomClearance";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Magenta;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(371, 539);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Shipment";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label9.Location = new System.Drawing.Point(294, 539);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "LCOpening";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label8.Location = new System.Drawing.Point(203, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "LCProcessing";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightPink;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label7.Location = new System.Drawing.Point(129, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "PIReceive";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.GreenYellow;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(52, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "OrderPlace";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label12.Location = new System.Drawing.Point(17, 539);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "PSI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(35, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "PSI#";
            // 
            // txtPSINo
            // 
            this.txtPSINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPSINo.Location = new System.Drawing.Point(73, 110);
            this.txtPSINo.Name = "txtPSINo";
            this.txtPSINo.Size = new System.Drawing.Size(206, 23);
            this.txtPSINo.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(989, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 26);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintLCRequisition
            // 
            this.btnPrintLCRequisition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLCRequisition.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPrintLCRequisition.Location = new System.Drawing.Point(989, 239);
            this.btnPrintLCRequisition.Name = "btnPrintLCRequisition";
            this.btnPrintLCRequisition.Size = new System.Drawing.Size(104, 27);
            this.btnPrintLCRequisition.TabIndex = 30;
            this.btnPrintLCRequisition.Text = "Print LC Req";
            this.btnPrintLCRequisition.UseVisualStyleBackColor = true;
            this.btnPrintLCRequisition.Click += new System.EventHandler(this.btnPrintLCRequisition_Click);
            // 
            // frmSCMLCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 565);
            this.Controls.Add(this.btnPrintLCRequisition);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPSINo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnLCProcessingDate);
            this.Controls.Add(this.btnNONLC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.btnLCProcess);
            this.Controls.Add(this.btnPIReceived);
            this.Controls.Add(this.lvwLC);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblPINo);
            this.Controls.Add(this.txtPINo);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSCMLCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSCMLCS";
            this.Load += new System.EventHandler(this.frmSCMLCS_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLCProcessingDate;
        private System.Windows.Forms.Button btnNONLC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btnLCProcess;
        private System.Windows.Forms.Button btnPIReceived;
        private System.Windows.Forms.ListView lvwLC;
        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colPSINo;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colSupplier;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPINo;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader colPINO;
        private System.Windows.Forms.ColumnHeader colPIReceiveDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPSINo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colLCRequisitionNo;
        private System.Windows.Forms.ColumnHeader colLCNo;
        private System.Windows.Forms.Button btnPrintLCRequisition;
    }
}