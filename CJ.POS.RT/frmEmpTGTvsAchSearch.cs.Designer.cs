namespace CJ.POS.RT
{
    partial class frmEmpTGTvsAchSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpTGTvsAchSearch));
            this.lblYear = new System.Windows.Forms.Label();
            this.rdoByMonth = new System.Windows.Forms.RadioButton();
            this.rdoByWeek = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtWeek = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpoyee = new System.Windows.Forms.ComboBox();
            this.lblSalesPerson = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(14, 16);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(70, 15);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "Month/Year";
            // 
            // rdoByMonth
            // 
            this.rdoByMonth.AutoSize = true;
            this.rdoByMonth.Checked = true;
            this.rdoByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoByMonth.Location = new System.Drawing.Point(92, 45);
            this.rdoByMonth.Name = "rdoByMonth";
            this.rdoByMonth.Size = new System.Drawing.Size(68, 19);
            this.rdoByMonth.TabIndex = 13;
            this.rdoByMonth.TabStop = true;
            this.rdoByMonth.Text = "Monthly";
            this.rdoByMonth.UseVisualStyleBackColor = true;
            this.rdoByMonth.CheckedChanged += new System.EventHandler(this.rdoByMonth_CheckedChanged);
            // 
            // rdoByWeek
            // 
            this.rdoByWeek.AutoSize = true;
            this.rdoByWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoByWeek.Location = new System.Drawing.Point(233, 49);
            this.rdoByWeek.Name = "rdoByWeek";
            this.rdoByWeek.Size = new System.Drawing.Size(64, 19);
            this.rdoByWeek.TabIndex = 14;
            this.rdoByWeek.Text = "Weekly";
            this.rdoByWeek.UseVisualStyleBackColor = true;
            this.rdoByWeek.CheckedChanged += new System.EventHandler(this.rdoByWeek_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Report Type:";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(222, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Preview ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtWeek
            // 
            this.dtWeek.CustomFormat = "MMM-yyyy";
            this.dtWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWeek.Location = new System.Drawing.Point(90, 15);
            this.dtWeek.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtWeek.Name = "dtWeek";
            this.dtWeek.ShowUpDown = true;
            this.dtWeek.Size = new System.Drawing.Size(132, 21);
            this.dtWeek.TabIndex = 18;
            this.dtWeek.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            // 
            // cmbEmpoyee
            // 
            this.cmbEmpoyee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpoyee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpoyee.FormattingEnabled = true;
            this.cmbEmpoyee.Location = new System.Drawing.Point(90, 42);
            this.cmbEmpoyee.Name = "cmbEmpoyee";
            this.cmbEmpoyee.Size = new System.Drawing.Size(314, 23);
            this.cmbEmpoyee.TabIndex = 20;
            // 
            // lblSalesPerson
            // 
            this.lblSalesPerson.AutoSize = true;
            this.lblSalesPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesPerson.Location = new System.Drawing.Point(3, 45);
            this.lblSalesPerson.Name = "lblSalesPerson";
            this.lblSalesPerson.Size = new System.Drawing.Size(83, 15);
            this.lblSalesPerson.TabIndex = 19;
            this.lblSalesPerson.Text = "Sales Person:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(317, 79);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(90, 15);
            this.dtDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.ShowUpDown = true;
            this.dtDate.Size = new System.Drawing.Size(132, 21);
            this.dtDate.TabIndex = 10;
            this.dtDate.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            // 
            // frmEmpTGTvsAchSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 120);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbEmpoyee);
            this.Controls.Add(this.lblSalesPerson);
            this.Controls.Add(this.dtWeek);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoByWeek);
            this.Controls.Add(this.rdoByMonth);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblYear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmpTGTvsAchSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emp TGT vs Ach Search";
            this.Load += new System.EventHandler(this.frmEmpTGTvsAchSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.RadioButton rdoByMonth;
        private System.Windows.Forms.RadioButton rdoByWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtWeek;
        private System.Windows.Forms.ComboBox cmbEmpoyee;
        private System.Windows.Forms.Label lblSalesPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}