namespace CJ.Win.CSD
{
    partial class frmCSDJobSummeryDateWiseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSDJobSummeryDateWiseReport));
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoOtherBrand = new System.Windows.Forms.RadioButton();
            this.rdoSamsung = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(76, 23);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtFromDate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date From: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To: ";
            // 
            // dtToDate
            // 
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(210, 23);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(104, 20);
            this.dtToDate.TabIndex = 7;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(250, 58);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(64, 27);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "View";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoOtherBrand);
            this.groupBox2.Controls.Add(this.rdoSamsung);
            this.groupBox2.Location = new System.Drawing.Point(78, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 41);
            this.groupBox2.TabIndex = 195;
            this.groupBox2.TabStop = false;
            // 
            // rdoOtherBrand
            // 
            this.rdoOtherBrand.AutoSize = true;
            this.rdoOtherBrand.Checked = true;
            this.rdoOtherBrand.Location = new System.Drawing.Point(6, 14);
            this.rdoOtherBrand.Name = "rdoOtherBrand";
            this.rdoOtherBrand.Size = new System.Drawing.Size(82, 17);
            this.rdoOtherBrand.TabIndex = 188;
            this.rdoOtherBrand.TabStop = true;
            this.rdoOtherBrand.Text = "Other Brand";
            this.rdoOtherBrand.UseVisualStyleBackColor = true;
            // 
            // rdoSamsung
            // 
            this.rdoSamsung.AutoSize = true;
            this.rdoSamsung.Location = new System.Drawing.Point(88, 14);
            this.rdoSamsung.Name = "rdoSamsung";
            this.rdoSamsung.Size = new System.Drawing.Size(69, 17);
            this.rdoSamsung.TabIndex = 189;
            this.rdoSamsung.Text = "Samsung";
            this.rdoSamsung.UseVisualStyleBackColor = true;
            // 
            // frmCSDJobSummeryDateWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 99);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCSDJobSummeryDateWiseReport";
            this.Text = "CSD Job Summery Date Wise Report";
            this.Load += new System.EventHandler(this.frmCSDJobSummeryDateWiseReport_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoOtherBrand;
        private System.Windows.Forms.RadioButton rdoSamsung;
    }
}