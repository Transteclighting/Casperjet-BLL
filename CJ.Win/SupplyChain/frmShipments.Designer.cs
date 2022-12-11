namespace CJ.Win.SupplyChain
{
    partial class frmShipments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShipments));
            this.lvwShipment = new System.Windows.Forms.ListView();
            this.colShipmentNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShipmentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLCNO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPSINO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShipment = new System.Windows.Forms.Button();
            this.btnCustomerClearance = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnReadyForGRD = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtPSINo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblShipmentNo = new System.Windows.Forms.Label();
            this.txtShipmentNo = new System.Windows.Forms.TextBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblLCNo = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnfrmLogAcknowledgement = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwShipment
            // 
            this.lvwShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwShipment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShipmentNo,
            this.colShipmentDate,
            this.colInvoiceNo,
            this.colLCNO,
            this.colOrderNo,
            this.colPSINO,
            this.colSupplier,
            this.colCompany,
            this.colStatus});
            this.lvwShipment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwShipment.FullRowSelect = true;
            this.lvwShipment.GridLines = true;
            this.lvwShipment.HideSelection = false;
            this.lvwShipment.Location = new System.Drawing.Point(15, 179);
            this.lvwShipment.MultiSelect = false;
            this.lvwShipment.Name = "lvwShipment";
            this.lvwShipment.Size = new System.Drawing.Size(906, 378);
            this.lvwShipment.TabIndex = 17;
            this.lvwShipment.UseCompatibleStateImageBehavior = false;
            this.lvwShipment.View = System.Windows.Forms.View.Details;
            // 
            // colShipmentNo
            // 
            this.colShipmentNo.Text = "Shipment#";
            this.colShipmentNo.Width = 82;
            // 
            // colShipmentDate
            // 
            this.colShipmentDate.Text = "Shipment Date";
            this.colShipmentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colShipmentDate.Width = 95;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice#";
            this.colInvoiceNo.Width = 96;
            // 
            // colLCNO
            // 
            this.colLCNO.Text = "LC#";
            this.colLCNO.Width = 94;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Order#";
            this.colOrderNo.Width = 92;
            // 
            // colPSINO
            // 
            this.colPSINO.Text = "PSI#";
            this.colPSINO.Width = 102;
            // 
            // colSupplier
            // 
            this.colSupplier.Text = "Supplier";
            this.colSupplier.Width = 145;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 170;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 99;
            // 
            // btnShipment
            // 
            this.btnShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShipment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnShipment.Location = new System.Drawing.Point(929, 179);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(128, 33);
            this.btnShipment.TabIndex = 18;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.UseVisualStyleBackColor = true;
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // btnCustomerClearance
            // 
            this.btnCustomerClearance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomerClearance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCustomerClearance.Location = new System.Drawing.Point(929, 219);
            this.btnCustomerClearance.Name = "btnCustomerClearance";
            this.btnCustomerClearance.Size = new System.Drawing.Size(128, 33);
            this.btnCustomerClearance.TabIndex = 19;
            this.btnCustomerClearance.Text = "Custom Clearance";
            this.btnCustomerClearance.UseVisualStyleBackColor = true;
            this.btnCustomerClearance.Click += new System.EventHandler(this.btnCustomerClearance_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnRelease.Location = new System.Drawing.Point(929, 260);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(128, 32);
            this.btnRelease.TabIndex = 20;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnReadyForGRD
            // 
            this.btnReadyForGRD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadyForGRD.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnReadyForGRD.Location = new System.Drawing.Point(929, 299);
            this.btnReadyForGRD.Name = "btnReadyForGRD";
            this.btnReadyForGRD.Size = new System.Drawing.Size(128, 33);
            this.btnReadyForGRD.TabIndex = 21;
            this.btnReadyForGRD.Text = "Ready For GRD";
            this.btnReadyForGRD.UseVisualStyleBackColor = true;
            this.btnReadyForGRD.Click += new System.EventHandler(this.btnReadyForGRD_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBilling.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnBilling.Location = new System.Drawing.Point(929, 339);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(128, 31);
            this.btnBilling.TabIndex = 22;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(929, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 33);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 61);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(22, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(182, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(51, 28);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(129, 23);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(238, 24);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(129, 23);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(210, 28);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(14, 31);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // txtPSINo
            // 
            this.txtPSINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPSINo.Location = new System.Drawing.Point(85, 137);
            this.txtPSINo.Name = "txtPSINo";
            this.txtPSINo.Size = new System.Drawing.Size(182, 23);
            this.txtPSINo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(47, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "PSI#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(504, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(571, 75);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(214, 23);
            this.cmbCompany.TabIndex = 13;
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.AutoSize = true;
            this.lblShipmentNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblShipmentNo.Location = new System.Drawing.Point(12, 82);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(69, 15);
            this.lblShipmentNo.TabIndex = 0;
            this.lblShipmentNo.Text = "Shipment#";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtShipmentNo.Location = new System.Drawing.Point(85, 79);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Size = new System.Drawing.Size(182, 23);
            this.txtShipmentNo.TabIndex = 1;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtOrderNo.Location = new System.Drawing.Point(331, 108);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(170, 23);
            this.txtOrderNo.TabIndex = 9;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetData.Location = new System.Drawing.Point(686, 141);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(99, 31);
            this.btnGetData.TabIndex = 16;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblOrderNo.Location = new System.Drawing.Point(277, 111);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(48, 15);
            this.lblOrderNo.TabIndex = 8;
            this.lblOrderNo.Text = "Order#";
            // 
            // lblLCNo
            // 
            this.lblLCNo.AutoSize = true;
            this.lblLCNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblLCNo.Location = new System.Drawing.Point(296, 83);
            this.lblLCNo.Name = "lblLCNo";
            this.lblLCNo.Size = new System.Drawing.Size(29, 15);
            this.lblLCNo.TabIndex = 2;
            this.lblLCNo.Text = "LC#";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtLCNo.Location = new System.Drawing.Point(331, 79);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(170, 23);
            this.txtLCNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(24, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Invoice#";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvoiceNo.Location = new System.Drawing.Point(85, 108);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(182, 23);
            this.txtInvoiceNo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(284, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(331, 137);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(170, 23);
            this.cmbStatus.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(512, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(571, 104);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(214, 23);
            this.cmbSupplier.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label12.Location = new System.Drawing.Point(21, 569);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 180;
            this.label12.Text = "PSI";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.GreenYellow;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(56, 569);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 181;
            this.label6.Text = "OrderPlace";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightPink;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label7.Location = new System.Drawing.Point(133, 569);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 182;
            this.label7.Text = "PIReceive";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label8.Location = new System.Drawing.Point(206, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 183;
            this.label8.Text = "LCProcessing";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label9.Location = new System.Drawing.Point(297, 569);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 184;
            this.label9.Text = "LCOpening";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Magenta;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(374, 569);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 185;
            this.label10.Text = "Shipment";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Yellow;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label11.Location = new System.Drawing.Point(441, 569);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 15);
            this.label11.TabIndex = 186;
            this.label11.Text = "CustomerClearance";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Cyan;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label13.Location = new System.Drawing.Point(563, 569);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 187;
            this.label13.Text = "Release";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Green;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label14.Location = new System.Drawing.Point(624, 569);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 188;
            this.label14.Text = "ReadyForGRD";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Silver;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label15.Location = new System.Drawing.Point(721, 569);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 189;
            this.label15.Text = "Billing";
            // 
            // btnfrmLogAcknowledgement
            // 
            this.btnfrmLogAcknowledgement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfrmLogAcknowledgement.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnfrmLogAcknowledgement.Location = new System.Drawing.Point(929, 377);
            this.btnfrmLogAcknowledgement.Name = "btnfrmLogAcknowledgement";
            this.btnfrmLogAcknowledgement.Size = new System.Drawing.Size(128, 44);
            this.btnfrmLogAcknowledgement.TabIndex = 190;
            this.btnfrmLogAcknowledgement.Text = "Log Acknowledgement";
            this.btnfrmLogAcknowledgement.UseVisualStyleBackColor = true;
            this.btnfrmLogAcknowledgement.Click += new System.EventHandler(this.btnfrmLogAcknowledgement_Click);
            // 
            // frmShipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 594);
            this.Controls.Add(this.btnfrmLogAcknowledgement);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.txtPSINo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblShipmentNo);
            this.Controls.Add(this.txtShipmentNo);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.lblLCNo);
            this.Controls.Add(this.txtLCNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnReadyForGRD);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnCustomerClearance);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.lvwShipment);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShipments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShipments";
            this.Load += new System.EventHandler(this.frmShipments_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwShipment;
        private System.Windows.Forms.ColumnHeader colShipmentNo;
        private System.Windows.Forms.ColumnHeader colShipmentDate;
        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colPSINO;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colLCNO;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.Button btnCustomerClearance;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnReadyForGRD;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtPSINo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblShipmentNo;
        private System.Windows.Forms.TextBox txtShipmentNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblLCNo;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.ColumnHeader colSupplier;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnfrmLogAcknowledgement;
    }
}