namespace CJ.Win.Inventory
{
    partial class frmWarehouseCurrentStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarehouseCurrentStock));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWarehouseParent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Parent Warehouse:";
            // 
            // cmbWarehouseParent
            // 
            this.cmbWarehouseParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseParent.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseParent.FormattingEnabled = true;
            this.cmbWarehouseParent.Location = new System.Drawing.Point(126, 9);
            this.cmbWarehouseParent.Name = "cmbWarehouseParent";
            this.cmbWarehouseParent.Size = new System.Drawing.Size(396, 24);
            this.cmbWarehouseParent.TabIndex = 25;
            this.cmbWarehouseParent.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouseParent_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(126, 39);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(396, 24);
            this.cmbWarehouse.TabIndex = 27;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Product :";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.Black;
            this.btnPreview.Location = new System.Drawing.Point(396, 100);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(126, 35);
            this.btnPreview.TabIndex = 33;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlProduct1.Location = new System.Drawing.Point(126, 69);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(403, 25);
            this.ctlProduct1.TabIndex = 34;
            // 
            // frmWarehouseCurrentStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 147);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbWarehouseParent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWarehouseCurrentStock";
            this.Text = "Current Stock (Warehouse wise)";
            this.Load += new System.EventHandler(this.frmWarehouseCurrentStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWarehouseParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreview;
    }
}