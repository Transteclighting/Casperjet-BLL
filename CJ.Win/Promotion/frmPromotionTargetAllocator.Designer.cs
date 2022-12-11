namespace CJ.Win.Promotion
{
    partial class frmPromotionTargetAllocator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromotionTargetAllocator));
            this.dgvTargetAllocator = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNetSalesVal1 = new System.Windows.Forms.TextBox();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.txtTotalNetVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetQty1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTargetVal1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPromoCostVal1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegSalesQty1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotRegSalesQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotProCostVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotTargetVal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotTargetQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalTargetMC = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTargetMC1 = new System.Windows.Forms.TextBox();
            this.txtSalesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTargetQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTargetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPromoCostValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNetSalesValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRegularSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTargetMC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalesTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetAllocator)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTargetAllocator
            // 
            this.dgvTargetAllocator.AllowUserToAddRows = false;
            this.dgvTargetAllocator.CausesValidation = false;
            this.dgvTargetAllocator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTargetAllocator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSalesType,
            this.txtTargetQty,
            this.txtTargetValue,
            this.txtPromoCostValue,
            this.txtNetSalesValue,
            this.txtRegularSalesQty,
            this.txtTargetMC,
            this.txtSalesTypeID});
            this.dgvTargetAllocator.Location = new System.Drawing.Point(12, 95);
            this.dgvTargetAllocator.Name = "dgvTargetAllocator";
            this.dgvTargetAllocator.ReadOnly = true;
            this.dgvTargetAllocator.Size = new System.Drawing.Size(681, 118);
            this.dgvTargetAllocator.TabIndex = 8;
            this.dgvTargetAllocator.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTargetAllocator_RowsRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Type";
            // 
            // txtNetSalesVal1
            // 
            this.txtNetSalesVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNetSalesVal1.Location = new System.Drawing.Point(607, 41);
            this.txtNetSalesVal1.Name = "txtNetSalesVal1";
            this.txtNetSalesVal1.Size = new System.Drawing.Size(86, 21);
            this.txtNetSalesVal1.TabIndex = 5;
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(88, 12);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(244, 23);
            this.cmbSalesType.TabIndex = 1;
            // 
            // txtTotalNetVal
            // 
            this.txtTotalNetVal.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotalNetVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalNetVal.Location = new System.Drawing.Point(607, 218);
            this.txtTotalNetVal.Name = "txtTotalNetVal";
            this.txtTotalNetVal.ReadOnly = true;
            this.txtTotalNetVal.Size = new System.Drawing.Size(86, 21);
            this.txtTotalNetVal.TabIndex = 10;
            this.txtTotalNetVal.Text = "0.00";
            this.txtTotalNetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(524, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Net Sales Value";
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSet.Location = new System.Drawing.Point(616, 269);
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
            this.btnAddToList.Location = new System.Drawing.Point(616, 67);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(77, 26);
            this.btnAddToList.TabIndex = 7;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(524, 43);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(83, 13);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Net Sales Value";
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
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Target Qty";
            // 
            // txtTargetQty1
            // 
            this.txtTargetQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTargetQty1.Location = new System.Drawing.Point(88, 41);
            this.txtTargetQty1.Name = "txtTargetQty1";
            this.txtTargetQty1.Size = new System.Drawing.Size(86, 21);
            this.txtTargetQty1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Target Value";
            // 
            // txtTargetVal1
            // 
            this.txtTargetVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTargetVal1.Location = new System.Drawing.Point(246, 41);
            this.txtTargetVal1.Name = "txtTargetVal1";
            this.txtTargetVal1.Size = new System.Drawing.Size(86, 21);
            this.txtTargetVal1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Prom. Cost Value";
            // 
            // txtPromoCostVal1
            // 
            this.txtPromoCostVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPromoCostVal1.Location = new System.Drawing.Point(429, 41);
            this.txtPromoCostVal1.Name = "txtPromoCostVal1";
            this.txtPromoCostVal1.Size = new System.Drawing.Size(86, 21);
            this.txtPromoCostVal1.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Reg. Sales Qty";
            // 
            // txtRegSalesQty1
            // 
            this.txtRegSalesQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtRegSalesQty1.Location = new System.Drawing.Point(88, 70);
            this.txtRegSalesQty1.Name = "txtRegSalesQty1";
            this.txtRegSalesQty1.Size = new System.Drawing.Size(86, 21);
            this.txtRegSalesQty1.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(8, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Reg. Sales Qty";
            // 
            // txtTotRegSalesQty
            // 
            this.txtTotRegSalesQty.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotRegSalesQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotRegSalesQty.Location = new System.Drawing.Point(88, 247);
            this.txtTotRegSalesQty.Name = "txtTotRegSalesQty";
            this.txtTotRegSalesQty.ReadOnly = true;
            this.txtTotRegSalesQty.Size = new System.Drawing.Size(86, 21);
            this.txtTotRegSalesQty.TabIndex = 21;
            this.txtTotRegSalesQty.Text = "0.00";
            this.txtTotRegSalesQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(341, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Prom. Cost Value";
            // 
            // txtTotProCostVal
            // 
            this.txtTotProCostVal.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotProCostVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotProCostVal.Location = new System.Drawing.Point(429, 218);
            this.txtTotProCostVal.Name = "txtTotProCostVal";
            this.txtTotProCostVal.ReadOnly = true;
            this.txtTotProCostVal.Size = new System.Drawing.Size(86, 21);
            this.txtTotProCostVal.TabIndex = 23;
            this.txtTotProCostVal.Text = "0.00";
            this.txtTotProCostVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(177, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Target Value";
            // 
            // txtTotTargetVal
            // 
            this.txtTotTargetVal.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotTargetVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotTargetVal.Location = new System.Drawing.Point(246, 219);
            this.txtTotTargetVal.Name = "txtTotTargetVal";
            this.txtTotTargetVal.ReadOnly = true;
            this.txtTotTargetVal.Size = new System.Drawing.Size(86, 21);
            this.txtTotTargetVal.TabIndex = 25;
            this.txtTotTargetVal.Text = "0.00";
            this.txtTotTargetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.Location = new System.Drawing.Point(30, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Target Qty";
            // 
            // txtTotTargetQty
            // 
            this.txtTotTargetQty.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotTargetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotTargetQty.Location = new System.Drawing.Point(88, 218);
            this.txtTotTargetQty.Name = "txtTotTargetQty";
            this.txtTotTargetQty.ReadOnly = true;
            this.txtTotTargetQty.Size = new System.Drawing.Size(86, 21);
            this.txtTotTargetQty.TabIndex = 27;
            this.txtTotTargetQty.Text = "0.00";
            this.txtTotTargetQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.Location = new System.Drawing.Point(188, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Target MC";
            // 
            // txtTotalTargetMC
            // 
            this.txtTotalTargetMC.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtTotalTargetMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalTargetMC.Location = new System.Drawing.Point(246, 247);
            this.txtTotalTargetMC.Name = "txtTotalTargetMC";
            this.txtTotalTargetMC.ReadOnly = true;
            this.txtTotalTargetMC.Size = new System.Drawing.Size(86, 21);
            this.txtTotalTargetMC.TabIndex = 29;
            this.txtTotalTargetMC.Text = "0.00";
            this.txtTotalTargetMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Target MC";
            // 
            // txtTargetMC1
            // 
            this.txtTargetMC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTargetMC1.Location = new System.Drawing.Point(246, 68);
            this.txtTargetMC1.Name = "txtTargetMC1";
            this.txtTargetMC1.Size = new System.Drawing.Size(86, 21);
            this.txtTargetMC1.TabIndex = 34;
            // 
            // txtSalesType
            // 
            this.txtSalesType.HeaderText = "SalesType";
            this.txtSalesType.Name = "txtSalesType";
            this.txtSalesType.ReadOnly = true;
            // 
            // txtTargetQty
            // 
            this.txtTargetQty.HeaderText = "Target Qty";
            this.txtTargetQty.Name = "txtTargetQty";
            this.txtTargetQty.ReadOnly = true;
            this.txtTargetQty.Width = 80;
            // 
            // txtTargetValue
            // 
            this.txtTargetValue.HeaderText = "TargetValue";
            this.txtTargetValue.Name = "txtTargetValue";
            this.txtTargetValue.ReadOnly = true;
            this.txtTargetValue.Width = 90;
            // 
            // txtPromoCostValue
            // 
            this.txtPromoCostValue.HeaderText = "PromoCostVal";
            this.txtPromoCostValue.Name = "txtPromoCostValue";
            this.txtPromoCostValue.ReadOnly = true;
            this.txtPromoCostValue.Width = 90;
            // 
            // txtNetSalesValue
            // 
            this.txtNetSalesValue.HeaderText = "NetSalesVal";
            this.txtNetSalesValue.Name = "txtNetSalesValue";
            this.txtNetSalesValue.ReadOnly = true;
            this.txtNetSalesValue.Width = 90;
            // 
            // txtRegularSalesQty
            // 
            this.txtRegularSalesQty.HeaderText = "RegularSales Qty";
            this.txtRegularSalesQty.Name = "txtRegularSalesQty";
            this.txtRegularSalesQty.ReadOnly = true;
            this.txtRegularSalesQty.Width = 80;
            // 
            // txtTargetMC
            // 
            this.txtTargetMC.HeaderText = "Target MC";
            this.txtTargetMC.Name = "txtTargetMC";
            this.txtTargetMC.ReadOnly = true;
            this.txtTargetMC.Width = 90;
            // 
            // txtSalesTypeID
            // 
            this.txtSalesTypeID.HeaderText = "SalesTypeID";
            this.txtSalesTypeID.Name = "txtSalesTypeID";
            this.txtSalesTypeID.ReadOnly = true;
            this.txtSalesTypeID.Visible = false;
            this.txtSalesTypeID.Width = 50;
            // 
            // frmPromotionTargetAllocator
            // 
            this.AcceptButton = this.btnSet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 307);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTargetMC1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalTargetMC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotTargetQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotTargetVal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTotProCostVal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotRegSalesQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRegSalesQty1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPromoCostVal1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTargetVal1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetQty1);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalNetVal);
            this.Controls.Add(this.cmbSalesType);
            this.Controls.Add(this.txtNetSalesVal1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTargetAllocator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPromotionTargetAllocator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promotion Target Allocator";
            this.Load += new System.EventHandler(this.frmPromotionTargetAllocator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetAllocator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTargetAllocator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNetSalesVal1;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.TextBox txtTotalNetVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetQty1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTargetVal1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPromoCostVal1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegSalesQty1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotRegSalesQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotProCostVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotTargetVal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotTargetQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalTargetMC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTargetMC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTargetQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTargetValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPromoCostValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNetSalesValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRegularSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTargetMC;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalesTypeID;
    }
}