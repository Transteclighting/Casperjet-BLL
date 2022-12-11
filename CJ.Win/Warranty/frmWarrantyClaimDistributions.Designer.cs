namespace CJ.Win.Warranty
{
    partial class frmWarrantyClaimDistributions
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
            System.Windows.Forms.ColumnHeader colSparePartsCharge;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarrantyClaimDistributions));
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProductType = new System.Windows.Forms.Label();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.colDeliveryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwWarrantyClaimDistributions = new System.Windows.Forms.ListView();
            this.colServiceCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTransportationCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOtherCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsWarrantyDistribution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIsWD = new System.Windows.Forms.ComboBox();
            colSparePartsCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // colSparePartsCharge
            // 
            colSparePartsCharge.Text = "SparePartsCharge";
            colSparePartsCharge.Width = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(831, 381);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Job No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(73, 9);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(164, 21);
            this.txtJobNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Service Type";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(108, 41);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(129, 23);
            this.cmbServiceType.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(831, 78);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblProductType
            // 
            this.lblProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.Location = new System.Drawing.Point(254, 10);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(67, 17);
            this.lblProductType.TabIndex = 2;
            this.lblProductType.Text = "Job Type";
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(327, 7);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(135, 23);
            this.cmbJobType.TabIndex = 3;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(571, 37);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(93, 30);
            this.btnGetData.TabIndex = 6;
            this.btnGetData.Text = "&Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.Text = "Delivery Date";
            this.colDeliveryDate.Width = 89;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 77;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Customer Address";
            this.colAddress.Width = 142;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 160;
            // 
            // colServiceType
            // 
            this.colServiceType.Text = "Service Type";
            this.colServiceType.Width = 95;
            // 
            // colJobStatus
            // 
            this.colJobStatus.Text = "Job Status";
            this.colJobStatus.Width = 84;
            // 
            // colJobType
            // 
            this.colJobType.Text = "Job Type";
            this.colJobType.Width = 85;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 76;
            // 
            // lvwWarrantyClaimDistributions
            // 
            this.lvwWarrantyClaimDistributions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWarrantyClaimDistributions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colJobType,
            this.colServiceType,
            this.colJobStatus,
            this.colDeliveryDate,
            this.colCustomerName,
            this.colAddress,
            this.colCreateDate,
            colSparePartsCharge,
            this.colServiceCharge,
            this.colTransportationCharge,
            this.colOtherCharge,
            this.colIsWarrantyDistribution});
            this.lvwWarrantyClaimDistributions.FullRowSelect = true;
            this.lvwWarrantyClaimDistributions.GridLines = true;
            this.lvwWarrantyClaimDistributions.Location = new System.Drawing.Point(12, 78);
            this.lvwWarrantyClaimDistributions.Name = "lvwWarrantyClaimDistributions";
            this.lvwWarrantyClaimDistributions.Size = new System.Drawing.Size(813, 333);
            this.lvwWarrantyClaimDistributions.TabIndex = 7;
            this.lvwWarrantyClaimDistributions.UseCompatibleStateImageBehavior = false;
            this.lvwWarrantyClaimDistributions.View = System.Windows.Forms.View.Details;
            // 
            // colServiceCharge
            // 
            this.colServiceCharge.Text = "ServiceCharge";
            this.colServiceCharge.Width = 0;
            // 
            // colTransportationCharge
            // 
            this.colTransportationCharge.Text = "TransportationCharge";
            this.colTransportationCharge.Width = 0;
            // 
            // colOtherCharge
            // 
            this.colOtherCharge.Text = "OtherCharge";
            this.colOtherCharge.Width = 0;
            // 
            // colIsWarrantyDistribution
            // 
            this.colIsWarrantyDistribution.Text = "IsWarrantyDistribution";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Is Warranty Distribution";
            // 
            // cmbIsWD
            // 
            this.cmbIsWD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsWD.FormattingEnabled = true;
            this.cmbIsWD.Location = new System.Drawing.Point(421, 41);
            this.cmbIsWD.Name = "cmbIsWD";
            this.cmbIsWD.Size = new System.Drawing.Size(135, 23);
            this.cmbIsWD.TabIndex = 11;
            // 
            // frmWarrantyClaimDistributions
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 423);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbIsWD);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.cmbJobType);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lvwWarrantyClaimDistributions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWarrantyClaimDistributions";
            this.Text = "Delivery Job";
            this.Load += new System.EventHandler(this.frmWarrantyClaimDistributions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colDeliveryDate;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colServiceType;
        private System.Windows.Forms.ColumnHeader colJobStatus;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ListView lvwWarrantyClaimDistributions;
        private System.Windows.Forms.ColumnHeader colServiceCharge;
        private System.Windows.Forms.ColumnHeader colTransportationCharge;
        private System.Windows.Forms.ColumnHeader colOtherCharge;
        private System.Windows.Forms.ColumnHeader colIsWarrantyDistribution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIsWD;
    }
}