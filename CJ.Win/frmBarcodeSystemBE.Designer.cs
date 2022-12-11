namespace CJ.Win
{
    partial class frmBarcodeSystemBE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarcodeSystemBE));
            this.btnClose = new System.Windows.Forms.Button();
            this.dtBEDate = new System.Windows.Forms.DateTimePicker();
            this.lblBENo = new System.Windows.Forms.Label();
            this.txtBENo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTRanNo = new System.Windows.Forms.Label();
            this.lblTranDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(327, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtBEDate
            // 
            this.dtBEDate.CustomFormat = "dd-MMM-yyyy";
            this.dtBEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBEDate.Location = new System.Drawing.Point(150, 102);
            this.dtBEDate.Name = "dtBEDate";
            this.dtBEDate.Size = new System.Drawing.Size(264, 23);
            this.dtBEDate.TabIndex = 1;
            // 
            // lblBENo
            // 
            this.lblBENo.AutoSize = true;
            this.lblBENo.Location = new System.Drawing.Point(33, 75);
            this.lblBENo.Name = "lblBENo";
            this.lblBENo.Size = new System.Drawing.Size(105, 15);
            this.lblBENo.TabIndex = 2;
            this.lblBENo.Text = "BE/VAT Challan #";
            // 
            // txtBENo
            // 
            this.txtBENo.Location = new System.Drawing.Point(150, 72);
            this.txtBENo.Name = "txtBENo";
            this.txtBENo.Size = new System.Drawing.Size(264, 23);
            this.txtBENo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "BE/VAT Challan Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tran #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tran Date:";
            // 
            // lblTRanNo
            // 
            this.lblTRanNo.AutoSize = true;
            this.lblTRanNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTRanNo.Location = new System.Drawing.Point(63, 21);
            this.lblTRanNo.Name = "lblTRanNo";
            this.lblTRanNo.Size = new System.Drawing.Size(13, 15);
            this.lblTRanNo.TabIndex = 7;
            this.lblTRanNo.Text = "?";
            // 
            // lblTranDate
            // 
            this.lblTranDate.AutoSize = true;
            this.lblTranDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTranDate.Location = new System.Drawing.Point(333, 21);
            this.lblTranDate.Name = "lblTranDate";
            this.lblTranDate.Size = new System.Drawing.Size(13, 15);
            this.lblTranDate.TabIndex = 8;
            this.lblTranDate.Text = "?";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmBarcodeSystemBE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 171);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTranDate);
            this.Controls.Add(this.lblTRanNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBENo);
            this.Controls.Add(this.lblBENo);
            this.Controls.Add(this.dtBEDate);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBarcodeSystemBE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Barcode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtBEDate;
        private System.Windows.Forms.Label lblBENo;
        private System.Windows.Forms.TextBox txtBENo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTRanNo;
        private System.Windows.Forms.Label lblTranDate;
        private System.Windows.Forms.Button btnSave;
    }
}