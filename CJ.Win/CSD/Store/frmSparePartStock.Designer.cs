namespace CJ.Win
{
    partial class frmSparePartStock
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParentStore = new System.Windows.Forms.ComboBox();
            this.cmbChildStore = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSpareCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpareCode = new System.Windows.Forms.TextBox();
            this.txtSpareName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbSpareLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Store";
            // 
            // cmbParentStore
            // 
            this.cmbParentStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentStore.FormattingEnabled = true;
            this.cmbParentStore.Location = new System.Drawing.Point(90, 7);
            this.cmbParentStore.Name = "cmbParentStore";
            this.cmbParentStore.Size = new System.Drawing.Size(244, 21);
            this.cmbParentStore.TabIndex = 1;
            this.cmbParentStore.SelectedIndexChanged += new System.EventHandler(this.cmbParentStore_SelectedIndexChanged);
            // 
            // cmbChildStore
            // 
            this.cmbChildStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildStore.FormattingEnabled = true;
            this.cmbChildStore.Location = new System.Drawing.Point(90, 32);
            this.cmbChildStore.Name = "cmbChildStore";
            this.cmbChildStore.Size = new System.Drawing.Size(244, 21);
            this.cmbChildStore.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Child Store";
            // 
            // cmbSpareCategory
            // 
            this.cmbSpareCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpareCategory.FormattingEnabled = true;
            this.cmbSpareCategory.Location = new System.Drawing.Point(90, 56);
            this.cmbSpareCategory.Name = "cmbSpareCategory";
            this.cmbSpareCategory.Size = new System.Drawing.Size(244, 21);
            this.cmbSpareCategory.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Spare Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spare Code";
            // 
            // txtSpareCode
            // 
            this.txtSpareCode.Location = new System.Drawing.Point(90, 106);
            this.txtSpareCode.Name = "txtSpareCode";
            this.txtSpareCode.Size = new System.Drawing.Size(244, 20);
            this.txtSpareCode.TabIndex = 7;
            // 
            // txtSpareName
            // 
            this.txtSpareName.Location = new System.Drawing.Point(90, 129);
            this.txtSpareName.Name = "txtSpareName";
            this.txtSpareName.Size = new System.Drawing.Size(244, 20);
            this.txtSpareName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Spare Name";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(259, 155);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 25);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbSpareLocation
            // 
            this.cmbSpareLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpareLocation.FormattingEnabled = true;
            this.cmbSpareLocation.Location = new System.Drawing.Point(90, 81);
            this.cmbSpareLocation.Name = "cmbSpareLocation";
            this.cmbSpareLocation.Size = new System.Drawing.Size(244, 21);
            this.cmbSpareLocation.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Spare Location";
            // 
            // frmSparePartStock
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 185);
            this.Controls.Add(this.cmbSpareLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtSpareName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSpareCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSpareCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbChildStore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbParentStore);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmSparePartStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Part Stock";
            this.Load += new System.EventHandler(this.frmSparePartStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbParentStore;
        private System.Windows.Forms.ComboBox cmbChildStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSpareCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSpareCode;
        private System.Windows.Forms.TextBox txtSpareName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbSpareLocation;
        private System.Windows.Forms.Label label6;
    }
}