namespace CJ.Win.HR
{
    partial class frmMobileBillEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMobileBillEdit));
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblMobileNumber = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblBillMonth = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.rdoEditBill = new System.Windows.Forms.RadioButton();
            this.rdoDeleteBill = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(5, 32);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(78, 13);
            this.lblMobile.TabIndex = 2;
            this.lblMobile.Text = "Mobile Number";
            // 
            // lblMobileNumber
            // 
            this.lblMobileNumber.AutoSize = true;
            this.lblMobileNumber.Location = new System.Drawing.Point(82, 33);
            this.lblMobileNumber.Name = "lblMobileNumber";
            this.lblMobileNumber.Size = new System.Drawing.Size(13, 13);
            this.lblMobileNumber.TabIndex = 3;
            this.lblMobileNumber.Text = "?";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(21, 102);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(59, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Bill Amount";
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Location = new System.Drawing.Point(86, 101);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(159, 20);
            this.txtBillAmount.TabIndex = 7;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(161, 127);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 27);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(25, 75);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(53, 13);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.Text = "Bill Month";
            // 
            // lblBillMonth
            // 
            this.lblBillMonth.AutoSize = true;
            this.lblBillMonth.Location = new System.Drawing.Point(81, 76);
            this.lblBillMonth.Name = "lblBillMonth";
            this.lblBillMonth.Size = new System.Drawing.Size(13, 13);
            this.lblBillMonth.TabIndex = 5;
            this.lblBillMonth.Text = "?";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(23, 53);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(60, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User Name";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(82, 54);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(13, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "?";
            // 
            // rdoEditBill
            // 
            this.rdoEditBill.AutoSize = true;
            this.rdoEditBill.Location = new System.Drawing.Point(12, 5);
            this.rdoEditBill.Name = "rdoEditBill";
            this.rdoEditBill.Size = new System.Drawing.Size(59, 17);
            this.rdoEditBill.TabIndex = 11;
            this.rdoEditBill.TabStop = true;
            this.rdoEditBill.Text = "Bill Edit";
            this.rdoEditBill.UseVisualStyleBackColor = true;
            this.rdoEditBill.CheckedChanged += new System.EventHandler(this.rdoEditBill_CheckedChanged);
            // 
            // rdoDeleteBill
            // 
            this.rdoDeleteBill.AutoSize = true;
            this.rdoDeleteBill.Location = new System.Drawing.Point(77, 5);
            this.rdoDeleteBill.Name = "rdoDeleteBill";
            this.rdoDeleteBill.Size = new System.Drawing.Size(72, 17);
            this.rdoDeleteBill.TabIndex = 12;
            this.rdoDeleteBill.TabStop = true;
            this.rdoDeleteBill.Text = "Bill Delete";
            this.rdoDeleteBill.UseVisualStyleBackColor = true;
            this.rdoDeleteBill.CheckedChanged += new System.EventHandler(this.rdoDeleteBill_CheckedChanged);
            // 
            // frmMobileBillEdit
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 160);
            this.Controls.Add(this.rdoDeleteBill);
            this.Controls.Add(this.rdoEditBill);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblBillMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblMobileNumber);
            this.Controls.Add(this.lblMobile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileBillEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Bill Edit";
            this.Load += new System.EventHandler(this.frmMobileBillEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblMobileNumber;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.RadioButton rdoEditBill;
        private System.Windows.Forms.RadioButton rdoDeleteBill;
    }
}