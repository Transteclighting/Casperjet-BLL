namespace CJ.Win.HR
{
    partial class frmMobileDatapacClearHistory
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
            this.chkIsDatapacClear = new System.Windows.Forms.CheckBox();
            this.chkIsISDClear = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkIsDatapacClear
            // 
            this.chkIsDatapacClear.AutoSize = true;
            this.chkIsDatapacClear.Location = new System.Drawing.Point(11, 41);
            this.chkIsDatapacClear.Name = "chkIsDatapacClear";
            this.chkIsDatapacClear.Size = new System.Drawing.Size(111, 17);
            this.chkIsDatapacClear.TabIndex = 2;
            this.chkIsDatapacClear.Text = "Is Datapac Clear?";
            this.chkIsDatapacClear.UseVisualStyleBackColor = true;
            // 
            // chkIsISDClear
            // 
            this.chkIsISDClear.AutoSize = true;
            this.chkIsISDClear.Location = new System.Drawing.Point(126, 41);
            this.chkIsISDClear.Name = "chkIsISDClear";
            this.chkIsISDClear.Size = new System.Drawing.Size(88, 17);
            this.chkIsISDClear.TabIndex = 3;
            this.chkIsISDClear.Text = "Is ISD Clear?";
            this.chkIsISDClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Remarks";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(56, 64);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(127, 20);
            this.dtDate.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(56, 91);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(324, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(295, 118);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mobile Number ";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMobileNo.Location = new System.Drawing.Point(88, 14);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(14, 13);
            this.lblMobileNo.TabIndex = 1;
            this.lblMobileNo.Text = "?";
            // 
            // frmMobileDatapacClearHistory
            // 
            this.AcceptButton = this.btnClear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 149);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkIsISDClear);
            this.Controls.Add(this.chkIsDatapacClear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileDatapacClearHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datapac Clear History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsDatapacClear;
        private System.Windows.Forms.CheckBox chkIsISDClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMobileNo;
    }
}