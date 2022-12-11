namespace CJ.Win.Warranty
{
    partial class frmWarrantyClaimDistribution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarrantyClaimDistribution));
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalTransportationCharge = new System.Windows.Forms.TextBox();
            this.txtTotalSPCharge = new System.Windows.Forms.TextBox();
            this.txtTotalServiceCharge = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtServiceCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaterialCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTransporttionCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOtherCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWarrantyparamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransportCharge = new System.Windows.Forms.TextBox();
            this.txtSPCharge = new System.Windows.Forms.TextBox();
            this.txtSCharge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalOtherCharge = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SC.W";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 55;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "SP.W";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 55;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "S.W";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Supplier";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 192;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total";
            // 
            // txtTotalTransportationCharge
            // 
            this.txtTotalTransportationCharge.Location = new System.Drawing.Point(445, 326);
            this.txtTotalTransportationCharge.Name = "txtTotalTransportationCharge";
            this.txtTotalTransportationCharge.ReadOnly = true;
            this.txtTotalTransportationCharge.Size = new System.Drawing.Size(80, 21);
            this.txtTotalTransportationCharge.TabIndex = 5;
            this.txtTotalTransportationCharge.Text = "0";
            // 
            // txtTotalSPCharge
            // 
            this.txtTotalSPCharge.Location = new System.Drawing.Point(354, 326);
            this.txtTotalSPCharge.Name = "txtTotalSPCharge";
            this.txtTotalSPCharge.ReadOnly = true;
            this.txtTotalSPCharge.Size = new System.Drawing.Size(80, 21);
            this.txtTotalSPCharge.TabIndex = 4;
            this.txtTotalSPCharge.Text = "0";
            // 
            // txtTotalServiceCharge
            // 
            this.txtTotalServiceCharge.Location = new System.Drawing.Point(263, 326);
            this.txtTotalServiceCharge.Name = "txtTotalServiceCharge";
            this.txtTotalServiceCharge.ReadOnly = true;
            this.txtTotalServiceCharge.Size = new System.Drawing.Size(80, 21);
            this.txtTotalServiceCharge.TabIndex = 3;
            this.txtTotalServiceCharge.Text = "0";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSupplier,
            this.txtServiceCharge,
            this.txtMaterialCharge,
            this.txtTransporttionCharge,
            this.txtOtherCharge,
            this.txtSupplierID,
            this.txtWarrantyparamID});
            this.dgvList.Location = new System.Drawing.Point(12, 159);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(621, 161);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            // 
            // txtSupplier
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSupplier.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtSupplier.Frozen = true;
            this.txtSupplier.HeaderText = "Supplier";
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Width = 199;
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.HeaderText = "Service Charge";
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.Width = 90;
            // 
            // txtMaterialCharge
            // 
            this.txtMaterialCharge.HeaderText = "Spare Parts";
            this.txtMaterialCharge.Name = "txtMaterialCharge";
            this.txtMaterialCharge.Width = 90;
            // 
            // txtTransporttionCharge
            // 
            this.txtTransporttionCharge.HeaderText = "Transportation Charge";
            this.txtTransporttionCharge.Name = "txtTransporttionCharge";
            this.txtTransporttionCharge.Width = 90;
            // 
            // txtOtherCharge
            // 
            this.txtOtherCharge.HeaderText = "OtherCharge";
            this.txtOtherCharge.Name = "txtOtherCharge";
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
            this.txtWarrantyparamID.HeaderText = "WarrantyClaimDistID";
            this.txtWarrantyparamID.Name = "txtWarrantyparamID";
            this.txtWarrantyparamID.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOCharge);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtTransportCharge);
            this.groupBox3.Controls.Add(this.txtSPCharge);
            this.groupBox3.Controls.Add(this.txtSCharge);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 141);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Warranty Claim Distribution";
            // 
            // txtOCharge
            // 
            this.txtOCharge.Location = new System.Drawing.Point(151, 104);
            this.txtOCharge.Name = "txtOCharge";
            this.txtOCharge.ReadOnly = true;
            this.txtOCharge.Size = new System.Drawing.Size(120, 21);
            this.txtOCharge.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Other Charge";
            // 
            // txtTransportCharge
            // 
            this.txtTransportCharge.Location = new System.Drawing.Point(151, 77);
            this.txtTransportCharge.Name = "txtTransportCharge";
            this.txtTransportCharge.ReadOnly = true;
            this.txtTransportCharge.Size = new System.Drawing.Size(120, 21);
            this.txtTransportCharge.TabIndex = 5;
            // 
            // txtSPCharge
            // 
            this.txtSPCharge.Location = new System.Drawing.Point(151, 50);
            this.txtSPCharge.Name = "txtSPCharge";
            this.txtSPCharge.ReadOnly = true;
            this.txtSPCharge.Size = new System.Drawing.Size(120, 21);
            this.txtSPCharge.TabIndex = 3;
            // 
            // txtSCharge
            // 
            this.txtSCharge.Location = new System.Drawing.Point(151, 23);
            this.txtSCharge.Name = "txtSCharge";
            this.txtSCharge.ReadOnly = true;
            this.txtSCharge.Size = new System.Drawing.Size(120, 21);
            this.txtSCharge.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transportation Charge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Spare Parts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Charge";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "CSupplierIDolumn1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(542, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(445, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalOtherCharge
            // 
            this.txtTotalOtherCharge.Location = new System.Drawing.Point(536, 326);
            this.txtTotalOtherCharge.Name = "txtTotalOtherCharge";
            this.txtTotalOtherCharge.ReadOnly = true;
            this.txtTotalOtherCharge.Size = new System.Drawing.Size(80, 21);
            this.txtTotalOtherCharge.TabIndex = 6;
            this.txtTotalOtherCharge.Text = "0";
            // 
            // frmWarrantyClaimDistribution
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 398);
            this.Controls.Add(this.txtTotalOtherCharge);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalTransportationCharge);
            this.Controls.Add(this.txtTotalSPCharge);
            this.Controls.Add(this.txtTotalServiceCharge);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWarrantyClaimDistribution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Delivery Job";
            this.Load += new System.EventHandler(this.frmWarrantyClaimDistribution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalTransportationCharge;
        private System.Windows.Forms.TextBox txtTotalSPCharge;
        private System.Windows.Forms.TextBox txtTotalServiceCharge;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtServiceCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMaterialCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTransporttionCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOtherCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWarrantyparamID;
        private System.Windows.Forms.TextBox txtOCharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTransportCharge;
        private System.Windows.Forms.TextBox txtSPCharge;
        private System.Windows.Forms.TextBox txtSCharge;
        private System.Windows.Forms.TextBox txtTotalOtherCharge;
    }
}