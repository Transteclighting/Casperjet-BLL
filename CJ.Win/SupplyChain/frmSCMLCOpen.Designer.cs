namespace CJ.Win.SupplyChain
{
    partial class frmSCMLCOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMLCOpen));
            this.dgvLCQty = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPIQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLCQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtLCDdate = new System.Windows.Forms.DateTimePicker();
            this.lblPINO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblExpGRDWeek = new System.Windows.Forms.Label();
            this.lblPSINo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblweek = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtLCValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHSCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreShipmentNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtPreShipment = new System.Windows.Forms.DateTimePicker();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBEILLCItem = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBEILLCItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLCQty
            // 
            this.dgvLCQty.AllowUserToAddRows = false;
            this.dgvLCQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLCQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDetails,
            this.txtPIQty,
            this.txtLCQty,
            this.TxtProductID});
            this.dgvLCQty.Location = new System.Drawing.Point(26, 185);
            this.dgvLCQty.Name = "dgvLCQty";
            this.dgvLCQty.Size = new System.Drawing.Size(626, 191);
            this.dgvLCQty.TabIndex = 29;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 80;
            // 
            // txtProductDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.ReadOnly = true;
            this.txtProductDetails.Width = 240;
            // 
            // txtPIQty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPIQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtPIQty.HeaderText = "PIQty";
            this.txtPIQty.Name = "txtPIQty";
            this.txtPIQty.ReadOnly = true;
            // 
            // txtLCQty
            // 
            this.txtLCQty.HeaderText = "LCQty";
            this.txtLCQty.Name = "txtLCQty";
            // 
            // TxtProductID
            // 
            this.TxtProductID.HeaderText = "ProductID";
            this.TxtProductID.Name = "TxtProductID";
            this.TxtProductID.ReadOnly = true;
            this.TxtProductID.Visible = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRemarks.Location = new System.Drawing.Point(23, 396);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 30;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(77, 393);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(575, 20);
            this.txtRemarks.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(496, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(577, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDate.Location = new System.Drawing.Point(63, 96);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 13);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "LC Date:";
            // 
            // dtLCDdate
            // 
            this.dtLCDdate.CustomFormat = "dd-MMM-yyyy";
            this.dtLCDdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtLCDdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLCDdate.Location = new System.Drawing.Point(118, 94);
            this.dtLCDdate.Name = "dtLCDdate";
            this.dtLCDdate.Size = new System.Drawing.Size(193, 20);
            this.dtLCDdate.TabIndex = 1;
            // 
            // lblPINO
            // 
            this.lblPINO.AutoSize = true;
            this.lblPINO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPINO.ForeColor = System.Drawing.Color.Blue;
            this.lblPINO.Location = new System.Drawing.Point(343, 41);
            this.lblPINO.Name = "lblPINO";
            this.lblPINO.Size = new System.Drawing.Size(13, 13);
            this.lblPINO.TabIndex = 27;
            this.lblPINO.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(309, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "PINo:";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSupplierName.ForeColor = System.Drawing.Color.Blue;
            this.lblSupplierName.Location = new System.Drawing.Point(102, 41);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(13, 13);
            this.lblSupplierName.TabIndex = 23;
            this.lblSupplierName.Text = "?";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Location = new System.Drawing.Point(102, 15);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 13);
            this.lblCompanyName.TabIndex = 12;
            this.lblCompanyName.Text = "?";
            // 
            // lblExpGRDWeek
            // 
            this.lblExpGRDWeek.AutoSize = true;
            this.lblExpGRDWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblExpGRDWeek.ForeColor = System.Drawing.Color.Blue;
            this.lblExpGRDWeek.Location = new System.Drawing.Point(589, 15);
            this.lblExpGRDWeek.Name = "lblExpGRDWeek";
            this.lblExpGRDWeek.Size = new System.Drawing.Size(13, 13);
            this.lblExpGRDWeek.TabIndex = 25;
            this.lblExpGRDWeek.Text = "?";
            // 
            // lblPSINo
            // 
            this.lblPSINo.AutoSize = true;
            this.lblPSINo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPSINo.ForeColor = System.Drawing.Color.Blue;
            this.lblPSINo.Location = new System.Drawing.Point(343, 15);
            this.lblPSINo.Name = "lblPSINo";
            this.lblPSINo.Size = new System.Drawing.Size(13, 13);
            this.lblPSINo.TabIndex = 16;
            this.lblPSINo.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Supplier Name:";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblweek.Location = new System.Drawing.Point(504, 15);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(84, 13);
            this.lblweek.TabIndex = 24;
            this.lblweek.Text = "Exp.GRDWeek:";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPO.Location = new System.Drawing.Point(299, 15);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(44, 13);
            this.lblPO.TabIndex = 15;
            this.lblPO.Text = "PSI No:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCompany.Location = new System.Drawing.Point(16, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(85, 13);
            this.lblCompany.TabIndex = 11;
            this.lblCompany.Text = "Company Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(70, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "LC NO:";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtLCNo.Location = new System.Drawing.Point(118, 68);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(193, 20);
            this.txtLCNo.TabIndex = 0;
            // 
            // cmbBankName
            // 
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(467, 68);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(185, 21);
            this.cmbBankName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(395, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Bank Name:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCurrency.Location = new System.Drawing.Point(408, 100);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 13);
            this.lblCurrency.TabIndex = 31;
            this.lblCurrency.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(466, 95);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(186, 21);
            this.cmbCurrency.TabIndex = 5;
            // 
            // txtLCValue
            // 
            this.txtLCValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtLCValue.Location = new System.Drawing.Point(118, 120);
            this.txtLCValue.Name = "txtLCValue";
            this.txtLCValue.Size = new System.Drawing.Size(193, 20);
            this.txtLCValue.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(59, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "LC Value:";
            // 
            // txtHSCode
            // 
            this.txtHSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtHSCode.Location = new System.Drawing.Point(466, 122);
            this.txtHSCode.Name = "txtHSCode";
            this.txtHSCode.Size = new System.Drawing.Size(186, 20);
            this.txtHSCode.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(411, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "HSCode:";
            // 
            // txtPreShipmentNo
            // 
            this.txtPreShipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPreShipmentNo.Location = new System.Drawing.Point(118, 146);
            this.txtPreShipmentNo.Name = "txtPreShipmentNo";
            this.txtPreShipmentNo.Size = new System.Drawing.Size(193, 20);
            this.txtPreShipmentNo.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(8, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "PreShipmentInspNo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.Location = new System.Drawing.Point(348, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "PreShipmentInspDate:";
            // 
            // dtPreShipment
            // 
            this.dtPreShipment.CustomFormat = "dd-MMM-yyyy";
            this.dtPreShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtPreShipment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPreShipment.Location = new System.Drawing.Point(467, 148);
            this.dtPreShipment.Name = "dtPreShipment";
            this.dtPreShipment.Size = new System.Drawing.Size(183, 20);
            this.dtPreShipment.TabIndex = 7;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblOrderNo.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderNo.Location = new System.Drawing.Point(589, 41);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(13, 13);
            this.lblOrderNo.TabIndex = 35;
            this.lblOrderNo.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(538, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "OrderNo:";
            // 
            // dgvBEILLCItem
            // 
            this.dgvBEILLCItem.AllowUserToAddRows = false;
            this.dgvBEILLCItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBEILLCItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.txtBOMItems,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.txtBOMItemID});
            this.dgvBEILLCItem.Location = new System.Drawing.Point(26, 185);
            this.dgvBEILLCItem.Name = "dgvBEILLCItem";
            this.dgvBEILLCItem.Size = new System.Drawing.Size(626, 191);
            this.dgvBEILLCItem.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Details";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // txtBOMItems
            // 
            this.txtBOMItems.HeaderText = "BOM Items";
            this.txtBOMItems.Name = "txtBOMItems";
            this.txtBOMItems.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "PIQty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "LCQty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // txtBOMItemID
            // 
            this.txtBOMItemID.HeaderText = "BOMItemID";
            this.txtBOMItemID.Name = "txtBOMItemID";
            this.txtBOMItemID.ReadOnly = true;
            this.txtBOMItemID.Visible = false;
            this.txtBOMItemID.Width = 60;
            // 
            // frmSCMLCOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 453);
            this.Controls.Add(this.dgvBEILLCItem);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtPreShipment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPreShipmentNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtHSCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtLCValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBankName);
            this.Controls.Add(this.txtLCNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLCQty);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtLCDdate);
            this.Controls.Add(this.lblPINO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblExpGRDWeek);
            this.Controls.Add(this.lblPSINo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSCMLCOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LC Open";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBEILLCItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLCQty;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtLCDdate;
        private System.Windows.Forms.Label lblPINO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblExpGRDWeek;
        private System.Windows.Forms.Label lblPSINo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblweek;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.TextBox txtLCValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHSCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPreShipmentNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtPreShipment;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPIQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLCQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtProductID;
        private System.Windows.Forms.DataGridView dgvBEILLCItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMItemID;
    }
}