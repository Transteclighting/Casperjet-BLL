namespace CJ.Win.IT
{
    partial class frmITEquipmentHistory
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwITEquipmentHistoryList = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromStore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToStore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblDate = new System.Windows.Forms.Label();
            this.txtAssetNo = new System.Windows.Forms.TextBox();
            this.cbTranType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.cbCurStoreName = new System.Windows.Forms.ComboBox();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.cbCurCompany = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAssetRemarks = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtTranRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctlNewEmployee = new CJ.Win.ctlEmployee();
            this.label8 = new System.Windows.Forms.Label();
            this.cbStoreName = new System.Windows.Forms.ComboBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteHistory = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(638, 117);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 27);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // lvwITEquipmentHistoryList
            // 
            this.lvwITEquipmentHistoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colType,
            this.colUser,
            this.colFromStore,
            this.colToStore,
            this.colCompany,
            this.colRemarks});
            this.lvwITEquipmentHistoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwITEquipmentHistoryList.FullRowSelect = true;
            this.lvwITEquipmentHistoryList.GridLines = true;
            this.lvwITEquipmentHistoryList.HideSelection = false;
            this.lvwITEquipmentHistoryList.Location = new System.Drawing.Point(6, 18);
            this.lvwITEquipmentHistoryList.MultiSelect = false;
            this.lvwITEquipmentHistoryList.Name = "lvwITEquipmentHistoryList";
            this.lvwITEquipmentHistoryList.Size = new System.Drawing.Size(770, 157);
            this.lvwITEquipmentHistoryList.TabIndex = 0;
            this.lvwITEquipmentHistoryList.UseCompatibleStateImageBehavior = false;
            this.lvwITEquipmentHistoryList.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Tran Date";
            this.colDate.Width = 100;
            // 
            // colType
            // 
            this.colType.Text = "Tran Type";
            this.colType.Width = 150;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 165;
            // 
            // colFromStore
            // 
            this.colFromStore.Text = "From Store";
            this.colFromStore.Width = 100;
            // 
            // colToStore
            // 
            this.colToStore.Text = "To Store";
            this.colToStore.Width = 100;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 255;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 255;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(25, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(58, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Asset No";
            // 
            // txtAssetNo
            // 
            this.txtAssetNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtAssetNo.Location = new System.Drawing.Point(86, 14);
            this.txtAssetNo.Name = "txtAssetNo";
            this.txtAssetNo.Size = new System.Drawing.Size(106, 20);
            this.txtAssetNo.TabIndex = 1;
            this.txtAssetNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssetNo_KeyPress);
            // 
            // cbTranType
            // 
            this.cbTranType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTranType.FormattingEnabled = true;
            this.cbTranType.Location = new System.Drawing.Point(86, 14);
            this.cbTranType.Name = "cbTranType";
            this.cbTranType.Size = new System.Drawing.Size(171, 21);
            this.cbTranType.TabIndex = 1;
            this.cbTranType.SelectedIndexChanged += new System.EventHandler(this.cbTranType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(18, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tran Type";
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.Location = new System.Drawing.Point(197, 13);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(30, 21);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "...";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Brand";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(593, 40);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(183, 20);
            this.txtBrand.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Model No";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(593, 15);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(183, 20);
            this.txtModelNo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Product No";
            // 
            // txtProductNo
            // 
            this.txtProductNo.Location = new System.Drawing.Point(359, 40);
            this.txtProductNo.Name = "txtProductNo";
            this.txtProductNo.Size = new System.Drawing.Size(173, 20);
            this.txtProductNo.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSupplier);
            this.groupBox2.Controls.Add(this.cbCurStoreName);
            this.groupBox2.Controls.Add(this.dtPurchaseDate);
            this.groupBox2.Controls.Add(this.cbCurCompany);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtAssetRemarks);
            this.groupBox2.Controls.Add(this.txtSerial);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBrand);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.txtAssetNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btSearch);
            this.groupBox2.Controls.Add(this.txtModelNo);
            this.groupBox2.Controls.Add(this.txtProductNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 124);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbSupplier
            // 
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(86, 39);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(183, 21);
            this.cbSupplier.TabIndex = 8;
            // 
            // cbCurStoreName
            // 
            this.cbCurStoreName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurStoreName.FormattingEnabled = true;
            this.cbCurStoreName.Location = new System.Drawing.Point(593, 66);
            this.cbCurStoreName.Name = "cbCurStoreName";
            this.cbCurStoreName.Size = new System.Drawing.Size(171, 21);
            this.cbCurStoreName.TabIndex = 18;
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDate.Location = new System.Drawing.Point(360, 67);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(97, 20);
            this.dtPurchaseDate.TabIndex = 16;
            // 
            // cbCurCompany
            // 
            this.cbCurCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurCompany.Location = new System.Drawing.Point(86, 66);
            this.cbCurCompany.Name = "cbCurCompany";
            this.cbCurCompany.Size = new System.Drawing.Size(173, 21);
            this.cbCurCompany.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(558, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Store";
            // 
            // txtAssetRemarks
            // 
            this.txtAssetRemarks.Location = new System.Drawing.Point(86, 92);
            this.txtAssetRemarks.Name = "txtAssetRemarks";
            this.txtAssetRemarks.Size = new System.Drawing.Size(690, 20);
            this.txtAssetRemarks.TabIndex = 20;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(359, 14);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(173, 20);
            this.txtSerial.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Serial No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(278, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Purchase Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Company";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Supplier Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Remarks";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtpTranDate);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtTranRemarks);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ctlNewEmployee);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbStoreName);
            this.groupBox1.Controls.Add(this.cbCompany);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbDepartment);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbTranType);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(7, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(535, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Tran Date";
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranDate.Location = new System.Drawing.Point(593, 13);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(97, 20);
            this.dtpTranDate.TabIndex = 5;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(296, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = "For Company";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(183, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(98, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "For Department";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(85, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "For Individual";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtTranRemarks
            // 
            this.txtTranRemarks.Location = new System.Drawing.Point(86, 121);
            this.txtTranRemarks.Name = "txtTranRemarks";
            this.txtTranRemarks.Size = new System.Drawing.Size(551, 20);
            this.txtTranRemarks.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Remarks";
            // 
            // ctlNewEmployee
            // 
            this.ctlNewEmployee.Location = new System.Drawing.Point(86, 63);
            this.ctlNewEmployee.Name = "ctlNewEmployee";
            this.ctlNewEmployee.Size = new System.Drawing.Size(454, 25);
            this.ctlNewEmployee.TabIndex = 10;
            this.ctlNewEmployee.ChangeSelection += new System.EventHandler(this.ctlNewEmployee_ChangeSelection);
            this.ctlNewEmployee.Load += new System.EventHandler(this.ctlNewEmployee_Load);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Company";
            // 
            // cbStoreName
            // 
            this.cbStoreName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStoreName.FormattingEnabled = true;
            this.cbStoreName.Location = new System.Drawing.Point(359, 14);
            this.cbStoreName.Name = "cbStoreName";
            this.cbStoreName.Size = new System.Drawing.Size(140, 21);
            this.cbStoreName.TabIndex = 3;
            // 
            // cbCompany
            // 
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.Location = new System.Drawing.Point(360, 91);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(173, 21);
            this.cbCompany.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Store Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Department";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Employee";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.Location = new System.Drawing.Point(86, 91);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(202, 21);
            this.cbDepartment.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwITEquipmentHistoryList);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(10, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(782, 183);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "History";
            // 
            // btnDeleteHistory
            // 
            this.btnDeleteHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteHistory.Location = new System.Drawing.Point(9, 477);
            this.btnDeleteHistory.Name = "btnDeleteHistory";
            this.btnDeleteHistory.Size = new System.Drawing.Size(111, 24);
            this.btnDeleteHistory.TabIndex = 20;
            this.btnDeleteHistory.Text = "Delete History";
            this.btnDeleteHistory.UseVisualStyleBackColor = true;
            this.btnDeleteHistory.Click += new System.EventHandler(this.btnDeleteHistory_Click);
            // 
            // frmITEquipmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 502);
            this.Controls.Add(this.btnDeleteHistory);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmITEquipmentHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History List";
            this.Load += new System.EventHandler(this.frmEquipmentHistoryList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwITEquipmentHistoryList;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtAssetNo;
        private System.Windows.Forms.ComboBox cbTranType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProductNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAssetRemarks;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTranRemarks;
        private System.Windows.Forms.Label label7;
        private ctlEmployee ctlNewEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbStoreName;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.ColumnHeader colFromStore;
        private System.Windows.Forms.ColumnHeader colToStore;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.ComboBox cbCurStoreName;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.ComboBox cbCurCompany;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnDeleteHistory;
    }
}