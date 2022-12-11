namespace CJ.Win.DMS
{
    partial class frmReordering
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
            this.btnGo = new System.Windows.Forms.Button();
            this.pbreordering = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dvwReordering = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LWSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STFloorSTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.dvwReordering)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Customer";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(531, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(77, 24);
            this.btnGo.TabIndex = 77;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pbreordering
            // 
            this.pbreordering.Location = new System.Drawing.Point(6, 97);
            this.pbreordering.Name = "pbreordering";
            this.pbreordering.Size = new System.Drawing.Size(1065, 23);
            this.pbreordering.TabIndex = 80;
            this.pbreordering.Visible = false;
            this.pbreordering.Click += new System.EventHandler(this.pbStockIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Area";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(106, 12);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(136, 21);
            this.cmbArea.TabIndex = 82;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(265, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Territory";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(325, 12);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(136, 21);
            this.cmbTerritory.TabIndex = 84;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnProcess.Location = new System.Drawing.Point(1074, 126);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(95, 50);
            this.btnProcess.TabIndex = 86;
            this.btnProcess.Text = "Process Re-ordering";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dvwReordering
            // 
            this.dvwReordering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvwReordering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.ProductID,
            this.CustomerCode,
            this.CustName,
            this.ASG,
            this.Brand,
            this.ProductCode,
            this.ProductName,
            this.CrStock,
            this.LWSalesQty,
            this.STFloorSTK,
            this.MOQ,
            this.ReqQty});
            this.dvwReordering.Location = new System.Drawing.Point(6, 126);
            this.dvwReordering.Name = "dvwReordering";
            this.dvwReordering.Size = new System.Drawing.Size(1065, 409);
            this.dvwReordering.TabIndex = 87;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = false;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "Customer Code";
            this.CustomerCode.Name = "CustomerCode";
            // 
            // CustName
            // 
            this.CustName.HeaderText = "Name";
            this.CustName.Name = "CustName";
            this.CustName.Width = 200;
            // 
            // ASG
            // 
            this.ASG.HeaderText = "ASG";
            this.ASG.Name = "ASG";
            this.ASG.Width = 60;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.Width = 60;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Width = 70;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 200;
            // 
            // CrStock
            // 
            this.CrStock.HeaderText = "Current Stock";
            this.CrStock.Name = "CrStock";
            this.CrStock.Width = 50;
            // 
            // LWSalesQty
            // 
            this.LWSalesQty.HeaderText = "Last Week SalesQty";
            this.LWSalesQty.Name = "LWSalesQty";
            this.LWSalesQty.Width = 80;
            // 
            // STFloorSTK
            // 
            this.STFloorSTK.HeaderText = "Standard Floo Stock";
            this.STFloorSTK.Name = "STFloorSTK";
            this.STFloorSTK.Width = 80;
            // 
            // MOQ
            // 
            this.MOQ.HeaderText = "MOQ";
            this.MOQ.Name = "MOQ";
            this.MOQ.Width = 50;
            // 
            // ReqQty
            // 
            this.ReqQty.HeaderText = "Require Qty";
            this.ReqQty.Name = "ReqQty";
            this.ReqQty.Width = 70;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(104, 50);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(414, 25);
            this.ctlCustomer1.TabIndex = 75;
            // 
            // frmReordering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 538);
            this.Controls.Add(this.dvwReordering);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbreordering);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlCustomer1);
            this.Name = "frmReordering";
            this.Text = "frmReordering";
            this.Load += new System.EventHandler(this.frmReordering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvwReordering)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ProgressBar pbreordering;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dvwReordering;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn LWSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn STFloorSTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReqQty;
    }
}