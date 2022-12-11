namespace CJ.Win
{
    partial class frmComplainAssign
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
            this.btnAssign = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
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
            this.lblActionDetails = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(310, 144);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 27);
            this.btnAssign.TabIndex = 113;
            this.btnAssign.Text = "&Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(82, 113);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(408, 25);
            this.ctlEmployee1.TabIndex = 114;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(312, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 158;
            this.label6.Text = "Action Date";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(400, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 157;
            this.label1.Text = "ActionDate";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 156;
            this.label5.Text = "Complain No";
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainNo.Location = new System.Drawing.Point(400, 10);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(84, 19);
            this.lblComplainNo.TabIndex = 155;
            this.lblComplainNo.Text = "ComplainNo";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 154;
            this.label3.Text = "Complain Detail";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 153;
            this.label2.Text = "Contact No";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 152;
            this.label7.Text = "Complainer";
            // 
            // lblContacNo
            // 
            this.lblContacNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContacNo.Location = new System.Drawing.Point(111, 33);
            this.lblContacNo.Name = "lblContacNo";
            this.lblContacNo.Size = new System.Drawing.Size(189, 20);
            this.lblContacNo.TabIndex = 151;
            this.lblContacNo.Text = "ContactNo";
            // 
            // lblComplainer
            // 
            this.lblComplainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainer.Location = new System.Drawing.Point(111, 10);
            this.lblComplainer.Name = "lblComplainer";
            this.lblComplainer.Size = new System.Drawing.Size(189, 19);
            this.lblComplainer.TabIndex = 150;
            this.lblComplainer.Text = "Complainer";
            // 
            // lblComplainDetail
            // 
            this.lblComplainDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComplainDetail.Location = new System.Drawing.Point(111, 57);
            this.lblComplainDetail.Name = "lblComplainDetail";
            this.lblComplainDetail.Size = new System.Drawing.Size(373, 30);
            this.lblComplainDetail.TabIndex = 149;
            this.lblComplainDetail.Text = "ComplainDetail";
            // 
            // lblActionDetails
            // 
            this.lblActionDetails.AutoSize = true;
            this.lblActionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionDetails.Location = new System.Drawing.Point(18, 116);
            this.lblActionDetails.Name = "lblActionDetails";
            this.lblActionDetails.Size = new System.Drawing.Size(63, 13);
            this.lblActionDetails.TabIndex = 159;
            this.lblActionDetails.Text = "Assign To";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(396, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 160;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmComplainAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 179);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblActionDetails);
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
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.btnAssign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComplainAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Complain Assign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAssign;
        private ctlEmployee ctlEmployee1;
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
        private System.Windows.Forms.Label lblActionDetails;
        private System.Windows.Forms.Button btnCancel;
    }
}