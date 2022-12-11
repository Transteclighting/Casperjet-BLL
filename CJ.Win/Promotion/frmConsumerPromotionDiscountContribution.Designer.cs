namespace CJ.Win.Promotion
{
    partial class frmConsumerPromotionDiscountContribution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumerPromotionDiscountContribution));
            this.dgvContribution = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContributionAmount = new System.Windows.Forms.TextBox();
            this.cmbContributor = new System.Windows.Forms.ComboBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.rdoDiscountPercent = new System.Windows.Forms.RadioButton();
            this.rdoFlatAmt = new System.Windows.Forms.RadioButton();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtContributorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtContributorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribution)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContribution
            // 
            this.dgvContribution.AllowUserToAddRows = false;
            this.dgvContribution.CausesValidation = false;
            this.dgvContribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContribution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtContributorName,
            this.txtAmount,
            this.txtContributorID,
            this.txtType});
            this.dgvContribution.Location = new System.Drawing.Point(12, 68);
            this.dgvContribution.Name = "dgvContribution";
            this.dgvContribution.ReadOnly = true;
            this.dgvContribution.Size = new System.Drawing.Size(509, 145);
            this.dgvContribution.TabIndex = 8;
            this.dgvContribution.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvContribution_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contributor";
            // 
            // txtContributionAmount
            // 
            this.txtContributionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtContributionAmount.Location = new System.Drawing.Point(292, 41);
            this.txtContributionAmount.Name = "txtContributionAmount";
            this.txtContributionAmount.Size = new System.Drawing.Size(86, 21);
            this.txtContributionAmount.TabIndex = 5;
            // 
            // cmbContributor
            // 
            this.cmbContributor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContributor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbContributor.FormattingEnabled = true;
            this.cmbContributor.Location = new System.Drawing.Point(82, 12);
            this.cmbContributor.Name = "cmbContributor";
            this.cmbContributor.Size = new System.Drawing.Size(439, 23);
            this.cmbContributor.TabIndex = 1;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalAmount.Location = new System.Drawing.Point(415, 219);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(106, 21);
            this.txtTotalAmount.TabIndex = 10;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(360, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Amount";
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSet.Location = new System.Drawing.Point(444, 246);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(77, 26);
            this.btnSet.TabIndex = 11;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddToList.Location = new System.Drawing.Point(444, 37);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(77, 26);
            this.btnAddToList.TabIndex = 7;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // rdoDiscountPercent
            // 
            this.rdoDiscountPercent.AutoSize = true;
            this.rdoDiscountPercent.Location = new System.Drawing.Point(149, 41);
            this.rdoDiscountPercent.Name = "rdoDiscountPercent";
            this.rdoDiscountPercent.Size = new System.Drawing.Size(62, 17);
            this.rdoDiscountPercent.TabIndex = 3;
            this.rdoDiscountPercent.Text = "Percent";
            this.rdoDiscountPercent.UseVisualStyleBackColor = true;
            this.rdoDiscountPercent.CheckedChanged += new System.EventHandler(this.rdoDiscountPercent_CheckedChanged);
            // 
            // rdoFlatAmt
            // 
            this.rdoFlatAmt.AutoSize = true;
            this.rdoFlatAmt.Checked = true;
            this.rdoFlatAmt.Location = new System.Drawing.Point(82, 41);
            this.rdoFlatAmt.Name = "rdoFlatAmt";
            this.rdoFlatAmt.Size = new System.Drawing.Size(61, 17);
            this.rdoFlatAmt.TabIndex = 2;
            this.rdoFlatAmt.TabStop = true;
            this.rdoFlatAmt.Text = "Amount";
            this.rdoFlatAmt.UseVisualStyleBackColor = true;
            this.rdoFlatAmt.CheckedChanged += new System.EventHandler(this.rdoFlatAmt_CheckedChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(223, 43);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(63, 13);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Contribution";
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Location = new System.Drawing.Point(384, 43);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(49, 13);
            this.lblDiscountType.TabIndex = 6;
            this.lblDiscountType.Text = "(Amount)";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Contributor";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 365;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ContributorID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // txtContributorName
            // 
            this.txtContributorName.HeaderText = "Contributor";
            this.txtContributorName.Name = "txtContributorName";
            this.txtContributorName.ReadOnly = true;
            this.txtContributorName.Width = 365;
            // 
            // txtAmount
            // 
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            // 
            // txtContributorID
            // 
            this.txtContributorID.HeaderText = "ContributorID";
            this.txtContributorID.Name = "txtContributorID";
            this.txtContributorID.ReadOnly = true;
            this.txtContributorID.Visible = false;
            // 
            // txtType
            // 
            this.txtType.HeaderText = "Type";
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Visible = false;
            // 
            // frmConsumerPromotionDiscountContribution
            // 
            this.AcceptButton = this.btnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 279);
            this.Controls.Add(this.lblDiscountType);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.rdoDiscountPercent);
            this.Controls.Add(this.rdoFlatAmt);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.cmbContributor);
            this.Controls.Add(this.txtContributionAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvContribution);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsumerPromotionDiscountContribution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Promotion Discount Contribution";
            this.Load += new System.EventHandler(this.frmConsumerPromotionDiscountContribution_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContribution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContribution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContributionAmount;
        private System.Windows.Forms.ComboBox cmbContributor;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.RadioButton rdoDiscountPercent;
        private System.Windows.Forms.RadioButton rdoFlatAmt;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtContributorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtContributorName;
    }
}