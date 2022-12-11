namespace CJ.Win.Dealer
{
    partial class frmDealerOutlet
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
            this.txtOutletName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOutletName = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbAddress = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.SuspendLayout();
            // 
            // txtOutletName
            // 
            this.txtOutletName.Location = new System.Drawing.Point(81, 61);
            this.txtOutletName.Name = "txtOutletName";
            this.txtOutletName.Size = new System.Drawing.Size(301, 20);
            this.txtOutletName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // lblOutletName
            // 
            this.lblOutletName.Location = new System.Drawing.Point(11, 61);
            this.lblOutletName.Name = "lblOutletName";
            this.lblOutletName.Size = new System.Drawing.Size(68, 20);
            this.lblOutletName.TabIndex = 2;
            this.lblOutletName.Text = "Outlet Name";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(82, 164);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(301, 20);
            this.txtContactNo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contact No.";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(81, 138);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(301, 20);
            this.txtContactPerson.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contact Person";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(82, 190);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(301, 20);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.Text = "na@na.com";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(41, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // rtbAddress
            // 
            this.rtbAddress.Location = new System.Drawing.Point(81, 87);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(301, 48);
            this.rtbAddress.TabIndex = 5;
            this.rtbAddress.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(422, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Is Active?";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(81, 225);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(15, 14);
            this.chkIsActive.TabIndex = 17;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(81, 9);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 50);
            this.ctlCustomer1.TabIndex = 1;
            this.ctlCustomer1.Load += new System.EventHandler(this.ctlCustomer1_Load);
            // 
            // frmDealerOutlet
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 269);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutletName);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOutletName);
            this.Name = "frmDealerOutlet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dealer Outlet";
            this.Load += new System.EventHandler(this.frmDealerOutlet_Load);
            this.Click += new System.EventHandler(this.frmDealerOutlet_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutletName;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOutletName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}