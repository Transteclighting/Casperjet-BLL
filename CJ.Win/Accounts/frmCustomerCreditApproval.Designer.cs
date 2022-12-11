namespace CJ.Win.Accounts
{
    partial class frmCustomerCreditApproval
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.cboOutlet = new System.Windows.Forms.ComboBox();
            this.txtProductOrService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCreditPeriod = new System.Windows.Forms.TextBox();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPicker = new System.Windows.Forms.Button();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.txtConsumerCode = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.lblCAN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(76, 247);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(59, 16);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Amount: ";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(139, 244);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(160, 23);
            this.txtAmount.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(468, 351);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 32);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(67, 79);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 16);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer: ";
            // 
            // lblOutlet
            // 
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlet.Location = new System.Drawing.Point(86, 47);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(49, 16);
            this.lblOutlet.TabIndex = 2;
            this.lblOutlet.Text = "Outlet: ";
            // 
            // cboOutlet
            // 
            this.cboOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutlet.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOutlet.FormattingEnabled = true;
            this.cboOutlet.Location = new System.Drawing.Point(139, 44);
            this.cboOutlet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboOutlet.Name = "cboOutlet";
            this.cboOutlet.Size = new System.Drawing.Size(233, 24);
            this.cboOutlet.TabIndex = 3;
            this.cboOutlet.SelectedIndexChanged += new System.EventHandler(this.cboOutlet_SelectedIndexChanged);
            // 
            // txtProductOrService
            // 
            this.txtProductOrService.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductOrService.Location = new System.Drawing.Point(139, 137);
            this.txtProductOrService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductOrService.Multiline = true;
            this.txtProductOrService.Name = "txtProductOrService";
            this.txtProductOrService.Size = new System.Drawing.Size(510, 68);
            this.txtProductOrService.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Product/Service: ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(9, 216);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(126, 16);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "Credit Period (Days): ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(139, 275);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(510, 68);
            this.txtRemarks.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Remarks: ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(562, 351);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 32);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCreditPeriod
            // 
            this.txtCreditPeriod.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditPeriod.Location = new System.Drawing.Point(139, 213);
            this.txtCreditPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCreditPeriod.Name = "txtCreditPeriod";
            this.txtCreditPeriod.Size = new System.Drawing.Size(94, 23);
            this.txtCreditPeriod.TabIndex = 13;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(139, 76);
            this.ctlCustomer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(431, 25);
            this.ctlCustomer1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consumer:";
            // 
            // btnPicker
            // 
            this.btnPicker.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPicker.Location = new System.Drawing.Point(241, 108);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(29, 24);
            this.btnPicker.TabIndex = 8;
            this.btnPicker.Text = "...";
            this.btnPicker.UseVisualStyleBackColor = true;
            this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.BackColor = System.Drawing.SystemColors.Control;
            this.txtConsumerName.Enabled = false;
            this.txtConsumerName.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumerName.Location = new System.Drawing.Point(272, 108);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(292, 23);
            this.txtConsumerName.TabIndex = 9;
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumerCode.Location = new System.Drawing.Point(139, 108);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.Size = new System.Drawing.Size(100, 23);
            this.txtConsumerCode.TabIndex = 7;
            this.txtConsumerCode.TextChanged += new System.EventHandler(this.txtConsumerCode_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(68, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 15);
            this.label28.TabIndex = 0;
            this.label28.Text = "Sales Type";
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(139, 14);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(160, 23);
            this.cmbSalesType.TabIndex = 1;
            this.cmbSalesType.SelectedIndexChanged += new System.EventHandler(this.cmbSalesType_SelectedIndexChanged);
            // 
            // lblCAN
            // 
            this.lblCAN.AutoSize = true;
            this.lblCAN.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCAN.Location = new System.Drawing.Point(402, 47);
            this.lblCAN.Name = "lblCAN";
            this.lblCAN.Size = new System.Drawing.Size(0, 16);
            this.lblCAN.TabIndex = 20;
            // 
            // frmCustomerCreditApproval
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 392);
            this.Controls.Add(this.lblCAN);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cmbSalesType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.txtConsumerCode);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.txtCreditPeriod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtProductOrService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOutlet);
            this.Controls.Add(this.lblOutlet);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerCreditApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Credit Approval";
            this.Load += new System.EventHandler(this.frmCustomerCreditApproval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.ComboBox cboOutlet;
        private System.Windows.Forms.TextBox txtProductOrService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCreditPeriod;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPicker;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.TextBox txtConsumerCode;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.Label lblCAN;
    }
}