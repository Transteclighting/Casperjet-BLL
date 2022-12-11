namespace CJ.Win.Distribution
{
    partial class frmDutyVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDutyVehicle));
            this.lblShipmentDate = new System.Windows.Forms.Label();
            this.dtShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.dgvDutyVehicle = new System.Windows.Forms.DataGridView();
            this.txtType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDutyTranNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDutyTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDutyTranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromWHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToWHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDriverMobileNo = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeliveryMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbParcelType = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGatePassNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCapacity = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutyVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShipmentDate
            // 
            this.lblShipmentDate.AutoSize = true;
            this.lblShipmentDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentDate.Location = new System.Drawing.Point(11, 15);
            this.lblShipmentDate.Name = "lblShipmentDate";
            this.lblShipmentDate.Size = new System.Drawing.Size(95, 15);
            this.lblShipmentDate.TabIndex = 0;
            this.lblShipmentDate.Text = "Shipment Date";
            // 
            // dtShipmentDate
            // 
            this.dtShipmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtShipmentDate.Enabled = false;
            this.dtShipmentDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShipmentDate.Location = new System.Drawing.Point(110, 12);
            this.dtShipmentDate.Name = "dtShipmentDate";
            this.dtShipmentDate.Size = new System.Drawing.Size(217, 23);
            this.dtShipmentDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vehicle Vendor";
            // 
            // cmbVendor
            // 
            this.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendor.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(110, 104);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(217, 23);
            this.cmbVendor.TabIndex = 7;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(333, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 15);
            this.label12.TabIndex = 10;
            this.label12.Text = "Vehicle Number";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(437, 12);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(365, 23);
            this.cmbVehicle.TabIndex = 9;
            this.cmbVehicle.SelectedIndexChanged += new System.EventHandler(this.cmbVehicle_SelectedIndexChanged);
            // 
            // dgvDutyVehicle
            // 
            this.dgvDutyVehicle.AllowUserToAddRows = false;
            this.dgvDutyVehicle.AllowUserToDeleteRows = false;
            this.dgvDutyVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDutyVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtType,
            this.txtTranNo,
            this.txtTranDate,
            this.txtDutyTranNo,
            this.txtDutyTranDate,
            this.txtFromWH,
            this.txtToWH,
            this.txtTranID,
            this.txtDutyTranID,
            this.txtFromWHID,
            this.txtToWHID});
            this.dgvDutyVehicle.Location = new System.Drawing.Point(13, 133);
            this.dgvDutyVehicle.Name = "dgvDutyVehicle";
            this.dgvDutyVehicle.Size = new System.Drawing.Size(791, 303);
            this.dgvDutyVehicle.TabIndex = 18;
            // 
            // txtType
            // 
            this.txtType.HeaderText = "Type";
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Width = 70;
            // 
            // txtTranNo
            // 
            this.txtTranNo.HeaderText = "Tran#";
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.ReadOnly = true;
            // 
            // txtTranDate
            // 
            this.txtTranDate.HeaderText = "Tran Date ";
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.ReadOnly = true;
            this.txtTranDate.Width = 90;
            // 
            // txtDutyTranNo
            // 
            this.txtDutyTranNo.HeaderText = "Duty Tran #";
            this.txtDutyTranNo.Name = "txtDutyTranNo";
            this.txtDutyTranNo.ReadOnly = true;
            this.txtDutyTranNo.Width = 105;
            // 
            // txtDutyTranDate
            // 
            this.txtDutyTranDate.HeaderText = "Duty Tran Date";
            this.txtDutyTranDate.Name = "txtDutyTranDate";
            this.txtDutyTranDate.ReadOnly = true;
            this.txtDutyTranDate.Width = 120;
            // 
            // txtFromWH
            // 
            this.txtFromWH.HeaderText = "From WH";
            this.txtFromWH.Name = "txtFromWH";
            this.txtFromWH.ReadOnly = true;
            this.txtFromWH.Width = 130;
            // 
            // txtToWH
            // 
            this.txtToWH.HeaderText = "To WH";
            this.txtToWH.Name = "txtToWH";
            this.txtToWH.ReadOnly = true;
            this.txtToWH.Width = 130;
            // 
            // txtTranID
            // 
            this.txtTranID.HeaderText = "TranID";
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.ReadOnly = true;
            this.txtTranID.Visible = false;
            // 
            // txtDutyTranID
            // 
            this.txtDutyTranID.HeaderText = "Duty TranID";
            this.txtDutyTranID.Name = "txtDutyTranID";
            this.txtDutyTranID.ReadOnly = true;
            this.txtDutyTranID.Visible = false;
            // 
            // txtFromWHID
            // 
            this.txtFromWHID.HeaderText = "FromWHID";
            this.txtFromWHID.Name = "txtFromWHID";
            this.txtFromWHID.ReadOnly = true;
            this.txtFromWHID.Visible = false;
            // 
            // txtToWHID
            // 
            this.txtToWHID.HeaderText = "ToWHID";
            this.txtToWHID.Name = "txtToWHID";
            this.txtToWHID.ReadOnly = true;
            this.txtToWHID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(706, 442);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 30);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(600, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVehicle
            // 
            this.txtVehicle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicle.Location = new System.Drawing.Point(437, 42);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(365, 23);
            this.txtVehicle.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vehicle";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverName.Location = new System.Drawing.Point(437, 98);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(155, 23);
            this.txtDriverName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(353, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Driver Name";
            // 
            // txtDriverMobileNo
            // 
            this.txtDriverMobileNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverMobileNo.Location = new System.Drawing.Point(647, 98);
            this.txtDriverMobileNo.Name = "txtDriverMobileNo";
            this.txtDriverMobileNo.Size = new System.Drawing.Size(155, 23);
            this.txtDriverMobileNo.TabIndex = 17;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(596, 102);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(48, 15);
            this.txt.TabIndex = 16;
            this.txt.Text = "Mobile";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Delivery Mode";
            // 
            // cmbDeliveryMode
            // 
            this.cmbDeliveryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeliveryMode.FormattingEnabled = true;
            this.cmbDeliveryMode.Location = new System.Drawing.Point(110, 42);
            this.cmbDeliveryMode.Name = "cmbDeliveryMode";
            this.cmbDeliveryMode.Size = new System.Drawing.Size(217, 23);
            this.cmbDeliveryMode.TabIndex = 3;
            this.cmbDeliveryMode.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveryMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Parcel Type";
            // 
            // cmbParcelType
            // 
            this.cmbParcelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParcelType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParcelType.FormattingEnabled = true;
            this.cmbParcelType.Location = new System.Drawing.Point(110, 73);
            this.cmbParcelType.Name = "cmbParcelType";
            this.cmbParcelType.Size = new System.Drawing.Size(217, 23);
            this.cmbParcelType.TabIndex = 5;
            this.cmbParcelType.SelectedIndexChanged += new System.EventHandler(this.cmbParcelType_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tran No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tran Date ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 85;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Duty Tran No";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 105;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Duty TranDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "From WH";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "To WH";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 130;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "TranID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Duty TranID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "FromWHID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "ToWHID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // lblGatePassNo
            // 
            this.lblGatePassNo.AutoSize = true;
            this.lblGatePassNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblGatePassNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGatePassNo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblGatePassNo.Location = new System.Drawing.Point(11, 450);
            this.lblGatePassNo.Name = "lblGatePassNo";
            this.lblGatePassNo.Size = new System.Drawing.Size(17, 20);
            this.lblGatePassNo.TabIndex = 19;
            this.lblGatePassNo.Text = "?";
            this.lblGatePassNo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(331, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vehicle Capacity";
            // 
            // cmbCapacity
            // 
            this.cmbCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapacity.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapacity.FormattingEnabled = true;
            this.cmbCapacity.Location = new System.Drawing.Point(437, 71);
            this.cmbCapacity.Name = "cmbCapacity";
            this.cmbCapacity.Size = new System.Drawing.Size(365, 23);
            this.cmbCapacity.TabIndex = 13;
            // 
            // frmDutyVehicle
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 480);
            this.Controls.Add(this.cmbCapacity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblGatePassNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbParcelType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeliveryMode);
            this.Controls.Add(this.txtDriverMobileNo);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDutyVehicle);
            this.Controls.Add(this.lblShipmentDate);
            this.Controls.Add(this.dtShipmentDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVendor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbVehicle);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDutyVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duty Vehicle";
            this.Load += new System.EventHandler(this.frmDutyVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDutyVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShipmentDate;
        private System.Windows.Forms.DateTimePicker dtShipmentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.DataGridView dgvDutyVehicle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDriverMobileNo;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeliveryMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbParcelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToWHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromWHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDutyTranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDutyTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDutyTranNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtType;
        private System.Windows.Forms.Label lblGatePassNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCapacity;
    }
}