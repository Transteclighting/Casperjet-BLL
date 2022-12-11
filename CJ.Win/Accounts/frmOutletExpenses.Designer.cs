namespace CJ.Win.Accounts
{
    partial class frmOutletExpenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletExpenses));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.txtMSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMRatePerSqFeet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMVAT = new System.Windows.Forms.TextBox();
            this.txtMAdvance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtUpcomingRenewalDate = new System.Windows.Forms.DateTimePicker();
            this.dtMAgreementStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWHName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRatePerSqFeet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAdvance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAgreementStartDate = new RSMS.BaseItems.DateTimePickerColumn();
            this.txtUpComingRenewalDate = new RSMS.BaseItems.DateTimePickerColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Outlet:";
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(119, 19);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(263, 21);
            this.cmbOutlet.TabIndex = 39;
            // 
            // txtMSpace
            // 
            this.txtMSpace.Location = new System.Drawing.Point(119, 46);
            this.txtMSpace.Name = "txtMSpace";
            this.txtMSpace.Size = new System.Drawing.Size(166, 20);
            this.txtMSpace.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Space (Square Feet):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Rate Per Square Feet";
            // 
            // txtMRatePerSqFeet
            // 
            this.txtMRatePerSqFeet.Location = new System.Drawing.Point(119, 72);
            this.txtMRatePerSqFeet.Name = "txtMRatePerSqFeet";
            this.txtMRatePerSqFeet.Size = new System.Drawing.Size(166, 20);
            this.txtMRatePerSqFeet.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Vat";
            // 
            // txtMVAT
            // 
            this.txtMVAT.Location = new System.Drawing.Point(473, 46);
            this.txtMVAT.Name = "txtMVAT";
            this.txtMVAT.Size = new System.Drawing.Size(158, 20);
            this.txtMVAT.TabIndex = 45;
            // 
            // txtMAdvance
            // 
            this.txtMAdvance.Location = new System.Drawing.Point(473, 72);
            this.txtMAdvance.Name = "txtMAdvance";
            this.txtMAdvance.Size = new System.Drawing.Size(158, 20);
            this.txtMAdvance.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Advance Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(347, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "UpcomingRenewal Date";
            // 
            // dtUpcomingRenewalDate
            // 
            this.dtUpcomingRenewalDate.CustomFormat = "dd-MMM-yyyy";
            this.dtUpcomingRenewalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtUpcomingRenewalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUpcomingRenewalDate.Location = new System.Drawing.Point(473, 98);
            this.dtUpcomingRenewalDate.Name = "dtUpcomingRenewalDate";
            this.dtUpcomingRenewalDate.Size = new System.Drawing.Size(158, 20);
            this.dtUpcomingRenewalDate.TabIndex = 52;
            // 
            // dtMAgreementStartDate
            // 
            this.dtMAgreementStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtMAgreementStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMAgreementStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMAgreementStartDate.Location = new System.Drawing.Point(119, 98);
            this.dtMAgreementStartDate.Name = "dtMAgreementStartDate";
            this.dtMAgreementStartDate.Size = new System.Drawing.Size(166, 20);
            this.dtMAgreementStartDate.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Agreement Start Date";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtWHName,
            this.txtSpace,
            this.txtRatePerSqFeet,
            this.txtVAT,
            this.txtAdvance,
            this.txtAgreementStartDate,
            this.txtUpComingRenewalDate,
            this.txtID});
            this.dgvLineItem.Location = new System.Drawing.Point(6, 19);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(635, 208);
            this.dgvLineItem.TabIndex = 53;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(589, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(508, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbOutlet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMSpace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtUpcomingRenewalDate);
            this.groupBox1.Controls.Add(this.txtMRatePerSqFeet);
            this.groupBox1.Controls.Add(this.dtMAgreementStartDate);
            this.groupBox1.Controls.Add(this.txtMVAT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMAdvance);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(16, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 131);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Warehouse";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLineItem);
            this.groupBox2.Location = new System.Drawing.Point(16, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 241);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub Warehouse";
            // 
            // txtWHName
            // 
            this.txtWHName.HeaderText = "WH Name";
            this.txtWHName.Name = "txtWHName";
            this.txtWHName.Width = 180;
            // 
            // txtSpace
            // 
            this.txtSpace.HeaderText = "Space (Sq. Feet)";
            this.txtSpace.Name = "txtSpace";
            this.txtSpace.Width = 75;
            // 
            // txtRatePerSqFeet
            // 
            this.txtRatePerSqFeet.HeaderText = "Rate (Per Sq. Feet)";
            this.txtRatePerSqFeet.Name = "txtRatePerSqFeet";
            this.txtRatePerSqFeet.Width = 75;
            // 
            // txtVAT
            // 
            this.txtVAT.HeaderText = "VAT";
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Width = 75;
            // 
            // txtAdvance
            // 
            this.txtAdvance.HeaderText = "Advance Amount";
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.Width = 75;
            // 
            // txtAgreementStartDate
            // 
            this.txtAgreementStartDate.HeaderText = "Agreement Start Date";
            this.txtAgreementStartDate.Name = "txtAgreementStartDate";
            this.txtAgreementStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtAgreementStartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtUpComingRenewalDate
            // 
            this.txtUpComingRenewalDate.HeaderText = "Upcoming Renewal Date";
            this.txtUpComingRenewalDate.Name = "txtUpComingRenewalDate";
            this.txtUpComingRenewalDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtUpComingRenewalDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtID
            // 
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // frmOutletExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutletExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Expenses";
            this.Load += new System.EventHandler(this.frmOutletExpenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.TextBox txtMSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMRatePerSqFeet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMVAT;
        private System.Windows.Forms.TextBox txtMAdvance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtUpcomingRenewalDate;
        private System.Windows.Forms.DateTimePicker dtMAgreementStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWHName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRatePerSqFeet;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAdvance;
        private RSMS.BaseItems.DateTimePickerColumn txtAgreementStartDate;
        private RSMS.BaseItems.DateTimePickerColumn txtUpComingRenewalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
    }
}