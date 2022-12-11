namespace CJ.Win
{
    partial class frmComplainAction
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
            this.txtActionDetails = new System.Windows.Forms.TextBox();
            this.lblActionDetails = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblActionDate = new System.Windows.Forms.Label();
            this.dtActionDate = new System.Windows.Forms.DateTimePicker();
            this.rdbSolved = new System.Windows.Forms.RadioButton();
            this.rdbUnderProcess = new System.Windows.Forms.RadioButton();
            this.rdbMgtActionDecisionReq = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblContacNo = new System.Windows.Forms.Label();
            this.lblComplainer = new System.Windows.Forms.Label();
            this.lblComplainDetail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtActionStat = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtActionDetails
            // 
            this.txtActionDetails.Location = new System.Drawing.Point(37, 116);
            this.txtActionDetails.Multiline = true;
            this.txtActionDetails.Name = "txtActionDetails";
            this.txtActionDetails.Size = new System.Drawing.Size(465, 75);
            this.txtActionDetails.TabIndex = 0;
            // 
            // lblActionDetails
            // 
            this.lblActionDetails.AutoSize = true;
            this.lblActionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionDetails.Location = new System.Drawing.Point(35, 96);
            this.lblActionDetails.Name = "lblActionDetails";
            this.lblActionDetails.Size = new System.Drawing.Size(43, 13);
            this.lblActionDetails.TabIndex = 104;
            this.lblActionDetails.Text = "Action";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(376, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblActionDate
            // 
            this.lblActionDate.AutoSize = true;
            this.lblActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionDate.Location = new System.Drawing.Point(63, 256);
            this.lblActionDate.Name = "lblActionDate";
            this.lblActionDate.Size = new System.Drawing.Size(74, 13);
            this.lblActionDate.TabIndex = 114;
            this.lblActionDate.Text = "Action Date";
            // 
            // dtActionDate
            // 
            this.dtActionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtActionDate.Location = new System.Drawing.Point(194, 252);
            this.dtActionDate.Name = "dtActionDate";
            this.dtActionDate.Size = new System.Drawing.Size(110, 20);
            this.dtActionDate.TabIndex = 2;
            // 
            // rdbSolved
            // 
            this.rdbSolved.AutoSize = true;
            this.rdbSolved.Checked = true;
            this.rdbSolved.Location = new System.Drawing.Point(32, 13);
            this.rdbSolved.Name = "rdbSolved";
            this.rdbSolved.Size = new System.Drawing.Size(58, 17);
            this.rdbSolved.TabIndex = 115;
            this.rdbSolved.TabStop = true;
            this.rdbSolved.Text = "Solved";
            this.rdbSolved.UseVisualStyleBackColor = true;
            this.rdbSolved.CheckedChanged += new System.EventHandler(this.rdbSolved_CheckedChanged);
            // 
            // rdbUnderProcess
            // 
            this.rdbUnderProcess.AutoSize = true;
            this.rdbUnderProcess.Location = new System.Drawing.Point(128, 13);
            this.rdbUnderProcess.Name = "rdbUnderProcess";
            this.rdbUnderProcess.Size = new System.Drawing.Size(95, 17);
            this.rdbUnderProcess.TabIndex = 116;
            this.rdbUnderProcess.Text = "Under Process";
            this.rdbUnderProcess.UseVisualStyleBackColor = true;
            this.rdbUnderProcess.CheckedChanged += new System.EventHandler(this.rdbUnderProcess_CheckedChanged);
            // 
            // rdbMgtActionDecisionReq
            // 
            this.rdbMgtActionDecisionReq.AutoSize = true;
            this.rdbMgtActionDecisionReq.Location = new System.Drawing.Point(256, 13);
            this.rdbMgtActionDecisionReq.Name = "rdbMgtActionDecisionReq";
            this.rdbMgtActionDecisionReq.Size = new System.Drawing.Size(168, 17);
            this.rdbMgtActionDecisionReq.TabIndex = 117;
            this.rdbMgtActionDecisionReq.Text = "Mgt.Action/Decision Required";
            this.rdbMgtActionDecisionReq.UseVisualStyleBackColor = true;
            this.rdbMgtActionDecisionReq.CheckedChanged += new System.EventHandler(this.rdbMgtActionDecisionReq_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbMgtActionDecisionReq);
            this.groupBox1.Controls.Add(this.rdbUnderProcess);
            this.groupBox1.Controls.Add(this.rdbSolved);
            this.groupBox1.Location = new System.Drawing.Point(39, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 37);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(333, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 148;
            this.label6.Text = "Action Date";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(421, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "ActionDate";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(333, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 146;
            this.label5.Text = "Complain No";
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainNo.Location = new System.Drawing.Point(421, 11);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(84, 19);
            this.lblComplainNo.TabIndex = 145;
            this.lblComplainNo.Text = "ComplainNo";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 143;
            this.label3.Text = "Complain Detail";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 142;
            this.label2.Text = "Contact No";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 141;
            this.label7.Text = "Complainer";
            // 
            // lblContacNo
            // 
            this.lblContacNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContacNo.Location = new System.Drawing.Point(132, 34);
            this.lblContacNo.Name = "lblContacNo";
            this.lblContacNo.Size = new System.Drawing.Size(189, 20);
            this.lblContacNo.TabIndex = 140;
            this.lblContacNo.Text = "ContactNo";
            // 
            // lblComplainer
            // 
            this.lblComplainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainer.Location = new System.Drawing.Point(132, 11);
            this.lblComplainer.Name = "lblComplainer";
            this.lblComplainer.Size = new System.Drawing.Size(189, 19);
            this.lblComplainer.TabIndex = 139;
            this.lblComplainer.Text = "Complainer";
            // 
            // lblComplainDetail
            // 
            this.lblComplainDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainDetail.Location = new System.Drawing.Point(132, 58);
            this.lblComplainDetail.Name = "lblComplainDetail";
            this.lblComplainDetail.Size = new System.Drawing.Size(373, 30);
            this.lblComplainDetail.TabIndex = 137;
            this.lblComplainDetail.Text = "ComplainDetail";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.TabIndex = 150;
            this.label4.Text = "Status";
            // 
            // txtActionStat
            // 
            this.txtActionStat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionStat.Location = new System.Drawing.Point(365, 91);
            this.txtActionStat.Name = "txtActionStat";
            this.txtActionStat.Size = new System.Drawing.Size(140, 19);
            this.txtActionStat.TabIndex = 149;
            this.txtActionStat.Text = "ActionStatus";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(456, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 27);
            this.btnCancel.TabIndex = 151;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmComplainAction
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 284);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtActionStat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblContacNo);
            this.Controls.Add(this.lblComplainer);
            this.Controls.Add(this.lblComplainDetail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblActionDate);
            this.Controls.Add(this.dtActionDate);
            this.Controls.Add(this.txtActionDetails);
            this.Controls.Add(this.lblActionDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComplainAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Action Against Complain";
            this.Load += new System.EventHandler(this.frmComplainAction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActionDetails;
        private System.Windows.Forms.Label lblActionDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblActionDate;
        private System.Windows.Forms.DateTimePicker dtActionDate;
        private System.Windows.Forms.RadioButton rdbSolved;
        private System.Windows.Forms.RadioButton rdbUnderProcess;
        private System.Windows.Forms.RadioButton rdbMgtActionDecisionReq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblContacNo;
        private System.Windows.Forms.Label lblComplainer;
        private System.Windows.Forms.Label lblComplainDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtActionStat;
        private System.Windows.Forms.Button btnCancel;
    }
}