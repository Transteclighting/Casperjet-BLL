namespace CJ.Win.SupplyChain
{
    partial class frmNonLC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonLC));
            this.dgvNONLCQty = new System.Windows.Forms.DataGridView();
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
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbOrderNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBomList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPIQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLCQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNONLCQty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNONLCQty
            // 
            this.dgvNONLCQty.AllowUserToAddRows = false;
            this.dgvNONLCQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNONLCQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDetails,
            this.txtBomList,
            this.txtPIQty,
            this.txtLCQty,
            this.TxtProductID,
            this.txtBomID});
            this.dgvNONLCQty.Location = new System.Drawing.Point(12, 89);
            this.dgvNONLCQty.Name = "dgvNONLCQty";
            this.dgvNONLCQty.Size = new System.Drawing.Size(597, 167);
            this.dgvNONLCQty.TabIndex = 0;
            // 
            // lblPINO
            // 
            this.lblPINO.AutoSize = true;
            this.lblPINO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPINO.ForeColor = System.Drawing.Color.Blue;
            this.lblPINO.Location = new System.Drawing.Point(94, 61);
            this.lblPINO.Name = "lblPINO";
            this.lblPINO.Size = new System.Drawing.Size(13, 13);
            this.lblPINO.TabIndex = 42;
            this.lblPINO.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(54, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "PINo:";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSupplierName.ForeColor = System.Drawing.Color.Blue;
            this.lblSupplierName.Location = new System.Drawing.Point(465, 9);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(13, 13);
            this.lblSupplierName.TabIndex = 38;
            this.lblSupplierName.Text = "?";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Location = new System.Drawing.Point(94, 9);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 13);
            this.lblCompanyName.TabIndex = 32;
            this.lblCompanyName.Text = "?";
            // 
            // lblExpGRDWeek
            // 
            this.lblExpGRDWeek.AutoSize = true;
            this.lblExpGRDWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblExpGRDWeek.ForeColor = System.Drawing.Color.Blue;
            this.lblExpGRDWeek.Location = new System.Drawing.Point(465, 35);
            this.lblExpGRDWeek.Name = "lblExpGRDWeek";
            this.lblExpGRDWeek.Size = new System.Drawing.Size(13, 13);
            this.lblExpGRDWeek.TabIndex = 40;
            this.lblExpGRDWeek.Text = "?";
            // 
            // lblPSINo
            // 
            this.lblPSINo.AutoSize = true;
            this.lblPSINo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPSINo.ForeColor = System.Drawing.Color.Blue;
            this.lblPSINo.Location = new System.Drawing.Point(94, 35);
            this.lblPSINo.Name = "lblPSINo";
            this.lblPSINo.Size = new System.Drawing.Size(13, 13);
            this.lblPSINo.TabIndex = 36;
            this.lblPSINo.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(380, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Supplier Name:";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblweek.Location = new System.Drawing.Point(375, 35);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(84, 13);
            this.lblweek.TabIndex = 39;
            this.lblweek.Text = "Exp.GRDWeek:";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPO.Location = new System.Drawing.Point(44, 35);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(44, 13);
            this.lblPO.TabIndex = 35;
            this.lblPO.Text = "PSI No:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCompany.Location = new System.Drawing.Point(3, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(85, 13);
            this.lblCompany.TabIndex = 31;
            this.lblCompany.Text = "Company Name:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRemarks.Location = new System.Drawing.Point(10, 273);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 46;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(65, 270);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(542, 20);
            this.txtRemarks.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(453, 296);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(534, 297);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbOrderNo
            // 
            this.lbOrderNo.AutoSize = true;
            this.lbOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbOrderNo.ForeColor = System.Drawing.Color.Blue;
            this.lbOrderNo.Location = new System.Drawing.Point(465, 61);
            this.lbOrderNo.Name = "lbOrderNo";
            this.lbOrderNo.Size = new System.Drawing.Size(13, 13);
            this.lbOrderNo.TabIndex = 48;
            this.lbOrderNo.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(409, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "OrderNo:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Details";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Bom List";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "PI Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "LC Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "BomID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
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
            this.txtProductDetails.Width = 170;
            // 
            // txtBomList
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBomList.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtBomList.HeaderText = "Bom List";
            this.txtBomList.Name = "txtBomList";
            this.txtBomList.ReadOnly = true;
            this.txtBomList.Width = 150;
            // 
            // txtPIQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPIQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtPIQty.HeaderText = "PI Qty";
            this.txtPIQty.Name = "txtPIQty";
            this.txtPIQty.ReadOnly = true;
            this.txtPIQty.Width = 80;
            // 
            // txtLCQty
            // 
            this.txtLCQty.HeaderText = "LC Qty";
            this.txtLCQty.Name = "txtLCQty";
            this.txtLCQty.Width = 80;
            // 
            // TxtProductID
            // 
            this.TxtProductID.HeaderText = "ProductID";
            this.TxtProductID.Name = "TxtProductID";
            this.TxtProductID.ReadOnly = true;
            this.TxtProductID.Visible = false;
            // 
            // txtBomID
            // 
            this.txtBomID.HeaderText = "BomID";
            this.txtBomID.Name = "txtBomID";
            this.txtBomID.ReadOnly = true;
            this.txtBomID.Visible = false;
            // 
            // frmNonLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 334);
            this.Controls.Add(this.lbOrderNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
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
            this.Controls.Add(this.dgvNONLCQty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNonLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non LC";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNONLCQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNONLCQty;
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
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbOrderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBomList;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPIQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLCQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}