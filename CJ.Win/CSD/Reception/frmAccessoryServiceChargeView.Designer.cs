namespace CJ.Win.CSD.Reception
{
    partial class frmAccessoryServiceChargeView
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaidServiceCharge = new System.Windows.Forms.TextBox();
            this.txtWarrantyServiceCharge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAccessoryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paid SC";
            // 
            // txtPaidServiceCharge
            // 
            this.txtPaidServiceCharge.Location = new System.Drawing.Point(89, 30);
            this.txtPaidServiceCharge.Name = "txtPaidServiceCharge";
            this.txtPaidServiceCharge.ReadOnly = true;
            this.txtPaidServiceCharge.Size = new System.Drawing.Size(210, 20);
            this.txtPaidServiceCharge.TabIndex = 1;
            // 
            // txtWarrantyServiceCharge
            // 
            this.txtWarrantyServiceCharge.Location = new System.Drawing.Point(89, 53);
            this.txtWarrantyServiceCharge.Name = "txtWarrantyServiceCharge";
            this.txtWarrantyServiceCharge.ReadOnly = true;
            this.txtWarrantyServiceCharge.Size = new System.Drawing.Size(210, 20);
            this.txtWarrantyServiceCharge.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Warranty SC";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(224, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Accessory";
            // 
            // lblAccessoryName
            // 
            this.lblAccessoryName.AutoSize = true;
            this.lblAccessoryName.Location = new System.Drawing.Point(91, 9);
            this.lblAccessoryName.Name = "lblAccessoryName";
            this.lblAccessoryName.Size = new System.Drawing.Size(13, 13);
            this.lblAccessoryName.TabIndex = 6;
            this.lblAccessoryName.Text = "?";
            // 
            // frmAccessoryServiceChargeView
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 115);
            this.Controls.Add(this.lblAccessoryName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtWarrantyServiceCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaidServiceCharge);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccessoryServiceChargeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accessory Service ChargeView";
            this.Load += new System.EventHandler(this.frmAccessoryServiceChargeView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaidServiceCharge;
        private System.Windows.Forms.TextBox txtWarrantyServiceCharge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAccessoryName;
    }
}