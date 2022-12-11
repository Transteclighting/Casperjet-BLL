namespace CJ.Win.Inventory
{
    partial class frmMsgPIQty
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
            this.btnCancle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.lvwStockList = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colPIQty = new System.Windows.Forms.ColumnHeader();
            this.coluTotalReceive = new System.Windows.Forms.ColumnHeader();
            this.lbPONo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(437, 251);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 13;
            this.btnCancle.Text = "No";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Product Receive History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "PO  Number :";
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 150;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(356, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Yes";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwStockList
            // 
            this.lvwStockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colPIQty,
            this.coluTotalReceive});
            this.lvwStockList.FullRowSelect = true;
            this.lvwStockList.GridLines = true;
            this.lvwStockList.HideSelection = false;
            this.lvwStockList.Location = new System.Drawing.Point(3, 46);
            this.lvwStockList.MultiSelect = false;
            this.lvwStockList.Name = "lvwStockList";
            this.lvwStockList.Size = new System.Drawing.Size(509, 173);
            this.lvwStockList.TabIndex = 10;
            this.lvwStockList.UseCompatibleStateImageBehavior = false;
            this.lvwStockList.View = System.Windows.Forms.View.Details;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 100;
            // 
            // colPIQty
            // 
            this.colPIQty.Text = "PI Qty";
            this.colPIQty.Width = 100;
            // 
            // coluTotalReceive
            // 
            this.coluTotalReceive.Text = "Total Receive";
            this.coluTotalReceive.Width = 150;
            // 
            // lbPONo
            // 
            this.lbPONo.AutoSize = true;
            this.lbPONo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPONo.Location = new System.Drawing.Point(108, 6);
            this.lbPONo.Name = "lbPONo";
            this.lbPONo.Size = new System.Drawing.Size(16, 16);
            this.lbPONo.TabIndex = 9;
            this.lbPONo.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(4, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(517, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Do You Want to Set This Purchase Requisition as Fully Warehouse Received Status ?" +
                "";
            // 
            // frmMsgPIQty
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(520, 279);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwStockList);
            this.Controls.Add(this.lbPONo);
            this.Name = "frmMsgPIQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PI Receive History ";
            this.Load += new System.EventHandler(this.frmMsgPIQty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvwStockList;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colPIQty;
        private System.Windows.Forms.ColumnHeader coluTotalReceive;
        private System.Windows.Forms.Label lbPONo;
        private System.Windows.Forms.Label label3;
    }
}