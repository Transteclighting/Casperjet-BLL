namespace CJ.Win.Warranty
{
    partial class frmWarrantyParameter
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
            this.lvwWarrantyParams = new System.Windows.Forms.ListView();
            this.colProdCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colASG = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.colProductType = new System.Windows.Forms.ColumnHeader();
            this.colSvrWarr = new System.Windows.Forms.ColumnHeader();
            this.colSpareWarranty = new System.Windows.Forms.ColumnHeader();
            this.colSpecialCom = new System.Windows.Forms.ColumnHeader();
            this.colCardPrint = new System.Windows.Forms.ColumnHeader();
            this.colBarcodeStore = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblProductType = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.btnParameter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwWarrantyParams
            // 
            this.lvwWarrantyParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWarrantyParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProdCode,
            this.colProductName,
            this.colASG,
            this.colBrand,
            this.colProductType,
            this.colSvrWarr,
            this.colSpareWarranty,
            this.colSpecialCom,
            this.colCardPrint,
            this.colBarcodeStore,
            this.colStatus});
            this.lvwWarrantyParams.FullRowSelect = true;
            this.lvwWarrantyParams.GridLines = true;
            this.lvwWarrantyParams.Location = new System.Drawing.Point(0, 84);
            this.lvwWarrantyParams.Name = "lvwWarrantyParams";
            this.lvwWarrantyParams.Size = new System.Drawing.Size(719, 346);
            this.lvwWarrantyParams.TabIndex = 1;
            this.lvwWarrantyParams.UseCompatibleStateImageBehavior = false;
            this.lvwWarrantyParams.View = System.Windows.Forms.View.Details;
            // 
            // colProdCode
            // 
            this.colProdCode.Text = "Prod Code";
            this.colProdCode.Width = 76;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 200;
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            this.colASG.Width = 98;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 92;
            // 
            // colProductType
            // 
            this.colProductType.Text = "ProdType";
            // 
            // colSvrWarr
            // 
            this.colSvrWarr.Text = "Free Service";
            this.colSvrWarr.Width = 65;
            // 
            // colSpareWarranty
            // 
            this.colSpareWarranty.Text = "Parts";
            this.colSpareWarranty.Width = 65;
            // 
            // colSpecialCom
            // 
            this.colSpecialCom.Text = "Special Comp.";
            // 
            // colCardPrint
            // 
            this.colCardPrint.Text = "Card Print";
            // 
            // colBarcodeStore
            // 
            this.colBarcodeStore.Text = "BarcodeStore";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 73;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(651, 48);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(68, 30);
            this.btnGetData.TabIndex = 148;
            this.btnGetData.Text = "&Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblProductType
            // 
            this.lblProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.Location = new System.Drawing.Point(13, 54);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(84, 13);
            this.lblProductType.TabIndex = 151;
            this.lblProductType.Text = "Product Type";
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Location = new System.Drawing.Point(98, 51);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(144, 21);
            this.cmbProductType.TabIndex = 150;
            // 
            // btnParameter
            // 
            this.btnParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParameter.Location = new System.Drawing.Point(725, 84);
            this.btnParameter.Name = "btnParameter";
            this.btnParameter.Size = new System.Drawing.Size(85, 30);
            this.btnParameter.TabIndex = 152;
            this.btnParameter.Text = "&Parameter";
            this.btnParameter.UseVisualStyleBackColor = true;
            this.btnParameter.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 154;
            this.label1.Text = "ASG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(289, 51);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(144, 21);
            this.cmbASG.TabIndex = 153;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 156;
            this.label2.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(495, 52);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(144, 21);
            this.cmbBrand.TabIndex = 155;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(98, 23);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(144, 20);
            this.txtProductCode.TabIndex = 157;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Product Code";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 160;
            this.label4.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(349, 24);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(290, 20);
            this.txtProductName.TabIndex = 159;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(725, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 161;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmWarrantyParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 455);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.btnParameter);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.cmbProductType);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lvwWarrantyParams);
            this.Name = "frmWarrantyParameter";
            this.Text = "Warranty Parameter";
            this.Load += new System.EventHandler(this.frmWarrantyParameter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwWarrantyParams;
        private System.Windows.Forms.ColumnHeader colProdCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colSvrWarr;
        private System.Windows.Forms.ColumnHeader colSpareWarranty;
        private System.Windows.Forms.ColumnHeader colSpecialCom;
        private System.Windows.Forms.ColumnHeader colCardPrint;
        private System.Windows.Forms.ColumnHeader colBarcodeStore;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colProductType;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.ComboBox cmbProductType;
        private System.Windows.Forms.Button btnParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnClose;
    }
}