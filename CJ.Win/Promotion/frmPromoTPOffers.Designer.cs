namespace CJ.Win.Promotion
{
    partial class frmPromoTPOffers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromoTPOffers));
            this.lvwPromoOffers = new System.Windows.Forms.ListView();
            this.colOfferNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOfferDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRatio = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnOk = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMinInvoiceQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBrandDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGroupTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatio)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPromoOffers
            // 
            this.lvwPromoOffers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPromoOffers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOfferNo,
            this.colOfferDetails});
            this.lvwPromoOffers.FullRowSelect = true;
            this.lvwPromoOffers.GridLines = true;
            this.lvwPromoOffers.HideSelection = false;
            this.lvwPromoOffers.Location = new System.Drawing.Point(12, 32);
            this.lvwPromoOffers.Name = "lvwPromoOffers";
            this.lvwPromoOffers.Size = new System.Drawing.Size(561, 130);
            this.lvwPromoOffers.TabIndex = 0;
            this.lvwPromoOffers.UseCompatibleStateImageBehavior = false;
            this.lvwPromoOffers.View = System.Windows.Forms.View.Details;
            // 
            // colOfferNo
            // 
            this.colOfferNo.Text = "Offer Name";
            this.colOfferNo.Width = 80;
            // 
            // colOfferDetails
            // 
            this.colOfferDetails.Text = "Offer Description";
            this.colOfferDetails.Width = 400;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRatio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slab Product Qty";
            // 
            // dgvRatio
            // 
            this.dgvRatio.AllowUserToAddRows = false;
            this.dgvRatio.AllowUserToDeleteRows = false;
            this.dgvRatio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtMAG,
            this.txtBrandDescription,
            this.Column1,
            this.ProductID,
            this.txtBrandID,
            this.txtGroupTypeID});
            this.dgvRatio.Location = new System.Drawing.Point(11, 19);
            this.dgvRatio.Name = "dgvRatio";
            this.dgvRatio.Size = new System.Drawing.Size(563, 89);
            this.dgvRatio.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtName.Location = new System.Drawing.Point(83, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(191, 21);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Slab Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.lvwPromoOffers);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Offer Detail";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(507, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 15);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add Offer";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(510, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Add";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = " Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 230;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // txtMinInvoiceQty
            // 
            this.txtMinInvoiceQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMinInvoiceQty.Location = new System.Drawing.Point(475, 12);
            this.txtMinInvoiceQty.Name = "txtMinInvoiceQty";
            this.txtMinInvoiceQty.Size = new System.Drawing.Size(116, 21);
            this.txtMinInvoiceQty.TabIndex = 3;
            this.txtMinInvoiceQty.TextChanged += new System.EventHandler(this.txtMinInvoiceQty_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(379, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min. Invoice Qty";
            // 
            // txtMAG
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMAG.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtMAG.Frozen = true;
            this.txtMAG.HeaderText = "MAG";
            this.txtMAG.Name = "txtMAG";
            this.txtMAG.Width = 220;
            // 
            // txtBrandDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.txtBrandDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtBrandDescription.Frozen = true;
            this.txtBrandDescription.HeaderText = "Brand Description";
            this.txtBrandDescription.Name = "txtBrandDescription";
            this.txtBrandDescription.ReadOnly = true;
            this.txtBrandDescription.Width = 220;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Min. Qty";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductGroupID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // txtBrandID
            // 
            this.txtBrandID.HeaderText = "BrandID";
            this.txtBrandID.Name = "txtBrandID";
            this.txtBrandID.ReadOnly = true;
            this.txtBrandID.Visible = false;
            // 
            // txtGroupTypeID
            // 
            this.txtGroupTypeID.HeaderText = "GroupTypeID";
            this.txtGroupTypeID.Name = "txtGroupTypeID";
            this.txtGroupTypeID.ReadOnly = true;
            this.txtGroupTypeID.Visible = false;
            // 
            // frmPromoTPOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 367);
            this.Controls.Add(this.txtMinInvoiceQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPromoTPOffers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Slab";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPromoOffers;
        private System.Windows.Forms.ColumnHeader colOfferNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvRatio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader colOfferDetails;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtMinInvoiceQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBrandDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGroupTypeID;
    }
}