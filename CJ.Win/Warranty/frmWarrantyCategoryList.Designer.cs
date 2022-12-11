namespace CJ.Win.Warranty
{
    partial class frmWarrantyCategoryList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwWarrantyList = new System.Windows.Forms.ListView();
            this.colService = new System.Windows.Forms.ColumnHeader();
            this.colSpare = new System.Windows.Forms.ColumnHeader();
            this.colSpecialPart = new System.Windows.Forms.ColumnHeader();
            this.colEffectDate = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(552, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 182;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colName
            // 
            this.colName.Text = "Category Name";
            this.colName.Width = 300;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(552, 37);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 27);
            this.btnEdit.TabIndex = 180;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // colDate
            // 
            this.colDate.Text = "Create Date";
            this.colDate.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(552, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 27);
            this.btnAdd.TabIndex = 179;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwWarrantyList
            // 
            this.lvwWarrantyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwWarrantyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDate,
            this.colEffectDate,
            this.colService,
            this.colSpare,
            this.colSpecialPart});
            this.lvwWarrantyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwWarrantyList.FullRowSelect = true;
            this.lvwWarrantyList.GridLines = true;
            this.lvwWarrantyList.HideSelection = false;
            this.lvwWarrantyList.Location = new System.Drawing.Point(4, 4);
            this.lvwWarrantyList.MultiSelect = false;
            this.lvwWarrantyList.Name = "lvwWarrantyList";
            this.lvwWarrantyList.Size = new System.Drawing.Size(542, 429);
            this.lvwWarrantyList.TabIndex = 178;
            this.lvwWarrantyList.UseCompatibleStateImageBehavior = false;
            this.lvwWarrantyList.View = System.Windows.Forms.View.Details;
            // 
            // colService
            // 
            this.colService.DisplayIndex = 2;
            this.colService.Text = "Service Validity";
            this.colService.Width = 150;
            // 
            // colSpare
            // 
            this.colSpare.DisplayIndex = 3;
            this.colSpare.Text = "Spare Validity";
            this.colSpare.Width = 150;
            // 
            // colSpecialPart
            // 
            this.colSpecialPart.DisplayIndex = 4;
            this.colSpecialPart.Text = "Special Part Validity";
            this.colSpecialPart.Width = 150;
            // 
            // colEffectDate
            // 
            this.colEffectDate.DisplayIndex = 5;
            this.colEffectDate.Text = "Effect from";
            this.colEffectDate.Width = 100;
            // 
            // frmWarrantyCategoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 438);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwWarrantyList);
            this.Name = "frmWarrantyCategoryList";
            this.Text = "frmWarrantyCategoryList";
            this.Load += new System.EventHandler(this.frmWarrantyCategoryList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwWarrantyList;
        private System.Windows.Forms.ColumnHeader colService;
        private System.Windows.Forms.ColumnHeader colSpare;
        private System.Windows.Forms.ColumnHeader colSpecialPart;
        private System.Windows.Forms.ColumnHeader colEffectDate;
    }
}