namespace CJ.Win.CSD
{
    partial class frmCustomerSatisfactions
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwCustSatisfaction = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeliveryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsHappyCall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCallStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbIsHappyCall = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCallStatus = new System.Windows.Forms.ComboBox();
            this.linklblMultiSelectBrands = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "JobNo";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(98, 55);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(180, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(899, 164);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwCustSatisfaction
            // 
            this.lvwCustSatisfaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustSatisfaction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colJobCreationDate,
            this.colDeliveryDate,
            this.colCustomerName,
            this.colMobile,
            this.colProductName,
            this.colBrand,
            this.colSerialNo,
            this.colJobType,
            this.colServiceType,
            this.colIsHappyCall,
            this.colCallStatus});
            this.lvwCustSatisfaction.FullRowSelect = true;
            this.lvwCustSatisfaction.GridLines = true;
            this.lvwCustSatisfaction.HideSelection = false;
            this.lvwCustSatisfaction.Location = new System.Drawing.Point(12, 164);
            this.lvwCustSatisfaction.MultiSelect = false;
            this.lvwCustSatisfaction.Name = "lvwCustSatisfaction";
            this.lvwCustSatisfaction.Size = new System.Drawing.Size(881, 368);
            this.lvwCustSatisfaction.TabIndex = 146;
            this.lvwCustSatisfaction.UseCompatibleStateImageBehavior = false;
            this.lvwCustSatisfaction.View = System.Windows.Forms.View.Details;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "JobNo";
            this.colJobNo.Width = 95;
            // 
            // colJobCreationDate
            // 
            this.colJobCreationDate.Text = "JobCreationDate";
            this.colJobCreationDate.Width = 103;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.Text = "DeliveryDate";
            this.colDeliveryDate.Width = 97;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "CustomerName";
            this.colCustomerName.Width = 123;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Mobile";
            this.colMobile.Width = 94;
            // 
            // colProductName
            // 
            this.colProductName.Text = "ProductName";
            this.colProductName.Width = 200;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 100;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "SerialNo";
            this.colSerialNo.Width = 103;
            // 
            // colJobType
            // 
            this.colJobType.Text = "JobType";
            this.colJobType.Width = 104;
            // 
            // colServiceType
            // 
            this.colServiceType.Text = "ServiceType";
            this.colServiceType.Width = 123;
            // 
            // colIsHappyCall
            // 
            this.colIsHappyCall.Text = "IsHappyCall";
            this.colIsHappyCall.Width = 72;
            // 
            // colCallStatus
            // 
            this.colCallStatus.Text = "Call Status";
            this.colCallStatus.Width = 100;
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(98, 81);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(401, 20);
            this.txtCustName.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 147;
            this.label4.Text = "Customer Name:";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(348, 55);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(151, 20);
            this.txtMobile.TabIndex = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "Mobile No:";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(348, 107);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(151, 20);
            this.txtSL.TabIndex = 154;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 153;
            this.label6.Text = "Serial No:";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(98, 107);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(185, 20);
            this.txtProduct.TabIndex = 152;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 151;
            this.label7.Text = "Product Name:";
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(589, 80);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(150, 21);
            this.cmbJobType.TabIndex = 163;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(529, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 164;
            this.label8.Text = "Job Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(510, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 166;
            this.label9.Text = "Service Type:";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(589, 110);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(150, 21);
            this.cmbServiceType.TabIndex = 165;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 168;
            this.label10.Text = "Is HappyCall:";
            // 
            // cmbIsHappyCall
            // 
            this.cmbIsHappyCall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsHappyCall.FormattingEnabled = true;
            this.cmbIsHappyCall.Location = new System.Drawing.Point(590, 52);
            this.cmbIsHappyCall.Name = "cmbIsHappyCall";
            this.cmbIsHappyCall.Size = new System.Drawing.Size(150, 21);
            this.cmbIsHappyCall.TabIndex = 167;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(899, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 170;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(818, 134);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 24);
            this.btnGetData.TabIndex = 172;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Location = new System.Drawing.Point(98, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 44);
            this.groupBox2.TabIndex = 173;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "To Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "From Date:";
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(256, 19);
            this.dtTodate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(99, 20);
            this.dtTodate.TabIndex = 8;
            this.dtTodate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(70, 19);
            this.dtFromdate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(95, 20);
            this.dtFromdate.TabIndex = 7;
            this.dtFromdate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(19, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(524, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 175;
            this.label11.Text = "Call Status:";
            // 
            // cmbCallStatus
            // 
            this.cmbCallStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallStatus.FormattingEnabled = true;
            this.cmbCallStatus.Location = new System.Drawing.Point(590, 137);
            this.cmbCallStatus.Name = "cmbCallStatus";
            this.cmbCallStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbCallStatus.TabIndex = 174;
            // 
            // linklblMultiSelectBrands
            // 
            this.linklblMultiSelectBrands.AutoSize = true;
            this.linklblMultiSelectBrands.Location = new System.Drawing.Point(254, 137);
            this.linklblMultiSelectBrands.Name = "linklblMultiSelectBrands";
            this.linklblMultiSelectBrands.Size = new System.Drawing.Size(98, 13);
            this.linklblMultiSelectBrands.TabIndex = 176;
            this.linklblMultiSelectBrands.TabStop = true;
            this.linklblMultiSelectBrands.Text = "Multi Select Brands";
            this.linklblMultiSelectBrands.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblMultiSelectBrands_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 178;
            this.label12.Text = "Brand:";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(98, 133);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 21);
            this.cmbBrand.TabIndex = 177;
            // 
            // frmCustomerSatisfactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 549);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.linklblMultiSelectBrands);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbCallStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbIsHappyCall);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbJobType);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvwCustSatisfaction);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomerSatisfactions";
            this.Text = "frmCustomerSatisfactions";
            this.Load += new System.EventHandler(this.frmCustomerSatisfactions_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwCustSatisfaction;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colJobCreationDate;
        private System.Windows.Forms.ColumnHeader colDeliveryDate;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colServiceType;
        private System.Windows.Forms.ColumnHeader colIsHappyCall;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIsHappyCall;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCallStatus;
        private System.Windows.Forms.ColumnHeader colCallStatus;
        private System.Windows.Forms.LinkLabel linklblMultiSelectBrands;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBrand;
    }
}