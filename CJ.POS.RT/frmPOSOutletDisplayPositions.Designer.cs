namespace CJ.POS.RT
{
    partial class frmPOSOutletDisplayPositions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSOutletDisplayPositions));
            this.label17 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.txtAssignProduct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtForProduct = new System.Windows.Forms.TextBox();
            this.txtProductModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.colMAG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPositionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.colShowroomCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChallanNo = new System.Windows.Forms.Label();
            this.colPositionCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPositionCode = new System.Windows.Forms.TextBox();
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colASG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssignDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwOutletDisplayPositions = new System.Windows.Forms.ListView();
            this.colRackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenForAll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label20 = new System.Windows.Forms.Label();
            this.btnADD = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRackName = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbOpenForAll = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightSalmon;
            this.label17.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(43, 521);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 15);
            this.label17.TabIndex = 166;
            this.label17.Text = "Blank";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(14, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(186, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(119, 21);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(116, 23);
            this.dtFromdate.TabIndex = 2;
            // 
            // txtAssignProduct
            // 
            this.txtAssignProduct.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAssignProduct.Location = new System.Drawing.Point(661, 158);
            this.txtAssignProduct.Name = "txtAssignProduct";
            this.txtAssignProduct.Size = new System.Drawing.Size(189, 23);
            this.txtAssignProduct.TabIndex = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(556, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 164;
            this.label1.Text = "Assign Product:";
            // 
            // txtForProduct
            // 
            this.txtForProduct.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtForProduct.Location = new System.Drawing.Point(131, 158);
            this.txtForProduct.Name = "txtForProduct";
            this.txtForProduct.Size = new System.Drawing.Size(189, 23);
            this.txtForProduct.TabIndex = 163;
            // 
            // txtProductModel
            // 
            this.txtProductModel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtProductModel.Location = new System.Drawing.Point(131, 129);
            this.txtProductModel.Name = "txtProductModel";
            this.txtProductModel.Size = new System.Drawing.Size(189, 23);
            this.txtProductModel.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(27, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 158;
            this.label3.Text = "Product Model:";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(661, 66);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(189, 23);
            this.cmbBrand.TabIndex = 145;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(364, 71);
            this.cmbPG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(189, 23);
            this.cmbPG.TabIndex = 149;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 148;
            this.label10.Text = "PG";
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 83;
            // 
            // colPG
            // 
            this.colPG.Text = "PG";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(323, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 152;
            this.label12.Text = "MAG";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(335, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 15);
            this.label13.TabIndex = 159;
            this.label13.Text = "AG";
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(364, 162);
            this.cmbAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(189, 23);
            this.cmbAG.TabIndex = 160;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(328, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 15);
            this.label14.TabIndex = 156;
            this.label14.Text = "ASG";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Location = new System.Drawing.Point(9, 162);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(118, 16);
            this.lblProduct.TabIndex = 161;
            this.lblProduct.Text = "For Product Detail:";
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(352, 20);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(116, 23);
            this.dtTodate.TabIndex = 4;
            // 
            // colMAG
            // 
            this.colMAG.Text = "MAG";
            // 
            // colPositionName
            // 
            this.colPositionName.Text = "Position Name";
            this.colPositionName.Width = 104;
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(364, 131);
            this.cmbASG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(189, 23);
            this.cmbASG.TabIndex = 157;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // colShowroomCode
            // 
            this.colShowroomCode.Text = "Showroom Code";
            this.colShowroomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colShowroomCode.Width = 112;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(29, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 146;
            this.label5.Text = "Position Name:";
            // 
            // txtPositionName
            // 
            this.txtPositionName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtPositionName.Location = new System.Drawing.Point(131, 100);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(189, 23);
            this.txtPositionName.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(599, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 150;
            this.label4.Text = "IsActive:";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(661, 96);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(189, 23);
            this.cmbIsActive.TabIndex = 151;
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(364, 101);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(189, 23);
            this.cmbMAG.TabIndex = 153;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(608, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 154;
            this.label2.Text = "Status:";
            // 
            // lblChallanNo
            // 
            this.lblChallanNo.AutoSize = true;
            this.lblChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChallanNo.Location = new System.Drawing.Point(32, 73);
            this.lblChallanNo.Name = "lblChallanNo";
            this.lblChallanNo.Size = new System.Drawing.Size(93, 15);
            this.lblChallanNo.TabIndex = 142;
            this.lblChallanNo.Text = "Position Code:";
            // 
            // colPositionCode
            // 
            this.colPositionCode.Text = "Position Code";
            this.colPositionCode.Width = 100;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(210, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(79, 26);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(37, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(661, 129);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(189, 23);
            this.cmbStatus.TabIndex = 155;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(326, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "To";
            // 
            // txtPositionCode
            // 
            this.txtPositionCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtPositionCode.Location = new System.Drawing.Point(131, 70);
            this.txtPositionCode.Name = "txtPositionCode";
            this.txtPositionCode.Size = new System.Drawing.Size(189, 23);
            this.txtPositionCode.TabIndex = 143;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "For Product Detail";
            this.colProductCode.Width = 165;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Assign Product Detail";
            this.colProductName.Width = 174;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            // 
            // colProductSerialNo
            // 
            this.colProductSerialNo.Text = "Product Serial #";
            this.colProductSerialNo.Width = 106;
            // 
            // colProductModel
            // 
            this.colProductModel.Text = "Product Model";
            this.colProductModel.Width = 118;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(612, 70);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(46, 15);
            this.lblBrand.TabIndex = 144;
            this.lblBrand.Text = "Brand:";
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGetData.Location = new System.Drawing.Point(855, 154);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(90, 31);
            this.btnGetData.TabIndex = 139;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 52);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            // 
            // colAssignDate
            // 
            this.colAssignDate.Text = "Assign Date";
            // 
            // colAG
            // 
            this.colAG.Text = "AG";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(958, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 140;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwOutletDisplayPositions
            // 
            this.lvwOutletDisplayPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOutletDisplayPositions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowroomCode,
            this.colPositionCode,
            this.colPositionName,
            this.colRackName,
            this.colProductCode,
            this.colProductName,
            this.colProductModel,
            this.colAG,
            this.colASG,
            this.colMAG,
            this.colPG,
            this.colBrand,
            this.colProductSerialNo,
            this.colCreateDate,
            this.colAssignDate,
            this.colStatus,
            this.colIsActive,
            this.colOpenForAll});
            this.lvwOutletDisplayPositions.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lvwOutletDisplayPositions.FullRowSelect = true;
            this.lvwOutletDisplayPositions.GridLines = true;
            this.lvwOutletDisplayPositions.HideSelection = false;
            this.lvwOutletDisplayPositions.Location = new System.Drawing.Point(12, 192);
            this.lvwOutletDisplayPositions.MultiSelect = false;
            this.lvwOutletDisplayPositions.Name = "lvwOutletDisplayPositions";
            this.lvwOutletDisplayPositions.Size = new System.Drawing.Size(937, 326);
            this.lvwOutletDisplayPositions.TabIndex = 137;
            this.lvwOutletDisplayPositions.UseCompatibleStateImageBehavior = false;
            this.lvwOutletDisplayPositions.View = System.Windows.Forms.View.Details;
            this.lvwOutletDisplayPositions.DoubleClick += new System.EventHandler(this.lvwOutletDisplayPositions_DoubleClick);
            // 
            // colRackName
            // 
            this.colRackName.Text = "Rack Name";
            this.colRackName.Width = 104;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand Desc";
            // 
            // colOpenForAll
            // 
            this.colOpenForAll.Text = "Open For All";
            this.colOpenForAll.Width = 90;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(15, 521);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 15);
            this.label20.TabIndex = 141;
            this.label20.Text = "Fill";
            // 
            // btnADD
            // 
            this.btnADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADD.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnADD.Location = new System.Drawing.Point(958, 192);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(90, 30);
            this.btnADD.TabIndex = 136;
            this.btnADD.Text = "Action";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(580, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 167;
            this.label9.Text = "Rack Name:";
            // 
            // cmbRackName
            // 
            this.cmbRackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRackName.FormattingEnabled = true;
            this.cmbRackName.Location = new System.Drawing.Point(661, 36);
            this.cmbRackName.Name = "cmbRackName";
            this.cmbRackName.Size = new System.Drawing.Size(189, 23);
            this.cmbRackName.TabIndex = 168;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnReport.Location = new System.Drawing.Point(958, 228);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(90, 30);
            this.btnReport.TabIndex = 169;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbOpenForAll
            // 
            this.cbOpenForAll.AutoSize = true;
            this.cbOpenForAll.Location = new System.Drawing.Point(661, 11);
            this.cbOpenForAll.Name = "cbOpenForAll";
            this.cbOpenForAll.Size = new System.Drawing.Size(142, 19);
            this.cbOpenForAll.TabIndex = 170;
            this.cbOpenForAll.Text = "Open for all Models";
            this.cbOpenForAll.UseVisualStyleBackColor = true;
            // 
            // frmPOSOutletDisplayPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 545);
            this.Controls.Add(this.cbOpenForAll);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbRackName);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtAssignProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtForProduct);
            this.Controls.Add(this.txtProductModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPositionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblChallanNo);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtPositionCode);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwOutletDisplayPositions);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnADD);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPOSOutletDisplayPositions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Display Position List";
            this.Load += new System.EventHandler(this.frmPOSOutletDisplayPositions_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lvwOutletDisplayPositions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colAG;
        private System.Windows.Forms.ColumnHeader colAssignDate;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ColumnHeader colProductModel;
        private System.Windows.Forms.ColumnHeader colProductSerialNo;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.TextBox txtPositionCode;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ColumnHeader colPositionCode;
        private System.Windows.Forms.Label lblChallanNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colShowroomCode;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ColumnHeader colPositionName;
        private System.Windows.Forms.ColumnHeader colMAG;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader colPG;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductModel;
        private System.Windows.Forms.TextBox txtForProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAssignProduct;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRackName;
        private System.Windows.Forms.ColumnHeader colRackName;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox cbOpenForAll;
        private System.Windows.Forms.ColumnHeader colOpenForAll;
    }
}