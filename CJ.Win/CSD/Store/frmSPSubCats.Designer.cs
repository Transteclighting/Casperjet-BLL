namespace CJ.Win
{
    partial class frmSPSubCats
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
            this.lvwSPSubCats = new System.Windows.Forms.ListView();
            this.colSubCatName = new System.Windows.Forms.ColumnHeader();
            this.colMainCatName = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbMainCategory = new System.Windows.Forms.ComboBox();
            this.lblMainCat = new System.Windows.Forms.Label();
            this.txtSubCatName = new System.Windows.Forms.TextBox();
            this.lblSPSubCatName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwSPSubCats
            // 
            this.lvwSPSubCats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSPSubCats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSubCatName,
            this.colMainCatName,
            this.colCreatedBy,
            this.colCreateDate});
            this.lvwSPSubCats.FullRowSelect = true;
            this.lvwSPSubCats.GridLines = true;
            this.lvwSPSubCats.Location = new System.Drawing.Point(3, 76);
            this.lvwSPSubCats.MultiSelect = false;
            this.lvwSPSubCats.Name = "lvwSPSubCats";
            this.lvwSPSubCats.Size = new System.Drawing.Size(557, 255);
            this.lvwSPSubCats.TabIndex = 5;
            this.lvwSPSubCats.UseCompatibleStateImageBehavior = false;
            this.lvwSPSubCats.View = System.Windows.Forms.View.Details;
            this.lvwSPSubCats.DoubleClick += new System.EventHandler(this.lvwSPSubCats_DoubleClick);
            // 
            // colSubCatName
            // 
            this.colSubCatName.Text = "Sub Category Name";
            this.colSubCatName.Width = 140;
            // 
            // colMainCatName
            // 
            this.colMainCatName.Text = "Main Category Name";
            this.colMainCatName.Width = 144;
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
            this.btnEdit.Location = new System.Drawing.Point(566, 105);
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
            this.btnClose.Location = new System.Drawing.Point(566, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(492, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(566, 76);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 27);
            this.btnNew.TabIndex = 6;
            this.btnNew.TabStop = false;
            this.btnNew.Tag = "M34.2.1";
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cmbMainCategory
            // 
            this.cmbMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainCategory.FormattingEnabled = true;
            this.cmbMainCategory.Location = new System.Drawing.Point(154, 38);
            this.cmbMainCategory.Name = "cmbMainCategory";
            this.cmbMainCategory.Size = new System.Drawing.Size(173, 21);
            this.cmbMainCategory.TabIndex = 3;
            // 
            // lblMainCat
            // 
            this.lblMainCat.AutoSize = true;
            this.lblMainCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainCat.Location = new System.Drawing.Point(62, 41);
            this.lblMainCat.Name = "lblMainCat";
            this.lblMainCat.Size = new System.Drawing.Size(88, 13);
            this.lblMainCat.TabIndex = 2;
            this.lblMainCat.Text = "Main Category";
            // 
            // txtSubCatName
            // 
            this.txtSubCatName.Location = new System.Drawing.Point(154, 12);
            this.txtSubCatName.Name = "txtSubCatName";
            this.txtSubCatName.Size = new System.Drawing.Size(220, 20);
            this.txtSubCatName.TabIndex = 1;
            // 
            // lblSPSubCatName
            // 
            this.lblSPSubCatName.AutoSize = true;
            this.lblSPSubCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPSubCatName.Location = new System.Drawing.Point(31, 15);
            this.lblSPSubCatName.Name = "lblSPSubCatName";
            this.lblSPSubCatName.Size = new System.Drawing.Size(119, 13);
            this.lblSPSubCatName.TabIndex = 0;
            this.lblSPSubCatName.Text = "Sub Category Name";
            // 
            // frmSPSubCats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 343);
            this.Controls.Add(this.cmbMainCategory);
            this.Controls.Add(this.lblMainCat);
            this.Controls.Add(this.txtSubCatName);
            this.Controls.Add(this.lblSPSubCatName);
            this.Controls.Add(this.lvwSPSubCats);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSPSubCats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Parts Sub Categories";
            this.Load += new System.EventHandler(this.frmSPSubCats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSPSubCats;
        private System.Windows.Forms.ColumnHeader colMainCatName;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colSubCatName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbMainCategory;
        private System.Windows.Forms.Label lblMainCat;
        private System.Windows.Forms.TextBox txtSubCatName;
        private System.Windows.Forms.Label lblSPSubCatName;
    }
}