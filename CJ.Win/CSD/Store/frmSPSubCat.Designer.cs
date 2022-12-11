namespace CJ.Win
{
    partial class frmSPSubCat
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSubCatName = new System.Windows.Forms.TextBox();
            this.lblSPSubCatName = new System.Windows.Forms.Label();
            this.cmbMainCategory = new System.Windows.Forms.ComboBox();
            this.lblMainCat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(257, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(358, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSubCatName
            // 
            this.txtSubCatName.Location = new System.Drawing.Point(163, 29);
            this.txtSubCatName.Name = "txtSubCatName";
            this.txtSubCatName.Size = new System.Drawing.Size(220, 20);
            this.txtSubCatName.TabIndex = 1;
            // 
            // lblSPSubCatName
            // 
            this.lblSPSubCatName.AutoSize = true;
            this.lblSPSubCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPSubCatName.Location = new System.Drawing.Point(40, 32);
            this.lblSPSubCatName.Name = "lblSPSubCatName";
            this.lblSPSubCatName.Size = new System.Drawing.Size(119, 13);
            this.lblSPSubCatName.TabIndex = 0;
            this.lblSPSubCatName.Text = "Sub Category Name";
            // 
            // cmbMainCategory
            // 
            this.cmbMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainCategory.FormattingEnabled = true;
            this.cmbMainCategory.Location = new System.Drawing.Point(163, 64);
            this.cmbMainCategory.Name = "cmbMainCategory";
            this.cmbMainCategory.Size = new System.Drawing.Size(171, 21);
            this.cmbMainCategory.TabIndex = 3;
            // 
            // lblMainCat
            // 
            this.lblMainCat.AutoSize = true;
            this.lblMainCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainCat.Location = new System.Drawing.Point(71, 67);
            this.lblMainCat.Name = "lblMainCat";
            this.lblMainCat.Size = new System.Drawing.Size(88, 13);
            this.lblMainCat.TabIndex = 2;
            this.lblMainCat.Text = "Main Category";
            // 
            // frmSPSubCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 149);
            this.Controls.Add(this.cmbMainCategory);
            this.Controls.Add(this.lblMainCat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSubCatName);
            this.Controls.Add(this.lblSPSubCatName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSPSubCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Spare Parts Sub Category";
            this.Load += new System.EventHandler(this.frmSPSubCat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSubCatName;
        private System.Windows.Forms.Label lblSPSubCatName;
        private System.Windows.Forms.ComboBox cmbMainCategory;
        private System.Windows.Forms.Label lblMainCat;
    }
}