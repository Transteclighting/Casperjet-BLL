namespace CJ.Win
{
    partial class frmSMSMessage
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
            this.txtSMSText = new System.Windows.Forms.TextBox();
            this.lblComplainDetails = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSMSLenth = new System.Windows.Forms.Label();
            this.lblSMSID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSMSCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(395, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 105;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSMSText
            // 
            this.txtSMSText.Location = new System.Drawing.Point(86, 53);
            this.txtSMSText.Multiline = true;
            this.txtSMSText.Name = "txtSMSText";
            this.txtSMSText.Size = new System.Drawing.Size(414, 46);
            this.txtSMSText.TabIndex = 103;
            this.txtSMSText.TextChanged += new System.EventHandler(this.txtSMSText_TextChanged);
            // 
            // lblComplainDetails
            // 
            this.lblComplainDetails.AutoSize = true;
            this.lblComplainDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainDetails.Location = new System.Drawing.Point(21, 54);
            this.lblComplainDetails.Name = "lblComplainDetails";
            this.lblComplainDetails.Size = new System.Drawing.Size(62, 13);
            this.lblComplainDetails.TabIndex = 107;
            this.lblComplainDetails.Text = "SMS Text";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(85, 114);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(125, 20);
            this.txtMobile.TabIndex = 104;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.Location = new System.Drawing.Point(19, 117);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(64, 13);
            this.lblMobile.TabIndex = 106;
            this.lblMobile.Text = "Mobile No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "SMS Length:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSMSLenth
            // 
            this.lblSMSLenth.AutoSize = true;
            this.lblSMSLenth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSLenth.ForeColor = System.Drawing.Color.Green;
            this.lblSMSLenth.Location = new System.Drawing.Point(85, 150);
            this.lblSMSLenth.Name = "lblSMSLenth";
            this.lblSMSLenth.Size = new System.Drawing.Size(24, 25);
            this.lblSMSLenth.TabIndex = 110;
            this.lblSMSLenth.Text = "?";
            // 
            // lblSMSID
            // 
            this.lblSMSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSMSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSMSID.Location = new System.Drawing.Point(87, 15);
            this.lblSMSID.Name = "lblSMSID";
            this.lblSMSID.Size = new System.Drawing.Size(123, 20);
            this.lblSMSID.TabIndex = 131;
            this.lblSMSID.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "SMS ID";
            // 
            // lblSMSCode
            // 
            this.lblSMSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSMSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSMSCode.Location = new System.Drawing.Point(303, 15);
            this.lblSMSCode.Name = "lblSMSCode";
            this.lblSMSCode.Size = new System.Drawing.Size(135, 20);
            this.lblSMSCode.TabIndex = 129;
            this.lblSMSCode.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 128;
            this.label5.Text = "SMS Code";
            // 
            // frmSMSMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 195);
            this.Controls.Add(this.lblSMSID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSMSCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSMSLenth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSMSText);
            this.Controls.Add(this.lblComplainDetails);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSMSMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSMSMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSMSText;
        private System.Windows.Forms.Label lblComplainDetails;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSMSLenth;
        private System.Windows.Forms.Label lblSMSID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSMSCode;
        private System.Windows.Forms.Label label5;
    }
}