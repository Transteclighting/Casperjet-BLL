namespace CJ.Win.IT
{
    partial class frmITEquipmentFeature
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTypeName = new System.Windows.Forms.ComboBox();
            this.dgvEquipmentFeature = new System.Windows.Forms.DataGridView();
            this.Feature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentFeature)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btClose);
            this.groupBox3.Controls.Add(this.btSave);
            this.groupBox3.Location = new System.Drawing.Point(12, 424);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 63);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(144, 16);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 34);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(63, 16);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 34);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbTypeName);
            this.groupBox2.Controls.Add(this.dgvEquipmentFeature);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 411);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Type Name";
            // 
            // cbTypeName
            // 
            this.cbTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeName.FormattingEnabled = true;
            this.cbTypeName.Location = new System.Drawing.Point(106, 14);
            this.cbTypeName.Name = "cbTypeName";
            this.cbTypeName.Size = new System.Drawing.Size(140, 21);
            this.cbTypeName.TabIndex = 1;
            this.cbTypeName.SelectedIndexChanged += new System.EventHandler(this.cbTypeName_SelectedIndexChanged);
            // 
            // dgvEquipmentFeature
            // 
            this.dgvEquipmentFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Feature});
            this.dgvEquipmentFeature.Location = new System.Drawing.Point(14, 43);
            this.dgvEquipmentFeature.Name = "dgvEquipmentFeature";
            this.dgvEquipmentFeature.Size = new System.Drawing.Size(251, 354);
            this.dgvEquipmentFeature.TabIndex = 2;
            // 
            // Feature
            // 
            this.Feature.HeaderText = "Feature Name";
            this.Feature.Name = "Feature";
            this.Feature.Width = 200;
            // 
            // frmITEquipmentFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmITEquipmentFeature";
            this.Text = "Equipment Feature";
            this.Load += new System.EventHandler(this.frmITEquipmentFeature_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentFeature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbTypeName;
        private System.Windows.Forms.DataGridView dgvEquipmentFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feature;
    }
}