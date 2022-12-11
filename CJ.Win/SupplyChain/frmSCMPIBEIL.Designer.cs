namespace CJ.Win.SupplyChain
{
    partial class frmSCMPIBEIL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMPIBEIL));
            this.lblODate = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPIQty = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFindBOM = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TxtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblExpGRDWeek = new System.Windows.Forms.Label();
            this.lblPSINo = new System.Windows.Forms.Label();
            this.lblPINo = new System.Windows.Forms.Label();
            this.txtPINO = new System.Windows.Forms.TextBox();
            this.lblOPlaceDate = new System.Windows.Forms.Label();
            this.dtPIReceivedate = new System.Windows.Forms.DateTimePicker();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblweek = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPIValue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbPICurrency = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblODate
            // 
            this.lblODate.AutoSize = true;
            this.lblODate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblODate.ForeColor = System.Drawing.Color.Black;
            this.lblODate.Location = new System.Drawing.Point(525, 63);
            this.lblODate.Name = "lblODate";
            this.lblODate.Size = new System.Drawing.Size(100, 15);
            this.lblODate.TabIndex = 10;
            this.lblODate.Text = "OrderPlaceDate:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblOrderDate.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderDate.Location = new System.Drawing.Point(625, 63);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(13, 15);
            this.lblOrderDate.TabIndex = 11;
            this.lblOrderDate.Text = "?";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblOrderNo.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderNo.Location = new System.Drawing.Point(625, 35);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(13, 15);
            this.lblOrderNo.TabIndex = 7;
            this.lblOrderNo.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(567, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "OrderNo:";
            // 
            // dgvPIQty
            // 
            this.dgvPIQty.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPIQty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPIQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPIQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDetails,
            this.txtOrderQty,
            this.txtBOMList,
            this.txtFindBOM,
            this.TxtProductID});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPIQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPIQty.GridColor = System.Drawing.Color.Black;
            this.dgvPIQty.Location = new System.Drawing.Point(17, 150);
            this.dgvPIQty.Name = "dgvPIQty";
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvPIQty.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPIQty.Size = new System.Drawing.Size(822, 230);
            this.dgvPIQty.TabIndex = 20;
            this.dgvPIQty.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPIQty_CellContentClick);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 80;
            // 
            // txtProductDetails
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.ReadOnly = true;
            this.txtProductDetails.Width = 240;
            // 
            // txtOrderQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrderQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtOrderQty.HeaderText = "Order Qty";
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.txtOrderQty.Width = 60;
            // 
            // txtBOMList
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.txtBOMList.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtBOMList.HeaderText = "BOM List";
            this.txtBOMList.Name = "txtBOMList";
            this.txtBOMList.Width = 250;
            // 
            // txtFindBOM
            // 
            this.txtFindBOM.HeaderText = ".....";
            this.txtFindBOM.Name = "txtFindBOM";
            this.txtFindBOM.Width = 35;
            // 
            // TxtProductID
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtProductID.DefaultCellStyle = dataGridViewCellStyle6;
            this.TxtProductID.HeaderText = "ProductID";
            this.TxtProductID.Name = "TxtProductID";
            this.TxtProductID.ReadOnly = true;
            this.TxtProductID.Visible = false;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblSupplierName.ForeColor = System.Drawing.Color.Blue;
            this.lblSupplierName.Location = new System.Drawing.Point(121, 35);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(13, 15);
            this.lblSupplierName.TabIndex = 5;
            this.lblSupplierName.Text = "?";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Location = new System.Drawing.Point(121, 10);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 15);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "?";
            // 
            // lblExpGRDWeek
            // 
            this.lblExpGRDWeek.AutoSize = true;
            this.lblExpGRDWeek.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblExpGRDWeek.ForeColor = System.Drawing.Color.Blue;
            this.lblExpGRDWeek.Location = new System.Drawing.Point(121, 63);
            this.lblExpGRDWeek.Name = "lblExpGRDWeek";
            this.lblExpGRDWeek.Size = new System.Drawing.Size(13, 15);
            this.lblExpGRDWeek.TabIndex = 9;
            this.lblExpGRDWeek.Text = "?";
            // 
            // lblPSINo
            // 
            this.lblPSINo.AutoSize = true;
            this.lblPSINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblPSINo.ForeColor = System.Drawing.Color.Blue;
            this.lblPSINo.Location = new System.Drawing.Point(625, 10);
            this.lblPSINo.Name = "lblPSINo";
            this.lblPSINo.Size = new System.Drawing.Size(13, 15);
            this.lblPSINo.TabIndex = 3;
            this.lblPSINo.Text = "?";
            // 
            // lblPINo
            // 
            this.lblPINo.AutoSize = true;
            this.lblPINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblPINo.ForeColor = System.Drawing.Color.Black;
            this.lblPINo.Location = new System.Drawing.Point(92, 95);
            this.lblPINo.Name = "lblPINo";
            this.lblPINo.Size = new System.Drawing.Size(25, 15);
            this.lblPINo.TabIndex = 12;
            this.lblPINo.Text = "PI#";
            // 
            // txtPINO
            // 
            this.txtPINO.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPINO.ForeColor = System.Drawing.Color.Black;
            this.txtPINO.Location = new System.Drawing.Point(124, 92);
            this.txtPINO.Name = "txtPINO";
            this.txtPINO.Size = new System.Drawing.Size(228, 23);
            this.txtPINO.TabIndex = 13;
            // 
            // lblOPlaceDate
            // 
            this.lblOPlaceDate.AutoSize = true;
            this.lblOPlaceDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblOPlaceDate.ForeColor = System.Drawing.Color.Black;
            this.lblOPlaceDate.Location = new System.Drawing.Point(525, 94);
            this.lblOPlaceDate.Name = "lblOPlaceDate";
            this.lblOPlaceDate.Size = new System.Drawing.Size(91, 15);
            this.lblOPlaceDate.TabIndex = 14;
            this.lblOPlaceDate.Text = "PI ReceiveDate";
            // 
            // dtPIReceivedate
            // 
            this.dtPIReceivedate.CustomFormat = "dd-MMM-yyyy";
            this.dtPIReceivedate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtPIReceivedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPIReceivedate.Location = new System.Drawing.Point(628, 92);
            this.dtPIReceivedate.Name = "dtPIReceivedate";
            this.dtPIReceivedate.Size = new System.Drawing.Size(192, 23);
            this.dtPIReceivedate.TabIndex = 15;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblRemarks.ForeColor = System.Drawing.Color.Black;
            this.lblRemarks.Location = new System.Drawing.Point(12, 392);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(55, 15);
            this.lblRemarks.TabIndex = 21;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtRemarks.ForeColor = System.Drawing.Color.Black;
            this.txtRemarks.Location = new System.Drawing.Point(76, 389);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(763, 23);
            this.txtRemarks.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(658, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(752, 422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Supplier Name:";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblweek.ForeColor = System.Drawing.Color.Black;
            this.lblweek.Location = new System.Drawing.Point(25, 63);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(92, 15);
            this.lblweek.TabIndex = 8;
            this.lblweek.Text = "Exp.GRDWeek:";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblPO.ForeColor = System.Drawing.Color.Black;
            this.lblPO.Location = new System.Drawing.Point(574, 10);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(48, 15);
            this.lblPO.TabIndex = 2;
            this.lblPO.Text = "PSI No:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCompany.ForeColor = System.Drawing.Color.Black;
            this.lblCompany.Location = new System.Drawing.Point(13, 10);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(103, 15);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company Name:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Details";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "Order Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "BOM List";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // txtPIValue
            // 
            this.txtPIValue.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPIValue.Location = new System.Drawing.Point(124, 121);
            this.txtPIValue.Name = "txtPIValue";
            this.txtPIValue.Size = new System.Drawing.Size(228, 23);
            this.txtPIValue.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(63, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "PI Value:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCurrency.Location = new System.Drawing.Point(563, 124);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(59, 15);
            this.lblCurrency.TabIndex = 18;
            this.lblCurrency.Text = "Currency:";
            // 
            // cmbPICurrency
            // 
            this.cmbPICurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPICurrency.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbPICurrency.FormattingEnabled = true;
            this.cmbPICurrency.Location = new System.Drawing.Point(628, 121);
            this.cmbPICurrency.Name = "cmbPICurrency";
            this.cmbPICurrency.Size = new System.Drawing.Size(195, 23);
            this.cmbPICurrency.TabIndex = 19;
            // 
            // frmSCMPIBEIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 458);
            this.Controls.Add(this.txtPIValue);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbPICurrency);
            this.Controls.Add(this.lblODate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPIQty);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblExpGRDWeek);
            this.Controls.Add(this.lblPSINo);
            this.Controls.Add(this.lblPINo);
            this.Controls.Add(this.txtPINO);
            this.Controls.Add(this.lblOPlaceDate);
            this.Controls.Add(this.dtPIReceivedate);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.lblCompany);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSCMPIBEIL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PI (BEIL)";
            this.Load += new System.EventHandler(this.frmSCMPIBEIL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblODate;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPIQty;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblExpGRDWeek;
        private System.Windows.Forms.Label lblPSINo;
        private System.Windows.Forms.Label lblPINo;
        private System.Windows.Forms.TextBox txtPINO;
        private System.Windows.Forms.Label lblOPlaceDate;
        private System.Windows.Forms.DateTimePicker dtPIReceivedate;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblweek;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMList;
        private System.Windows.Forms.DataGridViewButtonColumn txtFindBOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtProductID;
        private System.Windows.Forms.TextBox txtPIValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbPICurrency;
    }
}