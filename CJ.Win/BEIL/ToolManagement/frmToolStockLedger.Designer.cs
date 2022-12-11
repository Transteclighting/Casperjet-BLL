namespace CJ.Win.BEIL.ToolManagement
{
    partial class frmToolStockLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToolStockLedger));
            this.label5 = new System.Windows.Forms.Label();
            this.rdoWH = new System.Windows.Forms.RadioButton();
            this.rdoEmployee = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWH = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 202;
            this.label5.Text = "Employee";
            // 
            // rdoWH
            // 
            this.rdoWH.AutoSize = true;
            this.rdoWH.Location = new System.Drawing.Point(94, 66);
            this.rdoWH.Name = "rdoWH";
            this.rdoWH.Size = new System.Drawing.Size(120, 19);
            this.rdoWH.TabIndex = 205;
            this.rdoWH.TabStop = true;
            this.rdoWH.Text = "WareHouse Wise";
            this.rdoWH.UseVisualStyleBackColor = true;
            this.rdoWH.CheckedChanged += new System.EventHandler(this.rdoWH_CheckedChanged);
            // 
            // rdoEmployee
            // 
            this.rdoEmployee.AutoSize = true;
            this.rdoEmployee.Location = new System.Drawing.Point(94, 41);
            this.rdoEmployee.Name = "rdoEmployee";
            this.rdoEmployee.Size = new System.Drawing.Size(110, 19);
            this.rdoEmployee.TabIndex = 204;
            this.rdoEmployee.TabStop = true;
            this.rdoEmployee.Text = "Employee Wise";
            this.rdoEmployee.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 206;
            this.label1.Text = "Warehouse:";
            // 
            // lblWH
            // 
            this.lblWH.AutoSize = true;
            this.lblWH.Location = new System.Drawing.Point(91, 97);
            this.lblWH.Name = "lblWH";
            this.lblWH.Size = new System.Drawing.Size(43, 15);
            this.lblWH.TabIndex = 207;
            this.lblWH.Text = "Sound";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(507, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 32);
            this.btnClose.TabIndex = 209;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(410, 104);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 32);
            this.btnPrint.TabIndex = 208;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEmployee1.Location = new System.Drawing.Point(94, 10);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(505, 25);
            this.ctlEmployee1.TabIndex = 203;
            // 
            // frmToolStockLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 148);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblWH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoWH);
            this.Controls.Add(this.rdoEmployee);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmToolStockLedger";
            this.Text = "Tool Stock Ledger";
            this.Load += new System.EventHandler(this.frmEmployeeToolLedger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.RadioButton rdoWH;
        private System.Windows.Forms.RadioButton rdoEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWH;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
    }
}