namespace CJ.Win
{
    partial class frmEmail
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
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboSatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWebAccess = new System.Windows.Forms.CheckBox();
            this.dtpCreateDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(91, 12);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(457, 20);
            this.txtEmailAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email Address";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(474, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboSatus
            // 
            this.cboSatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSatus.Enabled = false;
            this.cboSatus.FormattingEnabled = true;
            this.cboSatus.Location = new System.Drawing.Point(357, 38);
            this.cboSatus.Name = "cboSatus";
            this.cboSatus.Size = new System.Drawing.Size(191, 21);
            this.cboSatus.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Status";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(91, 38);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(182, 21);
            this.cboType.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Type";
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(91, 65);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(182, 20);
            this.txtQuota.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quota";
            // 
            // chkWebAccess
            // 
            this.chkWebAccess.AutoSize = true;
            this.chkWebAccess.Location = new System.Drawing.Point(91, 95);
            this.chkWebAccess.Name = "chkWebAccess";
            this.chkWebAccess.Size = new System.Drawing.Size(87, 17);
            this.chkWebAccess.TabIndex = 10;
            this.chkWebAccess.Text = "Web Access";
            this.chkWebAccess.UseVisualStyleBackColor = true;
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDate.Location = new System.Drawing.Point(357, 65);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(191, 20);
            this.dtpCreateDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Create Date";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(91, 127);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(467, 25);
            this.ctlEmployee1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Employee";
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 194);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.chkWebAccess);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Name = "frmEmail";
            this.Text = "frmEmail";
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboSatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWebAccess;
        private System.Windows.Forms.DateTimePicker dtpCreateDate;
        private System.Windows.Forms.Label label3;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label4;
    }
}