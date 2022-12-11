namespace CJ.Win.CSD
{
    partial class frmCSDSMSHistoryCreate
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
            this.cmbSMSModel = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbJob = new System.Windows.Forms.Label();
            this.lblSMSStatus = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTextLength = new System.Windows.Forms.Label();
            this.txtOriginalMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.SuspendLayout();
            // 
            // cmbSMSModel
            // 
            this.cmbSMSModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSMSModel.FormattingEnabled = true;
            this.cmbSMSModel.Location = new System.Drawing.Point(68, 39);
            this.cmbSMSModel.Name = "cmbSMSModel";
            this.cmbSMSModel.Size = new System.Drawing.Size(463, 21);
            this.cmbSMSModel.TabIndex = 3;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(68, 67);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(463, 87);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(67, 240);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(160, 20);
            this.txtMobileNo.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(351, 275);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 25);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbJob
            // 
            this.lbJob.AutoSize = true;
            this.lbJob.Location = new System.Drawing.Point(35, 15);
            this.lbJob.Name = "lbJob";
            this.lbJob.Size = new System.Drawing.Size(24, 13);
            this.lbJob.TabIndex = 0;
            this.lbJob.Text = "Job";
            // 
            // lblSMSStatus
            // 
            this.lblSMSStatus.AutoSize = true;
            this.lblSMSStatus.Location = new System.Drawing.Point(2, 42);
            this.lblSMSStatus.Name = "lblSMSStatus";
            this.lblSMSStatus.Size = new System.Drawing.Size(59, 13);
            this.lblSMSStatus.TabIndex = 2;
            this.lblSMSStatus.Text = "Sms Model";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 70);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(3, 243);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(61, 13);
            this.lblMobileNo.TabIndex = 8;
            this.lblMobileNo.Text = "Modbile No";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(443, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Message Length";
            // 
            // lblTextLength
            // 
            this.lblTextLength.AutoSize = true;
            this.lblTextLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTextLength.Location = new System.Drawing.Point(479, 242);
            this.lblTextLength.Name = "lblTextLength";
            this.lblTextLength.Size = new System.Drawing.Size(24, 25);
            this.lblTextLength.TabIndex = 10;
            this.lblTextLength.Text = "?";
            // 
            // txtOriginalMessage
            // 
            this.txtOriginalMessage.Location = new System.Drawing.Point(67, 160);
            this.txtOriginalMessage.Multiline = true;
            this.txtOriginalMessage.Name = "txtOriginalMessage";
            this.txtOriginalMessage.ReadOnly = true;
            this.txtOriginalMessage.Size = new System.Drawing.Size(463, 74);
            this.txtOriginalMessage.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Original Msg";
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(68, 12);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(463, 20);
            this.ctlCSDJob1.TabIndex = 1;
            this.ctlCSDJob1.ChangeSelection += new System.EventHandler(this.ctlCSDJob1_ChangeSelection);
            // 
            // frmCSDSMSHistoryCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 310);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOriginalMessage);
            this.Controls.Add(this.lblTextLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSMSStatus);
            this.Controls.Add(this.lbJob);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cmbSMSModel);
            this.Controls.Add(this.ctlCSDJob1);
            this.MaximizeBox = false;
            this.Name = "frmCSDSMSHistoryCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD SMS History Create";
            this.Load += new System.EventHandler(this.frmCSDSMSHistoryCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.ComboBox cmbSMSModel;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lbJob;
        private System.Windows.Forms.Label lblSMSStatus;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTextLength;
        private System.Windows.Forms.TextBox txtOriginalMessage;
        private System.Windows.Forms.Label label2;
    }
}