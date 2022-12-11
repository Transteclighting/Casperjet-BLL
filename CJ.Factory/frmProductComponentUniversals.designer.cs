namespace CJ.Factory
{
    partial class frmProductComponentUniversals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductComponentUniversals));
            this.Chk = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.lvwProductComponentUniversals = new System.Windows.Forms.ListView();
            this.colSetID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colASGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrandDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComponentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAG = new System.Windows.Forms.Label();
            this.cboAG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cboASG = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.cboMAG = new System.Windows.Forms.ComboBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.cboPG = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbComponentName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintHeader = new System.Windows.Forms.Button();
            this.btnPicker = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnDefective = new System.Windows.Forms.Button();
            this.cbIsDefective = new System.Windows.Forms.CheckBox();
            this.Chk.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chk
            // 
            this.Chk.Controls.Add(this.label1);
            this.Chk.Controls.Add(this.label4);
            this.Chk.Controls.Add(this.chkAll);
            this.Chk.Controls.Add(this.dtFromDate);
            this.Chk.Controls.Add(this.dtToDate);
            this.Chk.Location = new System.Drawing.Point(14, 14);
            this.Chk.Name = "Chk";
            this.Chk.Size = new System.Drawing.Size(430, 51);
            this.Chk.TabIndex = 57;
            this.Chk.TabStop = false;
            this.Chk.Text = "    ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "To Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "From Date:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(22, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(179, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(78, 22);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(130, 21);
            this.dtFromDate.TabIndex = 12;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(293, 22);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(130, 21);
            this.dtToDate.TabIndex = 14;
            // 
            // lvwProductComponentUniversals
            // 
            this.lvwProductComponentUniversals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductComponentUniversals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSetID,
            this.colProductCode,
            this.colProductName,
            this.colProductModel,
            this.colAGName,
            this.colASGName,
            this.colMAGName,
            this.colPGName,
            this.colBrandDesc,
            this.colComponentName,
            this.colSerialNo,
            this.colCreateDate,
            this.colCreateUserID});
            this.lvwProductComponentUniversals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwProductComponentUniversals.FullRowSelect = true;
            this.lvwProductComponentUniversals.GridLines = true;
            this.lvwProductComponentUniversals.HideSelection = false;
            this.lvwProductComponentUniversals.Location = new System.Drawing.Point(14, 209);
            this.lvwProductComponentUniversals.MultiSelect = false;
            this.lvwProductComponentUniversals.Name = "lvwProductComponentUniversals";
            this.lvwProductComponentUniversals.Size = new System.Drawing.Size(727, 243);
            this.lvwProductComponentUniversals.TabIndex = 51;
            this.lvwProductComponentUniversals.UseCompatibleStateImageBehavior = false;
            this.lvwProductComponentUniversals.View = System.Windows.Forms.View.Details;
            // 
            // colSetID
            // 
            this.colSetID.Text = "Set ID";
            this.colSetID.Width = 52;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 77;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 139;
            // 
            // colProductModel
            // 
            this.colProductModel.Text = "Model";
            this.colProductModel.Width = 75;
            // 
            // colAGName
            // 
            this.colAGName.Text = "AG Name";
            this.colAGName.Width = 101;
            // 
            // colASGName
            // 
            this.colASGName.Text = "ASG Name";
            this.colASGName.Width = 104;
            // 
            // colMAGName
            // 
            this.colMAGName.Text = "MAG Name";
            this.colMAGName.Width = 100;
            // 
            // colPGName
            // 
            this.colPGName.Text = "PG Name";
            this.colPGName.Width = 117;
            // 
            // colBrandDesc
            // 
            this.colBrandDesc.Text = "Brand Desc";
            this.colBrandDesc.Width = 110;
            // 
            // colComponentName
            // 
            this.colComponentName.Text = "Component Name";
            this.colComponentName.Width = 123;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "Serial #";
            this.colSerialNo.Width = 122;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 97;
            // 
            // colCreateUserID
            // 
            this.colCreateUserID.Text = "Create User";
            this.colCreateUserID.Width = 69;
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAG.Location = new System.Drawing.Point(319, 98);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(60, 15);
            this.lblAG.TabIndex = 217;
            this.lblAG.Text = "AG Name";
            // 
            // cboAG
            // 
            this.cboAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAG.FormattingEnabled = true;
            this.cboAG.Location = new System.Drawing.Point(383, 94);
            this.cboAG.Name = "cboAG";
            this.cboAG.Size = new System.Drawing.Size(172, 23);
            this.cboAG.TabIndex = 216;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblASG.Location = new System.Drawing.Point(311, 71);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(68, 15);
            this.lblASG.TabIndex = 215;
            this.lblASG.Text = "ASG Name";
            // 
            // cboASG
            // 
            this.cboASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboASG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboASG.FormattingEnabled = true;
            this.cboASG.Location = new System.Drawing.Point(383, 67);
            this.cboASG.Name = "cboASG";
            this.cboASG.Size = new System.Drawing.Size(172, 23);
            this.cboASG.TabIndex = 214;
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAG.Location = new System.Drawing.Point(54, 101);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(71, 15);
            this.lblMAG.TabIndex = 213;
            this.lblMAG.Text = "MAG Name";
            // 
            // cboMAG
            // 
            this.cboMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMAG.FormattingEnabled = true;
            this.cboMAG.Location = new System.Drawing.Point(131, 98);
            this.cboMAG.Name = "cboMAG";
            this.cboMAG.Size = new System.Drawing.Size(172, 23);
            this.cboMAG.TabIndex = 212;
            // 
            // lblPG
            // 
            this.lblPG.AutoSize = true;
            this.lblPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPG.Location = new System.Drawing.Point(64, 74);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(61, 15);
            this.lblPG.TabIndex = 211;
            this.lblPG.Text = "PG Name";
            // 
            // cboPG
            // 
            this.cboPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPG.FormattingEnabled = true;
            this.cboPG.Location = new System.Drawing.Point(131, 71);
            this.cboPG.Name = "cboPG";
            this.cboPG.Size = new System.Drawing.Size(172, 23);
            this.cboPG.TabIndex = 210;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(383, 123);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(172, 23);
            this.cmbBrand.TabIndex = 209;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(308, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 15);
            this.label6.TabIndex = 208;
            this.label6.Text = "Brand Desc";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbComponentName
            // 
            this.cmbComponentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComponentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComponentName.FormattingEnabled = true;
            this.cmbComponentName.Location = new System.Drawing.Point(131, 127);
            this.cmbComponentName.Name = "cmbComponentName";
            this.cmbComponentName.Size = new System.Drawing.Size(172, 23);
            this.cmbComponentName.TabIndex = 220;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 219;
            this.label2.Text = "Component Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(131, 156);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(172, 21);
            this.txtSerialNo.TabIndex = 221;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 222;
            this.label3.Text = "Serial #";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 223;
            this.label5.Text = "Product Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(747, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 26);
            this.btnAdd.TabIndex = 224;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(747, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 26);
            this.btnClose.TabIndex = 226;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(747, 239);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 26);
            this.btnEdit.TabIndex = 227;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(544, 178);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(80, 26);
            this.btnGetData.TabIndex = 228;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(747, 271);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 26);
            this.btnPrint.TabIndex = 229;
            this.btnPrint.Text = "Reprint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintHeader
            // 
            this.btnPrintHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintHeader.Location = new System.Drawing.Point(747, 303);
            this.btnPrintHeader.Name = "btnPrintHeader";
            this.btnPrintHeader.Size = new System.Drawing.Size(80, 41);
            this.btnPrintHeader.TabIndex = 230;
            this.btnPrintHeader.Text = "Reprint Header";
            this.btnPrintHeader.UseVisualStyleBackColor = true;
            this.btnPrintHeader.Click += new System.EventHandler(this.btnPrintHeader_Click);
            // 
            // btnPicker
            // 
            this.btnPicker.Location = new System.Drawing.Point(234, 181);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(31, 22);
            this.btnPicker.TabIndex = 232;
            this.btnPicker.Text = "?";
            this.btnPicker.UseVisualStyleBackColor = true;
            this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(269, 181);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(269, 20);
            this.txtName.TabIndex = 233;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(131, 181);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 231;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // btnDefective
            // 
            this.btnDefective.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefective.Location = new System.Drawing.Point(747, 350);
            this.btnDefective.Name = "btnDefective";
            this.btnDefective.Size = new System.Drawing.Size(80, 41);
            this.btnDefective.TabIndex = 234;
            this.btnDefective.Text = "Defective";
            this.btnDefective.UseVisualStyleBackColor = true;
            this.btnDefective.Visible = false;
            this.btnDefective.Click += new System.EventHandler(this.btnDefective_Click);
            // 
            // cbIsDefective
            // 
            this.cbIsDefective.AutoSize = true;
            this.cbIsDefective.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbIsDefective.Location = new System.Drawing.Point(346, 159);
            this.cbIsDefective.Name = "cbIsDefective";
            this.cbIsDefective.Size = new System.Drawing.Size(85, 19);
            this.cbIsDefective.TabIndex = 235;
            this.cbIsDefective.Text = "IsDefective";
            this.cbIsDefective.UseVisualStyleBackColor = true;
            // 
            // frmProductComponentUniversals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 464);
            this.Controls.Add(this.cbIsDefective);
            this.Controls.Add(this.btnDefective);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnPrintHeader);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.cmbComponentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAG);
            this.Controls.Add(this.cboAG);
            this.Controls.Add(this.lblASG);
            this.Controls.Add(this.cboASG);
            this.Controls.Add(this.lblMAG);
            this.Controls.Add(this.cboMAG);
            this.Controls.Add(this.lblPG);
            this.Controls.Add(this.cboPG);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Chk);
            this.Controls.Add(this.lvwProductComponentUniversals);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductComponentUniversals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductComponentUniversals";
            this.Load += new System.EventHandler(this.frmProductComponentUniversals_Load);
            this.Chk.ResumeLayout(false);
            this.Chk.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox Chk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ListView lvwProductComponentUniversals;
        private System.Windows.Forms.ColumnHeader colSetID;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductModel;
        private System.Windows.Forms.ColumnHeader colAGName;
        private System.Windows.Forms.ColumnHeader colASGName;
        private System.Windows.Forms.ColumnHeader colMAGName;
        private System.Windows.Forms.ColumnHeader colPGName;
        private System.Windows.Forms.ColumnHeader colBrandDesc;
        private System.Windows.Forms.ColumnHeader colComponentName;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colCreateUserID;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.ComboBox cboAG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cboASG;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.ComboBox cboMAG;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.ComboBox cboPG;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbComponentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintHeader;
        private System.Windows.Forms.Button btnPicker;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnDefective;
        private System.Windows.Forms.CheckBox cbIsDefective;
    }
}