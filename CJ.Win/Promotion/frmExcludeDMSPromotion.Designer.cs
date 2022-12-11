namespace CJ.Win.Promotion
{
    partial class frmExcludeDMSPromotion
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
            this.rdoInclude = new System.Windows.Forms.RadioButton();
            this.rdoExclude = new System.Windows.Forms.RadioButton();
            this.txtConsumerPromotion = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rdoInclude
            // 
            this.rdoInclude.AutoSize = true;
            this.rdoInclude.Location = new System.Drawing.Point(169, 56);
            this.rdoInclude.Name = "rdoInclude";
            this.rdoInclude.Size = new System.Drawing.Size(60, 17);
            this.rdoInclude.TabIndex = 9;
            this.rdoInclude.Text = "Include";
            this.rdoInclude.UseVisualStyleBackColor = true;
            // 
            // rdoExclude
            // 
            this.rdoExclude.AutoSize = true;
            this.rdoExclude.Checked = true;
            this.rdoExclude.Location = new System.Drawing.Point(104, 56);
            this.rdoExclude.Name = "rdoExclude";
            this.rdoExclude.Size = new System.Drawing.Size(63, 17);
            this.rdoExclude.TabIndex = 8;
            this.rdoExclude.TabStop = true;
            this.rdoExclude.Text = "Exclude";
            this.rdoExclude.UseVisualStyleBackColor = true;
            // 
            // txtConsumerPromotion
            // 
            this.txtConsumerPromotion.Location = new System.Drawing.Point(62, 25);
            this.txtConsumerPromotion.Name = "txtConsumerPromotion";
            this.txtConsumerPromotion.Size = new System.Drawing.Size(314, 20);
            this.txtConsumerPromotion.TabIndex = 7;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(301, 83);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(220, 83);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "CP No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "From DMS";
            // 
            // frmExcludeDMSPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 118);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoInclude);
            this.Controls.Add(this.rdoExclude);
            this.Controls.Add(this.txtConsumerPromotion);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExcludeDMSPromotion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExcludeDMSPromotion";
            this.Load += new System.EventHandler(this.frmExcludeDMSPromotion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoInclude;
        private System.Windows.Forms.RadioButton rdoExclude;
        private System.Windows.Forms.TextBox txtConsumerPromotion;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}