namespace CJ.Win.CSD.Store
{
    partial class FrmSparePartsOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.colSpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colForecastQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpCode = new System.Windows.Forms.TextBox();
            this.txtSpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.gbProcess = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMag = new System.Windows.Forms.ComboBox();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.gbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(643, 55);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(89, 27);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSpID,
            this.colSpCode,
            this.colSpName,
            this.colCP,
            this.colRSP,
            this.colConsumption,
            this.colStock,
            this.colReorderLevel,
            this.colForecastQty,
            this.colFinalOrder});
            this.dgvOrder.Location = new System.Drawing.Point(12, 153);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.Size = new System.Drawing.Size(909, 273);
            this.dgvOrder.TabIndex = 9;
            // 
            // colSpID
            // 
            this.colSpID.HeaderText = "SP ID";
            this.colSpID.Name = "colSpID";
            this.colSpID.Visible = false;
            // 
            // colSpCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.colSpCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSpCode.HeaderText = "SP Code";
            this.colSpCode.Name = "colSpCode";
            this.colSpCode.ReadOnly = true;
            this.colSpCode.Width = 90;
            // 
            // colSpName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.colSpName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSpName.HeaderText = "SP Name";
            this.colSpName.Name = "colSpName";
            this.colSpName.ReadOnly = true;
            this.colSpName.Width = 250;
            // 
            // colCP
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.colCP.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCP.HeaderText = "CP";
            this.colCP.Name = "colCP";
            this.colCP.ReadOnly = true;
            this.colCP.Width = 50;
            // 
            // colRSP
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.colRSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRSP.HeaderText = "RSP";
            this.colRSP.Name = "colRSP";
            this.colRSP.ReadOnly = true;
            this.colRSP.Width = 50;
            // 
            // colConsumption
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.colConsumption.DefaultCellStyle = dataGridViewCellStyle5;
            this.colConsumption.HeaderText = "Consumption";
            this.colConsumption.Name = "colConsumption";
            this.colConsumption.ReadOnly = true;
            this.colConsumption.Width = 80;
            // 
            // colStock
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.colStock.DefaultCellStyle = dataGridViewCellStyle6;
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.Width = 50;
            // 
            // colReorderLevel
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.colReorderLevel.DefaultCellStyle = dataGridViewCellStyle7;
            this.colReorderLevel.HeaderText = "Reorder Level";
            this.colReorderLevel.Name = "colReorderLevel";
            this.colReorderLevel.ReadOnly = true;
            // 
            // colForecastQty
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            this.colForecastQty.DefaultCellStyle = dataGridViewCellStyle8;
            this.colForecastQty.HeaderText = "Forecast Qty";
            this.colForecastQty.Name = "colForecastQty";
            this.colForecastQty.Width = 90;
            // 
            // colFinalOrder
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colFinalOrder.DefaultCellStyle = dataGridViewCellStyle9;
            this.colFinalOrder.HeaderText = "Final Order";
            this.colFinalOrder.Name = "colFinalOrder";
            this.colFinalOrder.Width = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SP Code";
            // 
            // txtSpCode
            // 
            this.txtSpCode.Location = new System.Drawing.Point(68, 57);
            this.txtSpCode.Name = "txtSpCode";
            this.txtSpCode.Size = new System.Drawing.Size(160, 20);
            this.txtSpCode.TabIndex = 5;
            // 
            // txtSpName
            // 
            this.txtSpName.Location = new System.Drawing.Point(280, 57);
            this.txtSpName.Name = "txtSpName";
            this.txtSpName.Size = new System.Drawing.Size(137, 20);
            this.txtSpName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "SP Name";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(840, 458);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 28);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(755, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(463, 25);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(160, 21);
            this.cmbBrand.TabIndex = 13;
            // 
            // gbProcess
            // 
            this.gbProcess.Controls.Add(this.label9);
            this.gbProcess.Controls.Add(this.label8);
            this.gbProcess.Controls.Add(this.cmbMag);
            this.gbProcess.Controls.Add(this.cmbPG);
            this.gbProcess.Controls.Add(this.dtToDate);
            this.gbProcess.Controls.Add(this.label7);
            this.gbProcess.Controls.Add(this.dtFromDate);
            this.gbProcess.Controls.Add(this.label2);
            this.gbProcess.Controls.Add(this.txtDescription);
            this.gbProcess.Controls.Add(this.label1);
            this.gbProcess.Controls.Add(this.label5);
            this.gbProcess.Controls.Add(this.cmbBrand);
            this.gbProcess.Controls.Add(this.btnProcess);
            this.gbProcess.Controls.Add(this.txtSpName);
            this.gbProcess.Controls.Add(this.label3);
            this.gbProcess.Controls.Add(this.label4);
            this.gbProcess.Controls.Add(this.txtSpCode);
            this.gbProcess.Location = new System.Drawing.Point(12, 12);
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.Size = new System.Drawing.Size(742, 135);
            this.gbProcess.TabIndex = 14;
            this.gbProcess.TabStop = false;
            this.gbProcess.Text = "Process";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "MAG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "PG";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cmbMag
            // 
            this.cmbMag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMag.FormattingEnabled = true;
            this.cmbMag.Location = new System.Drawing.Point(463, 87);
            this.cmbMag.Name = "cmbMag";
            this.cmbMag.Size = new System.Drawing.Size(160, 21);
            this.cmbMag.TabIndex = 18;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(463, 57);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(160, 21);
            this.cmbPG.TabIndex = 17;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(280, 26);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(137, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Description";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(68, 26);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(160, 20);
            this.dtFromDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(69, 87);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(349, 20);
            this.txtDescription.TabIndex = 15;
            this.txtDescription.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(65, 432);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(856, 20);
            this.txtRemarks.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SP ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "SP Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "SP Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "CP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "RSP";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn6.HeaderText = "Reorder Level";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn7.HeaderText = "Consumption";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn8.HeaderText = "Stock";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn9.HeaderText = "Forecast Qty";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn10.HeaderText = "Final Order";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 95;
            // 
            // FrmSparePartsOrder
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 496);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gbProcess);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvOrder);
            this.Name = "FrmSparePartsOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Parts Order";
            this.Load += new System.EventHandler(this.FrmSparePartsOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.gbProcess.ResumeLayout(false);
            this.gbProcess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpCode;
        private System.Windows.Forms.TextBox txtSpName;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.GroupBox gbProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsumption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorderLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForecastQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalOrder;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMag;
        private System.Windows.Forms.ComboBox cmbPG;
    }
}