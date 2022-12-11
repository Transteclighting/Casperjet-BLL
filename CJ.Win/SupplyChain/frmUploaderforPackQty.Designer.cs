namespace CJ.Win.SupplyChain
{
    partial class frmUploaderforPackQty
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
            this.rbAddSales = new System.Windows.Forms.RadioButton();
            this.rbAddPlan = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSCMPSIItem = new System.Windows.Forms.DataGridView();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXLFilePath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSCMPSIItem)).BeginInit();
            this.SuspendLayout();
            // 
            // rbAddSales
            // 
            this.rbAddSales.AutoSize = true;
            this.rbAddSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAddSales.Location = new System.Drawing.Point(464, 423);
            this.rbAddSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAddSales.Name = "rbAddSales";
            this.rbAddSales.Size = new System.Drawing.Size(67, 17);
            this.rbAddSales.TabIndex = 123;
            this.rbAddSales.Text = "RM Qty";
            this.rbAddSales.UseVisualStyleBackColor = true;
            // 
            // rbAddPlan
            // 
            this.rbAddPlan.AutoSize = true;
            this.rbAddPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAddPlan.Location = new System.Drawing.Point(365, 423);
            this.rbAddPlan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbAddPlan.Name = "rbAddPlan";
            this.rbAddPlan.Size = new System.Drawing.Size(93, 17);
            this.rbAddPlan.TabIndex = 122;
            this.rbAddPlan.Text = "Pipeline Qty";
            this.rbAddPlan.UseVisualStyleBackColor = true;
            this.rbAddPlan.CheckedChanged += new System.EventHandler(this.rbAddPlan_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(391, 448);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 32);
            this.btnSave.TabIndex = 121;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSCMPSIItem
            // 
            this.dgvSCMPSIItem.AllowUserToAddRows = false;
            this.dgvSCMPSIItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSCMPSIItem.Location = new System.Drawing.Point(105, 41);
            this.dgvSCMPSIItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSCMPSIItem.Name = "dgvSCMPSIItem";
            this.dgvSCMPSIItem.Size = new System.Drawing.Size(685, 371);
            this.dgvSCMPSIItem.TabIndex = 120;
            this.dgvSCMPSIItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSCMPSIItem_CellContentClick);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpload.Location = new System.Drawing.Point(631, 8);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(72, 30);
            this.btnUpload.TabIndex = 119;
            this.btnUpload.Text = "Browse";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "File Path";
            // 
            // txtXLFilePath
            // 
            this.txtXLFilePath.Location = new System.Drawing.Point(185, 13);
            this.txtXLFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXLFilePath.Name = "txtXLFilePath";
            this.txtXLFilePath.ReadOnly = true;
            this.txtXLFilePath.Size = new System.Drawing.Size(440, 20);
            this.txtXLFilePath.TabIndex = 118;
            this.txtXLFilePath.TextChanged += new System.EventHandler(this.txtXLFilePath_TextChanged);
            // 
            // frmUploaderforPackQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 490);
            this.Controls.Add(this.rbAddSales);
            this.Controls.Add(this.rbAddPlan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvSCMPSIItem);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXLFilePath);
            this.Name = "frmUploaderforPackQty";
            this.Text = "frmUploaderforPackQty";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSCMPSIItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAddSales;
        private System.Windows.Forms.RadioButton rbAddPlan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSCMPSIItem;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXLFilePath;
    }
}