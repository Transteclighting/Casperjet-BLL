namespace CJ.Win.CSD
{
    partial class frmDailySalesCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailySalesCollection));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.cmbBrandType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServiceCenter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(230, 107);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 31);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(94, 13);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(123, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // cmbBrandType
            // 
            this.cmbBrandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrandType.FormattingEnabled = true;
            this.cmbBrandType.Items.AddRange(new object[] {
            "All",
            "Samsung",
            "Other"});
            this.cmbBrandType.Location = new System.Drawing.Point(94, 43);
            this.cmbBrandType.Name = "cmbBrandType";
            this.cmbBrandType.Size = new System.Drawing.Size(229, 24);
            this.cmbBrandType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brand";
            // 
            // cmbServiceCenter
            // 
            this.cmbServiceCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceCenter.FormattingEnabled = true;
            this.cmbServiceCenter.Items.AddRange(new object[] {
            "All",
            "Samsung",
            "Other"});
            this.cmbServiceCenter.Location = new System.Drawing.Point(94, 76);
            this.cmbServiceCenter.Name = "cmbServiceCenter";
            this.cmbServiceCenter.Size = new System.Drawing.Size(229, 24);
            this.cmbServiceCenter.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Service Center";
            // 
            // frmDailySalesCollection
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 148);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbServiceCenter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBrandType);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreview);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailySalesCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Sales Collection";
            this.Load += new System.EventHandler(this.frmDailySalesCollection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ComboBox cmbBrandType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServiceCenter;
        private System.Windows.Forms.Label label3;
    }
}