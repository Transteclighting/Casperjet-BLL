namespace CJ.Win.Promotion
{
    partial class frmConsumerPromotionDiscountSharingType
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscountSharingTypeName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Discount Sharing Type";
            // 
            // txtDiscountSharingTypeName
            // 
            this.txtDiscountSharingTypeName.Location = new System.Drawing.Point(133, 10);
            this.txtDiscountSharingTypeName.Name = "txtDiscountSharingTypeName";
            this.txtDiscountSharingTypeName.Size = new System.Drawing.Size(201, 20);
            this.txtDiscountSharingTypeName.TabIndex = 40;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmConsumerPromotionDiscountSharingType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 74);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscountSharingTypeName);
            this.Controls.Add(this.btnSave);
            this.Name = "frmConsumerPromotionDiscountSharingType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Promotion Discount Sharing Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountSharingTypeName;
        private System.Windows.Forms.Button btnSave;
    }
}