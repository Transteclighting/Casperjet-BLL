namespace CJ.Win
{
    partial class frmSMSReGenerate
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
            this.lblSMSCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtReGenReason = new System.Windows.Forms.TextBox();
            this.lblComplainDetails = new System.Windows.Forms.Label();
            this.lblSMSID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSMSCode
            // 
            this.lblSMSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSMSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSMSCode.Location = new System.Drawing.Point(355, 23);
            this.lblSMSCode.Name = "lblSMSCode";
            this.lblSMSCode.Size = new System.Drawing.Size(135, 20);
            this.lblSMSCode.TabIndex = 121;
            this.lblSMSCode.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "SMS Code";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(390, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 118;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtReGenReason
            // 
            this.txtReGenReason.Location = new System.Drawing.Point(139, 55);
            this.txtReGenReason.Multiline = true;
            this.txtReGenReason.Name = "txtReGenReason";
            this.txtReGenReason.Size = new System.Drawing.Size(354, 46);
            this.txtReGenReason.TabIndex = 117;
            // 
            // lblComplainDetails
            // 
            this.lblComplainDetails.AutoSize = true;
            this.lblComplainDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainDetails.Location = new System.Drawing.Point(7, 56);
            this.lblComplainDetails.Name = "lblComplainDetails";
            this.lblComplainDetails.Size = new System.Drawing.Size(130, 13);
            this.lblComplainDetails.TabIndex = 119;
            this.lblComplainDetails.Text = " Re-Generate Reason";
            // 
            // lblSMSID
            // 
            this.lblSMSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSMSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSMSID.Location = new System.Drawing.Point(139, 23);
            this.lblSMSID.Name = "lblSMSID";
            this.lblSMSID.Size = new System.Drawing.Size(123, 20);
            this.lblSMSID.TabIndex = 123;
            this.lblSMSID.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "SMS ID";
            // 
            // frmSMSReGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 148);
            this.Controls.Add(this.lblSMSID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSMSCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReGenReason);
            this.Controls.Add(this.lblComplainDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSMSReGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request for Re-Generate SMS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSMSCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReGenReason;
        private System.Windows.Forms.Label lblComplainDetails;
        private System.Windows.Forms.Label lblSMSID;
        private System.Windows.Forms.Label label3;
    }
}