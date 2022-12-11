namespace CJ.POS
{
    partial class frmUnsoldDefectiveProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnsoldDefectiveProduct));
            this.txtFault = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblProductSerial = new System.Windows.Forms.Label();
            this.lblFault = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbBarcode = new System.Windows.Forms.ComboBox();
            this.cmbDefectiveType = new System.Windows.Forms.ComboBox();
            this.lblDefectiveType = new System.Windows.Forms.Label();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefTrandate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProposeDicAmt = new System.Windows.Forms.TextBox();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOriginalSerial = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFault
            // 
            this.txtFault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFault.Location = new System.Drawing.Point(115, 130);
            this.txtFault.Multiline = true;
            this.txtFault.Name = "txtFault";
            this.txtFault.Size = new System.Drawing.Size(480, 57);
            this.txtFault.TabIndex = 15;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(115, 193);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(480, 57);
            this.txtReason.TabIndex = 17;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(115, 256);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(480, 57);
            this.txtRemarks.TabIndex = 19;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(22, 20);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(87, 15);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Product Detail:";
            // 
            // lblProductSerial
            // 
            this.lblProductSerial.AutoSize = true;
            this.lblProductSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductSerial.Location = new System.Drawing.Point(56, 50);
            this.lblProductSerial.Name = "lblProductSerial";
            this.lblProductSerial.Size = new System.Drawing.Size(56, 15);
            this.lblProductSerial.TabIndex = 2;
            this.lblProductSerial.Text = "Barcode:";
            // 
            // lblFault
            // 
            this.lblFault.AutoSize = true;
            this.lblFault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFault.Location = new System.Drawing.Point(9, 133);
            this.lblFault.Name = "lblFault";
            this.lblFault.Size = new System.Drawing.Size(102, 15);
            this.lblFault.TabIndex = 14;
            this.lblFault.Text = "Fault Description:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(59, 196);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 15);
            this.lblReason.TabIndex = 16;
            this.lblReason.Text = "Reason";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(52, 256);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(57, 15);
            this.lblRemarks.TabIndex = 18;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(421, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 27);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(513, 319);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 27);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbBarcode
            // 
            this.cmbBarcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBarcode.FormattingEnabled = true;
            this.cmbBarcode.Location = new System.Drawing.Point(115, 47);
            this.cmbBarcode.Name = "cmbBarcode";
            this.cmbBarcode.Size = new System.Drawing.Size(183, 23);
            this.cmbBarcode.TabIndex = 3;
            this.cmbBarcode.SelectedIndexChanged += new System.EventHandler(this.cmbBarcode_SelectedIndexChanged);
            // 
            // cmbDefectiveType
            // 
            this.cmbDefectiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectiveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDefectiveType.FormattingEnabled = true;
            this.cmbDefectiveType.Location = new System.Drawing.Point(409, 47);
            this.cmbDefectiveType.Name = "cmbDefectiveType";
            this.cmbDefectiveType.Size = new System.Drawing.Size(186, 23);
            this.cmbDefectiveType.TabIndex = 5;
            this.cmbDefectiveType.SelectedIndexChanged += new System.EventHandler(this.cmbDefectiveType_SelectedIndexChanged);
            // 
            // lblDefectiveType
            // 
            this.lblDefectiveType.AutoSize = true;
            this.lblDefectiveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectiveType.Location = new System.Drawing.Point(317, 50);
            this.lblDefectiveType.Name = "lblDefectiveType";
            this.lblDefectiveType.Size = new System.Drawing.Size(89, 15);
            this.lblDefectiveType.TabIndex = 4;
            this.lblDefectiveType.Text = "Defective Type:";
            // 
            // lblRefNo
            // 
            this.lblRefNo.AutoSize = true;
            this.lblRefNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefNo.Location = new System.Drawing.Point(32, 106);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(79, 15);
            this.lblRefNo.TabIndex = 10;
            this.lblRefNo.Text = "Ref. Tran No:";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(115, 103);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(183, 21);
            this.txtRefNo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tran Date";
            // 
            // txtRefTrandate
            // 
            this.txtRefTrandate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefTrandate.Location = new System.Drawing.Point(409, 76);
            this.txtRefTrandate.Name = "txtRefTrandate";
            this.txtRefTrandate.Size = new System.Drawing.Size(186, 21);
            this.txtRefTrandate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Propose Dic. Amt";
            // 
            // txtProposeDicAmt
            // 
            this.txtProposeDicAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProposeDicAmt.Location = new System.Drawing.Point(409, 103);
            this.txtProposeDicAmt.Name = "txtProposeDicAmt";
            this.txtProposeDicAmt.Size = new System.Drawing.Size(186, 21);
            this.txtProposeDicAmt.TabIndex = 13;
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlProduct1.Location = new System.Drawing.Point(115, 16);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(485, 25);
            this.ctlProduct1.TabIndex = 1;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Original Serial";
            // 
            // txtOriginalSerial
            // 
            this.txtOriginalSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalSerial.Location = new System.Drawing.Point(115, 76);
            this.txtOriginalSerial.Name = "txtOriginalSerial";
            this.txtOriginalSerial.Size = new System.Drawing.Size(183, 21);
            this.txtOriginalSerial.TabIndex = 7;
            // 
            // frmUnsoldDefectiveProduct
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 356);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOriginalSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProposeDicAmt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRefTrandate);
            this.Controls.Add(this.lblRefNo);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.cmbDefectiveType);
            this.Controls.Add(this.lblDefectiveType);
            this.Controls.Add(this.cmbBarcode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblFault);
            this.Controls.Add(this.lblProductSerial);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtFault);
            this.Controls.Add(this.ctlProduct1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUnsoldDefectiveProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Unsold Defective Product";
            this.Load += new System.EventHandler(this.frmUnsoldDefectiveProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.TextBox txtFault;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductSerial;
        private System.Windows.Forms.Label lblFault;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbBarcode;
        private System.Windows.Forms.ComboBox cmbDefectiveType;
        private System.Windows.Forms.Label lblDefectiveType;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefTrandate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProposeDicAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOriginalSerial;
    }
}