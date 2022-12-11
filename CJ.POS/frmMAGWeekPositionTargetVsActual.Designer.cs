namespace CJ.POS
{
    partial class frmMAGWeekPositionTargetVsActual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMAGWeekPositionTargetVsActual));
            this.btnClose = new System.Windows.Forms.Button();
            this.dtMonth = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesPerson = new System.Windows.Forms.Label();
            this.cmbEmpoyee = new System.Windows.Forms.ComboBox();
            this.rdoExecutiveWise = new System.Windows.Forms.RadioButton();
            this.rdoABMWise = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(309, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtMonth
            // 
            this.dtMonth.CustomFormat = "MMM-yyyy";
            this.dtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMonth.Location = new System.Drawing.Point(98, 14);
            this.dtMonth.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.ShowUpDown = true;
            this.dtMonth.Size = new System.Drawing.Size(117, 21);
            this.dtMonth.TabIndex = 1;
            this.dtMonth.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            this.dtMonth.ValueChanged += new System.EventHandler(this.dtMonth_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(215, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Preview ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(22, 17);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(70, 15);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Month/Year";
            // 
            // cmbWeek
            // 
            this.cmbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Location = new System.Drawing.Point(291, 14);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(105, 23);
            this.cmbWeek.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Week";
            // 
            // lblSalesPerson
            // 
            this.lblSalesPerson.AutoSize = true;
            this.lblSalesPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesPerson.Location = new System.Drawing.Point(12, 67);
            this.lblSalesPerson.Name = "lblSalesPerson";
            this.lblSalesPerson.Size = new System.Drawing.Size(80, 15);
            this.lblSalesPerson.TabIndex = 6;
            this.lblSalesPerson.Text = "Sales Person";
            this.lblSalesPerson.Visible = false;
            // 
            // cmbEmpoyee
            // 
            this.cmbEmpoyee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpoyee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpoyee.FormattingEnabled = true;
            this.cmbEmpoyee.Location = new System.Drawing.Point(98, 64);
            this.cmbEmpoyee.Name = "cmbEmpoyee";
            this.cmbEmpoyee.Size = new System.Drawing.Size(298, 23);
            this.cmbEmpoyee.TabIndex = 7;
            this.cmbEmpoyee.Visible = false;
            // 
            // rdoExecutiveWise
            // 
            this.rdoExecutiveWise.AutoSize = true;
            this.rdoExecutiveWise.Checked = true;
            this.rdoExecutiveWise.Location = new System.Drawing.Point(98, 39);
            this.rdoExecutiveWise.Name = "rdoExecutiveWise";
            this.rdoExecutiveWise.Size = new System.Drawing.Size(107, 19);
            this.rdoExecutiveWise.TabIndex = 4;
            this.rdoExecutiveWise.TabStop = true;
            this.rdoExecutiveWise.Text = "Executive Wise";
            this.rdoExecutiveWise.UseVisualStyleBackColor = true;
            this.rdoExecutiveWise.Visible = false;
            // 
            // rdoABMWise
            // 
            this.rdoABMWise.AutoSize = true;
            this.rdoABMWise.Location = new System.Drawing.Point(215, 39);
            this.rdoABMWise.Name = "rdoABMWise";
            this.rdoABMWise.Size = new System.Drawing.Size(81, 19);
            this.rdoABMWise.TabIndex = 5;
            this.rdoABMWise.Text = "ABM Wise";
            this.rdoABMWise.UseVisualStyleBackColor = true;
            this.rdoABMWise.Visible = false;
            // 
            // frmMAGWeekPositionTargetVsActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 127);
            this.Controls.Add(this.rdoABMWise);
            this.Controls.Add(this.rdoExecutiveWise);
            this.Controls.Add(this.cmbEmpoyee);
            this.Controls.Add(this.lblSalesPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbWeek);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtMonth);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMAGWeekPositionTargetVsActual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category wise Target Vs Actual";
            this.Load += new System.EventHandler(this.frmMAGWeekTargetPositionVsActual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtMonth;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalesPerson;
        private System.Windows.Forms.ComboBox cmbEmpoyee;
        private System.Windows.Forms.RadioButton rdoExecutiveWise;
        private System.Windows.Forms.RadioButton rdoABMWise;
    }
}