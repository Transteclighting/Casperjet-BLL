namespace CJ.Win.Warranty
{
    partial class frmWarrantyParam
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdoCardPrintYes = new System.Windows.Forms.RadioButton();
            this.rdoCardPrintNo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBarcodeStoreYes = new System.Windows.Forms.RadioButton();
            this.rdoBarcodeStoreNo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudServiceWarranty = new System.Windows.Forms.NumericUpDown();
            this.nudSpareParts = new System.Windows.Forms.NumericUpDown();
            this.nudSpecialComponent = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEffectDate = new System.Windows.Forms.DateTimePicker();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SWarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPwarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCWarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWarrantyparamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSW = new System.Windows.Forms.TextBox();
            this.txtSPW = new System.Windows.Forms.TextBox();
            this.txtSCW = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServiceWarranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpareParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialComponent)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoCardPrintYes
            // 
            this.rdoCardPrintYes.AutoSize = true;
            this.rdoCardPrintYes.Location = new System.Drawing.Point(22, 17);
            this.rdoCardPrintYes.Name = "rdoCardPrintYes";
            this.rdoCardPrintYes.Size = new System.Drawing.Size(43, 17);
            this.rdoCardPrintYes.TabIndex = 0;
            this.rdoCardPrintYes.Text = "Yes";
            this.rdoCardPrintYes.UseVisualStyleBackColor = true;
            // 
            // rdoCardPrintNo
            // 
            this.rdoCardPrintNo.AutoSize = true;
            this.rdoCardPrintNo.Location = new System.Drawing.Point(113, 17);
            this.rdoCardPrintNo.Name = "rdoCardPrintNo";
            this.rdoCardPrintNo.Size = new System.Drawing.Size(39, 17);
            this.rdoCardPrintNo.TabIndex = 1;
            this.rdoCardPrintNo.Text = "No";
            this.rdoCardPrintNo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCardPrintNo);
            this.groupBox1.Controls.Add(this.rdoCardPrintYes);
            this.groupBox1.Location = new System.Drawing.Point(251, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Is Print Warranty Card?";
            // 
            // rdoBarcodeStoreYes
            // 
            this.rdoBarcodeStoreYes.AutoSize = true;
            this.rdoBarcodeStoreYes.Location = new System.Drawing.Point(17, 18);
            this.rdoBarcodeStoreYes.Name = "rdoBarcodeStoreYes";
            this.rdoBarcodeStoreYes.Size = new System.Drawing.Size(43, 17);
            this.rdoBarcodeStoreYes.TabIndex = 3;
            this.rdoBarcodeStoreYes.Text = "Yes";
            this.rdoBarcodeStoreYes.UseVisualStyleBackColor = true;
            // 
            // rdoBarcodeStoreNo
            // 
            this.rdoBarcodeStoreNo.AutoSize = true;
            this.rdoBarcodeStoreNo.Location = new System.Drawing.Point(108, 18);
            this.rdoBarcodeStoreNo.Name = "rdoBarcodeStoreNo";
            this.rdoBarcodeStoreNo.Size = new System.Drawing.Size(39, 17);
            this.rdoBarcodeStoreNo.TabIndex = 4;
            this.rdoBarcodeStoreNo.Text = "No";
            this.rdoBarcodeStoreNo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoBarcodeStoreNo);
            this.groupBox2.Controls.Add(this.rdoBarcodeStoreYes);
            this.groupBox2.Location = new System.Drawing.Point(31, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 45);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Is Store Barcode?";
            // 
            // nudServiceWarranty
            // 
            this.nudServiceWarranty.Location = new System.Drawing.Point(154, 16);
            this.nudServiceWarranty.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudServiceWarranty.Name = "nudServiceWarranty";
            this.nudServiceWarranty.Size = new System.Drawing.Size(94, 20);
            this.nudServiceWarranty.TabIndex = 6;
            // 
            // nudSpareParts
            // 
            this.nudSpareParts.Location = new System.Drawing.Point(154, 42);
            this.nudSpareParts.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudSpareParts.Name = "nudSpareParts";
            this.nudSpareParts.Size = new System.Drawing.Size(94, 20);
            this.nudSpareParts.TabIndex = 7;
            // 
            // nudSpecialComponent
            // 
            this.nudSpecialComponent.Location = new System.Drawing.Point(154, 68);
            this.nudSpecialComponent.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudSpecialComponent.Name = "nudSpecialComponent";
            this.nudSpecialComponent.Size = new System.Drawing.Size(94, 20);
            this.nudSpecialComponent.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Free Service (Month)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Spare Parts (Month)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Special Component (Month)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudSpecialComponent);
            this.groupBox3.Controls.Add(this.nudSpareParts);
            this.groupBox3.Controls.Add(this.nudServiceWarranty);
            this.groupBox3.Location = new System.Drawing.Point(12, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 97);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Warranty Parameter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Effect Date";
            // 
            // dtEffectDate
            // 
            this.dtEffectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEffectDate.Location = new System.Drawing.Point(105, 6);
            this.dtEffectDate.Name = "dtEffectDate";
            this.dtEffectDate.Size = new System.Drawing.Size(123, 20);
            this.dtEffectDate.TabIndex = 14;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSupplier,
            this.SWarranty,
            this.SPwarranty,
            this.SCWarranty,
            this.txtSupplierID,
            this.txtWarrantyparamID});
            this.dgvList.Location = new System.Drawing.Point(12, 134);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(512, 118);
            this.dgvList.TabIndex = 15;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvList_RowsRemoved);
            // 
            // txtSupplier
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSupplier.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtSupplier.Frozen = true;
            this.txtSupplier.HeaderText = "Supplier";
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Width = 199;
            // 
            // SWarranty
            // 
            this.SWarranty.HeaderText = "S.W";
            this.SWarranty.Name = "SWarranty";
            this.SWarranty.Width = 90;
            // 
            // SPwarranty
            // 
            this.SPwarranty.HeaderText = "SP.W";
            this.SPwarranty.Name = "SPwarranty";
            this.SPwarranty.Width = 90;
            // 
            // SCWarranty
            // 
            this.SCWarranty.HeaderText = "SC.W";
            this.SCWarranty.Name = "SCWarranty";
            this.SCWarranty.Width = 90;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.HeaderText = "SupplierID";
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Visible = false;
            // 
            // txtWarrantyparamID
            // 
            this.txtWarrantyparamID.HeaderText = "WarrantyparamID";
            this.txtWarrantyparamID.Name = "txtWarrantyparamID";
            this.txtWarrantyparamID.Visible = false;
            // 
            // txtSW
            // 
            this.txtSW.Location = new System.Drawing.Point(267, 258);
            this.txtSW.Name = "txtSW";
            this.txtSW.ReadOnly = true;
            this.txtSW.Size = new System.Drawing.Size(67, 20);
            this.txtSW.TabIndex = 35;
            this.txtSW.Text = "0";
            // 
            // txtSPW
            // 
            this.txtSPW.Location = new System.Drawing.Point(359, 258);
            this.txtSPW.Name = "txtSPW";
            this.txtSPW.ReadOnly = true;
            this.txtSPW.Size = new System.Drawing.Size(67, 20);
            this.txtSPW.TabIndex = 36;
            this.txtSPW.Text = "0";
            // 
            // txtSCW
            // 
            this.txtSCW.Location = new System.Drawing.Point(451, 258);
            this.txtSCW.Name = "txtSCW";
            this.txtSCW.ReadOnly = true;
            this.txtSCW.Size = new System.Drawing.Size(67, 20);
            this.txtSCW.TabIndex = 37;
            this.txtSCW.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Total";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Supplier";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 192;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "S.W";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "SP.W";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 55;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SC.W";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "CSupplierIDolumn1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(449, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmWarrantyParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 359);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSCW);
            this.Controls.Add(this.txtSPW);
            this.Controls.Add(this.txtSW);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.dtEffectDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmWarrantyParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warranty Parameter";
            this.Load += new System.EventHandler(this.frmWarrantyParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServiceWarranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpareParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpecialComponent)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoCardPrintYes;
        private System.Windows.Forms.RadioButton rdoCardPrintNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBarcodeStoreYes;
        private System.Windows.Forms.RadioButton rdoBarcodeStoreNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudServiceWarranty;
        private System.Windows.Forms.NumericUpDown nudSpareParts;
        private System.Windows.Forms.NumericUpDown nudSpecialComponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEffectDate;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtSW;
        private System.Windows.Forms.TextBox txtSPW;
        private System.Windows.Forms.TextBox txtSCW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPwarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWarrantyparamID;
    }
}