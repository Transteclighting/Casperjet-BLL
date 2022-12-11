namespace CJ.Win.CSD
{
    partial class frmBrandsMultiSelect
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
            this.lvwItem = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwItem
            // 
            this.lvwItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItem.CheckBoxes = true;
            this.lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lvwItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.GridLines = true;
            this.lvwItem.HideSelection = false;
            this.lvwItem.Location = new System.Drawing.Point(12, 32);
            this.lvwItem.MultiSelect = false;
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.Size = new System.Drawing.Size(331, 295);
            this.lvwItem.TabIndex = 166;
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Department Name";
            this.colName.Width = 400;
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(12, 9);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(83, 17);
            this.ckbSelect.TabIndex = 169;
            this.ckbSelect.Text = "Checked All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(263, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 168;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.Location = new System.Drawing.Point(177, 335);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(80, 27);
            this.btnSet.TabIndex = 167;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // frmBrandsMultiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 374);
            this.Controls.Add(this.lvwItem);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSet);
            this.Name = "frmBrandsMultiSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brands Multi Select";
            this.Load += new System.EventHandler(this.frmBrandsMultiSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSet;
    }
}