namespace CJ.Win.POS
{
    partial class frmStockRequisitionDeliveryWH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockRequisitionDeliveryWH));
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRequisitionNo = new System.Windows.Forms.Label();
            this.lblRequisitionData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOutlet = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbWarehouseParent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(141, 102);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(275, 23);
            this.cmbWarehouse.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Requisition#";
            // 
            // lblRequisitionNo
            // 
            this.lblRequisitionNo.AutoSize = true;
            this.lblRequisitionNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRequisitionNo.Location = new System.Drawing.Point(90, 24);
            this.lblRequisitionNo.Name = "lblRequisitionNo";
            this.lblRequisitionNo.Size = new System.Drawing.Size(13, 15);
            this.lblRequisitionNo.TabIndex = 1;
            this.lblRequisitionNo.Text = "?";
            // 
            // lblRequisitionData
            // 
            this.lblRequisitionData.AutoSize = true;
            this.lblRequisitionData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionData.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRequisitionData.Location = new System.Drawing.Point(349, 24);
            this.lblRequisitionData.Name = "lblRequisitionData";
            this.lblRequisitionData.Size = new System.Drawing.Size(13, 15);
            this.lblRequisitionData.TabIndex = 3;
            this.lblRequisitionData.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Requisition Date:";
            // 
            // lblOutlet
            // 
            this.lblOutlet.AutoSize = true;
            this.lblOutlet.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutlet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblOutlet.Location = new System.Drawing.Point(90, 50);
            this.lblOutlet.Name = "lblOutlet";
            this.lblOutlet.Size = new System.Drawing.Size(13, 15);
            this.lblOutlet.TabIndex = 5;
            this.lblOutlet.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Outlet Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Set";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbWarehouseParent
            // 
            this.cmbWarehouseParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseParent.FormattingEnabled = true;
            this.cmbWarehouseParent.Location = new System.Drawing.Point(141, 73);
            this.cmbWarehouseParent.Name = "cmbWarehouseParent";
            this.cmbWarehouseParent.Size = new System.Drawing.Size(275, 23);
            this.cmbWarehouseParent.TabIndex = 7;
            this.cmbWarehouseParent.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouseParent_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Parent WH:";
            // 
            // frmStockRequisitionDeliveryWH
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 169);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbWarehouseParent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblOutlet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRequisitionData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRequisitionNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbWarehouse);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockRequisitionDeliveryWH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer Warehouse From";
            this.Load += new System.EventHandler(this.frmStockRequisitionDeliveryWH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRequisitionNo;
        private System.Windows.Forms.Label lblRequisitionData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOutlet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbWarehouseParent;
        private System.Windows.Forms.Label label5;
    }
}