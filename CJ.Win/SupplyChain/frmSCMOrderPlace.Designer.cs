namespace CJ.Win.SupplyChain
{
    partial class frmSCMOrderPlace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMOrderPlace));
            this.dtOrderPlascedate = new System.Windows.Forms.DateTimePicker();
            this.lblOPlaceDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblExpGRDWeek = new System.Windows.Forms.Label();
            this.lblPSINo = new System.Windows.Forms.Label();
            this.lblweek = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.dgvOrderQty = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPSIQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPreOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderQty)).BeginInit();
            this.SuspendLayout();
            // 
            // dtOrderPlascedate
            // 
            this.dtOrderPlascedate.CustomFormat = "dd-MMM-yyyy";
            this.dtOrderPlascedate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtOrderPlascedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOrderPlascedate.Location = new System.Drawing.Point(101, 48);
            this.dtOrderPlascedate.Name = "dtOrderPlascedate";
            this.dtOrderPlascedate.Size = new System.Drawing.Size(150, 20);
            this.dtOrderPlascedate.TabIndex = 0;
            // 
            // lblOPlaceDate
            // 
            this.lblOPlaceDate.AutoSize = true;
            this.lblOPlaceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOPlaceDate.Location = new System.Drawing.Point(12, 50);
            this.lblOPlaceDate.Name = "lblOPlaceDate";
            this.lblOPlaceDate.Size = new System.Drawing.Size(83, 13);
            this.lblOPlaceDate.TabIndex = 151;
            this.lblOPlaceDate.Text = "OrderPlaceDate";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(556, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(475, 299);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(67, 270);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(564, 20);
            this.txtRemarks.TabIndex = 154;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(12, 273);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 155;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Location = new System.Drawing.Point(298, 14);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 13);
            this.lblCompanyName.TabIndex = 184;
            this.lblCompanyName.Text = "?";
            // 
            // lblExpGRDWeek
            // 
            this.lblExpGRDWeek.AutoSize = true;
            this.lblExpGRDWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpGRDWeek.ForeColor = System.Drawing.Color.Blue;
            this.lblExpGRDWeek.Location = new System.Drawing.Point(563, 14);
            this.lblExpGRDWeek.Name = "lblExpGRDWeek";
            this.lblExpGRDWeek.Size = new System.Drawing.Size(13, 13);
            this.lblExpGRDWeek.TabIndex = 183;
            this.lblExpGRDWeek.Text = "?";
            // 
            // lblPSINo
            // 
            this.lblPSINo.AutoSize = true;
            this.lblPSINo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPSINo.ForeColor = System.Drawing.Color.Blue;
            this.lblPSINo.Location = new System.Drawing.Point(55, 14);
            this.lblPSINo.Name = "lblPSINo";
            this.lblPSINo.Size = new System.Drawing.Size(13, 13);
            this.lblPSINo.TabIndex = 182;
            this.lblPSINo.Text = "?";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblweek.Location = new System.Drawing.Point(480, 14);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(84, 13);
            this.lblweek.TabIndex = 180;
            this.lblweek.Text = "Exp.GRDWeek:";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPO.Location = new System.Drawing.Point(12, 14);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(44, 13);
            this.lblPO.TabIndex = 179;
            this.lblPO.Text = "PSI No:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(214, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(85, 13);
            this.lblCompany.TabIndex = 178;
            this.lblCompany.Text = "Company Name:";
            // 
            // dgvOrderQty
            // 
            this.dgvOrderQty.AllowUserToAddRows = false;
            this.dgvOrderQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDetails,
            this.txtPSIQty,
            this.txtPreOrderQty,
            this.txtOrderQty,
            this.TxtProductID});
            this.dgvOrderQty.Location = new System.Drawing.Point(12, 77);
            this.dgvOrderQty.Name = "dgvOrderQty";
            this.dgvOrderQty.Size = new System.Drawing.Size(619, 184);
            this.dgvOrderQty.TabIndex = 2;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // txtProductDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.Width = 240;
            // 
            // txtPSIQty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPSIQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtPSIQty.HeaderText = "PSIQty";
            this.txtPSIQty.Name = "txtPSIQty";
            this.txtPSIQty.Width = 80;
            // 
            // txtPreOrderQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPreOrderQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtPreOrderQty.HeaderText = "PreOrderQty";
            this.txtPreOrderQty.Name = "txtPreOrderQty";
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.HeaderText = "OrderQty";
            this.txtOrderQty.Name = "txtOrderQty";
            // 
            // TxtProductID
            // 
            this.TxtProductID.HeaderText = "ProductID";
            this.TxtProductID.Name = "TxtProductID";
            this.TxtProductID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(320, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 187;
            this.label4.Text = "Supplier";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(371, 47);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(260, 21);
            this.cmbSupplier.TabIndex = 1;
            // 
            // frmSCMOrderPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 335);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.dgvOrderQty);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblExpGRDWeek);
            this.Controls.Add(this.lblPSINo);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblOPlaceDate);
            this.Controls.Add(this.dtOrderPlascedate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSCMOrderPlace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Place";
            this.Load += new System.EventHandler(this.frmSCMOrderPlace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtOrderPlascedate;
        private System.Windows.Forms.Label lblOPlaceDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblExpGRDWeek;
        private System.Windows.Forms.Label lblPSINo;
        private System.Windows.Forms.Label lblweek;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DataGridView dgvOrderQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPSIQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPreOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtProductID;
    }
}