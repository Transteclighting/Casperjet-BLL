namespace CJ.Win.Basic
{
    partial class frmCustomerCreditLimit
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
            this.Code = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinCredit = new System.Windows.Forms.TextBox();
            this.txtMaxCredLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPickerEffDate = new System.Windows.Forms.DateTimePicker();
            this.lvwCreLimitCusttomer = new System.Windows.Forms.ListView();
            this.CreditLimitID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLimitExpiryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMinCreditLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxCreditLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGateData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Code
            // 
            this.Code.AutoSize = true;
            this.Code.Location = new System.Drawing.Point(13, 22);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(32, 13);
            this.Code.TabIndex = 5;
            this.Code.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Expiry Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min Credit Limit";
            // 
            // dateTimePicExpiryDate
            // 
            this.dateTimePicExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicExpiryDate.Location = new System.Drawing.Point(97, 78);
            this.dateTimePicExpiryDate.Name = "dateTimePicExpiryDate";
            this.dateTimePicExpiryDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicExpiryDate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Max Credit Limit";
            // 
            // txtMinCredit
            // 
            this.txtMinCredit.Location = new System.Drawing.Point(98, 111);
            this.txtMinCredit.Name = "txtMinCredit";
            this.txtMinCredit.Size = new System.Drawing.Size(100, 20);
            this.txtMinCredit.TabIndex = 13;
            // 
            // txtMaxCredLimit
            // 
            this.txtMaxCredLimit.Location = new System.Drawing.Point(97, 152);
            this.txtMaxCredLimit.Name = "txtMaxCredLimit";
            this.txtMaxCredLimit.Size = new System.Drawing.Size(100, 20);
            this.txtMaxCredLimit.TabIndex = 14;
            this.txtMaxCredLimit.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Effective Date";
            // 
            // dtPickerEffDate
            // 
            this.dtPickerEffDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerEffDate.Location = new System.Drawing.Point(97, 46);
            this.dtPickerEffDate.Name = "dtPickerEffDate";
            this.dtPickerEffDate.Size = new System.Drawing.Size(100, 20);
            this.dtPickerEffDate.TabIndex = 17;
            // 
            // lvwCreLimitCusttomer
            // 
            this.lvwCreLimitCusttomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCreLimitCusttomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreditLimitID,
            this.colCreateDate,
            this.colLimitExpiryDate,
            this.colMinCreditLimit,
            this.colMaxCreditLimit});
            this.lvwCreLimitCusttomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCreLimitCusttomer.FullRowSelect = true;
            this.lvwCreLimitCusttomer.GridLines = true;
            this.lvwCreLimitCusttomer.HideSelection = false;
            this.lvwCreLimitCusttomer.Location = new System.Drawing.Point(215, 43);
            this.lvwCreLimitCusttomer.MultiSelect = false;
            this.lvwCreLimitCusttomer.Name = "lvwCreLimitCusttomer";
            this.lvwCreLimitCusttomer.Size = new System.Drawing.Size(578, 180);
            this.lvwCreLimitCusttomer.TabIndex = 18;
            this.lvwCreLimitCusttomer.UseCompatibleStateImageBehavior = false;
            this.lvwCreLimitCusttomer.View = System.Windows.Forms.View.Details;
            // 
            // CreditLimitID
            // 
            this.CreditLimitID.DisplayIndex = 4;
            this.CreditLimitID.Text = "colCreditLimitID";
            this.CreditLimitID.Width = 0;
            // 
            // colCreateDate
            // 
            this.colCreateDate.DisplayIndex = 0;
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 115;
            // 
            // colLimitExpiryDate
            // 
            this.colLimitExpiryDate.DisplayIndex = 1;
            this.colLimitExpiryDate.Text = "Limit Expiry Date";
            this.colLimitExpiryDate.Width = 132;
            // 
            // colMinCreditLimit
            // 
            this.colMinCreditLimit.DisplayIndex = 2;
            this.colMinCreditLimit.Text = "Min Credit Limit";
            this.colMinCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMinCreditLimit.Width = 120;
            // 
            // colMaxCreditLimit
            // 
            this.colMaxCreditLimit.DisplayIndex = 3;
            this.colMaxCreditLimit.Text = "Max Credit Limit";
            this.colMaxCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMaxCreditLimit.Width = 150;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(97, 12);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(400, 25);
            this.ctlCustomer1.TabIndex = 15;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(112, 205);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGateData
            // 
            this.btnGateData.Location = new System.Drawing.Point(503, 12);
            this.btnGateData.Name = "btnGateData";
            this.btnGateData.Size = new System.Drawing.Size(75, 23);
            this.btnGateData.TabIndex = 20;
            this.btnGateData.Text = "GetData";
            this.btnGateData.UseVisualStyleBackColor = true;
            this.btnGateData.Click += new System.EventHandler(this.btnGateData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(718, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCustomerCreditLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 253);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGateData);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lvwCreLimitCusttomer);
            this.Controls.Add(this.dtPickerEffDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.txtMaxCredLimit);
            this.Controls.Add(this.txtMinCredit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicExpiryDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCustomerCreditLimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomerCreditLimit";
            this.Load += new System.EventHandler(this.frmCustomerCreditLimit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label Code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicExpiryDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinCredit;
        private System.Windows.Forms.TextBox txtMaxCredLimit;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPickerEffDate;
        private System.Windows.Forms.ListView lvwCreLimitCusttomer;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colLimitExpiryDate;
        private System.Windows.Forms.ColumnHeader colMinCreditLimit;
        private System.Windows.Forms.ColumnHeader colMaxCreditLimit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnGateData;
        private System.Windows.Forms.ColumnHeader CreditLimitID;
        private System.Windows.Forms.Button btnClose;

    }
}