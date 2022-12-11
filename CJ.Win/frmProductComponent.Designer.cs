namespace CJ.Win
{
    partial class frmProductComponent
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
            this.txtProductSerial = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPanelSerial = new System.Windows.Forms.TextBox();
            this.lblPanelSL = new System.Windows.Forms.Label();
            this.txtSSBSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPSUSerial = new System.Windows.Forms.TextBox();
            this.lblSSBSerial = new System.Windows.Forms.Label();
            this.txtBarcodeSerial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.SuspendLayout();
            // 
            // txtProductSerial
            // 
            this.txtProductSerial.Location = new System.Drawing.Point(110, 62);
            this.txtProductSerial.Name = "txtProductSerial";
            this.txtProductSerial.Size = new System.Drawing.Size(254, 20);
            this.txtProductSerial.TabIndex = 5;
            this.txtProductSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductSerial_KeyDown);
            // 
            // lblContactNo
            // 
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(1, 65);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(107, 13);
            this.lblContactNo.TabIndex = 6;
            this.lblContactNo.Text = "Product Serial";
            this.lblContactNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Product";
            // 
            // txtPanelSerial
            // 
            this.txtPanelSerial.Location = new System.Drawing.Point(110, 88);
            this.txtPanelSerial.Name = "txtPanelSerial";
            this.txtPanelSerial.Size = new System.Drawing.Size(254, 20);
            this.txtPanelSerial.TabIndex = 8;
            this.txtPanelSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPanelSerial_KeyDown);
            // 
            // lblPanelSL
            // 
            this.lblPanelSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelSL.Location = new System.Drawing.Point(4, 91);
            this.lblPanelSL.Name = "lblPanelSL";
            this.lblPanelSL.Size = new System.Drawing.Size(104, 13);
            this.lblPanelSL.TabIndex = 9;
            this.lblPanelSL.Text = "Panel Serial";
            this.lblPanelSL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSSBSerial
            // 
            this.txtSSBSerial.Location = new System.Drawing.Point(110, 114);
            this.txtSSBSerial.Name = "txtSSBSerial";
            this.txtSSBSerial.Size = new System.Drawing.Size(254, 20);
            this.txtSSBSerial.TabIndex = 10;
            this.txtSSBSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSSBSerial_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "PSU Serial";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPSUSerial
            // 
            this.txtPSUSerial.Location = new System.Drawing.Point(110, 140);
            this.txtPSUSerial.Name = "txtPSUSerial";
            this.txtPSUSerial.Size = new System.Drawing.Size(254, 20);
            this.txtPSUSerial.TabIndex = 12;
            this.txtPSUSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPSUSerial_KeyDown);
            // 
            // lblSSBSerial
            // 
            this.lblSSBSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSBSerial.Location = new System.Drawing.Point(4, 117);
            this.lblSSBSerial.Name = "lblSSBSerial";
            this.lblSSBSerial.Size = new System.Drawing.Size(104, 13);
            this.lblSSBSerial.TabIndex = 13;
            this.lblSSBSerial.Text = "SSB Serial";
            this.lblSSBSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcodeSerial
            // 
            this.txtBarcodeSerial.Location = new System.Drawing.Point(110, 166);
            this.txtBarcodeSerial.Name = "txtBarcodeSerial";
            this.txtBarcodeSerial.Size = new System.Drawing.Size(254, 20);
            this.txtBarcodeSerial.TabIndex = 15;
            this.txtBarcodeSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeSerial_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Barcode Serial";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(374, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 27);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(457, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(104, 22);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(436, 25);
            this.ctlProduct1.TabIndex = 0;
            this.ctlProduct1.Leave += new System.EventHandler(this.ctlProduct1_Leave);
            // 
            // frmProductComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 198);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBarcodeSerial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPSUSerial);
            this.Controls.Add(this.lblSSBSerial);
            this.Controls.Add(this.txtSSBSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPanelSerial);
            this.Controls.Add(this.lblPanelSL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProductSerial);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.ctlProduct1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProductComponent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product Component";
            this.Load += new System.EventHandler(this.frmProductComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlProduct ctlProduct1;
        private System.Windows.Forms.TextBox txtProductSerial;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPanelSerial;
        private System.Windows.Forms.Label lblPanelSL;
        private System.Windows.Forms.TextBox txtSSBSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPSUSerial;
        private System.Windows.Forms.Label lblSSBSerial;
        private System.Windows.Forms.TextBox txtBarcodeSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}