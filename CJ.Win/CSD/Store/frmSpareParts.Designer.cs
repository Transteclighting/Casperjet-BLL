namespace CJ.Win
{
    partial class frmSpareParts
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
            this.lvwSpareParts = new System.Windows.Forms.ListView();
            this.colPartCode = new System.Windows.Forms.ColumnHeader();
            this.colPartName = new System.Windows.Forms.ColumnHeader();
            this.coSalePrice = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.colSubCategory = new System.Windows.Forms.ColumnHeader();
            this.colMainCategory = new System.Windows.Forms.ColumnHeader();
            this.colProductModel = new System.Windows.Forms.ColumnHeader();
            this.colASG = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.lblPartCode = new System.Windows.Forms.Label();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditPartCode = new System.Windows.Forms.Button();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblInactive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwSpareParts
            // 
            this.lvwSpareParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSpareParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPartCode,
            this.colPartName,
            this.coSalePrice,
            this.colLocation,
            this.colSubCategory,
            this.colMainCategory,
            this.colProductModel,
            this.colASG,
            this.colBrand,
            this.colIsActive,
            this.colCreatedBy,
            this.colCreateDate});
            this.lvwSpareParts.FullRowSelect = true;
            this.lvwSpareParts.GridLines = true;
            this.lvwSpareParts.Location = new System.Drawing.Point(12, 78);
            this.lvwSpareParts.MultiSelect = false;
            this.lvwSpareParts.Name = "lvwSpareParts";
            this.lvwSpareParts.Size = new System.Drawing.Size(683, 318);
            this.lvwSpareParts.TabIndex = 5;
            this.lvwSpareParts.UseCompatibleStateImageBehavior = false;
            this.lvwSpareParts.View = System.Windows.Forms.View.Details;
            this.lvwSpareParts.DoubleClick += new System.EventHandler(this.lvwSpareParts_DoubleClick);
            this.lvwSpareParts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwSpareParts_ColumnClick);
            // 
            // colPartCode
            // 
            this.colPartCode.Text = "Part Code";
            this.colPartCode.Width = 110;
            // 
            // colPartName
            // 
            this.colPartName.Text = "Part Name";
            this.colPartName.Width = 164;
            // 
            // coSalePrice
            // 
            this.coSalePrice.Text = "Sale Price";
            this.coSalePrice.Width = 72;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 63;
            // 
            // colSubCategory
            // 
            this.colSubCategory.Text = "Sub Category";
            this.colSubCategory.Width = 100;
            // 
            // colMainCategory
            // 
            this.colMainCategory.Text = "Main Category";
            this.colMainCategory.Width = 90;
            // 
            // colProductModel
            // 
            this.colProductModel.Text = "Product Model";
            this.colProductModel.Width = 87;
            // 
            // colASG
            // 
            this.colASG.Text = "ASG Name";
            this.colASG.Width = 80;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 80;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 91;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 126;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(701, 107);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Tag = "M34.2.2";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(701, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(627, 45);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(68, 27);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(701, 78);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 6;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "M34.2.1";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(80, 18);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(220, 20);
            this.txtPartCode.TabIndex = 1;
            // 
            // lblPartCode
            // 
            this.lblPartCode.AutoSize = true;
            this.lblPartCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartCode.Location = new System.Drawing.Point(12, 21);
            this.lblPartCode.Name = "lblPartCode";
            this.lblPartCode.Size = new System.Drawing.Size(63, 13);
            this.lblPartCode.TabIndex = 0;
            this.lblPartCode.Text = "Part Code";
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(80, 44);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(220, 20);
            this.txtPartName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Part Name";
            // 
            // btnEditPartCode
            // 
            this.btnEditPartCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPartCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPartCode.Location = new System.Drawing.Point(701, 137);
            this.btnEditPartCode.Name = "btnEditPartCode";
            this.btnEditPartCode.Size = new System.Drawing.Size(87, 38);
            this.btnEditPartCode.TabIndex = 8;
            this.btnEditPartCode.Tag = "M34.2.2";
            this.btnEditPartCode.Text = "Edit (Only Part Code)";
            this.btnEditPartCode.UseVisualStyleBackColor = true;
            this.btnEditPartCode.Visible = false;
            this.btnEditPartCode.Click += new System.EventHandler(this.btnEditPartCode_Click);
            // 
            // lblActive
            // 
            this.lblActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActive.AutoSize = true;
            this.lblActive.BackColor = System.Drawing.Color.Transparent;
            this.lblActive.Location = new System.Drawing.Point(726, 194);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(37, 13);
            this.lblActive.TabIndex = 10;
            this.lblActive.Text = "Active";
            // 
            // lblInactive
            // 
            this.lblInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInactive.AutoSize = true;
            this.lblInactive.BackColor = System.Drawing.Color.LightGray;
            this.lblInactive.Location = new System.Drawing.Point(723, 210);
            this.lblInactive.Name = "lblInactive";
            this.lblInactive.Size = new System.Drawing.Size(45, 13);
            this.lblInactive.TabIndex = 11;
            this.lblInactive.Text = "Inactive";
            // 
            // frmSpareParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this.lblInactive);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.btnEditPartCode);
            this.Controls.Add(this.txtPartName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPartCode);
            this.Controls.Add(this.lblPartCode);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwSpareParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpareParts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Parts";
            this.Load += new System.EventHandler(this.frmSpareParts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSpareParts;
        private System.Windows.Forms.ColumnHeader colPartCode;
        private System.Windows.Forms.ColumnHeader colPartName;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader coSalePrice;
        private System.Windows.Forms.ColumnHeader colSubCategory;
        private System.Windows.Forms.ColumnHeader colMainCategory;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colProductModel;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label lblPartCode;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditPartCode;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblInactive;
    }
}