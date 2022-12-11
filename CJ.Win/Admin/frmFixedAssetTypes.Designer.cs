namespace CJ.Win.Admin
{
    partial class frmFixedAssetTypes
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwAssetTypeList = new System.Windows.Forms.ListView();
            this.colFATypeCode = new System.Windows.Forms.ColumnHeader();
            this.colFAName = new System.Windows.Forms.ColumnHeader();
            this.colFAGroup = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(636, 37);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(170, 27);
            this.btnEdit.TabIndex = 79;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(636, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(170, 27);
            this.btnAdd.TabIndex = 78;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwAssetTypeList
            // 
            this.lvwAssetTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAssetTypeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFATypeCode,
            this.colFAName,
            this.colFAGroup});
            this.lvwAssetTypeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAssetTypeList.FullRowSelect = true;
            this.lvwAssetTypeList.GridLines = true;
            this.lvwAssetTypeList.HideSelection = false;
            this.lvwAssetTypeList.Location = new System.Drawing.Point(2, 3);
            this.lvwAssetTypeList.MultiSelect = false;
            this.lvwAssetTypeList.Name = "lvwAssetTypeList";
            this.lvwAssetTypeList.Size = new System.Drawing.Size(628, 508);
            this.lvwAssetTypeList.TabIndex = 77;
            this.lvwAssetTypeList.UseCompatibleStateImageBehavior = false;
            this.lvwAssetTypeList.View = System.Windows.Forms.View.Details;
            this.lvwAssetTypeList.DoubleClick += new System.EventHandler(this.lvwAssetTypeList_DoubleClick);
            // 
            // colFATypeCode
            // 
            this.colFATypeCode.Text = "Asset Type Code";
            this.colFATypeCode.Width = 150;
            // 
            // colFAName
            // 
            this.colFAName.Text = "Asset Type Name";
            this.colFAName.Width = 255;
            // 
            // colFAGroup
            // 
            this.colFAGroup.Text = "Group";
            this.colFAGroup.Width = 300;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(635, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 27);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(636, 70);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(170, 27);
            this.btDelete.TabIndex = 81;
            this.btDelete.Tag = "M1.18";
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // frmFixedAssetTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 514);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwAssetTypeList);
            this.Name = "frmFixedAssetTypes";
            this.Text = "frmFixedAssetTypes";
            this.Load += new System.EventHandler(this.frmFixedAssetTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwAssetTypeList;
        private System.Windows.Forms.ColumnHeader colFATypeCode;
        private System.Windows.Forms.ColumnHeader colFAName;
        private System.Windows.Forms.ColumnHeader colFAGroup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btDelete;
    }
}