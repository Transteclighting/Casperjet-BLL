namespace CJ.Win.DMS
{
    partial class frmDMSUserOpt
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtOptDate = new System.Windows.Forms.DateTimePicker();
            this.lblOptDate = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(311, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(418, 139);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtOptDate
            // 
            this.dtOptDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtOptDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOptDate.Location = new System.Drawing.Point(112, 59);
            this.dtOptDate.Name = "dtOptDate";
            this.dtOptDate.Size = new System.Drawing.Size(112, 20);
            this.dtOptDate.TabIndex = 4;
            this.dtOptDate.Value = new System.DateTime(2018, 7, 6, 22, 26, 29, 0);
            // 
            // lblOptDate
            // 
            this.lblOptDate.AutoSize = true;
            this.lblOptDate.Location = new System.Drawing.Point(12, 65);
            this.lblOptDate.Name = "lblOptDate";
            this.lblOptDate.Size = new System.Drawing.Size(79, 13);
            this.lblOptDate.TabIndex = 6;
            this.lblOptDate.Text = "Operation Date";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(69, 5);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 50);
            this.ctlCustomer1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Distributor";
            // 
            // frmDMSUserOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 178);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOptDate);
            this.Controls.Add(this.dtOptDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmDMSUserOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DMS Operation";
            this.Load += new System.EventHandler(this.frmDMSUserOpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtOptDate;
        private System.Windows.Forms.Label lblOptDate;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label2;
    }
}