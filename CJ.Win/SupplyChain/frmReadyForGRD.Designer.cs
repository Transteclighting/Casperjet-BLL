namespace CJ.Win.SupplyChain
{
    partial class frmReadyForGRD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadyForGRD));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtReadyForGRDDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblShipmentNo = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblLCNO = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.Location = new System.Drawing.Point(392, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(483, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtReadyForGRDDate
            // 
            this.dtReadyForGRDDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReadyForGRDDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtReadyForGRDDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReadyForGRDDate.Location = new System.Drawing.Point(82, 79);
            this.dtReadyForGRDDate.Name = "dtReadyForGRDDate";
            this.dtReadyForGRDDate.Size = new System.Drawing.Size(120, 20);
            this.dtReadyForGRDDate.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.Location = new System.Drawing.Point(49, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 69;
            this.label12.Text = "Date";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblOrderNo.Location = new System.Drawing.Point(399, 55);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(13, 13);
            this.lblOrderNo.TabIndex = 58;
            this.lblOrderNo.Text = "?";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInvoiceNo.Location = new System.Drawing.Point(65, 55);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(13, 13);
            this.lblInvoiceNo.TabIndex = 57;
            this.lblInvoiceNo.Text = "?";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.AutoSize = true;
            this.lblShipmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblShipmentNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblShipmentNo.Location = new System.Drawing.Point(398, 9);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(13, 13);
            this.lblShipmentNo.TabIndex = 59;
            this.lblShipmentNo.Text = "?";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSupplier.Location = new System.Drawing.Point(66, 9);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(13, 13);
            this.lblSupplier.TabIndex = 61;
            this.lblSupplier.Text = "?";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label22.Location = new System.Drawing.Point(17, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 51;
            this.label22.Text = "Supplier:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label23.Location = new System.Drawing.Point(331, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 53;
            this.label23.Text = "ShipmentNo:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label24.Location = new System.Drawing.Point(6, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 55;
            this.label24.Text = "InvoiceNo:";
            // 
            // lblLCNO
            // 
            this.lblLCNO.AutoSize = true;
            this.lblLCNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLCNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLCNO.Location = new System.Drawing.Point(398, 32);
            this.lblLCNO.Name = "lblLCNO";
            this.lblLCNO.Size = new System.Drawing.Size(13, 13);
            this.lblLCNO.TabIndex = 60;
            this.lblLCNO.Text = "?";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompany.Location = new System.Drawing.Point(66, 32);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(13, 13);
            this.lblCompany.TabIndex = 62;
            this.lblCompany.Text = "?";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label16.Location = new System.Drawing.Point(11, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Company:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.Location = new System.Drawing.Point(362, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "LCNo:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(349, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "OrderNo:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtRemarks.Location = new System.Drawing.Point(82, 105);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(486, 20);
            this.txtRemarks.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(30, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Remarks";
            // 
            // frmReadyForGRD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 166);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtReadyForGRDDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.lblShipmentNo);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblLCNO);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReadyForGRD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ready For GRD";
            this.Load += new System.EventHandler(this.frmReadyForGRD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtReadyForGRDDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblShipmentNo;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblLCNO;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
    }
}