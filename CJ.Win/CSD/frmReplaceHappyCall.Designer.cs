namespace CJ.Win
{
    partial class frmReplaceHappyCall
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
            this.txtHappyDetails = new System.Windows.Forms.TextBox();
            this.lblHappyCallDetails = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDissatisfy = new System.Windows.Forms.RadioButton();
            this.rdbModerate = new System.Windows.Forms.RadioButton();
            this.rdbSatisfy = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReplaceID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(319, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHappyDetails
            // 
            this.txtHappyDetails.Location = new System.Drawing.Point(25, 157);
            this.txtHappyDetails.Multiline = true;
            this.txtHappyDetails.Name = "txtHappyDetails";
            this.txtHappyDetails.Size = new System.Drawing.Size(492, 58);
            this.txtHappyDetails.TabIndex = 3;
            // 
            // lblHappyCallDetails
            // 
            this.lblHappyCallDetails.AutoSize = true;
            this.lblHappyCallDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHappyCallDetails.Location = new System.Drawing.Point(22, 139);
            this.lblHappyCallDetails.Name = "lblHappyCallDetails";
            this.lblHappyCallDetails.Size = new System.Drawing.Size(64, 13);
            this.lblHappyCallDetails.TabIndex = 122;
            this.lblHappyCallDetails.Text = "Comments";
            this.lblHappyCallDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDissatisfy);
            this.groupBox1.Controls.Add(this.rdbModerate);
            this.groupBox1.Controls.Add(this.rdbSatisfy);
            this.groupBox1.Location = new System.Drawing.Point(25, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 37);
            this.groupBox1.TabIndex = 124;
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
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblContactNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblReplaceID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblCustomerName);
            this.groupBox3.Controls.Add(this.lblJobNo);
            this.groupBox3.Location = new System.Drawing.Point(15, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 68);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 152;
            this.label3.Text = "Contact No";
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContactNo.Location = new System.Drawing.Point(312, 40);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(172, 20);
            this.lblContactNo.TabIndex = 151;
            this.lblContactNo.Text = "ContactNo";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 150;
            this.label5.Text = "Replace ID";
            // 
            // lblReplaceID
            // 
            this.lblReplaceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReplaceID.Location = new System.Drawing.Point(90, 15);
            this.lblReplaceID.Name = "lblReplaceID";
            this.lblReplaceID.Size = new System.Drawing.Size(105, 19);
            this.lblReplaceID.TabIndex = 149;
            this.lblReplaceID.Text = "ReplaceID";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 147;
            this.label1.Text = "Job No";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerName.Location = new System.Drawing.Point(312, 14);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(172, 20);
            this.lblCustomerName.TabIndex = 146;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblJobNo
            // 
            this.lblJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobNo.Location = new System.Drawing.Point(91, 41);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(104, 19);
            this.lblJobNo.TabIndex = 145;
            this.lblJobNo.Text = "JobNo";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(413, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 27);
            this.btnCancel.TabIndex = 155;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReplaceHappyCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHappyCallDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHappyDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceHappyCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Happy Call";
            this.Load += new System.EventHandler(this.frmComplainHappyCall_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHappyDetails;
        private System.Windows.Forms.Label lblHappyCallDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDissatisfy;
        private System.Windows.Forms.RadioButton rdbModerate;
        private System.Windows.Forms.RadioButton rdbSatisfy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReplaceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.Button btnCancel;
    }
}