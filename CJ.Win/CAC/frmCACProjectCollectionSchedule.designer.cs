namespace CJ.Win.CAC
{
    partial class frmCACProjectCollectionSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjectCollectionSchedule));
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPaymentDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPaymentMethodValue = new System.Windows.Forms.TextBox();
            this.dgvPaymentMethod = new System.Windows.Forms.DataGridView();
            this.txtSecurityName = new CJ.Win.Control.CalenderControl();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCompletePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPaymentMethodAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPaymentMethodTotalAmt = new System.Windows.Forms.TextBox();
            this.btnAddtolist = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCompletePer = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethod)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(85, 10);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(90, 20);
            this.dtDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Date:";
            // 
            // txtPaymentDescription
            // 
            this.txtPaymentDescription.Location = new System.Drawing.Point(259, 11);
            this.txtPaymentDescription.Name = "txtPaymentDescription";
            this.txtPaymentDescription.Size = new System.Drawing.Size(260, 21);
            this.txtPaymentDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(228, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Amount";
            // 
            // txtPaymentMethodValue
            // 
            this.txtPaymentMethodValue.Location = new System.Drawing.Point(283, 40);
            this.txtPaymentMethodValue.Name = "txtPaymentMethodValue";
            this.txtPaymentMethodValue.Size = new System.Drawing.Size(149, 21);
            this.txtPaymentMethodValue.TabIndex = 7;
            this.txtPaymentMethodValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentMethodValue_KeyPress);
            // 
            // dgvPaymentMethod
            // 
            this.dgvPaymentMethod.AllowUserToAddRows = false;
            this.dgvPaymentMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentMethod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSecurityName,
            this.txtDescription,
            this.txtCompletePercentage,
            this.txtPaymentMethodAmount});
            this.dgvPaymentMethod.Location = new System.Drawing.Point(14, 68);
            this.dgvPaymentMethod.Name = "dgvPaymentMethod";
            this.dgvPaymentMethod.Size = new System.Drawing.Size(506, 146);
            this.dgvPaymentMethod.TabIndex = 9;
            this.dgvPaymentMethod.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPaymentMethod_RowsRemoved);
            // 
            // txtSecurityName
            // 
            this.txtSecurityName.HeaderText = "Date";
            this.txtSecurityName.Name = "txtSecurityName";
            this.txtSecurityName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtSecurityName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtDescription
            // 
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Width = 120;
            // 
            // txtCompletePercentage
            // 
            this.txtCompletePercentage.HeaderText = "Complete (%)";
            this.txtCompletePercentage.Name = "txtCompletePercentage";
            this.txtCompletePercentage.ReadOnly = true;
            this.txtCompletePercentage.Width = 120;
            // 
            // txtPaymentMethodAmount
            // 
            this.txtPaymentMethodAmount.HeaderText = "Amount";
            this.txtPaymentMethodAmount.Name = "txtPaymentMethodAmount";
            this.txtPaymentMethodAmount.ReadOnly = true;
            this.txtPaymentMethodAmount.Width = 125;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(404, 224);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 15);
            this.label25.TabIndex = 10;
            this.label25.Text = "Total:";
            // 
            // txtPaymentMethodTotalAmt
            // 
            this.txtPaymentMethodTotalAmt.Location = new System.Drawing.Point(442, 221);
            this.txtPaymentMethodTotalAmt.Name = "txtPaymentMethodTotalAmt";
            this.txtPaymentMethodTotalAmt.ReadOnly = true;
            this.txtPaymentMethodTotalAmt.Size = new System.Drawing.Size(78, 21);
            this.txtPaymentMethodTotalAmt.TabIndex = 11;
            this.txtPaymentMethodTotalAmt.Text = "0";
            this.txtPaymentMethodTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaymentMethodTotalAmt.TextChanged += new System.EventHandler(this.txtPaymentMethodTotalAmt_TextChanged);
            // 
            // btnAddtolist
            // 
            this.btnAddtolist.Location = new System.Drawing.Point(441, 39);
            this.btnAddtolist.Name = "btnAddtolist";
            this.btnAddtolist.Size = new System.Drawing.Size(78, 23);
            this.btnAddtolist.TabIndex = 8;
            this.btnAddtolist.Text = "Add to List";
            this.btnAddtolist.UseVisualStyleBackColor = true;
            this.btnAddtolist.Click += new System.EventHandler(this.btnAddtolist_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Complete %";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(445, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCompletePer
            // 
            this.txtCompletePer.Location = new System.Drawing.Point(85, 41);
            this.txtCompletePer.Name = "txtCompletePer";
            this.txtCompletePer.Size = new System.Drawing.Size(137, 21);
            this.txtCompletePer.TabIndex = 5;
            this.txtCompletePer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompletePer_KeyPress);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Complete (%)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // frmCACProjectCollectionSchedule
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 284);
            this.Controls.Add(this.txtCompletePer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvPaymentMethod);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtPaymentMethodTotalAmt);
            this.Controls.Add(this.btnAddtolist);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPaymentMethodValue);
            this.Controls.Add(this.txtPaymentDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjectCollectionSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Project Payment Method";
            this.Load += new System.EventHandler(this.frmCACProjectCollectionSchedule_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPaymentDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPaymentMethodValue;
        private System.Windows.Forms.DataGridView dgvPaymentMethod;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPaymentMethodTotalAmt;
        private System.Windows.Forms.Button btnAddtolist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCompletePer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Control.CalenderControl txtSecurityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompletePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPaymentMethodAmount;
    }
}