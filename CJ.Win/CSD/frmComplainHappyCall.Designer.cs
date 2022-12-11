namespace CJ.Win
{
    partial class frmComplainHappyCall
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
            this.txtHappyDetails = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHappyCallDetails = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDissatisfy = new System.Windows.Forms.RadioButton();
            this.rdbModerate = new System.Windows.Forms.RadioButton();
            this.rdbSatisfy = new System.Windows.Forms.RadioButton();
            this.chkFurtherActionRequired = new System.Windows.Forms.CheckBox();
            this.lblComplainDetail = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblComplainer = new System.Windows.Forms.Label();
            this.lblContacNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblActionDate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHappyDetails
            // 
            this.txtHappyDetails.Location = new System.Drawing.Point(16, 200);
            this.txtHappyDetails.Multiline = true;
            this.txtHappyDetails.Name = "txtHappyDetails";
            this.txtHappyDetails.Size = new System.Drawing.Size(464, 55);
            this.txtHappyDetails.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(305, 272);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHappyCallDetails
            // 
            this.lblHappyCallDetails.AutoSize = true;
            this.lblHappyCallDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHappyCallDetails.Location = new System.Drawing.Point(18, 180);
            this.lblHappyCallDetails.Name = "lblHappyCallDetails";
            this.lblHappyCallDetails.Size = new System.Drawing.Size(64, 13);
            this.lblHappyCallDetails.TabIndex = 121;
            this.lblHappyCallDetails.Text = "Comments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDissatisfy);
            this.groupBox1.Controls.Add(this.rdbModerate);
            this.groupBox1.Controls.Add(this.rdbSatisfy);
            this.groupBox1.Location = new System.Drawing.Point(17, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 37);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rdbDissatisfy
            // 
            this.rdbDissatisfy.AutoSize = true;
            this.rdbDissatisfy.Location = new System.Drawing.Point(256, 13);
            this.rdbDissatisfy.Name = "rdbDissatisfy";
            this.rdbDissatisfy.Size = new System.Drawing.Size(69, 17);
            this.rdbDissatisfy.TabIndex = 117;
            this.rdbDissatisfy.Text = "Dissatisfy";
            this.rdbDissatisfy.UseVisualStyleBackColor = true;
            this.rdbDissatisfy.CheckedChanged += new System.EventHandler(this.rdbDissatisfy_CheckedChanged);
            // 
            // rdbModerate
            // 
            this.rdbModerate.AutoSize = true;
            this.rdbModerate.Location = new System.Drawing.Point(138, 13);
            this.rdbModerate.Name = "rdbModerate";
            this.rdbModerate.Size = new System.Drawing.Size(70, 17);
            this.rdbModerate.TabIndex = 116;
            this.rdbModerate.Text = "Moderate";
            this.rdbModerate.UseVisualStyleBackColor = true;
            this.rdbModerate.CheckedChanged += new System.EventHandler(this.rdbModerate_CheckedChanged);
            // 
            // rdbSatisfy
            // 
            this.rdbSatisfy.AutoSize = true;
            this.rdbSatisfy.Checked = true;
            this.rdbSatisfy.Location = new System.Drawing.Point(32, 13);
            this.rdbSatisfy.Name = "rdbSatisfy";
            this.rdbSatisfy.Size = new System.Drawing.Size(56, 17);
            this.rdbSatisfy.TabIndex = 115;
            this.rdbSatisfy.TabStop = true;
            this.rdbSatisfy.Text = "Satisfy";
            this.rdbSatisfy.UseVisualStyleBackColor = true;
            this.rdbSatisfy.CheckedChanged += new System.EventHandler(this.rdbSatisfy_CheckedChanged);
            // 
            // chkFurtherActionRequired
            // 
            this.chkFurtherActionRequired.AutoSize = true;
            this.chkFurtherActionRequired.Enabled = false;
            this.chkFurtherActionRequired.Location = new System.Drawing.Point(37, 285);
            this.chkFurtherActionRequired.Name = "chkFurtherActionRequired";
            this.chkFurtherActionRequired.Size = new System.Drawing.Size(138, 17);
            this.chkFurtherActionRequired.TabIndex = 123;
            this.chkFurtherActionRequired.Text = "Further Action Required";
            this.chkFurtherActionRequired.UseVisualStyleBackColor = true;
            // 
            // lblComplainDetail
            // 
            this.lblComplainDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainDetail.Location = new System.Drawing.Point(104, 56);
            this.lblComplainDetail.Name = "lblComplainDetail";
            this.lblComplainDetail.Size = new System.Drawing.Size(373, 30);
            this.lblComplainDetail.TabIndex = 124;
            this.lblComplainDetail.Text = "ComplainDetail";
            // 
            // lblAction
            // 
            this.lblAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAction.Location = new System.Drawing.Point(104, 90);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(373, 32);
            this.lblAction.TabIndex = 125;
            this.lblAction.Text = "Action";
            // 
            // lblComplainer
            // 
            this.lblComplainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainer.Location = new System.Drawing.Point(104, 9);
            this.lblComplainer.Name = "lblComplainer";
            this.lblComplainer.Size = new System.Drawing.Size(189, 19);
            this.lblComplainer.TabIndex = 127;
            this.lblComplainer.Text = "Complainer";
            // 
            // lblContacNo
            // 
            this.lblContacNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContacNo.Location = new System.Drawing.Point(104, 32);
            this.lblContacNo.Name = "lblContacNo";
            this.lblContacNo.Size = new System.Drawing.Size(189, 20);
            this.lblContacNo.TabIndex = 128;
            this.lblContacNo.Text = "ContactNo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 129;
            this.label1.Text = "Complainer";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 130;
            this.label2.Text = "Contact No";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 131;
            this.label3.Text = "Complain Detail";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 32);
            this.label4.TabIndex = 132;
            this.label4.Text = "Action";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(305, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 134;
            this.label5.Text = "Complain No";
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainNo.Location = new System.Drawing.Point(393, 9);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(84, 19);
            this.lblComplainNo.TabIndex = 133;
            this.lblComplainNo.Text = "ComplainNo";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(305, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 136;
            this.label6.Text = "Action Date";
            // 
            // lblActionDate
            // 
            this.lblActionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActionDate.Location = new System.Drawing.Point(393, 33);
            this.lblActionDate.Name = "lblActionDate";
            this.lblActionDate.Size = new System.Drawing.Size(84, 19);
            this.lblActionDate.TabIndex = 135;
            this.lblActionDate.Text = "ActionDate";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(403, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 137;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmComplainHappyCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 314);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblActionDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblContacNo);
            this.Controls.Add(this.lblComplainer);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblComplainDetail);
            this.Controls.Add(this.chkFurtherActionRequired);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHappyCallDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHappyDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComplainHappyCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Happy Call Against Complain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHappyDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHappyCallDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDissatisfy;
        private System.Windows.Forms.RadioButton rdbModerate;
        private System.Windows.Forms.RadioButton rdbSatisfy;
        private System.Windows.Forms.CheckBox chkFurtherActionRequired;
        private System.Windows.Forms.Label lblComplainDetail;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblComplainer;
        private System.Windows.Forms.Label lblContacNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblActionDate;
        private System.Windows.Forms.Button btnCancel;
    }
}