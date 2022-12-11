namespace CJ.POS
{
    partial class frmDMSSalesOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMSSalesOrderSearch));
            this.lvwDMSSalesOrder = new System.Windows.Forms.ListView();
            this.colOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblTranNo = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwDMSSalesOrder
            // 
            this.lvwDMSSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDMSSalesOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderNo,
            this.colOrderDate,
            this.colEDD,
            this.colCustomerName,
            this.colAmount});
            this.lvwDMSSalesOrder.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwDMSSalesOrder.FullRowSelect = true;
            this.lvwDMSSalesOrder.GridLines = true;
            this.lvwDMSSalesOrder.HideSelection = false;
            this.lvwDMSSalesOrder.Location = new System.Drawing.Point(12, 74);
            this.lvwDMSSalesOrder.MultiSelect = false;
            this.lvwDMSSalesOrder.Name = "lvwDMSSalesOrder";
            this.lvwDMSSalesOrder.Size = new System.Drawing.Size(492, 250);
            this.lvwDMSSalesOrder.TabIndex = 34;
            this.lvwDMSSalesOrder.UseCompatibleStateImageBehavior = false;
            this.lvwDMSSalesOrder.View = System.Windows.Forms.View.Details;
            this.lvwDMSSalesOrder.DoubleClick += new System.EventHandler(this.lvwDMSSalesOrder_DoubleClick);
            this.lvwDMSSalesOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwDMSSalesOrder_KeyPress);
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Order No";
            this.colOrderNo.Width = 129;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Text = "Order Date";
            this.colOrderDate.Width = 84;
            // 
            // colEDD
            // 
            this.colEDD.Text = "Exp. Delivery Date";
            this.colEDD.Width = 97;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 190;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtCustomerName.Location = new System.Drawing.Point(114, 41);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(288, 23);
            this.txtCustomerName.TabIndex = 38;
            // 
            // lblTranNo
            // 
            this.lblTranNo.AutoSize = true;
            this.lblTranNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblTranNo.Location = new System.Drawing.Point(57, 15);
            this.lblTranNo.Name = "lblTranNo";
            this.lblTranNo.Size = new System.Drawing.Size(51, 15);
            this.lblTranNo.TabIndex = 35;
            this.lblTranNo.Text = "Order #";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtOrderNo.Location = new System.Drawing.Point(114, 12);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(203, 23);
            this.txtOrderNo.TabIndex = 36;
            // 
            // btnGetData
            // 
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetData.Location = new System.Drawing.Point(406, 38);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(98, 29);
            this.btnGetData.TabIndex = 39;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // frmDMSSalesOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 336);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblTranNo);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.lvwDMSSalesOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDMSSalesOrderSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDMSSalesOrderSearch";
            this.Load += new System.EventHandler(this.frmDMSSalesOrderSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDMSSalesOrder;
        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colOrderDate;
        private System.Windows.Forms.ColumnHeader colEDD;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblTranNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btnGetData;
    }
}