namespace CJ.Win.Basic
{
    partial class frmProductPrices
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
            this.lvwProducts = new System.Windows.Forms.ListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colASG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCostPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTradePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubBrand = new System.Windows.Forms.ComboBox();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMC = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwProducts
            // 
            this.lvwProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colASG,
            this.colBrand,
            this.colCostPrice,
            this.colTradePrice,
            this.colNSP,
            this.colRSP,
            this.colIsActive,
            this.colRemarks});
            this.lvwProducts.FullRowSelect = true;
            this.lvwProducts.GridLines = true;
            this.lvwProducts.HideSelection = false;
            this.lvwProducts.Location = new System.Drawing.Point(12, 205);
            this.lvwProducts.Name = "lvwProducts";
            this.lvwProducts.Size = new System.Drawing.Size(685, 325);
            this.lvwProducts.TabIndex = 1;
            this.lvwProducts.UseCompatibleStateImageBehavior = false;
            this.lvwProducts.View = System.Windows.Forms.View.Details;
            this.lvwProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwProducts_KeyDown);
            this.lvwProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwProducts_MouseDoubleClick);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 65;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 218;
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            this.colASG.Width = 70;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 75;
            // 
            // colCostPrice
            // 
            this.colCostPrice.Text = "CostPrice";
            this.colCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCostPrice.Width = 75;
            // 
            // colTradePrice
            // 
            this.colTradePrice.Text = "Trade Price";
            this.colTradePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTradePrice.Width = 75;
            // 
            // colNSP
            // 
            this.colNSP.Text = "NSP";
            this.colNSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNSP.Width = 75;
            // 
            // colRSP
            // 
            this.colRSP.Text = "RSP";
            this.colRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRSP.Width = 75;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            this.colIsActive.Width = 53;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.lblCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.btnGetData);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbSubBrand);
            this.groupBox2.Controls.Add(this.cmbPG);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblBrand);
            this.groupBox2.Controls.Add(this.cmbMAG);
            this.groupBox2.Controls.Add(this.cmbBrand);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbASG);
            this.groupBox2.Controls.Add(this.cmbAG);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 187);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Heirarchy Details";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 155);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(444, 20);
            this.txtName.TabIndex = 59;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(90, 129);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(114, 20);
            this.txtCode.TabIndex = 57;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 153);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 58;
            this.lblName.Text = "Product Name";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 132);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(72, 13);
            this.lblCode.TabIndex = 56;
            this.lblCode.Text = "Product Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(427, 74);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(208, 21);
            this.cmbStatus.TabIndex = 54;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(540, 148);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(95, 27);
            this.btnGetData.TabIndex = 37;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Sub Brand";
            // 
            // cmbSubBrand
            // 
            this.cmbSubBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubBrand.FormattingEnabled = true;
            this.cmbSubBrand.Location = new System.Drawing.Point(427, 46);
            this.cmbSubBrand.Name = "cmbSubBrand";
            this.cmbSubBrand.Size = new System.Drawing.Size(208, 21);
            this.cmbSubBrand.TabIndex = 5;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(90, 18);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(211, 21);
            this.cmbPG.TabIndex = 0;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "PG";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(352, 18);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 51;
            this.lblBrand.Text = "Brand";
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(90, 46);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(211, 21);
            this.cmbMAG.TabIndex = 1;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(427, 18);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(208, 21);
            this.cmbBrand.TabIndex = 4;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "MAG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "AG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(90, 74);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(211, 21);
            this.cmbASG.TabIndex = 2;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(90, 102);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(211, 21);
            this.cmbAG.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "ASG";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(712, 504);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(712, 238);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 26);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(712, 206);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 26);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMC
            // 
            this.btnMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMC.Location = new System.Drawing.Point(712, 270);
            this.btnMC.Name = "btnMC";
            this.btnMC.Size = new System.Drawing.Size(90, 26);
            this.btnMC.TabIndex = 42;
            this.btnMC.Text = "MC Set-Up";
            this.btnMC.UseVisualStyleBackColor = true;
            this.btnMC.Click += new System.EventHandler(this.btnMC_Click);
            // 
            // frmProductPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 542);
            this.Controls.Add(this.btnMC);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvwProducts);
            this.Name = "frmProductPrices";
            this.Text = "frmProductPrices";
            this.Load += new System.EventHandler(this.frmProductPrices_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwProducts;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubBrand;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colCostPrice;
        private System.Windows.Forms.ColumnHeader colNSP;
        private System.Windows.Forms.ColumnHeader colRSP;
        private System.Windows.Forms.ColumnHeader colTradePrice;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnMC;
    }
}