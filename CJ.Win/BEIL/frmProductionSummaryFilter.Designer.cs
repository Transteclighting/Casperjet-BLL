namespace CJ.Win.BEIL
{
    partial class frmProductionSummaryFilter
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblAG = new System.Windows.Forms.Label();
            this.cboAG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cboASG = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.cboMAG = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(445, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Preview";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(36, 41);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(41, 13);
            this.lblBrand.TabIndex = 17;
            this.lblBrand.Text = "Brand: ";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(77, 38);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(147, 21);
            this.cboBrand.TabIndex = 18;
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Location = new System.Drawing.Point(271, 69);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(28, 13);
            this.lblAG.TabIndex = 23;
            this.lblAG.Text = "AG: ";
            // 
            // cboAG
            // 
            this.cboAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAG.FormattingEnabled = true;
            this.cboAG.Location = new System.Drawing.Point(299, 63);
            this.cboAG.Name = "cboAG";
            this.cboAG.Size = new System.Drawing.Size(147, 21);
            this.cboAG.TabIndex = 24;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Location = new System.Drawing.Point(42, 67);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(35, 13);
            this.lblASG.TabIndex = 21;
            this.lblASG.Text = "ASG: ";
            // 
            // cboASG
            // 
            this.cboASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboASG.FormattingEnabled = true;
            this.cboASG.Location = new System.Drawing.Point(77, 64);
            this.cboASG.Name = "cboASG";
            this.cboASG.Size = new System.Drawing.Size(147, 21);
            this.cboASG.TabIndex = 22;
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Location = new System.Drawing.Point(262, 40);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(37, 13);
            this.lblMAG.TabIndex = 19;
            this.lblMAG.Text = "MAG: ";
            // 
            // cboMAG
            // 
            this.cboMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMAG.FormattingEnabled = true;
            this.cboMAG.Location = new System.Drawing.Point(299, 37);
            this.cboMAG.Name = "cboMAG";
            this.cboMAG.Size = new System.Drawing.Size(147, 21);
            this.cboMAG.TabIndex = 20;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(218, 94);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 13);
            this.lblName.TabIndex = 27;
            this.lblName.Text = "Product Name: ";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(-2, 93);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(78, 13);
            this.lblCode.TabIndex = 25;
            this.lblCode.Text = "Product Code: ";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(77, 91);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(135, 20);
            this.txtProductCode.TabIndex = 26;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(299, 90);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(221, 20);
            this.txtProductName.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(299, 8);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(131, 20);
            this.dtToDate.TabIndex = 40;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(77, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(126, 20);
            this.dtFromDate.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Date : ";
            // 
            // frmProductionSummaryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 153);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.lblAG);
            this.Controls.Add(this.cboAG);
            this.Controls.Add(this.lblASG);
            this.Controls.Add(this.cboASG);
            this.Controls.Add(this.lblMAG);
            this.Controls.Add(this.cboMAG);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductName);
            this.Name = "frmProductionSummaryFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionSummaryFilter";
            this.Load += new System.EventHandler(this.frmProductionSummaryFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.ComboBox cboAG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cboASG;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.ComboBox cboMAG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
    }
}